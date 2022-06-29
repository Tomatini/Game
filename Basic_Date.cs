using System;
using System.Collections.Generic;
public abstract class Basic_Date
{
	protected bool finish_game = false;
	protected string read_user_choice = null;
	protected string read_user_name = null;
	public abstract string CheckChoiceGame(string input, List<string> list);
	public abstract List<string> GenerateListAvailableWord();
	public abstract bool CheckName(string name);
}
