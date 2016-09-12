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
        public static void EnemyChoice()
        {
            DisplayUnitMenu();
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
                default:
                    break;
            }
        }
        public static void DisplayUnitMenu()
        {
            Console.WriteLine("1 - Grunt");
            Console.WriteLine("2 - Wolf");
            Console.WriteLine("3 - Boss");
            Console.WriteLine("4 - Grunt Army");
        }
        public static Unit StartingSetupHero()
        {
            Unit Hero = new Unit();
            Hero.BaseAttack = 8;
            Hero.BaseDefense = 100;
            Hero.Item = 3;
            Hero.Magic = 10;
            Hero.Name = "Hiro";
            return Hero;
        }
        public static Unit StartingSetupGrunt()
        {
            Unit Grunt = new Unit();
            Grunt.BaseAttack = 5;
            Grunt.BaseDefense = 8;
            Grunt.Name = "Grunt";
            return Grunt;
        }
        public static void GruntLoop()
        {
            Unit hero = StartingSetupHero();
            Unit grunt = StartingSetupGrunt();
            int loop = 0;
            while (loop < 5)
            {
                loop = Match(hero, grunt);
            }
        }
        public static Unit StartingSetupWolf()
        {
            Unit Wolf = new Unit();
            Wolf.BaseAttack = 15;
            Wolf.BaseDefense = 75;
            Wolf.Name = "Wolf";
            return Wolf;
        }
        public static void WolfLoop()
        {
            Unit hero = StartingSetupHero();
            Unit grunt = StartingSetupWolf();
            int loop = 0;
            while (loop < 5)
            {
                loop = Match(hero, grunt);
            }
        }
        public static Unit StartingSetupBoss()
        {
            Unit Boss = new Unit();
            Boss.BaseAttack = 15;
            Boss.BaseDefense = 200;
            Boss.Name = "Boss";
            Boss.Magic = 15;
            return Boss;
        }
        public static void BossLoop()
        {
            Unit hero = StartingSetupHero();
            Unit grunt = StartingSetupBoss();
            int loop = 0;
            while (loop < 5)
            {
                loop = Match(hero, grunt);
            }
        }

        public static void GruntArmyLoop()
        {//Make it easy to add enemies to that list to fight
            Unit hero = StartingSetupHero();
            List<Unit> AllEnemiesFighting = new List<Unit>();
            AllEnemiesFighting.Add(StartingSetupGrunt());
            AllEnemiesFighting.Add(StartingSetupGrunt());
            AllEnemiesFighting.Add(StartingSetupGrunt());
            int loop = 0;
            while (loop < AllEnemiesFighting.Count)
            {
                loop = MatchMultiples(hero, AllEnemiesFighting);
                loop = CheckEndGameList(hero, AllEnemiesFighting, loop);
            }
        }
        public static int Match(Unit hero, Unit grunt)
        {
            bool frozen = false;
            int option = DisplayStatsAndOptions(hero,grunt);
            switch (option)
            {
                case 1:
                    grunt.BaseDefense -= hero.BaseAttack;
                    Console.WriteLine(hero.Name+" did "+hero.BaseAttack+" damage to " + grunt.Name);
                    break;
                case 2:
                    Fire(hero,grunt);
                    break;
                case 3:
                    frozen = Ice(hero, grunt);
                    break;
                case 4:
                    Heal(hero);
                    break;
                case 5:
                    break;
                default:
                    Console.WriteLine("Incorrect input");
                    break;
            }
            CheckIfEnemyAttacks(hero, grunt, frozen);
            option = CheckEndGame(hero, grunt, option);
            Console.ReadKey();
            return option;
        }
        public static int MatchMultiples(Unit hero, List<Unit> AllEnemiesFighting)
        {
            int option = DisplayChooseWhichToAttack(hero, AllEnemiesFighting)-1;
            if (option<AllEnemiesFighting.Count)
            {
            Match(hero, AllEnemiesFighting[option]);
            }
            AllEnemiesFighting.RemoveAll(item => item.BaseDefense <= 0);
            return option;
        }
        public static int DisplayChooseWhichToAttack(Unit hero, List<Unit> AllEnemiesFighting)
        {
            int count = 1;
            Console.Clear();
            Console.WriteLine("Your Health Left: "+hero.BaseDefense);
            for (int index = 0; index < AllEnemiesFighting.Count; index++)
            {
                count++;
                Console.WriteLine(index+1 + " - " + AllEnemiesFighting[index].Name + " has " + AllEnemiesFighting[index].BaseDefense + " Health Left");
            }
            Console.WriteLine(count + " - To Exit");
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
            int choice = SetAttackCoice(grunt);
            EnemyAttack(choice, hero, grunt);
        }
        public static int SetAttackCoice(Unit grunt)
        {
            Random attack = new Random();
            int choose = 0;
            if (grunt.Magic < 9)
            {
                choose = attack.Next(1, 65);
            }
            else
            {
                choose = attack.Next(1, 101);
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
                Console.WriteLine(grunt.Name+" did "+ grunt.BaseAttack+" damage to "+ hero.Name);
            }
            return choose;
        }
        public static int DisplayStatsAndOptions(Unit hero, Unit them)
        {
            Console.Clear();
            Console.WriteLine(hero.Name + "!");
            Console.WriteLine("Health: " + hero.BaseDefense);
            Console.WriteLine("Spells Left: " + hero.Magic);
            Console.WriteLine("Potions Left: "+ hero.Item);
            Console.WriteLine("1 - Attack\t2 - Fire\t3 - Ice\n4 - Heal\t5 - Exit\n");
            Console.WriteLine(them.Name+"!");
            Console.WriteLine("Health: " + them.BaseDefense);
            return Convert.ToInt32(Prompt("What are you going to do?"));
        }
        public static void Fire(Unit attacker, Unit defender)
        {
            if (attacker.Magic > 0)
            {
                defender.BaseDefense -= attacker.Magic*2;
                Console.WriteLine(attacker.Name+"'s fire did "+attacker.Magic*2+" to "+defender.Name);
                attacker.Magic -= 1;
            }
            else
            {
                Console.WriteLine("You don't have enough magic!");
            }
        }
        public static bool Ice(Unit attacker, Unit defender)
        {
            bool freeze = false;
            if (attacker.Magic > 0)
            {
                defender.BaseDefense -= 12;
                Console.WriteLine(attacker.Name + " did 12 damage to " + defender.Name);
                attacker.Magic -= 1;
                freeze = CalculateFreeze();
            }
            else
            {
                Console.WriteLine("You don't have enough magic!");
            }
            return freeze;
        }
        public static bool CalculateFreeze()
        {
            Random freeze = new Random();
            bool isFrozen = false;
            int generate = freeze.Next(1,101);
            if (generate>=70)
            {
                isFrozen = true;
            }
            return isFrozen;
        }
        public static void Heal(Unit person)
        {
            if (person.Item > 0)
            {
                person.Item -= 1;
                person.BaseDefense = 100;
                Console.WriteLine(person.Name+" heals himself for 100");
            }
            else
            {
                Console.WriteLine("You don't have anymore potions!");
            }
        }
        public static int CheckEndGame(Unit hero, Unit grunt, int option)
        {
            if (hero.BaseDefense <= 0)
            {
                Console.WriteLine("You Lost!");
                option = 5;
            }
            else if(grunt.BaseDefense<=0)
            {
                Console.WriteLine("You Win!");
                option = 5;
            }
            return option;
        }
        public static int CheckEndGameList(Unit hero, List<Unit> AllEnemiesFighting, int option)
        {
            if (hero.BaseDefense <= 0)
            {
                Console.WriteLine("You Lost!");
                option = 5;
            }
            else if (AllEnemiesFighting.Count < 1)
            {
                Console.WriteLine("You Win!");
                option = 5;
            }
            return option;
        }
        public static string Prompt(string input)
        {
            Console.WriteLine(input);
            return Console.ReadLine();
        }
    }
}
