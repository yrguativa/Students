namespace Students.API.Migrations
{
    using Students.API.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Students.API.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Students.API.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            var course1 = new Curse() {
                Id = 1,
                Course = "Introducción a la programación"
            };

            var course2 = new Curse()
            {
                Id = 2,
                Course = "Programación POO"
            };

            var course3 = new Curse()
            {
                Id = 3,
                Course = "Introducción a Bases de datos"
            };
            var course4 = new Curse()
            {
                Id = 4,
                Course = "Programación Aplicaciones Web"
            };
            var course5 = new Curse()
            {
                Id = 5,
                Course = "Programación Aplicaciones Móviles "
            };
            context.Curses.AddOrUpdate(course1);
            context.Curses.AddOrUpdate(course2);
            context.Curses.AddOrUpdate(course3);
            context.Curses.AddOrUpdate(course4);
            context.Curses.AddOrUpdate(course5);
            context.SaveChanges();
        }
    }
}
