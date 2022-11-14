namespace Week8ClassLibrary2022.DataLayer.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Tracker.WebAPIClient;

    internal sealed class Configuration : DbMigrationsConfiguration<ClubModels.ClubsContext>
    {



        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ClubModels.ClubsContext context)
        {

            ActivityAPIClient.Track(StudentID: "S00211628", StudentName: "Martin Melody", activityName: "RAD301 Week 8 Lab 2223", Task: "Adding Club Events");

            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data


            SeedClubs(context);

        }

        private void SeedClubs(ClubModels.ClubsContext context)
        {
            context.Clubs.AddOrUpdate(c => c.ClubName,
                new ClubModels.Club
                {
                    ClubName = "Swimming Club",
                    CreationDate = DateTime.Now,
                    clubEvents = new List<ClubModels.ClubEvent>() {
                        new ClubModels.ClubEvent {
                            StartDateTime = DateTime.Now.Subtract(new TimeSpan(5, 0, 0, 0)),
                            EndDateTime = DateTime.Now.Subtract(new TimeSpan(5, 0, 0, 0)),
                            Location = "sligo", Venue = "Arena"
                        },
                        new ClubModels.ClubEvent
                        {
                            StartDateTime = DateTime.Now.Subtract(new TimeSpan(6,0, 0, 0)),
                            EndDateTime = DateTime.Now.Subtract(new TimeSpan(6,0,0,0)),
                            Location = "sligo", Venue = "Mullaghmore"
                        },
                        new ClubModels.ClubEvent
                        {
                            StartDateTime= DateTime.Now.Subtract(new TimeSpan(4,0,0,0)),
                            EndDateTime= DateTime.Now.Subtract(new TimeSpan(4,0,0,0)),
                            Location = "Dublin", Venue = "3 Arena"
                        }
                    }
                },
                new ClubModels.Club
                {
                    ClubName = "BasketBall Club",
                    CreationDate = DateTime.Now,
                    clubEvents = new List<ClubModels.ClubEvent>()
                    {
                        new ClubModels.ClubEvent
                        {
                            StartDateTime = DateTime.Now.Subtract(new TimeSpan(8,0,0,0)),
                            EndDateTime = DateTime.Now.Subtract(new TimeSpan(8,0,0,0)),
                            Location = "Sligo", Venue = "BasketBall Court"
                        },
                        new ClubModels.ClubEvent
                        {
                            StartDateTime = DateTime.Now.Subtract(new TimeSpan(4,0,0,0)),
                            EndDateTime = DateTime.Now.Subtract(new TimeSpan(4, 0, 0, 0)),
                            Location = "sligo", Venue = "knocknarea arena"
                        },
                        new ClubModels.ClubEvent
                        {
                            StartDateTime = DateTime.Now.Subtract(new TimeSpan(6,0,0,0)),
                            EndDateTime = DateTime.Now.Subtract(new TimeSpan(6,0,0,0)),
                            Location = "donegal", Venue = "Bundoran Basketball court"
                        }
                    }
                },
                
                new ClubModels.Club
                {
                    ClubName = "The Golf Club",
                    CreationDate = DateTime.Now,
                    clubEvents = new List<ClubModels.ClubEvent>()
                    {
                        new ClubModels.ClubEvent
                        {
                            StartDateTime = DateTime.Now.Subtract(new TimeSpan(2,0,0,0)),
                            EndDateTime = DateTime.Now.Subtract(new TimeSpan(2,0,0,0)),
                            Location = "sligo", Venue = "Rosses Point golf course"
                        },
                        new ClubModels.ClubEvent
                        {
                            StartDateTime = DateTime.Now.Subtract(new TimeSpan(1,0,0,0)),
                            EndDateTime = DateTime.Now.Subtract(new TimeSpan(1,0,0,0)),
                            Location = "sligo", Venue = "ATU Sligo"
                        },
                        new ClubModels.ClubEvent
                        {
                            StartDateTime = DateTime.Now.Subtract(new TimeSpan(12,0,0,0)),
                            EndDateTime = DateTime.Now.Subtract(new TimeSpan(12,0,0,0)),
                            Location = "Sligo", Venue = "Sligo Golf",
                        }
                    }                
                });

            context.SaveChanges();
                
        }
    }
}
