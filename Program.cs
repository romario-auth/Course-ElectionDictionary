using System;
using System.Collections.Generic;
using System.IO;


namespace Election
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter file full path:");
            string path = Console.ReadLine();

            Dictionary<string, int> election = new Dictionary<string, int>();

            try{
                using (StreamReader file = File.OpenText(path))
                {
                    while(!file.EndOfStream)
                    {
                        string[] line = file.ReadLine().Split(",");
                        string name = line[0].ToString();
                        int wishes = int.Parse(line[1]);

                        if(election.ContainsKey(name))
                        {
                            election[name] += wishes;
                        } else
                        {
                            election[name] = wishes;
                        }
                    }
                    
                }

                foreach(KeyValuePair<string, int> item in election)
                {
                    Console.WriteLine(item.Key + ": " + item.Value);
                }

            }
            catch(IOException e)
            {
                Console.WriteLine("Error" + e.Message);
            }

        }
    }
}
