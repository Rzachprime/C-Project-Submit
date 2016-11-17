using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CodeLouCsharpProject.Models
{
    public class Army
    {
        // army id number for database
        public int ArmyID { get; set; }

        //ruleset name field for database
        public string Ruleset { get; set; }

        // Faction name field for database
        public string Faction { get; set; }

        //Number of squads/units in army
        public int SquadCount { get; set; }

        //Total point cost of army
        public int Points { get; set; }
    }

    public class ArmyDataContext : DbContext
    {
        public DbSet<Army> Armies { get; set; }

    }
}