using System.Text;

namespace FlexibleList
{
    public class MyGenericFlexibleList<T>
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
            for (var i = 0; i < _index; i++)
            {
                Console.WriteLine($"På index {i} ligger verdien: {_values[i]}");
            }
        }

        public string GetSummary()
        {
            var summary = new StringBuilder();
            for (var i = 0; i < _index; i++)
            {
                summary.AppendLine($"På index {i} ligger verdien: {_values[i]}");
            }
            return summary.ToString();
        }

        //public string GetSummary()
        //{
        //    var summary = "";
        //    for (int i = 0; i < _index; i++)
        //    {
        //        summary += $"På index {i} ligger verdien: {_values[i]}\n";
        //    }

        //    return summary;
        //}
    }
}
