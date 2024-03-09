

using System.Runtime.CompilerServices;
using _03.Raiding.Core.Interface;
using _03.Raiding.IO.Interfaces;
using _03.Raiding.Modules;

namespace _03.Raiding.Core
{
    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;
        private readonly List<BaseHero> heros;  
     
        public Engine(IReader reader, IWriter writer)
        {
            this.reader = reader;
            this.writer = writer;
            heros = new List<BaseHero>();
        }
        public void Run()
        {


                // business Logic
            int numberHero = int.Parse(reader.ReadLine());

            for (int i = 0; i < numberHero; i++)
            {

               string heroName = reader.ReadLine();
               string heroType = reader.ReadLine();


                switch (heroType)
                {
                    case "Druid":
                        heros.Add(new Druid(heroName));
                        break;
                    case "Paladin":
                        heros.Add(new Paladin(heroName));
                        break;
                    case "Rogue":
                        heros.Add(new Rogue(heroName));
                        break;
                    case "Warrior":
                        heros.Add(new Warrior(heroName));
                        break;
                    default:
                        writer.WriteLine("Invalid hero!");
                        i--;
                        break;
                }
            }

            int bossPower = int.Parse(reader.ReadLine());
            int sumPower = heros.Sum(h => h.Power);

            foreach (var hero in heros)
            {
                writer.WriteLine(hero.CastAbility() );
            }

            if (sumPower >= bossPower)
            {
               writer.WriteLine("Victory!");
            }
            else
            {
                writer.WriteLine("Defeat...");
            }
            
        }
    }
}

