using EduxV4.Data;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EduxV4.Repo
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
      
        public DbSet<EduxV4.Data.Contact> Contacts { get; set; }
        public DbSet<EduxV4.Data.Activity> Activities { get; set; }
        public DbSet<EduxV4.Data.ActivityNextStep> ActivityNextSteps { get; set; }
        public DbSet<EduxV4.Data.ActivitySource> ActivitySources { get; set; }
        public DbSet<EduxV4.Data.ActivityStatus> ActivityStatuses { get; set; }
        public DbSet<EduxV4.Data.ActivityType> ActivityTypes { get; set; }
        public DbSet<EduxV4.Data.Campus> Campuses { get; set; }
        public DbSet<EduxV4.Data.ClassLevel> ClassLevels { get; set; }
        public DbSet<EduxV4.Data.Occupation> Occupations { get; set; }
        public DbSet<EduxV4.Data.Positiveness> Positivenesses { get; set; }
        public DbSet<EduxV4.Data.SchoolLevel> SchoolLevels { get; set; }
        public DbSet<EduxV4.Data.Country> Countries { get; set; }
        public DbSet<EduxV4.Data.City> Cities { get; set; }
        public DbSet<EduxV4.Data.County> Counties { get; set; }
        public DbSet<EduxV4.Data.District> Districts { get; set; }
        public DbSet<EduxV4.Data.Region> Regions { get; set; }
        public DbSet<EduxV4.Data.Family> Families { get; set; }
        public DbSet<EduxV4.Data.Announcement> Announcements { get; set; }
        public DbSet<EduxV4.Data.Branch> Branches { get; set; }
        public DbSet<EduxV4.Data.BranchAnnouncement> BranchAnnouncements { get; set; }
        public DbSet<EduxV4.Data.BranchCourseContent> BranchCourseContents { get; set; }
        public DbSet<EduxV4.Data.BranchHomework> BranchHomeworks { get; set; }
        public DbSet<EduxV4.Data.ContactCourseContent> ContactCourseContents { get; set; }
        public DbSet<EduxV4.Data.ContactHomework> ContactHomeworks { get; set; }
        public DbSet<EduxV4.Data.CourseResource> CourseResources { get; set; }
        public DbSet<EduxV4.Data.Homework> Homeworks { get; set; }
        public DbSet<EduxV4.Data.Room> Rooms { get; set; }
        public DbSet<EduxV4.Data.School> Schools { get; set; }
        public DbSet<EduxV4.Data.Season> Seasons { get; set; }
        public DbSet<EduxV4.Data.Course> Courses { get; set; }
        public DbSet<EduxV4.Data.CourseContent> CourseContents { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Activity>().HasOne(a => a.Contact)
                .WithMany(c => c.Activities).HasForeignKey(ac => ac.ContactId);
            modelBuilder.Entity<Activity>().HasOne(a => a.Staff)
               .WithMany(c => c.StaffActivities).HasForeignKey(s => s.StaffId);
            modelBuilder.Entity<Activity>().HasOne(a => a.ForContact)
               .WithMany(c => c.ActivitiesFor).HasForeignKey(a => a.ForContactId);

            modelBuilder.Entity<BranchAnnouncement>().HasKey(ba => new { ba.BranchId, ba.AnnouncementId });
            modelBuilder.Entity<BranchHomework>().HasKey(bh => new { bh.BranchId, bh.HomeworkId });
            modelBuilder.Entity<BranchCourseContent>().HasKey(bcc => new { bcc.BranchId, bcc.CourseContentId });
            modelBuilder.Entity<ContactCourseContent>().HasKey(ccc => new { ccc.ContactId, ccc.CourseContentId });
            modelBuilder.Entity<ContactHomework>().HasKey(ch => new { ch.ContactId, ch.HomeworkId });
        }
    }
}
