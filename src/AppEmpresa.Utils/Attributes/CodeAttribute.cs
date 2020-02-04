using System;

namespace AppEmpresa.Utils.Attributes
{
    [AttributeUsage(AttributeTargets.Field)]
    public class CodeAttribute : Attribute
    {
        public CodeAttribute(string code)
        {
            CodeValue = code;
        }

        public virtual string Code { get { return CodeValue; } }

        protected string CodeValue { get; set; }
    }
}