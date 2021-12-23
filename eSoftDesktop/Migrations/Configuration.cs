namespace eSoftDesktop.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<eSoftDesktop.Models.context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "eSoftDesktop.Models.context";
        }

        protected override void Seed(eSoftDesktop.Models.context context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
