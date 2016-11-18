using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [Required]
        public string Ruleset { get; set; }

        // Faction name field for database
        [Required]
        public string Faction { get; set; }

        //Number of squads/units in army
        public int SquadCount { get; set; }

        //Total point cost of army
        public int Points { get; set; }
    }

    public class ArmyDataContext : DbContext
    {
        public DbSet<Army> Armies { get; set; }

        public ArmyDataContext()
        {
            Database.SetInitializer<ArmyDataContext>(new ArmyInitializer());
        }

        public class ArmyInitializer : DropCreateDatabaseIfModelChanges<ArmyDataContext>
        {
        
            //seed data for new database

            public override void InitializeDatabase(ArmyDataContext dbContext)
            {
                base.InitializeDatabase(dbContext);

                if (!dbContext.Armies.Any(x => x.Ruleset == "Warhammer 40k"))
                {
                    dbContext.Armies.Add(new Models.Army()
                    {
                        Ruleset = "Warhammer 40k",
                        Faction = "Tau",
                        SquadCount = 12,
                        Points = 1850

                    });
                }

                 if (!dbContext.Armies.Any(x => x.Ruleset == "Age of Sigmar"))
                    {
                        dbContext.Armies.Add(new Models.Army()
                        {
                            Ruleset = "Age of Sigmar",
                            Faction = "Death",
                            SquadCount = 15,
                            Points = 1990

                        });
                        dbContext.SaveChanges();
                    }

                }
            }
        }
    }
