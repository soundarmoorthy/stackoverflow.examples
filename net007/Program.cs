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
            var ass1 = Assembly.LoadFrom("fx.console.app.exe");
            var ass2 = Assembly.LoadFrom("core.console.app.dll");

            ShowFrameworkVersion(ass1);
            ShowFrameworkVersion(ass2);

        }

        static void ShowFrameworkVersion(Assembly ass1)
        {
            var attributes = ass1.CustomAttributes;
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
