using System;
using System.ComponentModel.Design;
using System.Runtime.CompilerServices;

namespace IDisposable_Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            Test();
        }

        private static void Test()
        {
            Person person = null;

            try
            {
                person = new Person();

            }
            finally
            {
                if (person != null)
                {
                    person.Dispose();
                }
            }
        }
    }

    class Person : IDisposable
    {
        private bool _disposed = false;
        public string Name { get; set; }

        //Interface implementation
        public void Dispose()
        {
            Dispose(true);

            //Prevent finalization
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    //Free Managed Resources
                }

                //Free Unmanaged Resources
                _disposed = true;
            }
        }

        ~Person()
        {
            Dispose(false);
        }
    }

    class Derived : Person
    {
        private bool IsDisposed = false;

        protected override void Dispose(bool disposing)
        {
            if (IsDisposed) return;
            if (disposing)
            {
                //Free managed resources
            }
            IsDisposed = true;
            // Call base class dispose method
            base.Dispose(disposing);
        }
    }

}
 