namespace LibApiSampleAbstraction.Services.Dtos
{
    public class NewOccurrenceRequest
    {
        public NewOccurrenceRequest(string name, string message)
        {
            Name = name;
            Message = message;
        }

        public string Name { get; private set; }
        public string Message { get; private set; }
    }
}