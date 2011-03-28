using System;

namespace CEUtilities
{
    public class AssemblyInfo
    {
        public static string AssemblyDirectory()
        {
            System.Reflection.Assembly execAsm = System.Reflection.Assembly.GetExecutingAssembly();
            return AssemblyDirectory(execAsm);
        }

        public static string AssemblyDirectory(System.Reflection.Assembly execAsm)
        {
            return System.IO.Path.GetDirectoryName(execAsm.GetName().CodeBase);
        }
    }
}
