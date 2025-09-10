using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DI.MyClasses
{
    public partial class PhoneNumbers
    {
        public int id { get; set; }
        public string surname { get; set; }
        public string number { get; set; }

        public PhoneNumbers(int Id, string Surname, string Number)
        {
            id = Id;
            surname = Surname;
            number = Number;
        }

        public PhoneNumbers() { }
    }
}