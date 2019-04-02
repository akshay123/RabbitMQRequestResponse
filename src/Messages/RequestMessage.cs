namespace Messages
{
    public class RequestMessage
    {
        public RequestMessage(string msg)
        {
            Text = msg;
        }

        public string Text { get; set; }
    }
}
