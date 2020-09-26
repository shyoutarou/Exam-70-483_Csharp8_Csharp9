
using System.Net.Http;
using System;
using System.Net.Http.Headers;
using System.Threading.Tasks;


//using System;

//namespace C9_TopLevel
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            Console.WriteLine("Hello World!");
//        }
//    }
//}

//Subtituido por:


System.Console.WriteLine("Hello World!");

using (var httpClient = new HttpClient())
{
    httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("text/plain"));
    Console.WriteLine(httpClient.GetStringAsync(new Uri("http://www.microsoft.com")).Result);
}


async System.Threading.Tasks.Task<string> AwaitableMethodAsync()
{
    using (var httpClient = new System.Net.Http.HttpClient())
    {
        httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("text/plain"));

        string tarefa = await httpClient.GetStringAsync(new System.Uri("http://www.microsoft.com"));

        return tarefa;
    }
}

var textao = await AwaitableMethodAsync();
System.Console.WriteLine(textao);



var param1 = args[0];
var param2 = args[1];

System.Console.WriteLine($"Your params are {param1} and {param2}.");


System.Console.ReadKey();

//return 0;

