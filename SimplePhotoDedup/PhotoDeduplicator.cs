using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Policy;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;

namespace SimplePhotoDedup
{
    public enum Status
    {
        Idle,
        Running,
        Stopping,
        Error,
    }

    public class PhotoDeduplicator
    {
        public Status CurrentStatus { get; private set; }
        public delegate void DedupStatusChangeEventHandler(Status newStatus);
        public event DedupStatusChangeEventHandler StatusChangeEvent;
        private CancellationTokenSource cts = new CancellationTokenSource();

        public PhotoDeduplicator()
        {
            this.CurrentStatus = Status.Idle;
        }

        public void Run(ISet<string> directories)
        {
            if (this.CurrentStatus == Status.Running)
            {
                throw new InvalidOperationException("Already Running");
            }
            this.SetStatus(Status.Running);
            
            Task.Factory.StartNew(() => this.FindDuplicatedPhotos(cts.Token, directories));
        }

        public void Stop()
        {
            if (!this.IsRunning())
            {
                throw new InvalidOperationException("Not running");
            }
            this.SetStatus(Status.Stopping);
            this.cts.Cancel();
            this.cts = new CancellationTokenSource();
        }

        private async Task FindDuplicatedPhotos(CancellationToken cancelToken, ISet<string> directoreis)
        {
            try
            {
                await this.FindDuplicatedPhotosImpl(cancelToken, directoreis).ConfigureAwait(false);
                this.SetStatus( Status.Idle);
            }
            catch(Exception e)
            {
                this.SetStatus(Status.Error);
            }
        }

        private async Task FindDuplicatedPhotosImpl(CancellationToken cancelToken, ISet<string> directoreis)
        {
            var processedDirectories = new HashSet<string>();
            var filesFound = new HashSet<string>();
            foreach(string dir in directoreis)
            {
                DirSearch(dir, processedDirectories, filesFound);
            }
        }

        private void DirSearch(string dir, ISet<string> processedDirectories, ISet<string> filesFound)
        {
            if (this.cts.IsCancellationRequested)
            {
                return;
            }

            if (processedDirectories.Contains(dir))
            {
                return;
            }
            processedDirectories.Add(dir);

            foreach (string d in Directory.GetDirectories(dir))
            {
                foreach (string file in Directory.GetFiles(d))
                {
                    filesFound.Add(file);
                }
                DirSearch(d, processedDirectories, filesFound);
            }
        }


        public bool IsRunning()
        {
            return this.CurrentStatus == Status.Running;
        }

        private void SetStatus(Status status)
        {
            this.CurrentStatus = status;
            StatusChangeEvent?.Invoke(CurrentStatus);
        }
    }
}
