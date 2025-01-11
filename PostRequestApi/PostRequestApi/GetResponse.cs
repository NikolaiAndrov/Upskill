namespace PostRequestApi
{
    public class GetResponse
    {
        public int UserId { get; set; }

        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public string Body { get; set; } = string.Empty;

        public override string ToString()
        {
            return $"UserId: {UserId}, Id: {Id}, Title: {Title}, Body: {Body}";
        }
    }
}
