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
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    new Resource()
                    {
                        OwnerId = _userId,
                        EducatorId = model.EducatorId,
                        Title = model.Title,
                        Content = model.Content,
                        DateCreatedAndDownloaded = DateTimeOffset.Now,
                        SchoolGradeLevel = model.SchoolGradeLevel,
                        ReadingCategory = model.ReadingCategory,
                    };

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
                        .Select(                        //The Select() method takes each source element, transforms it, and returns a sequence of the transformed values.
                            e =>
                                new ResourceListItem
                                {
                                    ResourceId = e.ResourceId,
                                    Title = e.Title,
                                    DateCreatedAndDownloaded = e.DateCreatedAndDownloaded,
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
    }
}

        // Get Resource by Id
        //public IEnumerable<ResourceListItem> GetResourceById (int id)
       // {
            //using (var ctx = new ApplicationDbContext())
         //   {
               // var entity = ctx.Resources.Find(id);

               // if (entity != null)
           //     {
                    //var model = 
             //   }
            //}
        //}
    //}

