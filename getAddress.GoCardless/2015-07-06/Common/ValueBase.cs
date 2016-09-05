using System;


namespace getAddress.GoCardless._2015_07_06.Common
{
    public abstract class ValueBase
    {
        public ValueBase(string value)
        {
            if (value == null) throw new ArgumentNullException(nameof(value));

            Value = value;
        }
        public string Value { get; protected set; }
    }
}
