using System;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using AuthorProblem;

public class Tracker
{
    public void PrintMethodsByAuthor()
    {
        var type = typeof(StartUp);
        var methods = type.GetMethods(
            BindingFlags.Instance |
            BindingFlags.Static |
            BindingFlags.Public);

        foreach (var method in methods)
        {
            if (method.CustomAttributes.Any(a => a.AttributeType == typeof(AuthorAttribute)))
            {
                var attrs = method.GetCustomAttributes(false);

                foreach (AuthorAttribute attr in attrs)
                {
                    Console.WriteLine($"{method.Name} is written by {attr.Name}");
                }
            }
        }
    }
}
//namespace AuthorProblem
//{
//    public class Tracker
//    {
//        public void PrintMethodsByAuthor()
//        {
//            var type = typeof(StartUp);
//            var methods = type.GetMethods(
//                BindingFlags.Instance |
//                BindingFlags.Public);

//            foreach ( var method in methods ) 
//            {
//                if (method.CustomAttributes.Any(n => n.AttributeType == typeof(AuthorAttribute)))
//                {
//                    var attributes = method.GetCustomAttribute(false);
//                    foreach (AuthorAttribute attr in attributes)
//                    {
//                        Console.WriteLine($"{0} is written by {1}",
//                            method.Name,attr.Name);
//                    }
//                }
//            }

//        }
//    }
//}
