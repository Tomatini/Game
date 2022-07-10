using System;
using System.Collections.Generic;
using System.Text;

    public class Validation : Ivalidation
    {
        public string CheckNameWhile(string name )
        {
        while(CheckName(name) == false)
         {
            Console.WriteLine("Wrong name " + name + ".\nName must be not empty, max 20 char and no have number.\nPlease write your name:");
            name = Console.ReadLine();
            WhetherNameContainsNumber(name);
         }
        return name;
        }
        public bool CheckName(string name)
        {
            if(string.IsNullOrEmpty(name) || WhetherNameContainsNumber(name)==true || name.Length > 20)
            {
            return false;
            }
        return true;
        }
        public bool WhetherNameContainsNumber(string name)
        {

            for (int i = 0; i < name.Length; i++)
            {
                if (char.IsDigit(name[i]))
                {
                    return true;
                    //break;
                }
            }
        return false;
        }
        public Dictionary<string, string> GenerateListAvailableWord()
        {
        Dictionary<string, string> ExampleList = new Dictionary<string, string>();
        ExampleList.Add("papier", "Paper");
        ExampleList.Add("paper", "Paper");
        ExampleList.Add("rock", "Rock");
        // ExampleList.Add("status","status");
        ExampleList.Add("kamien", "Rock");
        ExampleList.Add("shears", "Shears");
        ExampleList.Add("nozyce", "Shears");

        return ExampleList;
    }
    }

