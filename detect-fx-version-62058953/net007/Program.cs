using System;
using System.Linq;
using System.Reflection;
using System.Runtime.Versioning;

namespace net007
{
    class Program
    {
        static void Main(string[] args)
        {
            //A .net framwwork dll in the same output fodler
            //as the current executable
            var fxAssembly = Assembly.LoadFrom("fx.console.app.exe");

            //A .net core dll in the same output fodler
            //as the current executable
            var netCoreAssembly = Assembly.LoadFrom("core.console.app.dll");

            ShowFrameworkVersion(fxAssembly); //.NETFramework,Version=v4.7.2
            ShowFrameworkVersion(netCoreAssembly);//.NETCoreApp,Version = v3.1
        }

        static void ShowFrameworkVersion(Assembly assembly)
        {
            var attributes = assembly.CustomAttributes;
            foreach (var attribute in attributes)
            {
                if (attribute.AttributeType == typeof(TargetFrameworkAttribute))
                {
                    var arg = attribute.ConstructorArguments.FirstOrDefault();
                    if (arg == null)
                        throw new NullReferenceException("Unable to read framework version");
                    Console.WriteLine(arg.Value);
                }
            }
        }
    }
}
