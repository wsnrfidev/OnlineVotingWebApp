namespace OnlineVotingApp.Models
{
    public class VoteOption
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public int Votes { get; set; }
    }
}
