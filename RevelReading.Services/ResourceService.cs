﻿using RevelReading.Data;
using RevelReading.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevelReading.Services
{
    public class ResourceService
    {
        private readonly Guid _userId;

        public ResourceService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateResource(ResourceCreate model)
        {
            var entity =
                new Resource()
                {
                    OwnerId = _userId,
                    ResourceName = model.Title,
                    Description = model.Content,
                    DateCreatedAndDownloaded = DateTimeOffset.Now
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Resources.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        // Get Resources
        public IEnumerable<ResourceListItem> GetResources()
        {
            using (var ctx = new ApplicationDbContext())
            {
                            // A query is a set of instructions that describes what data to retrieve from a given data source (or sources) 
                            // and what shape and organization the returned data should have.
                var query =
                    ctx
                        .Resources
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                            e =>
                                new ResourceListItem
                                {
                                    //ResourceId = e.ResourceId,
                                   // Title = e.ResourceName,
                                   // CreatedUtc = e.DateCreatedAndDownloaded,
                                });
                return query.ToArray(); 
            }
        }
    }
}
