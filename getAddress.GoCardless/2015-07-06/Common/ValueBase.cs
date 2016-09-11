using System;


namespace getAddress.GoCardless.Common
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
