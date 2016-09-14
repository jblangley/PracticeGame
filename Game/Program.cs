using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class Program
    {
        static void Main(string[] args)
        {
            RunLoop();
        }
        public static Random random = new Random(DateTime.Now.Millisecond);
        //////////////////////////////////////////Initailizes the game///////////////////////////////////////////////
        static void RunLoop()
        {
            int exit = 0;
            while (exit != 2)
            {
                exit = MainOptions();
            }
        }
        public static int MainOptions()
        {
            DisplayStartMenu();
            int option = Convert.ToInt32(Prompt("What would you like to do?"));
            switch (option)
            {
                case 1:
                    //Start New Game
                    EnemyChoice();
                    break;
                case 2:
                    //End Application
                    break;
                default:
                    Console.WriteLine("Incorrect Input");
                    break;
            }
            return option;
        }
        public static void DisplayStartMenu()
        {
            Console.Clear();
            Console.WriteLine("1 - Start Game");
            Console.WriteLine("2 - Exit Game");
        }
        ////////////////////////////////////Player Chooses their battle//////////////////////////////////////
        public static void EnemyChoice()
        {
            DisplayEnemyMenu();
            int option = Convert.ToInt32(Prompt("Which Unit would you like to face?"));
            switch (option)
            {
                case 1:
                    GruntLoop();
                    break;
                case 2:
                    WolfLoop();
                    break;
                case 3:
                    BossLoop();
                    break;
                case 4:
                    GruntArmyLoop();
                    break;
                case 5:
                    ArmyLoop();
                    break;
                default:
                    Console.WriteLine("Incorrect Input");
                    break;
            }
        }
        public static void DisplayEnemyMenu()
        {
            Console.Clear();
            Console.WriteLine("1 - Grunt");
            Console.WriteLine("2 - Wolf");
            Console.WriteLine("3 - Boss");
            Console.WriteLine("4 - Grunt Squad");
            Console.WriteLine("5 - Army Creation");
        }
        ////////////////////////////////////////////Creates Units/////////////////////////////////////////////////////
        public static Unit StartingSetupHero()
        {
            Unit Hero = new Unit();
            Hero.BaseAttack = 8;
            Hero.BaseDefense = 100;
            Hero.MaxDefense = 100;
            Hero.Item = 4;
            Hero.Magic = 12;
            Hero.MaxMagic = 12;
            Hero.Name = "Hiro";
            return Hero;
        }
        public static Unit StartingSetupGrunt()
        {
            Unit Grunt = new Unit();
            Grunt.BaseAttack = 1;
            Grunt.BaseDefense = 24;
            Grunt.Name = "Grunt";
            return Grunt;
        }
        public static Unit StartingSetupWolf()
        {
            Unit Wolf = new Unit();
            Wolf.BaseAttack = 15;
            Wolf.BaseDefense = 75;
            Wolf.Name = "Wolf";
            return Wolf;
        }
        public static Unit StartingSetupBoss()
        {
            Unit Boss = new Unit();
            Boss.BaseAttack = 15;
            Boss.BaseDefense = 150;
            Boss.MaxDefense = 150;
            Boss.Name = "Boss";
            Boss.Magic = 15;
            Boss.Item = 2;
            return Boss;
        }
        public static void StartingSetupGruntSquad(List<Unit> AllEnemiesFighting)
        {
            for (int index = 0; index < 4; index++)
            {
                AllEnemiesFighting.Add(StartingSetupGrunt());
            }
        }
        ///////////////////////////////////Runs the choosen battle////////////////////////////////
        public static void GruntLoop()
        {
            Unit hero = StartingSetupHero();
            Unit grunt = StartingSetupGrunt();
            List<Unit> AllEnemiesFighting = new List<Unit>();
            AllEnemiesFighting.Add(grunt);
            MatchMultiplesLoop(hero, AllEnemiesFighting);
        }
        public static void WolfLoop()
        {
            Unit hero = StartingSetupHero();
            Unit grunt = StartingSetupWolf();
            List<Unit> AllEnemiesFighting = new List<Unit>();
            AllEnemiesFighting.Add(grunt);
            MatchMultiplesLoop(hero, AllEnemiesFighting);
        }
        public static void BossLoop()
        {
            Unit hero = StartingSetupHero();
            Unit grunt = StartingSetupBoss();
            List<Unit> AllEnemiesFighting = new List<Unit>();
            AllEnemiesFighting.Add(grunt);
            MatchMultiplesLoop(hero, AllEnemiesFighting);
        }
        public static void GruntArmyLoop()
        {
            Unit hero = StartingSetupHero();
            List<Unit> AllEnemiesFighting = new List<Unit>();
            StartingSetupGruntSquad(AllEnemiesFighting);
            MatchMultiplesLoop(hero, AllEnemiesFighting);
        }
        ////////Allows the player to choose multiple enemies
        public static void ArmyLoop()
        {
            Unit hero = StartingSetupHero();
            List<Unit> AllEnemiesFighting = new List<Unit>();
            AddEnemyLoop(AllEnemiesFighting);
            MatchMultiplesLoop(hero, AllEnemiesFighting);
        }
        public static void AddEnemyLoop(List<Unit> AllEnemiesFighting)
        {
            int loop = 0;
            while (loop < 5)
            {
                loop = AddEnemies(AllEnemiesFighting);
            }
        }
        public static int AddEnemies(List<Unit> AllEnemiesFighting)
        {
            DisplayUnitMenu();
            int choice = Convert.ToInt32(Prompt("What enemies will you face?"));
            switch (choice)
            {
                case 1:
                    AllEnemiesFighting.Add(StartingSetupGrunt());
                    break;
                case 2:
                    AllEnemiesFighting.Add(StartingSetupWolf());
                    break;
                case 3:
                    AllEnemiesFighting.Add(StartingSetupBoss());
                    break;
                case 4:
                    StartingSetupGruntSquad(AllEnemiesFighting);
                    break;
                case 5:
                    break;
                default:
                    Console.WriteLine("Incorrect Input");
                    break;
            }
            return choice;
        }
        public static void DisplayUnitMenu()
        {
            Console.Clear();
            Console.WriteLine("1 - Grunt");
            Console.WriteLine("2 - Wolf");
            Console.WriteLine("3 - Boss");
            Console.WriteLine("4 - Grunt Squad");
            Console.WriteLine("5 - Begin Battle");
        }
        /////////////////////The Battle options for 1v1 or After an enemy is selected from the Army//////////////
        public static string Match(Unit hero, Unit grunt)
        {
            string ailment = "";
            int option = DisplayStatsAndOptions(hero, grunt);
            switch (option)
            {
                case 1:
                    grunt.BaseDefense -= hero.BaseAttack;
                    Console.WriteLine(hero.Name + " did " + hero.BaseAttack + " damage to " + grunt.Name);
                    break;
                case 2:
                    Fire(hero, grunt);
                    break;
                case 3:
                    ailment = Ice(hero, grunt);
                    break;
                case 4:
                    ItemMenu(hero);
                    ailment = "item";
                    break;
                default:
                    Console.WriteLine("Incorrect Input");
                    break;
            }
            return ailment;
        }
        public static int MatchMultiples(Unit hero, List<Unit> AllEnemiesFighting)
        {
            string ailment = "";
            int option = DisplayChooseWhichToAttack(hero, AllEnemiesFighting) - 1;
            if (option < AllEnemiesFighting.Count)
            {
                ailment = Match(hero, AllEnemiesFighting[option]);
            }
            AllEnemiesFighting.RemoveAll(item => item.BaseDefense <= 0);
            AllEnemiesAttack(hero, AllEnemiesFighting, ailment);
            return option;
        }
        public static void MatchMultiplesLoop(Unit hero, List<Unit> AllEnemiesFighting)
        {
            int loop = 0;
            while (loop <= AllEnemiesFighting.Count)
            {
                loop = MatchMultiples(hero, AllEnemiesFighting);
                loop = CheckEndGameList(hero, AllEnemiesFighting, loop);
                Console.WriteLine("Press enter to continue");
                Console.ReadKey();
            }
        }
        public static void AllEnemiesAttack(Unit hero, List<Unit> AllEnemiesFighting, string ailment)
        {
            switch (ailment)
            {
                case "item":
                    break;
                case "ice":
                    FreezeCheck(hero, AllEnemiesFighting);
                    break;
                default:
                    for (int index = 0; index < AllEnemiesFighting.Count; index++)
                    {
                        EnemyCanAttack(hero, AllEnemiesFighting[index]);
                    }
                    break;
            }
        }
        public static int DisplayChooseWhichToAttack(Unit hero, List<Unit> AllEnemiesFighting)
        {
            int count = 1;
            Console.Clear();
            Console.WriteLine("Your Health Left: " + hero.BaseDefense);
            for (int index = 0; index < AllEnemiesFighting.Count; index++)
            {
                count++;
                Console.WriteLine(index + 1 + " - " + AllEnemiesFighting[index].Name + " has " + AllEnemiesFighting[index].BaseDefense + " Health Left");
            }
            Console.WriteLine(count + 1 + " - To Exit");
            return Convert.ToInt32(Prompt("Which enemy are you going to attack?"));
        }
        public static void CheckIfEnemyAttacks(Unit hero, Unit grunt, bool frozen)
        {
            if (frozen == false)
            {
                EnemyCanAttack(hero, grunt);
            }
            else
            {
                Console.WriteLine("Enemey is Frozen for a turn!");
            }
        }
        public static void EnemyCanAttack(Unit hero, Unit grunt)
        {
            if (grunt.Item>0 & grunt.BaseDefense<grunt.MaxDefense/4)
            {
                RestoreHealth(grunt); 
            }
            else
            {
            int choice = SetAttackChoice(grunt);
            EnemyAttack(choice, hero, grunt);
            }
        }
        public static int SetAttackChoice(Unit grunt)
        {
            int choose = 0;
            if (grunt.Magic < 9)
            {
                choose = random.Next(1, 65);
            }
            else
            {
                choose = random.Next(1, 101);
            }
            return choose;
        }
        public static int EnemyAttack(int choose, Unit hero, Unit grunt)
        {
            if (choose >= 65)
            {
                Fire(grunt, hero);
            }
            else
            {
                hero.BaseDefense -= grunt.BaseAttack;
                Console.WriteLine(grunt.Name + " did " + grunt.BaseAttack + " damage to " + hero.Name);
            }
            return choose;
        }
        public static int DisplayStatsAndOptions(Unit hero, Unit grunt)
        {
            Console.Clear();
            Console.WriteLine(hero.Name + "!");
            Console.WriteLine("Health: " + hero.BaseDefense);
            Console.WriteLine("Spells Left: " + hero.Magic);
            Console.WriteLine("Potions Left: " + hero.Item);
            Console.WriteLine("1 - Attack\t2 - Fire\t3 - Ice\n4 - Items\n");
            Console.WriteLine(grunt.Name + "!");
            Console.WriteLine("Health: " + grunt.BaseDefense);
            return Convert.ToInt32(Prompt("What are you going to do?"));
        }
        /////////////////////////////////////Spells///////////////////////////////
        public static void Fire(Unit attacker, Unit defender)
        {
            if (attacker.Magic > 0)
            {
                defender.BaseDefense -= attacker.Magic * 2;
                Console.WriteLine(attacker.Name + "'s fire did " + attacker.Magic * 2 + " to " + defender.Name);
                attacker.Magic -= 1;
            }
            else
            {
                Console.WriteLine("You don't have enough magic!");
            }
        }
        public static string Ice(Unit attacker, Unit defender)
        {
            string ailment = "";
            if (attacker.Magic > 0)
            {
                defender.BaseDefense -= 6;
                Console.WriteLine(attacker.Name + " did 6 damage to " + defender.Name);
                attacker.Magic -= 1;
                ailment = "ice";
            }
            else
            {
                Console.WriteLine("You don't have enough magic!");
            }
            return ailment;
        }
        public static bool CalculateFreeze()
        {
            bool isFrozen = false;
            int generate = random.Next(1, 101);
            if (generate%2==0)
            {
                isFrozen = true;
            }
            return isFrozen;
        }
        public static void FreezeCheck(Unit hero, List<Unit> AllEnemiesFighting)
        {
            bool freeze = false;
            for (int index = 0; index < AllEnemiesFighting.Count; index++)
            {
                freeze = CalculateFreeze();
                if (freeze == false)
                {
                    EnemyCanAttack(hero, AllEnemiesFighting[index]);
                }
                else
                {
                    Console.WriteLine(AllEnemiesFighting[index].Name + " is frozen this turn!");
                }
            }
        }
        //////////////////////////////////Items//////////////////////////////////
        public static void ItemMenu(Unit person)
        {
            int option = ItemMenuDisplay(); ;
            switch (option)
            {
                case 1:
                    RestoreHealth(person);
                    break;
                case 2:
                    RestoreMagic(person);
                    break;
                default:
                    Console.WriteLine("Incorrect Input");
                    break;
            }
        }
        public static int ItemMenuDisplay()
        {
            Console.WriteLine("1 - Restore Health By 50");
            Console.WriteLine("2 - Restore Magic By 5");
            return Convert.ToInt32(Prompt("Which item will you use?"));
        }
        public static void RestoreHealth(Unit person)
        {
            if (person.Item > 0)
            {
                person.Item -= 1;
                person.BaseDefense += person.MaxDefense/2;
                if (person.BaseDefense > person.MaxDefense)
                {
                    person.BaseDefense = person.MaxDefense;
                }
                Console.WriteLine(person.Name + " heals himself!");
            }
            else
            {
                Console.WriteLine("You don't have anymore Items!");
            }
        }
        public static void RestoreMagic(Unit person)
        {
            if (person.Item > 0)
            {
                person.Item -= 1;
                person.Magic += 5;
                if (person.Magic > person.MaxMagic)
                {
                    person.Magic = person.MaxMagic;
                }
                Console.WriteLine(person.Name + " heals himself!");
            }
            else
            {
                Console.WriteLine("You don't have anymore Items!");
            }
        }
        /////////////////////////////////End Match check//////////////////////////
        public static int CheckEndGameList(Unit hero, List<Unit> AllEnemiesFighting, int option)
        {
            if (hero.BaseDefense <= 0)
            {
                Console.WriteLine("You Lost!");
                option = AllEnemiesFighting.Count + 1;
            }
            else if (AllEnemiesFighting.Count < 1)
            {
                Console.WriteLine("You Win!");
                option = AllEnemiesFighting.Count + 1;
            }
            return option;
        }
        ////////////////Simple prompt////////////
        public static string Prompt(string input)
        {
            Console.WriteLine(input);
            return Console.ReadLine();
        }
    }
}