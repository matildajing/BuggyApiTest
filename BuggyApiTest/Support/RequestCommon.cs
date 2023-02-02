using RestSharp;

namespace BuggyApiTest.Support
{
    public class RequestCommon
    {
            
        public RequestCommon()
        {
            
        }

        public static RestResponse Post(string url, string jsonBody)
        {
            RestClient client = new RestClient(url);
            RestRequest request = new RestRequest();

            request.Method = Method.Post;
            System.Console.WriteLine("jsonBody is: " + jsonBody);
            request.AddParameter("application/json", jsonBody, ParameterType.RequestBody);

            RestResponse response = client.Execute(request);

            return response;
        }
    }
}
