using RevelReading.Data;
using RevelReading.Models.SchoolModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevelReading.Services
{
    public class SchoolService //The service layer is how our application interacts with the database.  
    {
        private readonly Guid _userId; //Constructor: A method in the class which gets executed when a class object is created.  

        public SchoolService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateSchool(SchoolCreate model)
        {
            var entity =
                new School()
                {
                    OwnerId = _userId,
                    SchoolName = model.SchoolName,
                    SchoolGradeLevels = model.SchoolGradeLevels,
                    LowestGradeLevel = model.LowestGradeLevel,
                    HighestGradeLevel = model.HighestGradeLevel,
                    StreetAddress = model.StreetAddress,
                    City = model.City,
                    State = model.State,
                    ZipCode = model.ZipCode
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Schools.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<SchoolListItem> GetSchools()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Schools
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                            e =>
                                new SchoolListItem
                                {
                                    SchoolId = e.SchoolId,
                                    SchoolName = e.SchoolName,
                                    SchoolGradeLevels = e.SchoolGradeLevels,
                                    LowestGradeLevel = e.LowestGradeLevel,
                                    HighestGradeLevel = e.HighestGradeLevel,
                                    Educators = e.Educators,
                                }
                       );
                return query.ToArray();
            }
        }
    }
}
