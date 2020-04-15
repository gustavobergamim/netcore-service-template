using System;
using System.ComponentModel;
using System.Linq;

namespace ProjetoBase.Domain.Shared
{
    public static class EnumExtensions
    {
        public static string GetEnumDescription(this Enum enumValue)
        {
            var enumField = enumValue.GetType().GetField(enumValue.ToString());

            var descriptionAttr =
                enumField.GetCustomAttributes(typeof(DescriptionAttribute), false)
                .FirstOrDefault() as DescriptionAttribute;

            return descriptionAttr?.Description ?? enumValue.ToString();
        }

        public static T GetEnumValueFromDescription<T>(string description)
        {
            var type = typeof(T);

            var fields = type.GetFields();

            var field = fields
                .SelectMany(f =>
                f.GetCustomAttributes(typeof(DescriptionAttribute), false),
                (f, a) => new { Field = f, Att = a })
                .SingleOrDefault(a => ((DescriptionAttribute)a.Att).Description == description);

            return field == null ? default(T) : (T)field.Field.GetRawConstantValue();
        }
    }
}
