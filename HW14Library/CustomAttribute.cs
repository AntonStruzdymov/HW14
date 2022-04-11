using System.Text.RegularExpressions;

namespace HW14Library
{

    public class CustomAttribute : Attribute
    {
        public Regex CustomRegex { get; set; }

        public CustomAttribute(string pattern)
        {
            CustomRegex = new Regex(pattern);
        }

    }
}