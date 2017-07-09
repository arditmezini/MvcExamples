using System.Collections.Generic;
using System.Data.Entity;
using MvcExamples.Models.Visitor;
using System;
using Newtonsoft.Json;

namespace MvcExamples.Context
{
    public class MvcContext : DbContext
    {
        public MvcContext() : base("name=MvcContext")
        {
            Database.SetInitializer(new SeedDb());
        }

        public virtual DbSet<VisitorDto> Visitor { get; set; }
    }

    public class SeedDb : CreateDatabaseIfNotExists<MvcContext>
    {
        protected override void Seed(MvcContext context)
        {
            #region Vistor
            var _jsonPath = AppDomain.CurrentDomain.BaseDirectory + "App_Data\\visitor-mock.json";
            var visitorObject = System.IO.File.ReadAllText(_jsonPath);
            var visitor = JsonConvert.DeserializeObject<List<VisitorDto>>(visitorObject);
            context.Visitor.AddRange(visitor);
            #endregion

            base.Seed(context);
        }
    }
}