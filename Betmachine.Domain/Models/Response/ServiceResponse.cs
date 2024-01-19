namespace BetMachine.Domain.Models.Response
{
    /// <summary>
    /// Represents Service Response structure
    /// </summary>   
    public class ServiceResponse<T>
    {
        public T? Data { get; set; }
        public bool Success { get; set; } = false;
        public List<MessageResponse> Messages { get; } = [];
    }
}