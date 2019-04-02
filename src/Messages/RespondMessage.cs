namespace Messages
{
    public class RespondMessage
    {
        public RespondMessage(string msg)
        {
            Text = msg;
        }

        public string Text { get; set; }
    }
}
