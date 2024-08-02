using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DataAccess.Entities
{
    public partial class CosminisOfficialDBContext : DbContext
    {
        public CosminisOfficialDBContext()
        {
        }

        public CosminisOfficialDBContext(DbContextOptions<CosminisOfficialDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Class> Classes { get; set; } = null!;
        public virtual DbSet<Comment> Comments { get; set; } = null!;
        public virtual DbSet<Companion> Companions { get; set; } = null!;
        public virtual DbSet<Conversation> Conversations { get; set; } = null!;
        public virtual DbSet<Element> Elements { get; set; } = null!;
        public virtual DbSet<EmotionChart> EmotionCharts { get; set; } = null!;
        public virtual DbSet<FoodElement> FoodElements { get; set; } = null!;
        public virtual DbSet<FoodInventory> FoodInventories { get; set; } = null!;
        public virtual DbSet<FoodStat> FoodStats { get; set; } = null!;
        public virtual DbSet<Friends> Friends { get; set; } = null!;
        public virtual DbSet<Order> Orders { get; set; } = null!;
        public virtual DbSet<Post> Posts { get; set; } = null!;
        public virtual DbSet<Species> Species { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Class>(entity =>
            {
                entity.ToTable("class", "Cosminis");

                entity.Property(e => e.ClassId).HasColumnName("classId");

                entity.Property(e => e.BaseDex)
                    .HasColumnName("baseDex")
                    .HasDefaultValueSql("((10))");

                entity.Property(e => e.BaseInt)
                    .HasColumnName("baseInt")
                    .HasDefaultValueSql("((10))");

                entity.Property(e => e.BaseStr)
                    .HasColumnName("baseStr")
                    .HasDefaultValueSql("((10))");

                entity.Property(e => e.ClassName)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("className");
            });

            modelBuilder.Entity<Comment>(entity =>
            {
                entity.ToTable("comments", "Cosminis");

                entity.Property(e => e.CommentId).HasColumnName("commentId");

                entity.Property(e => e.Content)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("content");

                entity.Property(e => e.PostFk).HasColumnName("post_fk");

                entity.Property(e => e.UserFk).HasColumnName("user_fk");

                entity.HasOne(d => d.PostFkNavigation)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.PostFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__comments__post_f__3C34F16F");

                entity.HasOne(d => d.UserFkNavigation)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.UserFk)
                    .HasConstraintName("FK__comments__user_f__3B40CD36");
            });

            modelBuilder.Entity<Companion>(entity =>
            {
                entity.ToTable("companions", "Cosminis");

                entity.Property(e => e.CompanionId).HasColumnName("companionId");

                entity.Property(e => e.CompanionBirthday)
                    .HasColumnType("datetime")
                    .HasColumnName("companion_birthday")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Emotion)
                    .HasColumnName("emotion")
                    .HasDefaultValueSql("((5))");

                entity.Property(e => e.Hunger)
                    .HasColumnName("hunger")
                    .HasDefaultValueSql("((69))");

                entity.Property(e => e.Mood)
                    .HasColumnName("mood")
                    .HasDefaultValueSql("((69))");

                entity.Property(e => e.Nickname)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("nickname")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SpeciesFk).HasColumnName("species_fk");

                entity.Property(e => e.TimeSinceLastChangedHunger)
                    .HasColumnType("datetime")
                    .HasColumnName("timeSinceLastChangedHunger")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TimeSinceLastChangedMood)
                    .HasColumnType("datetime")
                    .HasColumnName("timeSinceLastChangedMood")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TimeSinceLastFed)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TimeSinceLastPet)
                    .HasColumnType("datetime")
                    .HasColumnName("timeSinceLastPet")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.UserFk).HasColumnName("user_fk");

                entity.HasOne(d => d.EmotionNavigation)
                    .WithMany(p => p.Companions)
                    .HasForeignKey(d => d.Emotion)
                    .HasConstraintName("FK__companion__emoti__1AD3FDA4");

                entity.HasOne(d => d.SpeciesFkNavigation)
                    .WithMany(p => p.Companions)
                    .HasForeignKey(d => d.SpeciesFk)
                    .HasConstraintName("FK__companion__speci__19DFD96B");

                entity.HasOne(d => d.UserFkNavigation)
                    .WithMany(p => p.Companions)
                    .HasForeignKey(d => d.UserFk)
                    .HasConstraintName("FK__companion__user___18EBB532");
            });

            modelBuilder.Entity<Conversation>(entity =>
            {
                entity.ToTable("conversation", "Cosminis");

                entity.Property(e => e.ConversationId).HasColumnName("conversationId");

                entity.Property(e => e.Message)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("message");

                entity.Property(e => e.Quality).HasColumnName("quality");

                entity.Property(e => e.SpeciesFk).HasColumnName("species_fk");

                entity.HasOne(d => d.SpeciesFkNavigation)
                    .WithMany(p => p.Conversations)
                    .HasForeignKey(d => d.SpeciesFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__conversat__speci__25518C17");
            });

            modelBuilder.Entity<Element>(entity =>
            {
                entity.ToTable("elements", "Cosminis");

                entity.Property(e => e.ElementId).HasColumnName("elementId");

                entity.Property(e => e.ElementType)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("elementType");
            });

            modelBuilder.Entity<EmotionChart>(entity =>
            {
                entity.HasKey(e => e.EmotionId)
                    .HasName("PK__emotionC__F10B8722B66EF896");

                entity.ToTable("emotionChart", "Cosminis");

                entity.Property(e => e.EmotionId).HasColumnName("emotionId");

                entity.Property(e => e.Emotion)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("emotion");

                entity.Property(e => e.Quality).HasColumnName("quality");
            });

            modelBuilder.Entity<FoodElement>(entity =>
            {
                entity.ToTable("foodElement", "Cosminis");

                entity.Property(e => e.FoodElementId).HasColumnName("foodElementId");

                entity.Property(e => e.FoodElement1)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("foodElement");
            });

            modelBuilder.Entity<FoodInventory>(entity =>
            {
                entity.HasKey(e => new { e.UserFk, e.FoodStatsFk })
                    .HasName("PK__foodInve__CB0B947DFBC82954");

                entity.ToTable("foodInventory", "Cosminis");

                entity.Property(e => e.UserFk).HasColumnName("user_fk");

                entity.Property(e => e.FoodStatsFk).HasColumnName("foodStats_fk");

                entity.Property(e => e.FoodCount).HasColumnName("foodCount");

                entity.HasOne(d => d.FoodStatsFkNavigation)
                    .WithMany(p => p.FoodInventories)
                    .HasForeignKey(d => d.FoodStatsFk)
                    .HasConstraintName("FK__foodInven__foodS__2BFE89A6");

                entity.HasOne(d => d.UserFkNavigation)
                    .WithMany(p => p.FoodInventories)
                    .HasForeignKey(d => d.UserFk)
                    .HasConstraintName("FK__foodInven__user___2B0A656D");
            });

            modelBuilder.Entity<FoodStat>(entity =>
            {
                entity.HasKey(e => e.FoodStatsId)
                    .HasName("PK__foodStat__0E4BD16BDB9114E2");

                entity.ToTable("foodStats", "Cosminis");

                entity.Property(e => e.FoodStatsId).HasColumnName("foodStatsId");

                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("description");

                entity.Property(e => e.FoodElementFk).HasColumnName("foodElement_fk");

                entity.Property(e => e.FoodName)
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("foodName");

                entity.Property(e => e.HungerRestore).HasColumnName("hungerRestore");

                entity.HasOne(d => d.FoodElementFkNavigation)
                    .WithMany(p => p.FoodStats)
                    .HasForeignKey(d => d.FoodElementFk)
                    .HasConstraintName("FK__foodStats__foodE__282DF8C2");
            });

            modelBuilder.Entity<Friends>(entity =>
            {
                entity.HasKey(e => new { e.UserFromFk, e.UserToFk })
                    .HasName("PK__friends__3E70DF1272FA2F32");

                entity.ToTable("friends", "Cosminis");

                entity.Property(e => e.userFromFk).HasColumnName("userFrom_fk");

                entity.Property(e => e.userToFk).HasColumnName("userTo_fk");

                entity.Property(e => e.Status)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("status");

                entity.HasOne(d => d.userFromFkNavigation)
                    .WithMany(p => p.FriendUserFromFkNavigations)
                    .HasForeignKey(d => d.userFromFk)
                    .HasConstraintName("FK__friends__userFro__2FCF1A8A");

                entity.HasOne(d => d.userToFkNavigation)
                    .WithMany(p => p.FriendUserToFkNavigations)
                    .HasForeignKey(d => d.userToFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__friends__userTo___30C33EC3");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("orders", "Cosminis");

                entity.Property(e => e.OrderId).HasColumnName("orderId");

                entity.Property(e => e.Cost)
                    .HasColumnType("money")
                    .HasColumnName("cost")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.Gems).HasColumnName("gems");

                entity.Property(e => e.TimeOrdered)
                    .HasColumnType("datetime")
                    .HasColumnName("timeOrdered")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.UserFk).HasColumnName("user_fk");

                entity.HasOne(d => d.UserFkNavigation)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.UserFk)
                    .HasConstraintName("FK__orders__user_fk__3F115E1A");
            });

            modelBuilder.Entity<Post>(entity =>
            {
                entity.ToTable("posts", "Cosminis");

                entity.Property(e => e.PostId).HasColumnName("postId");

                entity.Property(e => e.Content)
                    .HasMaxLength(600)
                    .IsUnicode(false)
                    .HasColumnName("content");

                entity.Property(e => e.UserFk).HasColumnName("user_fk");

                entity.HasOne(d => d.UserFkNavigation)
                    .WithMany(p => p.Posts)
                    .HasForeignKey(d => d.UserFk)
                    .HasConstraintName("FK__posts__user_fk__3493CFA7");
            });

            modelBuilder.Entity<Species>(entity =>
            {
                entity.ToTable("species", "Cosminis");

                entity.Property(e => e.SpeciesId).HasColumnName("speciesId");

                entity.Property(e => e.ClassFk)
                    .HasColumnName("class_fk")
                    .HasDefaultValueSql("((4))");

                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("description");

                entity.Property(e => e.ElementFk).HasColumnName("element_fk");

                entity.Property(e => e.FoodElementFk)
                    .HasColumnName("foodElement_fk")
                    .HasDefaultValueSql("((7))");

                entity.Property(e => e.IsMega).HasColumnName("isMega");

                entity.Property(e => e.OppFoodElementFk)
                    .HasColumnName("oppFoodElement_fk")
                    .HasDefaultValueSql("((7))");

                entity.Property(e => e.OpposingEle).HasColumnName("opposingEle");

                entity.Property(e => e.SpeciesName)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("speciesName");

                entity.HasOne(d => d.ClassFkNavigation)
                    .WithMany(p => p.Species)
                    .HasForeignKey(d => d.ClassFk)
                    .HasConstraintName("FK__species__class_f__0D7A0286");

                entity.HasOne(d => d.ElementFkNavigation)
                    .WithMany(p => p.SpeciesElementFkNavigations)
                    .HasForeignKey(d => d.ElementFk)
                    .HasConstraintName("FK__species__element__07C12930");

                entity.HasOne(d => d.FoodElementFkNavigation)
                    .WithMany(p => p.SpeciesFoodElementFkNavigations)
                    .HasForeignKey(d => d.FoodElementFk)
                    .HasConstraintName("FK__species__foodEle__09A971A2");

                entity.HasOne(d => d.OppFoodElementFkNavigation)
                    .WithMany(p => p.SpeciesOppFoodElementFkNavigations)
                    .HasForeignKey(d => d.OppFoodElementFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__species__oppFood__0B91BA14");

                entity.HasOne(d => d.OpposingEleNavigation)
                    .WithMany(p => p.SpeciesOpposingEleNavigations)
                    .HasForeignKey(d => d.OpposingEle)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__species__opposin__08B54D69");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("users", "Cosminis");

                entity.HasIndex(e => e.Username, "UQ__users__F3DBC5728B7B8E69")
                    .IsUnique();

                entity.Property(e => e.UserId).HasColumnName("userId");

                entity.Property(e => e.AboutMe)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("aboutMe")
                    .HasDefaultValueSql("('Enter about me here')");

                entity.Property(e => e.AccountAge)
                    .HasColumnType("datetime")
                    .HasColumnName("account_age")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.EggCount).HasColumnName("eggCount");

                entity.Property(e => e.EggTimer)
                    .HasColumnType("datetime")
                    .HasColumnName("eggTimer")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.GemCount).HasColumnName("gemCount");

                entity.Property(e => e.GoldCount).HasColumnName("goldCount");

                entity.Property(e => e.Notifications).HasColumnName("notifications");

                entity.Property(e => e.Password)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("password");

                entity.Property(e => e.ShowcaseCompanionFk).HasColumnName("showcaseCompanion_fk");

                entity.Property(e => e.Username)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("username");

                entity.HasOne(d => d.ShowcaseCompanionFkNavigation)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.ShowcaseCompanionFk)
                    .HasConstraintName("FK__users__showcaseC__42E1EEFE");

                entity.HasMany(d => d.PostFks)
                    .WithMany(p => p.UserFks)
                    .UsingEntity<Dictionary<string, object>>(
                        "Like",
                        l => l.HasOne<Post>().WithMany().HasForeignKey("PostFk").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__likes__post_fk__3864608B"),
                        r => r.HasOne<User>().WithMany().HasForeignKey("UserFk").HasConstraintName("FK__likes__user_fk__37703C52"),
                        j =>
                        {
                            j.HasKey("UserFk", "PostFk").HasName("PK__likes__1A5355BFD094D1B9");

                            j.ToTable("likes", "Cosminis");

                            j.IndexerProperty<int>("UserFk").HasColumnName("user_fk");

                            j.IndexerProperty<int>("PostFk").HasColumnName("post_fk");
                        });
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
