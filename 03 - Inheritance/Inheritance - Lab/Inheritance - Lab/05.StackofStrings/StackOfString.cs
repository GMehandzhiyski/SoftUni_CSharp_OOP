namespace CustomStack
{
    public class StackOfString : Stack<string>
    {
        public bool IsEmpty()
        { 
             return Count == 0; 
        }

        public void AddRange(IEnumerable<string> collection)
        {
            foreach (var element in collection)
            {
                Push(element);
;            }
        }
    }
}
