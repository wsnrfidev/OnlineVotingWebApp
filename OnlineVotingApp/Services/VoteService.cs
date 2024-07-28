using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineVotingApp.Services
{
    public class VoteService
    {
        // Dictionary untuk menyimpan hasil voting secara lokal
        private readonly Dictionary<string, int> votes = new Dictionary<string, int>
        {
            { "Candidate 1", 0 },
            { "Candidate 2", 0 },
            { "Candidate 3", 0 }
        };

        // Method untuk mendapatkan hasil voting
        public Task<List<VoteResult>> GetResultsAsync()
        {
            var totalVotes = votes.Values.Sum();

            var results = votes.Select(vote => new VoteResult
            {
                CandidateName = vote.Key,
                VoteCount = vote.Value,
                Percentage = totalVotes > 0 ? $"{(vote.Value * 100 / totalVotes)}%" : "0%"
            }).ToList();

            return Task.FromResult(results);
        }

        // Method untuk memberikan suara
        public Task VoteAsync(string candidateName)
        {
            if (votes.ContainsKey(candidateName))
            {
                votes[candidateName]++;
            }
            else
            {
                // Kandidat tidak ditemukan dalam dictionary
                // Tambahkan jika perlu atau tangani sesuai logika Anda
            }

            return Task.CompletedTask;
        }

        // Kelas untuk menyimpan hasil voting
        public class VoteResult
        {
            public string CandidateName { get; set; }
            public int VoteCount { get; set; }
            public string Percentage { get; set; }
        }
    }
}
