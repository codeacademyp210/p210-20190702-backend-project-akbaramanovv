﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AdminTEmplate.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class FitnessDbEntities1 : DbContext
    {
        public FitnessDbEntities1()
            : base("name=FitnessDbEntities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<ClubInfo> ClubInfoes { get; set; }
        public virtual DbSet<Cours> Courses { get; set; }
        public virtual DbSet<Kur> Kurs { get; set; }
        public virtual DbSet<Package> Packages { get; set; }
        public virtual DbSet<Payment> Payments { get; set; }
        public virtual DbSet<Room> Rooms { get; set; }
        public virtual DbSet<Trainer> Trainers { get; set; }
        public virtual DbSet<UserDeatil> UserDeatils { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UsersPending> UsersPendings { get; set; }
    }
}