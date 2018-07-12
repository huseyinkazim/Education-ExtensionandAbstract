using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public abstract class A :IEnumerable,IDisposable
    {
        public abstract IEnumerator GetEnumerator();

        public virtual void yazdir(string name)
        {
            Console.WriteLine($"{name} from A");
        }
        public abstract void yazdirma();

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~A() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion
    }
    public class B : A
    {
        public override IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public override void yazdir(string name)
        {
            
            Console.WriteLine($"{name} from B ");
        }

        public override void yazdirma()
        {
            throw new NotImplementedException();
        }
    }
    public class C :B
    {
        public override void yazdir(string name)
        {
            Console.WriteLine($"{name} from C");
        }
    }
}
