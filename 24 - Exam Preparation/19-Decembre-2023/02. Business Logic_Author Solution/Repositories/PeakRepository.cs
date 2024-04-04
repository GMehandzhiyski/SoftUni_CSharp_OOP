
namespace HighwayToPeak.Repositories
{
    using HighwayToPeak.Models.Contracts;
    using HighwayToPeak.Repositories.Contracts;
    using System.Collections.Generic;

    public class PeakRepository : IRepository<IPeak>
    {
        private List<IPeak> peaks = new List<IPeak>();

        public IReadOnlyCollection<IPeak> All => peaks.AsReadOnly();

        public void Add(IPeak model)
        {
            peaks.Add(model);
        }

        public IPeak Get(string name) => peaks.FirstOrDefault(p => p.Name == name);
    }
}
