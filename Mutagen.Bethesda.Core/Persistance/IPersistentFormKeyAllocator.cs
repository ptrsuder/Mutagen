using Noggog;
using System;

namespace Mutagen.Bethesda
{
    public abstract class BasePersistentFormKeyAllocator : BaseFormKeyAllocator, IPersistentFormKeyAllocator
    {
        protected string SaveLocation;

        public bool CommitOnDispose = true;

        private bool _disposed = false;

        protected BasePersistentFormKeyAllocator(IMod mod, string saveLocation) : base(mod)
        {
            this.SaveLocation = saveLocation;
        }

        /// <summary>
        /// Writes state to disk.
        /// </summary>
        public abstract void Commit();

        /// <summary>
        /// Reloads last committed state from disk.
        /// </summary>
        public abstract void Rollback();

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed) return;
            if (disposing)
            {
                if (CommitOnDispose) Commit();
            }
            _disposed = true;
        }

        public void Dispose() => Dispose(true);
    }

    /// <summary>
    /// An interface for something that can allocate new FormKeys when requested shared between multiple programs
    /// </summary>
    public interface IPersistentFormKeyAllocator : IFormKeyAllocator, IDisposable
    {
        public void Commit();

        public void Rollback();
    }
}
