namespace BetMachine.Domain.Dtos
{
    /// <summary>
    /// Data transfer object for getting/updating a match odd  and inherits from AddMatchOddDto
    /// </summary>
    public class MatchOddDto : AddMatchOddDto
    {
        public int Id { get; set; }
    }
}