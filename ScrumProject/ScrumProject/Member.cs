using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScrumProject
{
    class Member
    {
        string _name;
        string _surname;
        int _number;
        int _idNumber;

        public string Name
        {
            get { return _name; }
            set
            {
                if (value == null || value == "")
                {
                    throw new ArgumentException();
                }
                _name = value;
            }
        }

        public string Surname
        {
            get { return _surname; }
            set
            {
                if (value == null || value == "")
                {
                    throw new ArgumentException();
                }
                _surname = value;
            }
        }

        public int Number
        {
            get { return _number; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentException();
                }
                _number = value;
            }
        }

        public int IdNumber
        {
            get { return _idNumber; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentException();
                }
                _idNumber = value;
            }
        }

    }
}
