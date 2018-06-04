
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DllYuklemeMain
{
    class Program
    {
      static void Main(string[] args)
        {
            // DLL file path : ..\bin\Debug\HesaplamaYapanDLL.dll
            Assembly myAssembly = Assembly.LoadFrom(@"C:\Users\Zekeriya\Desktop\İleriProje\HesaplamaYapanDLL\HesaplamaYapanDLL\bin\Debug\HesaplamaYapanDLL.dll");
            Type type = myAssembly.GetType("HesaplamaYapanDLL.ClassHesaplama");
            object instance = Activator.CreateInstance(type);
            var method = type.GetMethod("HesaplaMatIfade");

            String hesaplanacakIfade = "56 + 25 * 12 - ( 5 * 4 ) / 2 ! ";
            double sonuc = (double)method.Invoke(instance, new object[] { hesaplanacakIfade });
            Console.WriteLine(sonuc);
        }
    }
}


