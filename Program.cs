using System.Data;
using System.Text.RegularExpressions;
class AdventOfCodeDay3
{
    string instructions = @"..\..\..\TEXTFILE\LIST.txt";
    string[] readInstructions = [];
    List<string> readInstructions2 = [];
    List<int> readInstructions3 = [];

    static void Main()
    {

        AdventOfCodeDay3 program = new AdventOfCodeDay3();
        int finalValues = 0;
        program.readInstructions = File.ReadAllLines(program.instructions);
        program.FindInstructions();
        for (int i = 0; i < program.readInstructions3.Count; i++)
        {
            finalValues += program.readInstructions3[i];
        }
        Console.WriteLine(finalValues);
    }
    void FindInstructions()
    {
        bool acceptingMul = true;
        readInstructions2 = new List<string>();
        string instruction;
        Regex regex = new Regex(@"mul\([0-9]{1,3},[0-9]{1,3}\)|do\(\)|don't\(\)");
        for (int i = 0; i < readInstructions.Length; i++)
        {
            foreach (Match match in regex.Matches(readInstructions[i]))
            {
                Console.WriteLine(match.Value);
                if (match.Value.Contains("do()"))
                {
                    acceptingMul = true;
                }
                else if (match.Value.Contains("don't()"))
                {
                    acceptingMul = false;
                }
                else if (acceptingMul)
                {
                    instruction = Regex.Replace(match.Value, @"mul\(", "");
                    readInstructions2.Add(Regex.Replace(instruction, @"\)", ""));
                }
            }
        }
        
        for (int i = 0; i < readInstructions2.Count; i++)
        {
                string[] splitInstructions = readInstructions2[i].Split(',');
                readInstructions3.Add(Int32.Parse(splitInstructions[0]) * Int32.Parse(splitInstructions[1]));
        }
    }
}