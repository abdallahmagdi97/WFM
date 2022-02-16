using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using WFM.Models;

namespace WFM.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
        public DbSet<WFM.Models.Users.ApplicationUser> ApplicationUser { get; set; }
        public DbSet<WFM.Models.Customer> Customer { get; set; }
        public DbSet<WFM.Models.Tech> Tech { get; set; }
        public DbSet<WFM.Models.Meter> Meter { get; set; }
        public DbSet<WFM.Models.Ticket> Ticket { get; set; }
        public DbSet<WFM.Models.Skill> Skill { get; set; }
        public DbSet<WFM.Models.Area> Area { get; set; }
        public DbSet<WFM.Models.Address> Address { get; set; }
        public DbSet<WFM.Models.Status> Status { get; set; }
        public DbSet<WFM.Models.AssignTicketRequest> AssignTicketRequest { get; set; }
        public DbSet<WFM.Models.TicketSkills> TicketSkills { get; set; }
        public DbSet<WFM.Models.CustomerMeters> CustomerMeters { get; set; }
        public DbSet<WFM.Models.TechSkills> TechSkills { get; set; }
        public DbSet<WFM.Models.CustomerAddress> CustomerAddresses { get; set; }
    }
}
