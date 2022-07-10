using System;
using System.Collections.Generic;
using System.Text;

    public class GenerateChoice : IGenerateChoice
{
    IChoice _choice;
    string _name; 

    public GenerateChoice(IChoice choice,string name)
    {
        this._choice = choice;
        this._name = name;
    }
    public string GetName()
    {
        return _name;
    }

    public void SetName(string name)
    {
        _name = name;
    }

   
}

