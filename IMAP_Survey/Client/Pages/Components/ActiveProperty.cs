namespace IMAP_Survey.Client.Pages.Components
{
    public class ActiveProperty<T>
    {
        private Action? Callback { get; init; }

        private T _value;
        public T Value
        {
            get
            {
                return _value;
            }
            set
            {
                if (EqualityComparer<T>.Default.Equals(_value, value))
                    return;

                _value = value;

                if (Callback != null)
                {
                    Callback.Invoke();
                }
            }
        }

        public ActiveProperty(T value, Action? callback)
        {
            Value = value;
            _value = value;
            Callback = callback;
        }
    }
}
