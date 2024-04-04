namespace HighwayToPeak.Repositories
{
    using HighwayToPeak.Models.Contracts;
    using HighwayToPeak.Repositories.Contracts;
    using System.Collections.Generic;

    public class ClimberRepository : IRepository<IClimber>
    {
        private List<IClimber> climbers = new List<IClimber>();
        public IReadOnlyCollection<IClimber> All => climbers.AsReadOnly();

        public void Add(IClimber model)
        {
            climbers.Add(model);
        }

        public IClimber Get(string name) => climbers.FirstOrDefault(c => c.Name == name);
    }
}
