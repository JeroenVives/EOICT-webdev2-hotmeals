using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace HotMeals.school;

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

    public virtual DbSet<AllergenPresence> AllergenPresences { get; set; }

    public virtual DbSet<AllergenSensitivity> AllergenSensitivities { get; set; }

    public virtual DbSet<Child> Children { get; set; }

    public virtual DbSet<Class> Classes { get; set; }

    public virtual DbSet<HotMeal> HotMeals { get; set; }

    public virtual DbSet<HotMealChoice> HotMealChoices { get; set; }

    public virtual DbSet<Ingredient> Ingredients { get; set; }

    public virtual DbSet<MealChoice> MealChoices { get; set; }

    public virtual DbSet<MealIngredient> MealIngredients { get; set; }

    public virtual DbSet<Parent> Parents { get; set; }

    public virtual DbSet<ParentalRelation> ParentalRelations { get; set; }

    public virtual DbSet<ScheduledHotMeal> ScheduledHotMeals { get; set; }

    public virtual DbSet<Staff> Staff { get; set; }

    public virtual DbSet<Teacher> Teachers { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySQL("server=localhost;port=3307;uid=root;pwd=root;database=school");

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
        });

        modelBuilder.Entity<AllergenPresence>(entity =>
        {
            entity.HasKey(e => new { e.AllergenId, e.IngredientId }).HasName("PRIMARY");

            entity.ToTable("allergen_presences");

            entity.HasIndex(e => e.IngredientId, "fk__allergen_presences__ingredient_id");

            entity.Property(e => e.AllergenId)
                .HasColumnType("int(11)")
                .HasColumnName("allergen_id");
            entity.Property(e => e.IngredientId)
                .HasColumnType("int(11)")
                .HasColumnName("ingredient_id");
        });

        modelBuilder.Entity<AllergenSensitivity>(entity =>
        {
            entity.HasKey(e => new { e.ChildId, e.AllergenId }).HasName("PRIMARY");

            entity.ToTable("allergen_sensitivities");

            entity.HasIndex(e => e.AllergenId, "fk__allergen_sensitivities__allergen_id");

            entity.Property(e => e.ChildId)
                .HasColumnType("int(11)")
                .HasColumnName("child_id");
            entity.Property(e => e.AllergenId)
                .HasColumnType("int(11)")
                .HasColumnName("allergen_id");
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
        });

        modelBuilder.Entity<Parent>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PRIMARY");

            entity.ToTable("parents");

            entity.Property(e => e.UserId)
                .HasColumnType("int(11)")
                .HasColumnName("user_id");
        });

        modelBuilder.Entity<ParentalRelation>(entity =>
        {
            entity.HasKey(e => new { e.ParentId, e.ChildId }).HasName("PRIMARY");

            entity.ToTable("parental_relations");

            entity.HasIndex(e => e.ChildId, "fk__parental_relations__child_id");

            entity.Property(e => e.ParentId)
                .HasColumnType("int(11)")
                .HasColumnName("parent_id");
            entity.Property(e => e.ChildId)
                .HasColumnType("int(11)")
                .HasColumnName("child_id");
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
        });

        modelBuilder.Entity<Teacher>(entity =>
        {
            entity.HasKey(e => new { e.StaffId, e.ClassId }).HasName("PRIMARY");

            entity.ToTable("teachers");

            entity.HasIndex(e => e.ClassId, "fk__teachers__class_id");

            entity.Property(e => e.StaffId)
                .HasColumnType("int(11)")
                .HasColumnName("staff_id");
            entity.Property(e => e.ClassId)
                .HasColumnType("int(11)")
                .HasColumnName("class_id");
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
