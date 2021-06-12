using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GalaxySearch
{
    public class Program
    {
        public static List<Galaxy> Galaxies = new List<Galaxy>();
        public static ObjectFactory ObjectFactory = new ObjectFactory(Program.Galaxies);
        public static SearchComponent SearchComponent = new SearchComponent(Program.Galaxies);

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            String command;
            bool quitNow = false;
            while (!quitNow)
            {
                command = Console.ReadLine();
                var commandArguments = command.Split(new char[2] {'[', ']'}).Where(it => it != " ").ToArray();
                var splitedMainCommand = commandArguments[0].Split(' ');
                switch (splitedMainCommand[0])
                {
                    case "add":
                        switch (splitedMainCommand[1])
                        {
                            case "galaxy":
                                var nameG = commandArguments[1];
                                var infoG = commandArguments[2].Split(' ').Where(it => it != String.Empty).ToArray();
                                var typeG = infoG[0];
                                var ageG = infoG[1];
                                Program.ObjectFactory.AddGalaxy(nameG, typeG, ageG);
                                break;
                            case "star":
                                var galaxyName = commandArguments[1];
                                var nameS = commandArguments[2];
                                var infoS = commandArguments[3].Split(' ').Where(it => it != String.Empty).ToArray();
                                var mass = Decimal.Parse(infoS[0]);
                                var size = Decimal.Parse(infoS[1]);
                                var temp = Int32.Parse(infoS[2]);
                                var luminosity = Decimal.Parse(infoS[3]);
                                Program.ObjectFactory.AddStar(galaxyName, nameS, mass, size, temp, luminosity);
                                break;
                            case "planet":
                                var starName = commandArguments[1];
                                var nameP = commandArguments[2];
                                var infoP = commandArguments[3].Split(' ').Where(it => it != String.Empty).ToArray();
                                var type = infoP[0];
                                var isSupportedLife = infoP[1];
                                Program.ObjectFactory.AddPlanet(starName, nameP, type, isSupportedLife == "yes" ? true : false);
                                break;
                            case "moon":
                                var planetName = commandArguments[1];
                                var nameM = commandArguments[2];
                                Program.ObjectFactory.AddMoon(planetName, nameM);
                                break;
                            default:
                                Console.WriteLine("None");
                                break;
                        }
                        break;
                    case "stats":
                        Console.WriteLine("--- Stats ---");
                        Console.Write(Program.GetStats());
                        Console.WriteLine("--- End of Stats ---");
                        break;
                    case "list":
                        switch (splitedMainCommand[1])
                        {
                            case "galaxies":
                                Console.WriteLine("--- List of all researched galaxies ---");
                                Console.WriteLine(Program.SearchComponent.GetGalaxies());
                                Console.WriteLine("--- End of galaxies list ---");
                                break;
                            case "stars":
                                Console.WriteLine("--- List of all researched stars ---");
                                Console.WriteLine(Program.SearchComponent.GetStars());
                                Console.WriteLine("--- End of stars list ---");
                                break;
                            case "planets":
                                Console.WriteLine("--- List of all researched planets ---");
                                Console.WriteLine(Program.SearchComponent.GetPlanets());
                                Console.WriteLine("--- End of planets list ---");
                                break;
                            case "moons":
                                Console.WriteLine("--- List of all researched moons ---");
                                Console.WriteLine(Program.SearchComponent.GetMoons());
                                Console.WriteLine("--- End of moons list ---");
                                break;
                            default:
                                Console.WriteLine("None");
                                break;
                        }
                        break;
                    case "print":
                        Program.PrintGalaxyInfo(commandArguments[1]);
                        break;
                    case "exit":
                        quitNow = true;
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("None");
                        break;
                }
            }
        }

        static String GetStats()
        {
            var stats = new StringBuilder();
            stats.AppendLine($"Galaxies: {Program.Galaxies.Count}");
            stats.AppendLine($"Stars: {Program.Galaxies.SelectMany(g => g.Stars).ToList().Count}");
            stats.AppendLine($"Planets: {Program.Galaxies.SelectMany(g => g.Stars).SelectMany(s => s.Planets).ToList().Count}");
            stats.AppendLine($"Moons: {Program.Galaxies.SelectMany(g => g.Stars).SelectMany(s => s.Planets).SelectMany(p => p.Moons).ToList().Count}");

            return stats.ToString();
        }

        static void PrintGalaxyInfo(String name)
        {
            var info = new StringBuilder();
            var galaxy = Program.Galaxies.FirstOrDefault(g => g.Name == name);
            var printComponent = new PrintComponent(Program.Galaxies);

            info.AppendLine($"Type: {galaxy.Type}");
            info.AppendLine($"Age: {galaxy.Age}");
            info.AppendLine("Stars:");
            foreach (var star in galaxy.Stars)
            {
                info.Append(printComponent.PrintStar(star));
            }
            Console.WriteLine($"--- Data for {name} galaxy ---");
            var text = info.ToString();
            var separate = text.Split(new char[2] { '(', ')' });
            for (int i = 0; i < separate.Length; i++)
            {
                if (i%2==0)
                {
                    Console.Write(separate[i]);
                }
                else
                {
                    Console.Write("(");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(separate[i]);
                    Console.ResetColor();
                    Console.Write(")");
                }
            }
            Console.WriteLine($"--- End of data for {name} galaxy ---");
        }
    }
}