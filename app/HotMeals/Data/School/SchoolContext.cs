using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace HotMeals.Data.School;

public partial class SchoolContext : DbContext
{
    public SchoolContext()
    {
    }

    public SchoolContext(DbContextOptions<SchoolContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Allergen> Allergens { get; set; }

    public virtual DbSet<Child> Children { get; set; }

    public virtual DbSet<Class> Classes { get; set; }

    public virtual DbSet<HotMeal> HotMeals { get; set; }

    public virtual DbSet<HotMealChoice> HotMealChoices { get; set; }

    public virtual DbSet<Ingredient> Ingredients { get; set; }

    public virtual DbSet<MealChoice> MealChoices { get; set; }

    public virtual DbSet<MealIngredient> MealIngredients { get; set; }

    public virtual DbSet<Parent> Parents { get; set; }

    public virtual DbSet<ScheduledHotMeal> ScheduledHotMeals { get; set; }

    public virtual DbSet<Staff> Staff { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Allergen>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("allergens");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .HasColumnName("description");

            entity.HasMany(d => d.Ingredients).WithMany(p => p.Allergens)
                .UsingEntity<Dictionary<string, object>>(
                    "AllergenPresence",
                    r => r.HasOne<Ingredient>().WithMany()
                        .HasForeignKey("IngredientId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .HasConstraintName("fk__allergen_presences__ingredient_id"),
                    l => l.HasOne<Allergen>().WithMany()
                        .HasForeignKey("AllergenId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .HasConstraintName("fk__allergen_presences__allergen_id"),
                    j =>
                    {
                        j.HasKey("AllergenId", "IngredientId").HasName("PRIMARY");
                        j.ToTable("allergen_presences");
                        j.HasIndex(new[] { "IngredientId" }, "fk__allergen_presences__ingredient_id");
                        j.IndexerProperty<int>("AllergenId")
                            .HasColumnType("int(11)")
                            .HasColumnName("allergen_id");
                        j.IndexerProperty<int>("IngredientId")
                            .HasColumnType("int(11)")
                            .HasColumnName("ingredient_id");
                    });
        });

        modelBuilder.Entity<Child>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PRIMARY");

            entity.ToTable("children");

            entity.HasIndex(e => e.ClassId, "fk__children__class_id");

            entity.Property(e => e.UserId)
                .HasColumnType("int(11)")
                .HasColumnName("user_id");
            entity.Property(e => e.ClassId)
                .HasColumnType("int(11)")
                .HasColumnName("class_id");
            entity.Property(e => e.FoodPreference)
                .HasColumnType("enum('meat','veggie','vegan')")
                .HasColumnName("food_preference");

            entity.HasOne(d => d.Class).WithMany(p => p.Children)
                .HasForeignKey(d => d.ClassId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk__children__class_id");

            entity.HasOne(d => d.User).WithOne(p => p.Child)
                .HasForeignKey<Child>(d => d.UserId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk__children__user_id");

            entity.HasMany(d => d.Allergens).WithMany(p => p.Children)
                .UsingEntity<Dictionary<string, object>>(
                    "AllergenSensitivity",
                    r => r.HasOne<Allergen>().WithMany()
                        .HasForeignKey("AllergenId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .HasConstraintName("fk__allergen_sensitivities__allergen_id"),
                    l => l.HasOne<Child>().WithMany()
                        .HasForeignKey("ChildId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .HasConstraintName("fk__allergen_sensitivities__child_id"),
                    j =>
                    {
                        j.HasKey("ChildId", "AllergenId").HasName("PRIMARY");
                        j.ToTable("allergen_sensitivities");
                        j.HasIndex(new[] { "AllergenId" }, "fk__allergen_sensitivities__allergen_id");
                        j.IndexerProperty<int>("ChildId")
                            .HasColumnType("int(11)")
                            .HasColumnName("child_id");
                        j.IndexerProperty<int>("AllergenId")
                            .HasColumnType("int(11)")
                            .HasColumnName("allergen_id");
                    });
        });

        modelBuilder.Entity<Class>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("classes");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .HasColumnName("description");
        });

        modelBuilder.Entity<HotMeal>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("hot_meals");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .HasColumnName("description");
            entity.Property(e => e.Recipe)
                .HasMaxLength(255)
                .HasColumnName("recipe");
        });

        modelBuilder.Entity<HotMealChoice>(entity =>
        {
            entity.HasKey(e => new { e.Date, e.MealChoiceChildId, e.HotMealId }).HasName("PRIMARY");

            entity.ToTable("hot_meal_choices");

            entity.HasIndex(e => e.HotMealId, "fk__hot_meal_choices__hot_meal_id");

            entity.HasIndex(e => new { e.Date, e.HotMealId }, "fk__hot_meal_choices__scheduled_hot_meal_composite");

            entity.Property(e => e.Date)
                .HasColumnType("date")
                .HasColumnName("date");
            entity.Property(e => e.MealChoiceChildId)
                .HasColumnType("int(11)")
                .HasColumnName("meal_choice_child_id");
            entity.Property(e => e.HotMealId)
                .HasColumnType("int(11)")
                .HasColumnName("hot_meal_id");

            entity.HasOne(d => d.ScheduledHotMeal).WithMany(p => p.HotMealChoices)
                .HasForeignKey(d => new { d.Date, d.HotMealId })
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk__hot_meal_choices__scheduled_hot_meal_composite");

            entity.HasOne(d => d.MealChoice).WithMany(p => p.HotMealChoices)
                .HasForeignKey(d => new { d.Date, d.MealChoiceChildId })
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk__hot_meal_choices__meal_choice_composite");
        });

        modelBuilder.Entity<Ingredient>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("ingredients");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .HasColumnName("description");
            entity.Property(e => e.Type)
                .HasColumnType("enum('meat','veggie','vegan')")
                .HasColumnName("type");
            entity.Property(e => e.UnitOfMeasurement)
                .HasColumnType("enum('kg','l','')")
                .HasColumnName("unit_of_measurement");
        });

        modelBuilder.Entity<MealChoice>(entity =>
        {
            entity.HasKey(e => new { e.Date, e.ChildId }).HasName("PRIMARY");

            entity.ToTable("meal_choices");

            entity.HasIndex(e => e.ChildId, "fk__meal_choices__child_id");

            entity.Property(e => e.Date)
                .HasColumnType("date")
                .HasColumnName("date");
            entity.Property(e => e.ChildId)
                .HasColumnType("int(11)")
                .HasColumnName("child_id");
            entity.Property(e => e.Choice)
                .HasColumnType("enum('home','cold','hot')")
                .HasColumnName("choice");

            entity.HasOne(d => d.Child).WithMany(p => p.MealChoices)
                .HasForeignKey(d => d.ChildId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk__meal_choices__child_id");
        });

        modelBuilder.Entity<MealIngredient>(entity =>
        {
            entity.HasKey(e => new { e.HotMealId, e.IngredientId }).HasName("PRIMARY");

            entity.ToTable("meal_ingredients");

            entity.HasIndex(e => e.IngredientId, "fk__meal_ingredients__ingredient_id");

            entity.Property(e => e.HotMealId)
                .HasColumnType("int(11)")
                .HasColumnName("hot_meal_id");
            entity.Property(e => e.IngredientId)
                .HasColumnType("int(11)")
                .HasColumnName("ingredient_id");
            entity.Property(e => e.Quantity).HasColumnName("quantity");

            entity.HasOne(d => d.HotMeal).WithMany(p => p.MealIngredients)
                .HasForeignKey(d => d.HotMealId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk__meal_ingredients__hot_meal_id");

            entity.HasOne(d => d.Ingredient).WithMany(p => p.MealIngredients)
                .HasForeignKey(d => d.IngredientId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk__meal_ingredients__ingredient_id");
        });

        modelBuilder.Entity<Parent>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PRIMARY");

            entity.ToTable("parents");

            entity.Property(e => e.UserId)
                .HasColumnType("int(11)")
                .HasColumnName("user_id");

            entity.HasOne(d => d.User).WithOne(p => p.Parent)
                .HasForeignKey<Parent>(d => d.UserId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk__parents__user_id");

            entity.HasMany(d => d.Children).WithMany(p => p.Parents)
                .UsingEntity<Dictionary<string, object>>(
                    "ParentalRelation",
                    r => r.HasOne<Child>().WithMany()
                        .HasForeignKey("ChildId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .HasConstraintName("fk__parental_relations__child_id"),
                    l => l.HasOne<Parent>().WithMany()
                        .HasForeignKey("ParentId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .HasConstraintName("fk__parental_relations__parent_id"),
                    j =>
                    {
                        j.HasKey("ParentId", "ChildId").HasName("PRIMARY");
                        j.ToTable("parental_relations");
                        j.HasIndex(new[] { "ChildId" }, "fk__parental_relations__child_id");
                        j.IndexerProperty<int>("ParentId")
                            .HasColumnType("int(11)")
                            .HasColumnName("parent_id");
                        j.IndexerProperty<int>("ChildId")
                            .HasColumnType("int(11)")
                            .HasColumnName("child_id");
                    });
        });

        modelBuilder.Entity<ScheduledHotMeal>(entity =>
        {
            entity.HasKey(e => new { e.Date, e.HotMealId }).HasName("PRIMARY");

            entity.ToTable("scheduled_hot_meals");

            entity.HasIndex(e => e.HotMealId, "fk__scheduled_hot_meals__hot_meal_id");

            entity.Property(e => e.Date)
                .HasColumnType("date")
                .HasColumnName("date");
            entity.Property(e => e.HotMealId)
                .HasColumnType("int(11)")
                .HasColumnName("hot_meal_id");

            entity.HasOne(d => d.HotMeal).WithMany(p => p.ScheduledHotMeals)
                .HasForeignKey(d => d.HotMealId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk__scheduled_hot_meals__hot_meal_id");
        });

        modelBuilder.Entity<Staff>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PRIMARY");

            entity.ToTable("staff");

            entity.Property(e => e.UserId)
                .HasColumnType("int(11)")
                .HasColumnName("user_id");
            entity.Property(e => e.Role)
                .HasColumnType("enum('kitchen','teaching','management')")
                .HasColumnName("role");

            entity.HasOne(d => d.User).WithOne(p => p.Staff)
                .HasForeignKey<Staff>(d => d.UserId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk__staff__user_id");

            entity.HasMany(d => d.Classes).WithMany(p => p.Staff)
                .UsingEntity<Dictionary<string, object>>(
                    "Teacher",
                    r => r.HasOne<Class>().WithMany()
                        .HasForeignKey("ClassId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .HasConstraintName("fk__teachers__class_id"),
                    l => l.HasOne<Staff>().WithMany()
                        .HasForeignKey("StaffId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .HasConstraintName("fk__teachers__staff_id"),
                    j =>
                    {
                        j.HasKey("StaffId", "ClassId").HasName("PRIMARY");
                        j.ToTable("teachers");
                        j.HasIndex(new[] { "ClassId" }, "fk__teachers__class_id");
                        j.IndexerProperty<int>("StaffId")
                            .HasColumnType("int(11)")
                            .HasColumnName("staff_id");
                        j.IndexerProperty<int>("ClassId")
                            .HasColumnType("int(11)")
                            .HasColumnName("class_id");
                    });
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("users");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.FirstName)
                .HasMaxLength(255)
                .HasColumnName("first_name");
            entity.Property(e => e.LastName)
                .HasMaxLength(255)
                .HasColumnName("last_name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
