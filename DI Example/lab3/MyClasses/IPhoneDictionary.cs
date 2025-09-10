using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DI.MyClasses
{
    public interface IPhoneDictionary
    {
        void Insert(string surname, string number);
        void Update(int id, string surname, string number);
        void Delete(int id);

        List<PhoneNumbers> GetAllSorted();
        PhoneNumbers GetLineById(int id);
    }
}
