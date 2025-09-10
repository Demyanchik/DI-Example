using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

using DI.MyClasses;

namespace DLL1
{
    public class Model: IPhoneDictionary
    {
        string JsonPath = @"D:\Projects\DI example\";
        string FileName = "data.json";

        string LogFile = "log.txt";

        List<PhoneNumbers> Numbers { get; set; }

        int line_id = 0;

        public Model()
        {
            Deserialize();
            if(Numbers.Count > 0)
                line_id = Numbers.Max(pn => { return pn.id; });

            using (StreamWriter sw = new StreamWriter(JsonPath + LogFile, true, System.Text.Encoding.Default))
            {
                sw.WriteLine("Model()");
            }
        }
        /// <summary>
        /// Сохраняем данные в json-файл
        /// </summary>
        public void Serialize()
        {
            string json = JsonSerializer.Serialize(Numbers);

            using (StreamWriter sw = new StreamWriter(JsonPath + FileName, false, System.Text.Encoding.Default))
            {
                sw.Write(json);
            }
        }
        /// <summary>
        /// Считываем данные из json-файла
        /// </summary>
        public void Deserialize()
        {
            using (StreamReader sr = new StreamReader(JsonPath + FileName))
            {
                string json = sr.ReadToEnd();
                var obj = JsonSerializer.Deserialize<List<PhoneNumbers>>(json);
                if (obj.Count == 0)
                    Numbers = new List<PhoneNumbers>();
                else
                    Numbers = obj;
            }
        }

        public void Insert(string surname, string number)
        {
            Numbers.Add(new PhoneNumbers(++line_id, surname, number));
            Serialize();
        }

        public void Update(int id, string surname, string number)
        {
            var line = GetLineById(id);
            line.surname = surname;
            line.number = number;
            Serialize();
        }

        public void Delete(int id)
        {
            Numbers.Remove(GetLineById(id));
            Serialize();
        }

        public List<PhoneNumbers> GetAllSorted()
        {
            var sortedNumbers = from element in Numbers
                                orderby element.surname
                                select element;

            return sortedNumbers.ToList();
        }

        public PhoneNumbers GetLineById(int id)
        {
            return Numbers.Find(x => x.id == id);
        }
    }
}
