using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = @"C:\Demos\Test.txt";

            ////string[] lines = File.ReadAllLines(filePath);
            //List<string> lines = File.ReadAllLines(filePath).ToList();

            //foreach(string line in lines)
            //{
            //    Console.WriteLine(line);
            //}

            //lines.Add("Sue,Storm,www.stormy.com");

            //File.WriteAllLines(filePath, lines);

            List<Person> people = new List<Person>();

            List<string> lines = File.ReadAllLines(filePath).ToList();

            foreach (var line in lines)
            {
                string[] entries = line.Split(",");

                if(entries.Length != 3)
                {
                    Console.WriteLine("An Entry is not valid");
                    continue;
                }

                Person newPerson = new Person();

                newPerson.FirstName = entries[0];
                newPerson.LastName = entries[1];
                newPerson.Url = entries[2];

                people.Add(newPerson);

                //people.Add(new Person { FirstName = entries[0], LastName = entries[1], Url = entries[2] });
            }

            foreach(var person in people)
            {
                Console.WriteLine($"{person.FirstName} {person.LastName}: {person.Url}");
            }

            people.Add(new Person { FirstName = "Greg", LastName = "Jones", Url = "https://github.com/JoyfulReaper" });

            List<string> output = new List<string>();

            foreach(var person in people)
            {
                output.Add($"{person.FirstName},{person.LastName},{person.Url}");
            }

            File.WriteAllLines(filePath, output);
        }
    }
}
