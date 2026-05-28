namespace FlexibleList.Test
{
    public class MyGenericFlexibleListTest
    {
        [Test]
        public void TestGetSummary()
        {
            // arrange
            var list = new MyGenericFlexibleList<string>();

            // act
            list.Add("A");
            var summary = list.GetSummary();

            // assert
            Assert.That(summary, Is.EqualTo("På index 0 ligger verdien: A\n"));
        }


        public static int Add(int a, int b)
        {
            return a + b;
        }

        public static void AddB()
        {
            var a = int.Parse(Console.ReadLine());
            var b = int.Parse(Console.ReadLine());
            Console.WriteLine(a+b);
        }

        [Test]
        public void TestAdd()
        {
            // arrange

            // act
            var sum = Add(2, 3);

            // assert
            Assert.That(sum, Is.EqualTo(5));
        }
    }
}
