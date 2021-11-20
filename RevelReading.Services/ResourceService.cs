using RevelReading.Data;
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
                        EducatorId = model.EducatorId,
                        //ResourceId = model.ResourceId,
                        Title = model.Title,
                        Content = model.Content,
                        SchoolGradeLevel = model.SchoolGradeLevel,
                        ReadingCategory = model.ReadingCategory,
                        DateCreatedAndDownloaded = DateTime.Now,
                        AccessDate = DateTime.Now
                    };
                using (var ctx = new ApplicationDbContext())
                {
                ctx.Resources.Add(entity);
                return ctx.SaveChanges() > 0;
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
                        .Select(                        //The Select() method takes each source element, transforms it, and returns a sequence of the transformed values.
                            e =>
                                new ResourceListItem
                                {
                                    ResourceId = e.ResourceId,
                                    Title = e.Title,
                                    DateCreatedAndDownloaded = e.DateCreatedAndDownloaded,
                                    AccessDate = e.AccessDate
                                });

                return query.ToArray();
            }
        }

        public ResourceDetail GetResourceById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Resources
                        .Single(e => e.ResourceId == id && e.OwnerId == _userId);
                return
                    new ResourceDetail
                    {
                        ResourceId = entity.ResourceId,
                        Title = entity.Title,
                        Content = entity.Content,
                        SchoolGradeLevel = entity.SchoolGradeLevel,
                        ReadingCategory = entity.ReadingCategory,
                        DateCreatedAndDownloaded = entity.DateCreatedAndDownloaded,
                        ModifiedResource = entity.ModifiedResource
                    };
            }
        }

        public bool UpdateResource(ResourceEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Resources
                        .Single(e => e.ResourceId == model.ResourceId && e.OwnerId == _userId);

                entity.Title = model.Title;
                entity.Content = model.Content;
                entity.SchoolGradeLevel = model.SchoolGradeLevel;
                entity.ReadingCategory = model.ReadingCategory;
                //entity.ModifiedResource = DateTimeOffset.UtcNow;

                return ctx.SaveChanges() == 1;
            };
        }

        public bool DeleteResource(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Resources
                        .Single(e => e.ResourceId == id && e.OwnerId == _userId);

                ctx.Resources.Remove(entity);

                return ctx.SaveChanges() > 0;
            }
        }
    }
}

