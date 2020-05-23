using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;
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
        
        public delegate void DedupProgressChangeEventHandler(int totalFiles, int processedFiles, int duplicatesFound);
        public event DedupProgressChangeEventHandler DedupProgressChangeEvent;

        public delegate void DedupCompletedEventHandler(SearchResult searchResult);
        public event DedupCompletedEventHandler DedupCompletedEvent;

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
            catch(Exception)
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
            
            var searchResults = this.ProcessFiles(filesFound, cancelToken);
            this.DedupCompletedEvent?.Invoke(searchResults);
        }
            
        private SearchResult ProcessFiles(HashSet<string> filesFound, CancellationToken cancelToken)
        {
            var searchResult = new Dictionary<string, ISet<string>>();
            var duplicatedFiles = new HashSet<string>();
            int duplicatesCount = 0;
            int filesProcessed = 0;
            foreach(var file in filesFound)
            {
                if (cancelToken.IsCancellationRequested)
                {
                    break;
                }
                String fileHash = this.ComputeFileHash(file);
                if (searchResult.ContainsKey(fileHash))
                {
                    duplicatedFiles.Add(fileHash);
                    searchResult[fileHash].Add(file);
                    duplicatesCount++;
                }
                else
                {
                    searchResult[fileHash] = new HashSet<string>() { file };
                }
                filesProcessed++;
                this.DedupProgressChangeEvent?.Invoke(filesFound.Count, filesProcessed, duplicatesCount);
            }
            return new SearchResult(searchResult, duplicatedFiles);
        }

        private String ComputeFileHash(String fileName)
        {
            if (!File.Exists(fileName))
            {
                throw new ArgumentException($"File {fileName} does not exist");
            }
            byte[] myHash;
            using (var md5 = MD5.Create())
            using (var stream = File.OpenRead(fileName))
                myHash = md5.ComputeHash(stream);

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < myHash.Length; i++)
            {
                sb.Append(myHash[i].ToString("x2"));
            }
            return sb.ToString();
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
            foreach (string file in Directory.GetFiles(dir))
            {
                // TODO: Only add images
                filesFound.Add(file);
            }

            foreach (string d in Directory.GetDirectories(dir))
            {
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

        public class SearchResult
        {
            public Dictionary<string, ISet<string>> processedFiles { get; private set; }
            public ISet<string> duplicatedHashes { get; private set; }

            public SearchResult(Dictionary<string, ISet<string>> processedFiles, ISet<string> duplicatedHashes)
            {
                this.processedFiles = processedFiles;
                this.duplicatedHashes = duplicatedHashes;
            }
        }
    }
}
