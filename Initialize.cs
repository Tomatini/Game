using System;
using System.Collections.Generic;

public class Initialize : Basic_Data
{
    bool isNumber = false;
    int actualRound = 0;
    Choices[] choices= new Choices[3];
    
    public Initialize()
	{
        //CreateTableChoices();
        GameLoop();
    }
    public void CreateTableChoices()
    {
        Choices Rock = new Choices("Rock");
        Choices Paper = new Choices("Paper");
        Choices Shears = new Choices("Shears");
        choices[0] = Rock;
        choices[1] = Paper;
        choices[2] = Shears;
        Console.WriteLine(Rock.EqualWithOther(Paper));
    }
    public void  GameLoop()
    {
        while (finish_game == false)
        {
            Console.Clear();
            Console.WriteLine("Stone, paper or shears? \nPlease write your name:");

            read_user_name = Console.ReadLine();
            CheckName(read_user_name);

            while (finish_game == false)
            {
                
                Console.WriteLine("Your choice :\nStone, paper or shears?");
                read_user_choice = Console.ReadLine();
                CheckChoiceGame(read_user_choice, GenerateListAvailableWord());
                Console.Clear();
                Console.WriteLine("Your choice:\t Computer choice: \n  " + read_user_choice+"\t\t   computer choice");
            }
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
    public override string CheckChoiceGame(string inputUser, Dictionary<string,string>list)
    {
        string check = "";
        int loop = 0;
        inputUser = inputUser.ToLower();
        while (check =="")
        {
            if (loop == 1)
            {
                Console.Clear();
                Console.WriteLine("Wrong word. Try again.\nYour choice :\nStone, paper or shears?");
                inputUser = Console.ReadLine().ToLower();
            }
            foreach (KeyValuePair<string, string> word in list)
            {
                if(inputUser == "status")
                {
                    Status();
                }
                else if (word.Key == inputUser)
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

    public override Dictionary<string,string> GenerateListAvailableWord()
    {
        Dictionary<string, string> ExampleList = new Dictionary<string, string>() ;// { "stone", "kamien" , "paper","status" }; 
        ExampleList.Add("papier", "Paper");
        ExampleList.Add("paper", "Paper");
        ExampleList.Add("stone", "Rock");
        ExampleList.Add("status","status");
        ExampleList.Add("kamien", "Rock");
        ExampleList.Add("shears", "Shears");
        ExampleList.Add("nozyce", "Shears");

        return ExampleList;
    }

    public override void Status()
    {
        Console.WriteLine(actualRound);
        throw new NotImplementedException();
    }
}
