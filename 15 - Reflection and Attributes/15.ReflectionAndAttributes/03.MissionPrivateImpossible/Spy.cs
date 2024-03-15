using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Stealer
{
    public class Spy
    {



        public string RevealPrivateMethods(string investigationClass)
        {
            StringBuilder sb = new StringBuilder();
            Type classType = Type.GetType(investigationClass);
            MethodInfo[] classMethods = classType.GetMethods(
                BindingFlags.Instance |
                BindingFlags.NonPublic);


            sb.AppendLine($"All private Methods of Class: {classType.FullName}");
            sb.AppendLine($"Base Class: {classType.BaseType.Name}");

            foreach (MethodInfo method in classMethods)
            {
                sb.AppendLine(method.Name);
            }


            return  sb.ToString().TrimEnd();
        }




        //public string AnalyzeAccessModifiers(string investigatedClass)
        //{

        //    Type classType = Type.GetType(investigatedClass);
        //    FieldInfo[] classFields = classType.GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.Instance);
        //    MethodInfo[] methodsPublic = classType.GetMethods(BindingFlags.Public | BindingFlags.Instance);
        //    MethodInfo[] methodsPrivate = classType.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);

        //    //MethodInfo[] methodsPublic = classType.GetMethods(
        //    //   BindingFlags.Instance |
        //    //   BindingFlags.Public);
        //    //MethodInfo[] methodsPrivate = classType.GetMethods(
        //    //    BindingFlags.Instance |
        //    //    BindingFlags.NonPublic);
        //    //FieldInfo[] classFields = classType.GetFields(
        //    //    BindingFlags.Instance |
        //    //    BindingFlags.Static |
        //    //    BindingFlags.Public);




        //    StringBuilder sb = new StringBuilder();

        //    foreach (FieldInfo field in classFields)
        //    { 
        //     sb.AppendLine($"{field.Name} must be private!");
        //    }

        //    foreach (var publicMethod in methodsPublic)
        //    {
        //        sb.AppendLine($"{publicMethod.Name} have to be public!");
        //    }

        //    foreach (var privateMethod in methodsPrivate)
        //    {
        //        sb.AppendLine($"{privateMethod.Name} have to be private");
        //    }
        //    return sb.ToString().TrimEnd();
        //}

        //public string StealFieldInfo(string investigatedClass, params string[] requestedFields)
        //{
        //    Type classType = Type.GetType(investigatedClass);
        //    FieldInfo[] classFields = classType.GetFields(
        //        BindingFlags.Instance |
        //        BindingFlags.Static |
        //        BindingFlags.NonPublic |
        //        BindingFlags.Public);

        //    StringBuilder sb = new StringBuilder();

        //    object classInstance = Activator.CreateInstance(classType, new object[] { });

        //    sb.AppendLine($"Class under investigation: {investigatedClass}");

        //    foreach (FieldInfo field in classFields.Where(f => requestedFields.Contains(f.Name)))
        //    {
        //        sb.AppendLine($"{field.Name} = {field.GetValue(classInstance)}");
        //    }

        //    return sb.ToString().TrimEnd();
        //}
    }
}
