using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DI.MyClasses;

namespace DLL2.EF
{
    public partial class MVC_lab4Entities : IPhoneDictionary
    {
        string JsonPath = @"D:\Projects\DI example\";
        string LogFile = "log.txt";

        public void Delete(int id)
        {
            PhoneNumbers.Remove(PhoneNumbers.Find(id));
            SaveChanges();
        }

        public List<DI.MyClasses.PhoneNumbers> GetAllSorted()
        {
            var sortedNumbers = from element in PhoneNumbers
                                orderby element.surname
                                select element;

            return EF.PhoneNumbers.ParseColl(sortedNumbers.ToList());
        }

        public DI.MyClasses.PhoneNumbers GetLineById(int id)
        {
            return EF.PhoneNumbers.ParseElement(PhoneNumbers.Find(id));
        }

        public void Insert(string surname, string number)
        {
            PhoneNumbers.Add(new PhoneNumbers(surname, number));
            SaveChanges();
        }

        public void Update(int id, string surname, string number)
        {
            var line = PhoneNumbers.Find(id);
            line.surname = surname;
            line.number = number;
            SaveChanges();
        }
    }

    public partial class PhoneNumbers
    {
        public PhoneNumbers(string Surname, string Number)
        {
            surname = Surname;
            number = Number;
        }
        public PhoneNumbers(int Id, string Surname, string Number)
        {
            id = Id;
            surname = Surname;
            number = Number;
        }

        public PhoneNumbers() { }

        public static DI.MyClasses.PhoneNumbers ParseElement(PhoneNumbers element)
        {
            return new DI.MyClasses.PhoneNumbers(element.id, element.surname, element.number);
        }

        public static List<DI.MyClasses.PhoneNumbers> ParseColl(List<PhoneNumbers> coll) 
        {
            var result = new List<DI.MyClasses.PhoneNumbers>();
            foreach (var element in coll) 
            {
                result.Add(ParseElement(element));
            }
            
            return result;
        }
    }
}
