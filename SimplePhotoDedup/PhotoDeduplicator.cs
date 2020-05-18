using System;
using System.Collections.Generic;

namespace SimplePhotoDedup
{
    public enum Status
    {
        Idle,
        Running,
    }

    public class PhotoDeduplicator
    {

        public Status CurrentStatus { get; private set; }
        public delegate void DedupStatusChangeEventHandler(Status newStatus);
        public event DedupStatusChangeEventHandler StatusChangeEvent;

        public PhotoDeduplicator()
        {
            this.CurrentStatus = Status.Idle;
        }

        public void Run(ISet<string> directories)
        {
            if (this.CurrentStatus == Status.Running)
            {
                throw new System.Exception("Already Running");
            }
            CurrentStatus = Status.Running;
            StatusChangeEvent?.Invoke(CurrentStatus);
            var processedDirectories = new HashSet<string>(StringComparer.InvariantCultureIgnoreCase);
        }

        public void Stop()
        {

        }
    }
}
