using RevelReading.Data;
using RevelReading.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevelReading.Services
{
    public class EducatorService
    {
        private readonly Guid _educatorUserId;

        public EducatorService(Guid educatorUserId)
        {
            _educatorUserId = educatorUserId;
        }

        public bool CreateEducator(EducatorCreate model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                  new Educator()
                  {
                      OwnerId = _educatorUserId,
                      EducatorId = model.EducatorId,
                      FirstName = model.FirstName,
                      LastName = model.LastName,
                      EmailAddress = model.EmailAddress,
                  };

                ctx.Educators.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<EducatorListItem> GetEducators()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Educators
                        .Where(e => e.OwnerId == _educatorUserId)
                        .Select(
                            e =>
                                new EducatorListItem
                                {
                                    EducatorId = e.EducatorId,
                                    FirstName = e.FirstName,
                                    LastName = e.LastName,
                                    EmailAddress = e.EmailAddress,
                                }
                                );
                return query.ToArray();
            }
        }
    }
}

