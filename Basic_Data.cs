using System;
using System.Collections.Generic;
public abstract class Basic_Data
{
	protected bool finish_game = false;
	protected string read_user_choice = null;
	protected string read_user_name = null;
	protected int userWin = 0;
	protected int userLose = 0;
	protected int userDraw = 0;
	public abstract string CheckChoiceGame(string input, Dictionary<string,string> list);
	public abstract Dictionary<string,string> GenerateListAvailableWord();
	public abstract bool CheckName(string name);
	public abstract void Status();

}
