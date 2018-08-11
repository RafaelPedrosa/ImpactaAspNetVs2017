using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;
using System.IO;
using System.Web;

namespace AspNetVS2017.Capitulo2.Http.Testes
{
    [TestClass]
    public class HttpTeste
    {
        [TestMethod]
        public void RequestGetTeste() {
            /*
             * C - Post
             * R - Get
             * U - Put
             * D - Delete 
             */

            var request = (HttpWebRequest)WebRequest.Create("http://www.example.com?usuarioId=18&cpf=35814039825");

            request.Method = "GET";

            request.UserAgent = "Visual Studio";
            request.Date = DateTime.Now;

            Console.WriteLine(GetRequestToString(request));
            Console.WriteLine(new string ('-', 100));
            Console.WriteLine("Query string:" + request.RequestUri.Query);
            Console.WriteLine(new string('-', 100));

            var response = (HttpWebResponse)request.GetResponse();

            Console.WriteLine(GetResponseToString(response));
        }

        [TestMethod]
        public void RequestPostTeste()
        {
            var request = (HttpWebRequest)WebRequest.Create("https://httpbin.org/post");

            request.Method = "POST";

            var dados = "nome=Rafael&Cpf=69874123685&endereco=Av.Alcantra147";
            
            var bytes = new System.Text.ASCIIEncoding().GetBytes(HttpUtility.HtmlEncode(dados));

            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = bytes.Length;

            request.GetRequestStream().Write(bytes, 0, bytes.Length);

            Console.WriteLine(GetRequestToString(request, dados));

        }

        private string GetResponseToString(HttpWebResponse response)
        {
            var statusLine = $"HTTP/{response.ProtocolVersion} {(int)response.StatusCode} {response.StatusDescription}";

            var reader = new StreamReader(response.GetResponseStream());

            return statusLine + Environment.NewLine + GetHeaders(response.Headers) + Environment.NewLine + reader.ReadToEnd();
        }

        private string GetRequestToString(HttpWebRequest request, string dados = null)
        {
            var requestLine = $"{request.Method} {request.RequestUri} HTTP/{request.ProtocolVersion}";

            return requestLine +  Environment.NewLine + GetHeaders(request.Headers) + Environment.NewLine + dados;

            Console.WriteLine(new string('-', 100));

            var response = (HttpWebResponse)request.GetResponse();

            Console.WriteLine(GetResponseToString(response));
        }

        private string GetHeaders(WebHeaderCollection header)
        {
            var headers = "";

            foreach (var Key in header.AllKeys)
            {
                headers += $"{Key}: {header[Key]}" + Environment.NewLine; 
            }

            return headers;
        }
    }
}
