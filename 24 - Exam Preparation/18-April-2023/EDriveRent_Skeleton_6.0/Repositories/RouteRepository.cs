using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using EDriveRent.Models.Contracts;
using EDriveRent.Repositories.Contracts;

namespace EDriveRent.Repositories
{
    public class RouteRepository : IRepository<IRoute>
    {
        private List<IRoute> routes;
        public RouteRepository()
        {
            routes = new List<IRoute>();
        }
        public void AddModel(IRoute route)
        {
           routes.Add(route);
        }
        public bool RemoveById(string identifier)
        {
            int intIdentifier = (int.Parse(identifier));

            return routes.Remove(routes.FirstOrDefault(r => r.RouteId == intIdentifier));
        }

        public IRoute FindById(string identifier)
        {
            int intIdentifier = (int.Parse(identifier));

            return routes.FirstOrDefault(r => r.RouteId == intIdentifier);
        }


        public IReadOnlyCollection<IRoute> GetAll() => routes;

    }
}
