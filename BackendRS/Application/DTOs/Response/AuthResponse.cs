namespace BackendSR.Application.DTOs.Response
{
    public class AuthResponse
    {
        public string message { get; set; }
        public string accessToken { get; set; }
        public AuthResponse(string Message, string AccessToken)
        {
            message = Message;
            accessToken = AccessToken;
        }
    }
}
