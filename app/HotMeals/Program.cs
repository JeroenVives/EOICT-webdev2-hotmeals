using HotMeals.school;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

using var db = new SchoolContext();

var user1 = new User { FirstName = "Jeroen", LastName = "Reinenbergh" };
db.Add(user1);
db.SaveChanges();

var parent1 = new Parent { User = user1 };
db.Add(parent1);
db.SaveChanges();

var user2 = new User { FirstName = "Milo", LastName = "Reinenbergh" };
db.Add(user2);
db.SaveChanges();

var class1 = new Class { Description = "Preschool" };
db.Add(class1);
db.SaveChanges();

var child1 = new Child { User = user2, FoodPreference = "meat", Class = class1 };
child1.Parents.Add(parent1);
db.Add(child1);
db.SaveChanges();