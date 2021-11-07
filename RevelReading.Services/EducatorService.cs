﻿using RevelReading.Data;
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
            var entity =
              new Educator()
              {
                  OwnerId = _educatorUserId,
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

        public EducatorDetail GetEducatorById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Educators
                        .Single(e => e.EducatorId == id && e.OwnerId == _educatorUserId);
                return
                    new EducatorDetail
                    {
                        EducatorId = entity.EducatorId, //ask about this!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!1
                        FirstName = entity.FirstName,
                        LastName = entity.LastName,
                        EmailAddress = entity.EmailAddress,
                        SchoolId = entity.SchoolId,
                        School = entity.School,
                        SchoolGradeLevel = entity.SchoolGradeLevel,
                        ResourceCount = entity.ResourceCount,
                        Resources = (List<ResourceListItem>)entity.Resources
                    };
            }
        }
    }

    // The service layer handles the validation logic.  It retrieves and creates
    // your 'Model' from various data sources (or data access objects).
    // It updates values across various repositories/resources.
    // It performs application-specific logic and manipulations.  
    // The controller requests and receives from the service layer.
}


