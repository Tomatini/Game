using System;

public class Choices
{
	public string choice { get; set; }
	public Choices(string choice)
	{
		this.choice = choice;
	}
    public int EqualWithOther(Choices otherObj)
    {
        if(this.choice == otherObj.choice)
        {
            return 0;
        }else
        {
            switch (this.choice)
            {
                case "Rock":
                    if(otherObj.choice== "Paper") { return -1; }
                    else if (otherObj.choice == "Shears") { return 1; }
                    break;
                case "Paper":
                    if (otherObj.choice == "Rock") { return 1; }
                    else if (otherObj.choice == "Shears") { return -1; }
                    break;
                case "Shears":
                    if (otherObj.choice == "Rock") { return -1; }
                    else if (otherObj.choice == "Paper") { return 1; }
                    break;
            }
        }
                return 0;
    }
}
