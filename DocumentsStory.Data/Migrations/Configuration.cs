using DocumentsStory.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;

namespace DocumentsStory.Data.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<DocumentsStory.Data.Contexts.MainContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DocumentsStory.Data.Contexts.MainContext context)
        {
            if (!context.Documents.Any())
            {
                context.Documents.AddRange(GetDefaultDocuments());
                context.SaveChanges();
            }
        }

        private IEnumerable<Document> GetDefaultDocuments()
        {
            return new Document[]
            {
                new Document(102, new DateTime(2002, 10, 10), new DateTime(2012, 10, 11)),
                new Document(103, new DateTime(2003, 10, 10), new DateTime(2013, 10, 11)),
                new Document(104, new DateTime(2004, 10, 10), new DateTime(2014, 10, 11)),
                new Document(105, new DateTime(2005, 10, 10), new DateTime(2015, 10, 11)),
                new Document(106, new DateTime(2006, 10, 10), new DateTime(2016, 10, 11)),
                new Document(107, new DateTime(2007, 10, 10), new DateTime(2017, 10, 11)),
                new Document(108, new DateTime(2008, 10, 10), new DateTime(2018, 10, 11)),
                new Document(109, new DateTime(2009, 10, 10), new DateTime(2019, 10, 11)),
                new Document(110, new DateTime(2010, 10, 10), new DateTime(2020, 10, 11)),
                new Document(111, new DateTime(2011, 10, 10), new DateTime(2021, 10, 11)),
                new Document(112, new DateTime(2023, 1, 10), new DateTime(2023, 2, 11)),
                new Document(113, new DateTime(2023, 1, 11), new DateTime(2023, 2, 12)),
                new Document(114, new DateTime(2023, 1, 12), new DateTime(2023, 2, 13)),
            };
        }
    }
}
