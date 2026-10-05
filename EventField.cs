using System;

namespace Shafir.EventField
{
    public class EventField<T>
    {
        public event Action<T> ValueChanged;

        private T _value;

        public T Value => _value;

        public static implicit operator T(EventField<T> eventField) =>
            eventField.Value;

        public EventField(T initialValue = default)
        {
            _value = initialValue;
        }

        public void SetValue(T newValue)
        {
            if (Equals(_value, newValue))
            {
                return;
            }

            _value = newValue;
            ValueChanged?.Invoke(_value);
        }
    }
}