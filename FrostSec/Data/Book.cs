namespace FrostSec.Data
{
    public class Book : Disposer, IShelfComponent
    {
        public string? CSSClass { get; set; }
        public string? Title { get; set; }

        protected override void Dispose(bool _disposing)
        {
            if (!IsDisposed)
            {
                if (_disposing)
                {
                    CSSClass = null;
                    Title = null;
                }
            }
            IsDisposed = true;
        }
        
 
        ~Book()
        {
            CSSClass = null;
            Title = null;
            IsDisposed = true;
        }
    }

    public interface IShelfComponent 
    {
        public string? CSSClass { get; set; }
        public string? Title { get; set; }
    }

    public abstract class Disposer : IDisposable
    {
        public bool IsDisposed { get; set; }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        
        protected virtual void Dispose(bool disposing)
        {
            if (!IsDisposed)
            {
                if (disposing)
                {
                    //calloc
                }

                IsDisposed = true;
            }
        }
    }
}
