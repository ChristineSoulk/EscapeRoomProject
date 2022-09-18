namespace DatabaseLibrary.Migrations
{
    using Entities;
    using Entities.Enums;
    using Entities.Models;
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
                "the chamber will be like nothing you've faced before.Pick up your wands,remember your spells and find your courage, you " +
                "will need all of them for the challenges that lie ahead!",
                Duration = 60,
                Genre = Genre.RolePlaying,
                Capacity = 6,
                Difficulty = Difficulty.Easy,
                HasActor = false,
                Rating = 0,
                EscapeRate = 0,
                IsActive = true,
                StartingPricePerPerson = 16,
                DiscountPerPerson = 0.05M,
                ImageUrl = "https://escapethereview.co.uk/wp-content/uploads/2019/03/game-2027.png",
                VideoId = "64NrDwoaYuU"

            };

            Room m2 = new Room()
            {
                Title = "Blackwing's Cave",
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
                Difficulty = Difficulty.Hard,
                HasActor = true,
                Rating = 0,
                EscapeRate = 0,
                IsActive = true,
                StartingPricePerPerson = 25,
                DiscountPerPerson = 0.1M,
                ImageUrl = "https://images.squarespace-cdn.com/content/v1/619d1eb2be8e7e4f5e08a243/5e72bfee-c3ab-4cca-bb0b-f7036e172ca2/Carfax+Gallery+7.jpg?format=2500w",
                VideoId = "T7jrHj3qjc4"

            };

            Room m3 = new Room()
            {
                Title = "Sherlock's Despair",
                Description = "21st of October 1891, London. A dark silence hangs over 221B Baker Street. The great detective Sherlock Holmes has been " +
                "discovered dead, washed up in the gutters outside a seedy East End opium den. Without his nemesis, the wicked Professor James Moriarty plots " +
                "world domination from the shadows. You - Sherlock's oldest friends and faithful assistants - are now the only hope of stopping him. You've " +
                "received a mysterious telegram saying that somewhere, hidden in Sherlock's study, is a file he compiled on Moriarty's evil plans. If this is " +
                "true, it must be discovered and delivered to Inspector Lestrade of Scotland Yard within the hour. Prove your mettle as Baker Street's finest " +
                "by tracking down the file, outsmarting the Napoleon of Crime, and solving the case. The plot thickens, but the game's afoot!",
                Duration = 80,
                Genre = Genre.Mystery,
                Capacity = 5,
                Difficulty = Difficulty.Easy,
                HasActor = false,
                Rating = 0,
                EscapeRate = 0,
                IsActive = true,
                StartingPricePerPerson = 22,
                DiscountPerPerson = 0.08M,
                ImageUrl = "https://www.everyescaperoom.co.uk/data/images/products/355/thumbnail/9e87c42b628d0ddaae453e2ec82cb144.jpg",
                VideoId = "0i85CJilgdQ"

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
                Difficulty = Difficulty.Easy,
                HasActor = false,
                Rating = 0,
                EscapeRate = 0,
                IsActive = true,
                StartingPricePerPerson = 18,
                DiscountPerPerson = 0.06M,
                ImageUrl = "https://img.grouponcdn.com/deal/22XfEvq2jx1vn7hL99SXn9yEhf9r/22-2000x1200/v1/c870x524.jpg",
                VideoId = "1TACbGt9dO4"

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
                Difficulty = Difficulty.Nightmare,
                HasActor = false,
                Rating = 0,
                EscapeRate = 0,
                IsActive = true,
                StartingPricePerPerson = 20,
                DiscountPerPerson = 0.1M,
                ImageUrl = "https://escapethereview.co.uk/wp-content/uploads/2017/04/warbg-e1491755688889.png",
                VideoId = "1beRQ5WqrPo"

            };

            Room m6 = new Room()
            {
                Title = "Butcher's Lair",
                Description = "Dr Vladimir Knifesblade: university professor by day, serial killer by night. He's an educated man - he knows his classical music, his literature, " +
                "and which bits of the human body taste best. The FBI have nicknamed him 'The Butcher'. A simple dinner party invitation to you - some of his favourite students " +
                "- fails to mention that you're the main ingredient on the menu tonight. You've become The Butcher's latest victims, or at least you will be if you don't escape " +
                "from his bloody basement lair. You have 60 minutes before the doctor begins cooking.Only the brightest brains survive... the rest get eaten with some fava beans " +
                "and a nice Chianti. So be smart and don't be lasagne.",
                Duration = 90,
                Genre = Genre.Horror,
                Capacity = 6,
                Difficulty = Difficulty.Nightmare,
                HasActor = true,
                Rating = 0,
                EscapeRate = 0,
                IsActive = true,
                StartingPricePerPerson = 25,
                DiscountPerPerson = 0.12M,
                ImageUrl = "https://i0.wp.com/scareaddicts.com/wp-content/uploads/2019/05/img_5043.jpg?resize=400%2C240",
                VideoId = "mWdqJfjOP8w"

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
                Difficulty = Difficulty.Easy,
                HasActor = false,
                Rating = 0,
                EscapeRate = 0,
                IsActive = true,
                StartingPricePerPerson = 24,
                DiscountPerPerson = 0.12M,
                ImageUrl = "https://s3-media0.fl.yelpcdn.com/bphoto/_i2AOgUQOu615EQ1b9fyuw/348s.jpg",
                VideoId = "Tj1Chebkz68"

            };

            Room m8 = new Room()
            {
                Title = "Patient Zero 2150",
                Description = "Armageddon beckons. The world's superpowers are no more. Renegade factions vie for domination. Rogue scientists have breached all moral boundaries creating " +
                "pathogens that create non-humans. Nerve agents so nightmarish that they corrupt physically and mentally, turning those exposed into the living dead - zombies. In the subterranean " +
                "depths of their secret facility, the pathogen has escaped. It must be contained or all humankind, as we know it, will cease to exist. Your mission ' contain the bio-threat, secure " +
                "the facility and escape uninfected. Can you hold your breath for 60 minutes? This high tech terror will test the smartest players.",
                Duration = 60,
                Genre = Genre.Thriller,
                Capacity = 5,
                Difficulty = Difficulty.Hard,
                HasActor = false,
                Rating = 0,
                EscapeRate = 0,
                IsActive = true,
                StartingPricePerPerson = 20,
                DiscountPerPerson = 0.1M,
                ImageUrl = "https://media-cdn.tripadvisor.com/media/photo-s/17/71/a4/65/psychopath-s-den.jpg",
                VideoId = "LuNhlOziCzc"
            };

            Room m9 = new Room()
            {
                Title = "Spy Heroes",
                Description = "You're going undercover. Your friend James has gone off the grid and you need to check if he's OK. You swing by his restaurant ' the lights are on but James isn't home. " +
                "The door slams shut, trapping you inside. James liked his security high-end. A note on the table tells you that James is actually an international spy ' this is all a cover for his " +
                "espionage escapades. It's his HQ and he has been snatched by the henchmen of his evil arch-enemy ' Mr Supervillain. You must solve all the puzzles and clues in the room and deploy the " +
                "huge array of gadgets to save your super-spy pal. As well as hardware and gizmos, you'll need to think with the cunning of an ace agent ' logic, speed and daring are required. Great " +
                "for all the family ' 10 to 60 welcome, comfortable clothes are advised.",
                Duration = 60,
                Genre = Genre.KidsFriendly,
                Capacity = 5,
                Difficulty = Difficulty.Easy,
                HasActor = false,
                Rating = 0,
                EscapeRate = 0,
                IsActive = true,
                StartingPricePerPerson = 17,
                DiscountPerPerson = 0.07M,
                ImageUrl = "https://thelogicescapesme.com/wp-content/uploads/2017/06/breakin-sherlock.jpg",
                VideoId = "asaREiqt-7M"

            };

            Room m10 = new Room()
            {
                Title = "Psychopath's Den",
                Description = "You know the instant the door slams shut behind you ' bad things happen here. Evil is Omnipresent. Heart-thumping terror builds relentlessly as each nerve-shredding minute " +
                "creeps past. Can you escape a dreadful fate or will you become another blood-stained or blood-drained statistic? Amid the gore-caked instruments of torture, hemmed in by the blood-spattered " +
                "walls you must keep your wits as sharp as his scalpels to avoid his clutches ' he is very close, somewhere in the shadows. Only by solving his crazed, fiendish puzzles can you, quite literally, " +
                "save your skin. Complete with a real crematorium and gallons of O-neg this is the ideal escape experience for lovers of horror and adrenaline-fuelled frights.",
                Duration = 70,
                Genre = Genre.Horror,
                Capacity = 6,
                Difficulty = Difficulty.Nightmare,
                HasActor = true,
                Rating = 0,
                EscapeRate = 0,
                IsActive = true,
                StartingPricePerPerson = 25,
                DiscountPerPerson = 0.1M,
                ImageUrl = "https://static.designmynight.com/uploads/2018/06/Aim-Escape-Room-Psychopaths-Den_041.png",
                VideoId = "-bVS5uHamck"
            };

            context.Rooms.AddOrUpdate(x => x.Title,m1,m2,m3,m4,m5,m6,m7,m8,m9,m10);
            context.SaveChanges();
            #endregion SeedingRooms

            #region SeedingPlayers
            Player p1 = new Player()
            {
                FirstName = "Xristina",
                LastName = "Soulkana",
                Email = "christineslkn@gmail.com",
                PhoneNumber = "6956844367",
                IsSubscribed = true
            };
            Player p2 = new Player()
            {
                FirstName = "Apostolis",
                LastName = "Sandalidis",
                Email = "apostolissn@gmail.com",
                PhoneNumber = "6954879658",
                IsSubscribed = true
            };
            Player p3 = new Player()
            {
                FirstName = "Alexandra",
                LastName = "Kefalloniti",
                Email = "marianta_86@windowslive.com",
                PhoneNumber = "6985645757",
                IsSubscribed = true
            };
            Player p4 = new Player()
            {
                FirstName = "Kostas",
                LastName = "Fiotakis",
                Email = "fiotiskostas@gmail.com",
                PhoneNumber = "6925346545",
                IsSubscribed = true
            };
            Player p5 = new Player()
            {
                FirstName = "Stefanos",
                LastName = "Ventis",
                Email = "steveventis@gmail.com",
                PhoneNumber = "6985323218",
                IsSubscribed = true
            };
            Player p6 = new Player()
            {
                FirstName = "Manos",
                LastName = "Vordakis",
                Email = "manosvordakis@gmail.com",
                PhoneNumber = "6954685487",
                IsSubscribed = true
            };
            context.Players.AddOrUpdate(x => x.Email, p1, p2, p3, p4, p5, p6);
            
            context.SaveChanges();

            #endregion
            
        }
    }
}
