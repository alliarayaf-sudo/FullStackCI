namespace FullStackCI.Models
{
    public class LinkDto
    {
        public string Rel { get; set; } = string.Empty;
        public string Href { get; set; } = string.Empty;
        public string Method { get; set; } = string.Empty;
    }

    public class Resource<T>
    {
        public T Data { get; set; }
        public List<LinkDto> Links { get; set; } = new();

        public Resource(T data)
        {
            Data = data;
        }
    }
}

