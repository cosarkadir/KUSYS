using KUSYS.Core.Entity;
using Microsoft.EntityFrameworkCore;

namespace KUSYS.Data
{
    public class KUSYSContext : DbContext
    {
        public KUSYSContext(DbContextOptions<KUSYSContext> options) : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>(entity =>
            {
                entity.ToTable("Course");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id);
                entity.Property(e => e.CourseName)
                    .HasColumnName("CourseName")
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.ToTable("Student");
                entity.HasKey(e=>e.Id); 
                entity.Property(e=>e.Id).UseIdentityColumn();
                entity.Property(e => e.CourseId)
                    .HasColumnName("CourseId")
                    .IsRequired();
                entity.Property(e => e.FirstName)
                    .HasColumnName("FirstName")
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
                entity.Property(e => e.LastName)
                    .HasColumnName("LastName")
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
                entity.Property(e => e.BirthDate)
                    .HasColumnName("BirthDate")
                    .IsRequired()
                    .IsUnicode(false);
                entity.HasOne<Course>(x => x.Course)
                    .WithMany(x => x.Students)
                    .HasForeignKey(x => x.CourseId);
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("Role");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).UseIdentityColumn();
                entity.Property(e => e.Code)
                    .HasColumnName("Code")
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
                entity.Property(e => e.Name)
                    .HasColumnName("Name")
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).UseIdentityColumn();
                entity.Property(e => e.RoleId)
                    .HasColumnName("RoleId")
                    .IsRequired();
                entity.Property(e => e.FirstName)
                    .HasColumnName("FirstName")
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
                entity.Property(e => e.LastName)
                    .HasColumnName("LastName")
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
                entity.Property(e => e.UserName)
                    .HasColumnName("UserName")
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
                entity.Property(e => e.Password)
                    .HasColumnName("Password")
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
                entity.HasOne<Role>(x => x.Role)
                    .WithMany(x => x.Users)
                    .HasForeignKey(x => x.RoleId);
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}