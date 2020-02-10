using AppEmpresa.Utils.Attributes;
using System;
using System.ComponentModel;

namespace AppEmpresa.Utils.Extensions
{
    public static class Enums
    {
        public static string GetCode(this Enum value)
        {
            var attribute = value.GetAttribute<CodeAttribute>();
            return attribute == null ? string.Empty : attribute.Code;
        }

        public static string GetDescription(this Enum value)
        {
            var attribute = value.GetAttribute<DescriptionAttribute>();
            return attribute == null ? string.Empty : attribute.Description;
        }

        public static T GetEnumByCode<T>(
            this string value,
            Enum defaultEnum) where T : Enum
        {
            Type type = typeof(T);

            foreach (T itemEnum in type.GetEnumValues())
            {
                string temtEnum = itemEnum.GetCode();

                if (value == temtEnum)
                    return itemEnum;
            }

            return (T)defaultEnum;
        }

        private static T GetAttribute<T>(this Enum value) where T : Attribute
        {
            var type = value.GetType();
            var memberInfo = type.GetMember(value.ToString());
            var attributes = memberInfo[0].GetCustomAttributes(typeof(T), false);
            return attributes.Length > 0
              ? (T)attributes[0]
              : null;
        }
    }
}
