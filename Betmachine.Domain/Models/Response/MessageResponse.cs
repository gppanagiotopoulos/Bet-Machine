namespace BetMachine.Domain.Models.Response
{
    /// <summary>
    /// Represents Message Response structure
    /// </summary>    
    public class MessageResponse
    {
        public int Code { get; set; }
        public string Message { get; set; } = string.Empty;
        public string ExtraDescription { get; set; } = string.Empty;
    }
}