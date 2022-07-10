using System;
using System.Collections.Generic;
using System.Text;


    public interface Ivalidation
    {
        public Dictionary<string, string> GenerateListAvailableWord();
        public bool CheckName(string name);
        public bool WhetherNameContainsNumber(string name);
    }
