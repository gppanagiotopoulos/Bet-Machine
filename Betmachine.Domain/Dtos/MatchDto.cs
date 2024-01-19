namespace BetMachine.Domain.Dtos
{
    /// <summary>
    /// Data transfer object for getting/updating a match  and inherits from AddMatchDto
    /// </summary>
    public class MatchDto : AddMatchDto
    {
        public int Id { get; set; }
    }
}