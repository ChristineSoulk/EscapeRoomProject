namespace DatabaseLibrary.Migrations
{
    using Entities;
    using Entities.Enums;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DatabaseLibrary.ApplicationContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(DatabaseLibrary.ApplicationContext context)
        {

            #region SeedingRooms 

            Room m1 = new Room()
            {
                Title = "Wizarding School: Fang of the Serpent",
                Description = "Another year at the Wizarding School brings with it new challenges. You have been summoned by the " +
                "headmaster to find a most precious artefact which has been lost for many decades. Its whereabouts unknown, your " +
                "search leads you to a mysterious part of the castle where no one has ventured in years.You feel danger lurking around " +
                "every dark corner... You and your friends must face a great evil in order to complete your mission.The monster guarding " +
                "the chamber will be like nothing you’ve faced before.Pick up your wands,remember your spells and find your courage, you " +
                "will need all of them for the challenges that lie ahead!",
                Duration = 60,
                Genre = Genre.RolePlaying,
                Capacity = 6,
                Difficulty = Difficulty.Beginner,
                HasActor = false,
                Rating = 0,
                EscapeRate = 0,
                Languages = { Language.Greek, Language.English, Language.Spanish },
                IsActive = true,
                PricePerPerson =
                {
                    {2, 16 },
                    {3, 14 },
                    {4, 12 },
                    {5, 11 },
                    {6, 10 }
                }
            };

            Room m2 = new Room()
            {
                Title = "Blackwing’s Cave",
                Description = "Holy padlocks, Blackwing! The evil games-master Doctor Drakker has broken out of jail and is on the loose in " +
                "Knightsbane City, swearing revenge on his arch nemesis - Blackwing, dark crusader of justice. Drakker's goons have tracked " +
                "down the location of Blackwing's secret base and riddled it with an onslaught of fiendishly twisted puzzles,trapping you - " +
                "Blackwing's trusty sidekicks - inside. They've hacked the security systems against you and planted an explosive surprise in the " +
                "darkness... Time is running out. Blackwing cannot battle Drakker alone.Outwit the booby - traps,defuse the bombs, escape the cave " +
                "and reunite your superhero family.So don your capes and pull on your masks - you'll need every skill in your utility belt to defeat " +
                "the villain and save the city!",
                Duration = 90,
                Genre = Genre.Horror,
                Capacity = 6,
                Difficulty = Difficulty.Intermediate,
                HasActor = true,
                Rating = 0,
                EscapeRate = 0,
                Languages = { Language.Greek, Language.English, Language.French },
                IsActive = true,
                PricePerPerson =
                {
                    {2, 25 },
                    {3, 22 },
                    {4, 20 },
                    {5, 18 },
                    {6, 17 }
                }
            };

            Room m3 = new Room()
            {
                Title = "Sherlock’s Despair",
                Description = "21st of October 1891, London. A dark silence hangs over 221B Baker Street. The great detective Sherlock Holmes has been " +
                "discovered dead, washed up in the gutters outside a seedy East End opium den. Without his nemesis, the wicked Professor James Moriarty plots " +
                "world domination from the shadows. You - Sherlock's oldest friends and faithful assistants - are now the only hope of stopping him. You've " +
                "received a mysterious telegram saying that somewhere, hidden in Sherlock's study, is a file he compiled on Moriarty's evil plans. If this is " +
                "true, it must be discovered and delivered to Inspector Lestrade of Scotland Yard within the hour. Prove your mettle as Baker Street's finest " +
                "by tracking down the file, outsmarting the Napoleon of Crime, and solving the case. The plot thickens, but the game's afoot!",
                Duration = 80,
                Genre = Genre.Mystery,
                Capacity = 5,
                Difficulty = Difficulty.Beginner,
                HasActor = false,
                Rating = 0,
                EscapeRate = 0,
                Languages = { Language.Greek, Language.English},
                IsActive = true,
                PricePerPerson =
                {
                    {2, 22 },
                    {3, 20 },
                    {4, 18 },
                    {5, 17 },
                }
            };

            Room m4 = new Room()
            {
                Title = "The Flying Dutchman",
                Description = "Avast ye! Tell me, shark-bait, have you heard the legend of The Flying Dutchman? That dreaded ship captained by the sea-devil Davy " +
                "Jones and his undead pirate crew? You'd best start believing in ghost stories... you're in one! After your ship sinks in a great tempest you awake " +
                "aboard the Dutchman.If you don't escape before sunrise you'll be trapped aboard her forever.Legend tells of a mythical diamond - the Heart of Calypso " +
                "- which can break the curse. It's hidden somewhere on the lower decks.The sun rises in an hour. So shiver your timbers, swash your buckles, and batten " +
                "down the hatches. You need to discover the diamond to escape the ship and a watery doom!",
                Duration = 70,
                Genre = Genre.KidsFriendly,
                Capacity = 6,
                Difficulty = Difficulty.Beginner,
                HasActor = false,
                Rating = 0,
                EscapeRate = 0,
                Languages = { Language.Greek, Language.English, Language.German },
                IsActive = true,
                PricePerPerson =
                {
                    {2, 18 },
                    {3, 16 },
                    {4, 15 },
                    {5, 14 },
                    {6, 12 }
                }
            };

            Room m5 = new Room()
            {
                Title = "War on Horizon Alpha",
                Description = "The galaxy is in peril, trapped under the cyborg fist of the feared Alpha One faction. The imperial regime rules from the space-fortress codenamed " +
                "Horizon Alpha, a terrifying superweapon with an impenetrable security system. You are a plucky band of rebels - the best in the parsec - chosen to infiltrate " +
                "the Horizon Alpha.In 60 minutes a massive rebel fleet will arrive through hyperspace and fire on the base, but you must manually deactivate the shields if this " +
                "daring assault is to work. Grab your laser - swords.Arm your blasters. Complete the mission and escape before the Horizon Alpha is reduced to atoms.Good luck, " +
                "you're our only hope!",
                Duration = 60,
                Genre = Genre.SciFi,
                Capacity = 5,
                Difficulty = Difficulty.Advanced,
                HasActor = false,
                Rating = 0,
                EscapeRate = 0,
                Languages = { Language.Greek, Language.English, Language.Italian },
                IsActive = true,
                PricePerPerson =
                {
                    {2, 20 },
                    {3, 18 },
                    {4, 17 },
                    {5, 15 }
                }
            };

            Room m6 = new Room()
            {
                Title = "Butcher’s Lair",
                Description = "Dr Vladimir Knifesblade: university professor by day, serial killer by night. He's an educated man - he knows his classical music, his literature, " +
                "and which bits of the human body taste best. The FBI have nicknamed him 'The Butcher'. A simple dinner party invitation to you - some of his favourite students " +
                "- fails to mention that you're the main ingredient on the menu tonight. You've become The Butcher's latest victims, or at least you will be if you don't escape " +
                "from his bloody basement lair. You have 60 minutes before the doctor begins cooking.Only the brightest brains survive... the rest get eaten with some fava beans " +
                "and a nice Chianti. So be smart and don't be lasagne.",
                Duration = 90,
                Genre = Genre.Horror,
                Capacity = 6,
                Difficulty = Difficulty.Advanced,
                HasActor = true,
                Rating = 0,
                EscapeRate = 0,
                Languages = { Language.Greek, Language.English},
                IsActive = true,
                PricePerPerson =
                {
                    {2, 25 },
                    {3, 22 },
                    {4, 20 },
                    {5, 18 },
                    {6, 17 }
                }
            };

            Room m7 = new Room()
            {
                Title = "Heist Plan",
                Description = "You are a gang of street racers planning a major heist in New York City. Operation: Race Day. The aim is to hit the five biggest banks in Manhattan in " +
                "one night, under the cover of an illegal street race you'll be competing in using two of your tuned-up cars. It's daring, but it just might work. However, word travels " +
                "fast in the criminal underworld.A rival gang have broken into your garage overnight, stolen one of your cars and wrecked the other one's engine. Now you have only one " +
                "hour to repair your broken car, find your second car and steal it back, get to the starting line and finish the job.Be fast and furious in your problem - solving. Does " +
                "your crew have what it takes ? ",
                Duration = 80,
                Genre = Genre.RolePlaying,
                Capacity = 4,
                Difficulty = Difficulty.Beginner,
                HasActor = false,
                Rating = 0,
                EscapeRate = 0,
                Languages = { Language.Greek, Language.English, Language.French },
                IsActive = true,
                PricePerPerson =
                {
                    {2, 24 },
                    {3, 22 },
                    {4, 20 },
                }
            };

            Room m8 = new Room()
            {
                Title = "Patient Zero 2150",
                Description = "Armageddon beckons. The world’s superpowers are no more. Renegade factions vie for domination. Rogue scientists have breached all moral boundaries creating " +
                "pathogens that create non-humans. Nerve agents so nightmarish that they corrupt physically and mentally, turning those exposed into the living dead - zombies. In the subterranean " +
                "depths of their secret facility, the pathogen has escaped. It must be contained or all humankind, as we know it, will cease to exist. Your mission – contain the bio-threat, secure " +
                "the facility and escape uninfected. Can you hold your breath for 60 minutes? This high tech terror will test the smartest players.",
                Duration = 60,
                Genre = Genre.Thriller,
                Capacity = 5,
                Difficulty = Difficulty.Intermediate,
                HasActor = false,
                Rating = 0,
                EscapeRate = 0,
                Languages = { Language.Greek, Language.English, Language.Italian },
                IsActive = true,
                PricePerPerson =
                {
                    {2, 20 },
                    {3, 18 },
                    {4, 17 },
                    {5, 15 }
                }
            };

            Room m9 = new Room()
            {
                Title = "Spy Heroes",
                Description = "You’re going undercover. Your friend James has gone off the grid and you need to check if he’s OK. You swing by his restaurant – the lights are on but James isn’t home. " +
                "The door slams shut, trapping you inside. James liked his security high-end. A note on the table tells you that James is actually an international spy – this is all a cover for his " +
                "espionage escapades. It’s his HQ and he has been snatched by the henchmen of his evil arch-enemy – Mr Supervillain. You must solve all the puzzles and clues in the room and deploy the " +
                "huge array of gadgets to save your super-spy pal. As well as hardware and gizmos, you’ll need to think with the cunning of an ace agent – logic, speed and daring are required. Great " +
                "for all the family – 10 to 60 welcome, comfortable clothes are advised.",
                Duration = 60,
                Genre = Genre.KidsFriendly,
                Capacity = 5,
                Difficulty = Difficulty.Beginner,
                HasActor = false,
                Rating = 0,
                EscapeRate = 0,
                Languages = { Language.Greek, Language.English, Language.Spanish },
                IsActive = true,
                PricePerPerson =
                {
                    {2, 17 },
                    {3, 15 },
                    {4, 14 },
                    {5, 12 },
                }
            };

            Room m10 = new Room()
            {
                Title = "Psychopath's Den",
                Description = "You know the instant the door slams shut behind you – bad things happen here. Evil is Omnipresent. Heart-thumping terror builds relentlessly as each nerve-shredding minute " +
                "creeps past. Can you escape a dreadful fate or will you become another blood-stained or blood-drained statistic? Amid the gore-caked instruments of torture, hemmed in by the blood-spattered " +
                "walls you must keep your wits as sharp as his scalpels to avoid his clutches – he is very close, somewhere in the shadows. Only by solving his crazed, fiendish puzzles can you, quite literally, " +
                "save your skin. Complete with a real crematorium and gallons of O-neg this is the ideal escape experience for lovers of horror and adrenaline-fuelled frights.",
                Duration = 70,
                Genre = Genre.Horror,
                Capacity = 6,
                Difficulty = Difficulty.Advanced,
                HasActor = true,
                Rating = 0,
                EscapeRate = 0,
                Languages = { Language.Greek, Language.English},
                IsActive = true,
                PricePerPerson =
                {
                    {2, 25 },
                    {3, 22 },
                    {4, 20 },
                    {5, 18 },
                    {6, 17 }
                }
            };

            context.Rooms.AddOrUpdate(m1, m2, m3, m4, m5, m6, m7, m8, m9, m10);
            #endregion SeedingRooms

            #region SeedingPlayers
            Player p1 = new Player()
            {
                FirstName = "Xristina",
                LastName = "Soulkana",
                Email = "eleutherosskopeuths1@bootcamp.com",
                PhoneNumber = "6956844367",
            };
            Player p2 = new Player()
            {
                FirstName = "Apostolis",
                LastName = "Sandalidis",
                Email = "Mastoras@bootcamp.com",
                PhoneNumber = "6954879658",
            };
            Player p3 = new Player()
            {
                FirstName = "Alexandra",
                LastName = "Kefaloniti",
                Email = "eleutherosskopeuths2@bootcamp.com",
                PhoneNumber = "6985645757",
            };
            Player p4 = new Player()
            {
                FirstName = "Kostas",
                LastName = "Fiotakis",
                Email = "Kallitexnis@bootcamp.com",
                PhoneNumber = "6925346545",
            };
            Player p5 = new Player()
            {
                FirstName = "Stefanos",
                LastName = "Ventis",
                Email = "tralalitralalo@bootcamp.com",
                PhoneNumber = "6985323218",
            };
            Player p6 = new Player()
            {
                FirstName = "Manos",
                LastName = "Vordakis",
                Email = "tramparoufas@gmail.com",
                PhoneNumber = "6954685487",
            };
            context.Players.AddOrUpdate(p1, p2, p3, p4, p5, p6);
            #region Seeding Reservation
            Reservation r1 = new Reservation()
            {               
                NumberOfPlayers = 4,
                GameStart = new DateTime(2022, 08, 25, 05, 30, 00),
            };
            Reservation r2 = new Reservation()
            {              
                NumberOfPlayers = 6,
                GameStart = new DateTime(2022, 08, 26, 07, 00, 00),
            };
            Reservation r3 = new Reservation()
            {              
                NumberOfPlayers = 3,
                GameStart = new DateTime(2022, 08, 25, 07, 00, 00),
            };
            Reservation r4 = new Reservation()
            {
                NumberOfPlayers = 2,
                GameStart = new DateTime(2022, 08, 27, 08, 00, 00),
            };
            Reservation r5 = new Reservation()
            {
                NumberOfPlayers = 4,
                GameStart = new DateTime(2022, 08, 25, 06, 30, 00),
            };
            r1.Room = m5;
            r1.Player = p4;
            
            r2.Room = m4;
            r2.Player = p2;
            
            r3.Room = m7;
            r3.Player = p1;
           
            r4.Room = m1;
            r4.Player = p3;
            
            r5.Room = m10;
            r5.Player = p5;
            

            context.Reservations.AddOrUpdate(r1, r2, r3, r4, r5);
            context.SaveChanges();

            #endregion




            #endregion
        }
    }
}
