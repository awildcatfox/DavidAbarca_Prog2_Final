using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DavidAbarca_Prog2_Final
{
    public class Categories
    {
        string _name;
        List<Tasks> _tasks;

        public Categories(string name)
        {
            _name = name;
            _tasks = new List<Tasks>();

        }

        public string Name { get => _name; set => _name = value; }
        public List<Tasks> Tasks { get => _tasks; set => _tasks = value; }

        public void AddItem(Tasks item)
        {

            _tasks.Add(item);

        }

        public override string ToString()
        {
            return $"{_name}";
        }


    } // class
} // namespace
