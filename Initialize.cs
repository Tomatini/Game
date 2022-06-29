using System;
using System.Collections.Generic;

public class Initialize : Basic_Date
{
    bool isNumber = false;

    public Initialize()
	{
        GameLoop();
	}

    public void  GameLoop()
    {
        while (finish_game == false)
        {
            Console.Clear();
            Console.WriteLine("Stone, paper or shears? \nPlease write your name:");

            read_user_name = Console.ReadLine();
            CheckName(read_user_name);

            Console.Clear();
            Console.WriteLine("Your choice :\nStone, paper or shears?");
            read_user_choice = Console.ReadLine();
            read_user_choice=CheckChoiceGame(read_user_choice,GenerateListAvailableWord());

            Console.WriteLine("Your choice: "+read_user_choice);
            finish_game = true;
        }

    }
    public override bool CheckName(string name)
    {
        WhetherNameContainsNumber(name);
        while (String.IsNullOrEmpty(name) || isNumber == true || name.Length >20 )
        {
            isNumber = false;
            Console.WriteLine("Wrong name.\nName must be not empty, max 20 char and no have number.\nPlease write your name:");
            name =Console.ReadLine();
            WhetherNameContainsNumber(name);
        }
        read_user_name = name;
        
        return true;
    }
    public void WhetherNameContainsNumber(string name)
    {

        for (int i = 0; i < name.Length; i++)
        {
            if (char.IsDigit(name[i]))
            {
                isNumber = true;
                break;
            }
        }
    }
    public override string CheckChoiceGame(string inputUser, List<string>list)
    {
        string check = "";
        int loop = 0;
        while (check =="")
        {
            if (loop == 1)
            {
                Console.Clear();
                Console.WriteLine("Wrong word. Try again.\nYour choice :\nStone, paper or shears?");
                inputUser = Console.ReadLine();
            }
            foreach (string word in list)
            {
                if (word == inputUser)
                {
                    Console.Clear();
                    check = inputUser;
                    break;
                }
                else
                {
                    //return check = "";
                }
            }
            loop = 1;
           // return check;
        }
        return check;
    }

    public override List<string> GenerateListAvailableWord()
    {
        List<string> ExampleList= new List<string> { "stone", "kamien" , "paper","status" }; 
        ExampleList.Add("papier");
        ExampleList.Add("shears");
        ExampleList.Add("nozyce");

        return ExampleList;
    }

}
