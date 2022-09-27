﻿namespace uMVVM.Sources.Infrastructure
{
    public class BindableProperty<T>
    {
        public delegate void ValueChangedHandler(T oldValue, T newValue);
        public ValueChangedHandler OnValueChanged;

        private T _value;
        public T Value
        {
            get => _value;
            set
            {
                if (!Equals(_value, value))
                {
                    var old = _value;
                    _value = value;
                    ValueChanged(old, _value);
                }
            }
        }

        private void ValueChanged(T oldValue, T newValue)
        {
            OnValueChanged?.Invoke(oldValue, newValue);
        }

        public override string ToString()
        {
            return (Value != null ? Value.ToString() : "null");
        }
    }
}
