using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using HRSystem.Models;

namespace HRSystem.DAL
{
    public class DataInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<HRContext>
    {
        protected override void Seed(HRContext context)
        {
            var users = new List<User>
            {
            new User{FirstName="Carson",LastName="Alexander",Email="alexander@mail.com",CityID=1},
            new User{FirstName="Meredith",LastName="Alonso",Email="alonso@mail.com",CityID=3},
            new User{FirstName="Arturo",LastName="Anand",Email="anand@mail.com",CityID=2},
            new User{FirstName="Gytis",LastName="Barzdukas",Email="barzdukas@mail.com",CityID=4},
            new User{FirstName="Yan",LastName="Li",Email="li@mail.com",CityID=5},
            new User{FirstName="Peggy",LastName="Justice",Email="justice@mail.com",CityID=2},
            new User{FirstName="Laura",LastName="Norman",Email="norman@mail.com",CityID=6},
            new User{FirstName="Nino",LastName="Olivetto",Email="olivetto@mail.com",CityID=7},
            new User{FirstName="Georgi",LastName="Stoev",Email="stoev@mail.com",CityID=8},
            new User{FirstName="Aron",LastName="Handosn",Email="hanson@mail.com",CityID=1},
            new User{FirstName="Barry",LastName="Allan",Email="allan@mail.com",CityID=2},
            new User{FirstName="Katy",LastName="Homes",Email="homes@mail.com",CityID=4}
            };

            users.ForEach(s => context.Users.Add(s));
            context.SaveChanges();
            var projects = new List<Project>
            {
            new Project{Name="Medicus"},
            new Project{Name="Nebuchadnezzar"},
            new Project{Name="Acrylis"},
            new Project{Name="Fontera"},
            new Project{Name="Piermo"},
            new Project{Name="Cancusa"},
            new Project{Name="Mindo"}
            };
            projects.ForEach(s => context.Projects.Add(s));
            context.SaveChanges();
            var cities = new List<City>
            {
            new City{Name="Sofia"},
            new City{Name="London"},
            new City{Name="Paris"},
            new City{Name="Athens"},
            new City{Name="Ardean"},
            new City{Name="Las Vegas"},
            new City{Name="Berlin"},
            new City{Name="Tronto"},
            new City{Name="Amsterdam"},
            new City{Name="Osaka"},
            new City{Name="Rome"},
            new City{Name="Otawa"},
            };
            cities.ForEach(s => context.Cities.Add(s));
            context.SaveChanges();

            var roles = new List<Role>
            {
            new Role{Name="CEO"},
            new Role{Name="Delivery Director"},
            new Role{Name="Project Manager"},
            new Role{Name="Team Leader"},
            new Role{Name="Senior"},
            new Role{Name="Intermediate"},
            new Role{Name="Junior"},
            new Role{Name="Trainee"},
            };
            roles.ForEach(s => context.Roles.Add(s));
            context.SaveChanges();
        }
    }
}