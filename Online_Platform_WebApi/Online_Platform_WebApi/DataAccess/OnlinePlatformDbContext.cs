using Microsoft.EntityFrameworkCore;
using Online_Platform_WebApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Online_Platform_WebApi.DataAccess
{
    public class OnlinePlatformDbContext:DbContext
    {

      
        public OnlinePlatformDbContext(DbContextOptions options):base(options)
        {
             
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server = DESKTOP - 33L0BFJ\\SQLEXPRESS; Database = OnlinePlatform; Trusted_Connection = true");
            }
        }


        public DbSet<Teacher> Teachers { get; set; } //Benim Product nesnemi veritabanındaki Products ile bağla demek buda.
        public DbSet<Student> Students { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<Homework> Homeworks { get; set; }
        public DbSet<TeacherStudent> TeacherStudents { get; set; }
        public DbSet<LessonStudent> LessonStudents { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
         
            modelBuilder.Entity<Homework>().Property(a => a.Name).IsRequired();
            modelBuilder.Entity<Homework>().Property(a => a.Directive).IsRequired();
            modelBuilder.Entity<Homework>().Property(a => a.DeliveryDate).IsRequired();
            modelBuilder.Entity<Lesson>().Property(a => a.Name).IsRequired();
            modelBuilder.Entity<Lesson>().Property(a => a.Time).IsRequired();
            modelBuilder.Entity<Teacher>().HasKey(a => a.TeacherId);
            modelBuilder.Entity<Student>().HasKey(a => a.StudentId);
            modelBuilder.Entity<Lesson>().HasKey(a => a.LessonId);
            modelBuilder.Entity<Homework>().HasKey(a => a.HomeworkId);
            modelBuilder.Entity<LessonStudent>().HasKey(a => new { a.LessonId, a.StudentId });
            modelBuilder.Entity<TeacherStudent>().HasKey(a => new { a.TeacherId, a.StudentId });


        
    

            modelBuilder.Entity<Lesson>()
               .HasMany(a => a.Homeworks)
               .WithOne(a => a.Lesson)
               .HasForeignKey(a => a.LessonId)
               .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Homework>()
                .HasOne(a => a.Lesson)
                .WithMany(a => a.Homeworks);


            modelBuilder.Entity<Teacher>()
              .HasMany(a => a.Lessons)
              .WithOne(a => a.Teacher)
              .HasForeignKey(a => a.TeacherId)
              .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Lesson>()
                .HasOne(a => a.Teacher)
                .WithMany(a => a.Lessons);


            modelBuilder.Entity<LessonStudent>()
           .HasOne(a => a.Lesson)
           .WithMany(a => a.LessonStudents)
           .HasForeignKey(a => a.LessonId)
           .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<LessonStudent>()
            .HasOne(a => a.Student)
            .WithMany(a => a.LessonStudents)
            .HasForeignKey(a => a.StudentId)
            .OnDelete(DeleteBehavior.NoAction);



            modelBuilder.Entity<TeacherStudent>()
            .HasOne(a=>a.Teacher)
            .WithMany(a => a.TeacherStudents)    
            .HasForeignKey(a => a.TeacherId)
            .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<TeacherStudent>()
            .HasOne(a => a.Student)
            .WithMany(a => a.TeacherStudents)
            .HasForeignKey(a => a.StudentId)
            .OnDelete(DeleteBehavior.NoAction);

         
        }

    }
}
