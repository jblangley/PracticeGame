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
                    GruntArmyLoop();
                    break;
                case 4:
                    FireElementalLoop();
                    break;
                case 5:
                    IceElementalLoop();
                    break;
                case 6:
                    BossLoop();
                    break;
                case 7:
                    ArmyLoop();
                    break;
                case 8:
                    RandomArmyLoop();
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
            Console.WriteLine("3 - Grunt Squad");
            Console.WriteLine("4 - Fire Elemental");
            Console.WriteLine("5 - Ice Elemental");
            Console.WriteLine("6 - Boss");
            Console.WriteLine("7 - Army Creation");
            Console.WriteLine("8 - Random Match");
        }
        ////////////////////////////////////////////Creates Units/////////////////////////////////////////////////////
        public static Unit StartingSetupHero()
        {
            Unit Hero = new Unit();
            Hero.BaseAttack = 12;
            Hero.BaseDefense = 150;
            Hero.MaxDefense = 150;
            Hero.Item = 4;
            Hero.Magic = 12;
            Hero.FireBonus = 13;
            Hero.IceBonus = 3;
            Hero.MaxMagic = 12;
            Hero.Name = "Hiro";
            return Hero;
        }
        public static Unit StartingSetupGrunt()
        {
            Unit Grunt = new Unit();
            Grunt.BaseAttack = 5;
            Grunt.BaseDefense = 50;
            Grunt.Name = "Grunt";
            return Grunt;
        }
        public static Unit StartingSetupWolf()
        {
            Unit Wolf = new Unit();
            Wolf.BaseAttack = 15;
            Wolf.BaseDefense = 80;
            Wolf.Name = "Wolf";
            return Wolf;
        }
        public static Unit StartingSetupFireElemental()
        {
            Unit Elemental = new Unit();
            Elemental.BaseAttack = 1;
            Elemental.BaseDefense = 200;
            Elemental.MaxDefense = 200;
            Elemental.Name = "Fire Elemental";
            Elemental.Magic = 20;
            Elemental.MaxMagic = 30;
            Elemental.FireBonus = 15;
            Elemental.Weakness = "ice";
            Elemental.Strength = "fire";
            return Elemental;
        }
        public static Unit StartingSetupIceElemental()
        {
            Unit Elemental = new Unit();
            Elemental.BaseAttack = 1;
            Elemental.BaseDefense = 200;
            Elemental.MaxDefense = 200;
            Elemental.Name = "Ice Elemental";
            Elemental.Magic = 20;
            Elemental.MaxMagic = 30;
            Elemental.FireBonus = 15;
            Elemental.Weakness = "fire";
            Elemental.Strength = "ice";
            return Elemental;
        }
        public static Unit StartingSetupBoss()
        {
            Unit Boss = new Unit();
            Boss.BaseAttack = 20;
            Boss.BaseDefense = 200;
            Boss.MaxDefense = 200;
            Boss.Name = "Boss";
            Boss.Magic = 15;
            Boss.FireBonus = 15;
            Boss.MaxMagic = 15;
            Boss.Strength = "fire";
            Boss.Item = 1;
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
        public static void FireElementalLoop()
        {
            Unit hero = StartingSetupHero();
            Unit grunt = StartingSetupFireElemental();
            List<Unit> AllEnemiesFighting = new List<Unit>();
            AllEnemiesFighting.Add(grunt);
            MatchMultiplesLoop(hero, AllEnemiesFighting);
        }
        public static void IceElementalLoop()
        {
            Unit hero = StartingSetupHero();
            Unit grunt = StartingSetupIceElemental();
            List<Unit> AllEnemiesFighting = new List<Unit>();
            AllEnemiesFighting.Add(grunt);
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
            while (loop < 7)
            {
                loop = AddEnemies(AllEnemiesFighting);
            }
        }
        public static int AddEnemies(List<Unit> AllEnemiesFighting)
        {
            DisplayUnitMenu(AllEnemiesFighting);
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
                     StartingSetupGruntSquad(AllEnemiesFighting);                   
                    break;
                case 4:
                    AllEnemiesFighting.Add(StartingSetupFireElemental());
                    break;
                case 5:
                    AllEnemiesFighting.Add(StartingSetupIceElemental());
                    break;
                case 6:
                    AllEnemiesFighting.Add(StartingSetupBoss());
                    break;
                case 7:
                    break;
                default:
                    break;
            }
            return choice;
        }
        public static void DisplayUnitMenu(List<Unit> AllEnemiesFighting)
        {
            Console.Clear();
            foreach (Unit enemy in AllEnemiesFighting)
            {
                Console.WriteLine(enemy.Name);
            }
            Console.WriteLine();
            Console.WriteLine("1 - Grunt");
            Console.WriteLine("2 - Wolf");
            Console.WriteLine("3 - Grunt Squad");
            Console.WriteLine("4 - Fire Elemental");
            Console.WriteLine("5 - Ice Elemental");
            Console.WriteLine("6 - Boss");
            Console.WriteLine("7 - Begin Battle");
        }
        public static void RandomArmyLoop()
        {
            Unit hero = StartingSetupHero();
            List<Unit> AllEnemiesFighting = new List<Unit>();
            AddRandomEnemyLoop(AllEnemiesFighting);
            MatchMultiplesLoop(hero, AllEnemiesFighting);
        }
        public static void AddRandomEnemyLoop(List<Unit> AllEnemiesFighting)
        {
            int loop = 0;
            while (loop < 100)
            {
                loop += RandomAddEnemies(AllEnemiesFighting);
            }
        }
        public static int RandomAddEnemies(List<Unit> AllEnemiesFighting)
        {
            int choice = random.Next(1, 51);
            if (choice % 10 == 0)
            {
                AllEnemiesFighting.Add(StartingSetupBoss());
                choice += 30;
            }
            else if (choice %  7 == 0)
            {
                AllEnemiesFighting.Add(StartingSetupFireElemental());
                choice += 20;
            }
            else if (choice % 4 == 0)
            {
                AllEnemiesFighting.Add(StartingSetupWolf());
                choice += 10;
            }
            else
            {
                AllEnemiesFighting.Add(StartingSetupGrunt());
            }
            return choice;
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
            AllEnemiesAttack(hero, AllEnemiesFighting, ailment, option);
            AllEnemiesFighting.RemoveAll(item => item.BaseDefense <= 0);
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
        public static void AllEnemiesAttack(Unit hero, List<Unit> AllEnemiesFighting, string ailment, int option)
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
            if (grunt.Item > 0 & grunt.BaseDefense < grunt.MaxDefense / 4)
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
                choose = random.Next(1, 60);
            }
            else if (grunt.Magic<16)
            {
                choose = random.Next(1, 101);
            }
            else
            {
                choose = 70;
            }
            return choose;
        }
        public static void EnemyAttack(int choose, Unit hero, Unit grunt)
        {
            if (choose >= 60)
            {
                EnemyMagicChoice(hero,grunt);
            }
            else
            {
                hero.BaseDefense -= grunt.BaseAttack;
                Console.WriteLine(grunt.Name + " did " + grunt.BaseAttack + " damage to " + hero.Name);
            }
        }
        public static void EnemyMagicChoice(Unit hero, Unit grunt)
        {
            switch (grunt.Strength)
            {
                case "ice":
                    Ice(grunt, hero);
                    break;
                case "fire":
                    Fire(grunt, hero);
                    break;
                default:
                    break;
            }
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
        public static string Fire(Unit attacker, Unit defender)
        {
            string ailment = "";
            if (attacker.Magic > 0)
            {
                ailment = "fire";
                AttackEffectiveness(attacker, defender, ailment);
                BurnCheck(defender);
            }
            else
            {
                Console.WriteLine("You don't have enough magic!");
            }
            return ailment;
        }
        public static string Ice(Unit attacker, Unit defender)
        {
            string ailment = "";
            if (attacker.Magic > 0)
            {
                ailment = "ice";
                AttackEffectiveness(attacker, defender, ailment);
            }
            else
            {
                Console.WriteLine("You don't have enough magic!");
            }
            return ailment;
        }
        private static void AttackEffectiveness(Unit attacker, Unit defender, string ailment)
        {
            int bonus = ChooseBonus(attacker, ailment);
            if (defender.Weakness == ailment)
            {
                defender.BaseDefense -= ((attacker.MaxMagic + bonus) * 3);
                Console.WriteLine("The attack was effective! " + attacker.Name + " did " + ((attacker.MaxMagic + bonus) * 3) + " damage to " + defender.Name + "!");
                attacker.Magic -= 1;
            }
            else if (defender.Strength == ailment)
            {
                defender.BaseDefense += (defender.MaxDefense / 4);
                Console.WriteLine("The attack was ineffective! " + defender.Name + " gained " + (defender.MaxDefense / 4) + " health!");
                attacker.Magic -= 1;
            }
            else
            {
                defender.BaseDefense -= (attacker.MaxMagic+bonus);
                Console.WriteLine(attacker.Name + " did " + (attacker.MaxMagic+bonus) + " damage to " + defender.Name);
                attacker.Magic -= 1;
            }
        }
        public static int ChooseBonus(Unit attacker , string ailment)
        {
            int bonus = 0;
            switch (ailment)
            {
                case "fire":
                    bonus = attacker.FireBonus;
                    break;
                case "ice":
                    bonus = attacker.IceBonus;
                    break;
                default:
                    break;
            }
            return bonus;
        }
        public static void BurnCheck(Unit defender)
        {
                bool burn = false;
                burn = CalculateBurn(defender);
                if (burn == true)
                {
                    defender.BaseDefense -= 15;
                    Console.WriteLine(defender.Name + " is burned this turn! 15 extra damage dealt");
                }
        }
        public static bool CalculateBurn(Unit defender)
        {
            bool isBurned = false;
            int generate = random.Next(1, 101);
            if (defender.Weakness == "fire" && generate <= 85)
            {
                isBurned = true;
            }
            else if (defender.Strength == "fire" && generate <= 1)
            {
                isBurned = true;
            }
            else if (generate <= 30)
            {
                isBurned  = true;
            }
            return isBurned;
        }
        public static bool CalculateFreeze(Unit defender)
        {
            bool isFrozen = false;
            int generate = random.Next(1, 101);
            if (defender.Weakness == "ice" && generate <= 80)
            {
                isFrozen = true;
            }
            else if (defender.Strength == "ice" && generate <= 1)
            {
                isFrozen = true;
            }
            else if (generate <= 40)
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
                freeze = CalculateFreeze(AllEnemiesFighting[index]);
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
                person.BaseDefense += person.MaxDefense / 2;
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