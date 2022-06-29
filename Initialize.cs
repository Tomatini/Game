using System;
using System.Collections.Generic;

public class Initialize : Basic_Data
{
    bool isNumber = false;
    Choices[] choices = new Choices[4];
    string computerChoice = "";
    int random = 0;

    public Initialize()
    {
        CreateTableChoices();
        GameLoop();
    }
    public void CreateTableChoices()
    {
        Choices Rock = new Choices("Rock");
        Choices Paper = new Choices("Paper");
        Choices Shears = new Choices("Shears");
        Choices PlayerChoice = new Choices("");
        choices[0] = Rock;
        choices[1] = Paper;
        choices[2] = Shears;
        choices[3] = PlayerChoice;
    }
    public void GameLoop()
    {
        while (finish_game == false)
        {
            Console.Clear();
            Console.WriteLine("Rock, paper or shears? \nPlease write your name:");

            read_user_name = Console.ReadLine();
            CheckName(read_user_name);

            while (finish_game == false)
            {
                Console.WriteLine(read_user_name + " choice :\nRock, paper or shears?");
                read_user_choice = Console.ReadLine();
                CheckStatus();
             
                CheckChoiceGame(read_user_choice, GenerateListAvailableWord());
                Console.Clear();
                CheckStatus();
               
                Random randomNumber = new Random();
                random = randomNumber.Next(0, 3);
                computerChoice = choices[random].choice;
                Console.WriteLine(read_user_name + " choice:\t Computer choice: \n  " + choices[3].choice + "\t\t   " + computerChoice + "\n");
                SumResults(choices[3].EqualWithOther(choices[random]));

            }
            finish_game = true;
        }

    }
    private void SumResults(int result)
    {
        switch (result)
        {
            case -1: userLose += 1;
                break;
            case 0: userDraw += 1;
                break;
            case 1: userWin += 1;
                break;
        }
    }
    public override bool CheckName(string name)
    {
        WhetherNameContainsNumber(name);
        while (String.IsNullOrEmpty(name) || isNumber == true || name.Length > 20)
        {
            isNumber = false;
            Console.WriteLine("Wrong name " + read_user_name + ".\nName must be not empty, max 20 char and no have number.\nPlease write your name:");
            name = Console.ReadLine();
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
    public override string CheckChoiceGame(string inputUser, Dictionary<string, string> list)
    {
        string check = "";
        int loop = 0;
        inputUser = inputUser.ToLower();     //all word char to lower
        while (check == "")
        {
            if (loop == 1)
            {
                Console.Clear();
                Console.WriteLine("Wrong word. Try again.\n"+ read_user_name + " Your choice :\nRock, paper or shears?");
                inputUser = Console.ReadLine().ToLower();
                read_user_choice = inputUser;
            }
            foreach (KeyValuePair<string, string> word in list)
            {
                if (inputUser == "status")
                {
                    Status();
                    check = "status";
                    break;
                }
                else if (inputUser.Length <= 2)     //check word with one char
                {
                    char[] wordKeyChar = word.Key.ToCharArray();
                    char[] inputUserChar = inputUser.ToCharArray();

                    if (wordKeyChar[0] == inputUserChar[0])
                    {
                        check = inputUser;
                        read_user_choice = check;
                        choices[3].choice = word.Value;
                        break;
                    }

                }
                else if (inputUser.Length > 2 && word.Key == inputUser)  //check all word and set player choice
                {
                    Console.Clear();
                    check = inputUser;
                    read_user_choice = check;
                    choices[3].choice = word.Value;
                    break;
                }
                else
                {
                    check = "";
                }

            }
            loop = 1;

        }
        return check;
    }

    public override Dictionary<string, string> GenerateListAvailableWord()
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
    private void CheckStatus()
    {
        if (read_user_choice == "status")
        {
            Status();
            Console.WriteLine(read_user_name + " choice :\nRock, paper or shears?");
            read_user_choice = Console.ReadLine();
        }
    }
    public override void Status()
    {
        Console.WriteLine("Statistics: \tWIn:\tLose:\tDraw:\n" +read_user_name+"\t\t"+userWin+"\t"+userLose+"\t"+ userDraw);
    }
}
