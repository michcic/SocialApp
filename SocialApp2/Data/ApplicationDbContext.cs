using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SocialApp.Models;
using SocialApp2.Models;

namespace SocialApp2.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Post> Posts { get; set; }
        public DbSet<Invitation> Invitation { get; set; }
        public DbSet<Friend> Friends { get; set; }
        public DbSet<Comment> Comments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            /*modelBuilder.Entity<Friend>()
                .HasKey(e => new { e.UserSenderId, e.UserReceiverId });

            modelBuilder.Entity<Friend>()
                .HasOne(e => e.UserSender)
                .WithMany(e => e.FriendsByReceived)
                .HasForeignKey(e => e.UserSenderId).OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Friend>()
                .HasOne(e => e.UserReceiver)
                .WithMany(e => e.FriendsBySend)
                .HasForeignKey(e => e.UserReceiverId).OnDelete(DeleteBehavior.Cascade);*/
        }
    }
}
