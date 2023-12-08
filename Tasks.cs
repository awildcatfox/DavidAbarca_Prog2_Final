using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DavidAbarca_Prog2_Final
{
    public class Tasks
    {
        // Fields
        bool _complete;
        string _name;
        bool _importance;
        bool _time;
        string _description;

        public Tasks(bool complete, string name, bool importance, bool time, string description)
        {
            _complete = complete;
            _name = name;
            _importance = importance;
            _time = time;
            _description = description;
        }

        // properties
        public bool Complete { get => _complete; set => _complete = value; }
        public string Name { get => _name; set => _name = value; }
        public bool Importance { get => _importance; set => _importance = value; }
        public bool Time { get => _time; set => _time = value; }
        public string Description { get => _description; set => _description = value; }

        // Method
        public string DisplayInformation()
        {
            string fullDisplay = "";
            fullDisplay += $"Task Name: {_name}\n";
            fullDisplay += $"------------------\n";
            fullDisplay += $"Task completion: {_complete}\n";
            fullDisplay += $"Task importance: {_importance}\n";
            fullDisplay += $"Task description: {_description}\n";

            return fullDisplay;


        }









    }
}
