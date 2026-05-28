namespace FlexibleList
{
    internal class MyFlexibleList
    {
        private string[] _texts;
        private int _index;

        public MyFlexibleList()
        {
            _texts = new string[4];
            _index = 0;
        }

        public void Add(string text)
        {
            if (_index >= _texts.Length)
            {
                var newTexts = new string[_texts.Length * 2];
                Array.Copy(_texts, newTexts, _texts.Length);
                _texts = newTexts;
            }

            _texts[_index] = text;
            _index++;
        }

        public void Show()
        {
            for (int i = 0; i < _index; i++)
            {
                Console.WriteLine($"På index {i} ligger teksten: {_texts[i]}");
            }
        }
    }
}
