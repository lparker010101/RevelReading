using RevelReading.Data;
using RevelReading.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevelReading.Services
{
    public class EducatorService // The service layer is how our application interacts with the database.
    {
        private readonly Guid _userId;

        public EducatorService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateEducator(EducatorCreate model)
        {
            var entity =
              new Educator()
              {
                  OwnerId = _userId,
                  EducatorId = model.EducatorId,
                  FirstName = model.FirstName,
                  LastName = model.LastName,
                  EmailAddress = model.EmailAddress,
              };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Educators.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<EducatorListItem> GetAllEducators()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Educators
                        .Where(e => e.OwnerId == _userId)
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

        public EducatorDetail GetEducatorById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Educators
                        .Single(e => e.EducatorId == id && e.OwnerId == _userId);  //To create a lamda expression, use a lamda declaration operator => to separate
                                                                                           //operator and an expression or a statement block on the other side.
                return
                    new EducatorDetail
                    {
                        EducatorId = entity.EducatorId,
                        FirstName = entity.FirstName,
                        LastName = entity.LastName,
                        EmailAddress = entity.EmailAddress,
                        School = entity.School,
                        SchoolGradeLevel = entity.SchoolGradeLevel,
                        ResourceCount = entity.ResourceCount,
                        Resources = entity.Resources
                    };
            }
        }

        public bool UpdateEducator(EducatorEdit model)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Educators
                        .Single(e => e.EducatorId == model.EducatorId && e.OwnerId == _userId);
                entity.FirstName = model.FirstName;
                entity.LastName = model.LastName;
                entity.EmailAddress = model.EmailAddress;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteEducator(int id)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Educators
                        .Single(e => e.EducatorId == id && e.OwnerId == _userId);
                ctx.Educators.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }

    // The service layer handles the validation logic.  It retrieves and creates
    // your 'Model' from various data sources (or data access objects).
    // It updates values across various repositories/resources.
    // It performs application-specific logic and manipulations.  
    // The controller requests and receives from the service layer.
}


