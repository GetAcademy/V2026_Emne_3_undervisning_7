namespace FlexibleList
{
    internal class MyGenericFlexibleList<T>
    {
        private T[] _values;
        private int _index;

        public MyGenericFlexibleList()
        {
            _values = new T[4];
            _index = 0;
        }

        public void Add(T text)
        {
            if (_index >= _values.Length)
            {
                var newValues = new T[_values.Length * 2];
                Array.Copy(_values, newValues, _values.Length);
                _values = newValues;
            }

            _values[_index] = text;
            _index++;
        }

        public void Show()
        {
            for (int i = 0; i < _index; i++)
            {
                Console.WriteLine($"På index {i} ligger verdien: {_values[i]}");
            }
        }
    }
}
