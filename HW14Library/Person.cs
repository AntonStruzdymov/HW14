using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HW14Library
{
    public class Person
    {
        
        [Custom(@"^[А-я]{2,15}$")]
        private string Name { get; set; }
        [Custom(@"^[А-я]{2,15}$")] 
        private string Surname { get; set; }
        [Custom(@"^\d{1,3}$")]
        private int Age { get; set; }
        public Person (string name, string surname, int age)
        {
            Name = name;
            Surname = surname;
            Age = age;
        }
        public bool IsValid()
        {
            Type item = this.GetType();

            PropertyInfo[] properties = item.GetProperties(BindingFlags.Instance
                    | BindingFlags.Static
                    | BindingFlags.Public
                    | BindingFlags.NonPublic);
            int count = 0;
            foreach (PropertyInfo propertie in properties)
            {
                
                foreach (var attr in propertie.GetCustomAttributes(false))
                {
                    
                    var temp = attr as CustomAttribute;
                    if (temp != null)
                    {                        
                        var newItem = propertie.GetValue(this);
                        MatchCollection matches = temp.CustomRegex.Matches(newItem.ToString());
                        if (matches.Count > 0)
                        {
                           count++;                            
                        }
                        
                    }
                    
                }
                if (count == properties.Length) { return true; }
            }
            
            return false;
        }
    }
}
