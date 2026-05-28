using FlexibleList;

var list = new List<ConsoleKey>();
while (true)
{
    Console.Write("Trykk en tast! ");
    var keyInfo = Console.ReadKey();
    Console.WriteLine();
    list.Add(keyInfo.Key);
    Console.WriteLine(string.Join(',',list));
}

//var list = new MyGenericFlexibleList<ConsoleKey>();
//while (true)
//{
//    Console.Write("Trykk en tast! ");
//    var keyInfo = Console.ReadKey();
//    Console.WriteLine();
//    list.Add(keyInfo.Key);
//    list.Show();
//}



//var list = new MyFlexibleList();
//while (true)
//{
//    Console.WriteLine("Trykk en tast!");
//    var keyInfo = Console.ReadKey();
//    list.Add(keyInfo.Key);
//    list.Show();
//}

//var texts = new string[4];
//int index = 0;

//while (true)
//{
//    Console.Write("Skriv noe: ");
//    var text = Console.ReadLine();

//    if (index >= texts.Length)
//    {
//        var newTexts = new string[texts.Length * 2];
//        Array.Copy(texts, newTexts, texts.Length);
//        texts = newTexts;
//    }

//    texts[index] = text;
//    index++;

//    // Vise hele arrayen
//    for (int i = 0; i < texts.Length; i++)
//    {
//        Console.WriteLine($"På index {i} ligger teksten: {texts[i]}");
//    }
//}