using System.Net;
using System.IO;

namespace ChatGpt
{ 
    class Program
    {
        static void Main(string[] args)
        {
            //Request URL
            var request = WebRequest.CreateHttp("https://api.chatgpt.com");

            //Request Method: POST
            request.Method = "POST";

            //Send data
            var postData = "{\"userId\":\"123456\", \"query\":\"Hi\"}";
            var data = Encoding.ASCII.GetBytes(postData);
            request.ContentType = "application/json";
            request.ContentLength = data.Length;

            using (var stream = request.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);
            }

            //Get Response
            var response = (HttpWebResponse)request.GetResponse();
            var responseEncode = response.GetResponseStream();
            
            StreamReader reader = new StreamReader(response.GetResponseStream());
            string responseText = reader.ReadToEnd();
            Console.WriteLine(responseText);
        }
    }
}

stop
