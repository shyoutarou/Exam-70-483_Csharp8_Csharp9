using System;
using System.IO;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace C8_AsynchronousDisposable
{
    public class DisposableFoo : IAsyncDisposable, IDisposable
    {
        private bool disposed = false;
        private Utf8JsonWriter _jsonWriter = new Utf8JsonWriter(new MemoryStream()); //IAsyncDisposable
        private HttpClient client = new System.Net.Http.HttpClient(); //IDisposable

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                client?.Dispose();
                (_jsonWriter as IDisposable)?.Dispose();
            }

            _jsonWriter = null;
            client = null;
            disposed = true;
        }

        public async ValueTask DisposeAsync()
        {
            await DisposeAsyncCore();

            Dispose(disposing: false);
            GC.SuppressFinalize(this);
        }

        protected virtual async ValueTask DisposeAsyncCore()
        {
            if (_jsonWriter != null)
            {
                await _jsonWriter.DisposeAsync().ConfigureAwait(false);
            }

            if (client is IAsyncDisposable disposable)
            {
                await disposable.DisposeAsync().ConfigureAwait(false);
            }
            else
            {
                client.Dispose();
            }

            _jsonWriter = null;
            client = null;
        }

        public async Task<string> AwaitableMethodAsync(Task arg1, Task arg)
        {
            string result = await client.GetStringAsync("http://www.microsoft.com");
            return result;
        }
    }


    public interface IAsyncDisposable
    {
        ValueTask DisposeAsync();
    }

    class Foo : IAsyncDisposable
    {
        public async ValueTask DisposeAsync()
        {
            Console.WriteLine("Delaying!");
            await Task.Delay(1000);
            Console.WriteLine("Disposed!");
        }
    }

    class Program
    {
        static async Task Main(string[] args)
        {

            var disposableObj = new DisposableFoo();
            var arg1 = ComputeArg();
            var arg2 = ComputeArg();
            await disposableObj.AwaitableMethodAsync(arg1, arg2);
            await Task.Run(() => disposableObj.Dispose());


            await using (var disposableObject = new Foo())
            {
                Console.WriteLine("Hello World!");
            }

            Console.WriteLine("Done!");

            //Foo disposableObject = null;
            //try
            //{
            //    disposableObject = new Foo();
            //    //...
            //}
            //finally
            //{
            //    if (disposableObject != null)
            //        await disposableObject.DisposeAsync();
            //}

            DoWorkAsync();
            DoWork2Async();
        }

        public static Task DoWorkAsync()
        {
            var arg1 = ComputeArg();
            var arg2 = ComputeArg();
            return AwaitableMethodAsync(arg1, arg2);
        }

        public static async Task DoWork2Async()
        {
            var arg1 = ComputeArg();
            var arg2 = ComputeArg();
            await AwaitableMethodAsync(arg1, arg2);
        }

        public static Task DoWorkFooAsync()
        {
            using (var service = new DisposableFoo())
            {
                var arg1 = ComputeArg();
                var arg2 = ComputeArg();
                return service.AwaitableMethodAsync(arg1, arg2);
            }
        }

        public static async Task DoWorkFoo2Async()
        {
            using (var service = new DisposableFoo())
            {
                var arg1 = ComputeArg();
                var arg2 = ComputeArg();
                await service.AwaitableMethodAsync(arg1, arg2);
            }
        }

        static public Task ComputeArg()
        {
            return Task.Run(() =>
            {
                Console.WriteLine($"{nameof(ComputeArg)} starting...");
                Task.Delay(1000).Wait();
                Console.WriteLine($"{nameof(ComputeArg)} ending...");
            });
        }

        public static async Task<string> AwaitableMethodAsync(Task arg1, Task arg)
        {
            using (System.Net.Http.HttpClient client = new System.Net.Http.HttpClient())
            {
                string result = await client.GetStringAsync("http://www.microsoft.com");
                return result;
            }
        }
    }
}
