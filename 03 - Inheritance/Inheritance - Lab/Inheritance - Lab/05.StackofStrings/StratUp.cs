namespace CustomStack
{
    public class StratUp
    {
        static void Main(string[] args)
        {
            StackOfString strings = new StackOfString();
            Console.WriteLine(strings.IsEmpty());
            strings.AddRange(new string[] { "saa", "sada" });
            Console.WriteLine(strings.IsEmpty());
        }
    }
}
