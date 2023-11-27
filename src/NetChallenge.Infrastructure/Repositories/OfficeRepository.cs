using Microsoft.EntityFrameworkCore;
using NetChallenge.Core.Database;
using NetChallenge.Core.Domain;
using NetChallenge.Infrastructure.Abstractions;

namespace NetChallenge.Infrastructure.Repositories
{
    public class OfficeRepository : IOfficeRepository
    {
        private readonly ChallengeContext _context;

        public OfficeRepository(ChallengeContext context)
        {
            _context = context;
        }

        public IEnumerable<Office> AsEnumerable() =>
            _context.Offices
                .Include(of => of.Location)
                .Include(of => of.OfficeResources)
                .ThenInclude(or => or.Resource)
                .AsEnumerable();

        public void Add(Office _)
        {
            var entryResult = _context.Offices.Add(_);
            
            foreach(var ofr in _.OfficeResources)
            {
                ofr.OfficeId = entryResult.Entity.Id;
                _context.OfficeResources.Add(ofr);
            }

            _context.SaveChanges();
        }
    }
}