using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace pry100.Utilitario.Idiomas_v2.Clases
{
    //[AttributeUsage(AttributeTargets.Field)]
    public class customDescripcion : Attribute
    {
        public string Descripcion { get; private set; }

        public customDescripcion(string target) { Descripcion = target; }
    }
    public static class clsEnumerable
    {
        public static customValue _getCustomPropertyEnum<customValue>(Enum enumValue) where customValue : Attribute
        {
            return enumValue.GetType().GetMember(enumValue.ToString()).First().GetCustomAttribute<customValue>() as customValue;
        }
    }
}
