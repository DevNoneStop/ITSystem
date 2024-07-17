namespace ITSystem.Models
{
    public class AlertResponse<T>
    {
        public int ID { get; set; }

        public DateTime? DateTimeStamp { get; set; }

        public string? Source { get; set; }

        public string? Type { get; set; }

        public string? Title { get; set; }

        public T Data { get; set; }

        public static AlertResponse<T> GetResult(int ID, string Source, T data = default(T))
        {
            return new AlertResponse<T>
            {
                ID = ID,
                Source = Source,
                Data = data
            };
        }




    }
}
