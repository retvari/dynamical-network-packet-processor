using System;
using System.Diagnostics;
using System.Reflection;

namespace server
{
    class Log
    {
        public static void AddEntry(string strMessage, params object[] oArguments)
        {
            MethodBase methodBase = new StackFrame(1).GetMethod();
            Console.WriteLine(methodBase.ReflectedType.Name + "::" + methodBase.Name + ": " + string.Format(strMessage, oArguments));
        }
    }
}
