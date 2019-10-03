using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using CodeFirstEfExercise.Models;

//DB is dropped and re-created every time the model changes, and then is populated with test data
namespace CodeFirstEfExercise.DAL
{
    public class CenterInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<CenterContext>
    {
        //Seed method populates the DB with test data
        protected override void Seed(CenterContext context)
        {
            var animals = new List<Animal>
            {
            new Animal{Species="Cat",Name="Fluffy"},
            new Animal{Species="Cat",Name="Whiskers"},
            new Animal{Species="Dog",Name="Fido"},
            new Animal{Species="Dog",Name="Spike"},
            new Animal{Species="Dog",Name="Princess"}
            };

            animals.ForEach(s => context.Animals.Add(s));
            context.SaveChanges();
            var infos = new List<Info>
            {
            new Info{InfoID=1001,Bio="Sweet and snuggly.",Age=2,Gender="Male"},
            new Info{InfoID=1002,Bio="Loves to play outside.",Age=3,Gender="Female"},
            new Info{InfoID=1003,Bio="Likes to curl up next to you on the couch.",Age=9,Gender="Male"},
            new Info{InfoID=1004,Bio="Loves to go on long hikes.",Age=4,Gender="Male"},
            new Info{InfoID=1005,Bio="Loves treats.",Age=1,Gender="Female"}
            };
            infos.ForEach(s => context.Infos.Add(s));
            context.SaveChanges();
            var adoptions = new List<Adoption>
            {
            new Adoption{AnimalID=1,InfoID=1001},
            new Adoption{AnimalID=2,InfoID=1002},
            new Adoption{AnimalID=3,InfoID=1003},
            new Adoption{AnimalID=4,InfoID=1004},
            new Adoption{AnimalID=5,InfoID=1005}
            };
            adoptions.ForEach(s => context.Adoptions.Add(s));
            context.SaveChanges();
        }
    }
}