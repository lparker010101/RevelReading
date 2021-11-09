using RevelReading.Data;
using RevelReading.Data.Entities;
using RevelReading.Models.SchoolModels;
using RevelReading.Services.HelperModels;
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
        private readonly AddressHelperModel _addressHelper = new AddressHelperModel();

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
                    Address = _addressHelper.CreateAddress(model),
                    EducatorId = model.EducatorId
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

        public SchoolDetail GetSchoolById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Schools
                        .Single(e => e.SchoolId == id && e.OwnerId == _userId);
                return
                    new SchoolDetail
                    {
                        SchoolId = entity.SchoolId,
                        SchoolName = entity.SchoolName,
                        SchoolGradeLevels = entity.SchoolGradeLevels,
                        LowestGradeLevel = entity.LowestGradeLevel,
                        HighestGradeLevel = entity.HighestGradeLevel,
                    };
            }
        }

        public bool UpdateSchool(SchoolEdit model)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Schools
                        .Single(e => e.SchoolId == model.SchoolId && e.OwnerId == _userId);

                entity.SchoolName = model.SchoolName;
                entity.SchoolGradeLevels = model.SchoolGradeLevels;
                entity.LowestGradeLevel = model.LowestGradeLevel;
                entity.HighestGradeLevel = model.HighestGradeLevel;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteSchool(int SchoolId)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Schools
                        .Single(e => e.SchoolId == SchoolId && e.OwnerId == _userId);

                ctx.Schools.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}

// Note To Self: 
// User looks at View with text fields.  View passes model into controller.  Controller passes it to Service.  Service takes 
// the Model and projects data into database.
