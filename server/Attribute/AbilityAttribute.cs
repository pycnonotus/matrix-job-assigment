using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Attribute
{
    public class AbilityAttribute : ValidationAttribute
    {
        public AbilityAttribute()
        {
        }


        private readonly string[] abilityList = new string[] { "Attacker", "Defender" };
        public override bool IsValid(object value)
        {
            if (!(value is string))
            {
                return false;

            }
            string str = ((string)value);

            return abilityList.Contains(str);
        }

    }
}
