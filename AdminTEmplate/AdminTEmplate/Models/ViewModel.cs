using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdminTEmplate.Models
{
    public class ViewModel
    {
        public List<Models.ClubInfo> ClubInfos { get; set; }
        public List<Models.Cours> Courses { get; set; }
        public List<Models.Package> Packs { get; set; }
        public List<Models.UsersPending> UsersPendings { get; set; }
        public List<Models.Payment> Payments { get; set; }
        public List<Models.Room> Rooms { get; set; }
        public List<Models.Trainer> Trainers { get; set; }
        public List<Models.User> Users { get; set; }
        public List<Models.Admin> Admins { get; set; }
        public List<Models.UserDeatil> UserDeatils { get; set; }
        public Package Package { get; set; }
        public Cours Cours { get; set; }
        public Room Room { get; set; }
        public Trainer Trainer { get; set; }
        public User User { get; set; }
        public List<string> Gender { get; set; }
        public List<string> Status { get; set; }


    }
}