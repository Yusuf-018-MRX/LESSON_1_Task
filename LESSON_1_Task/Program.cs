using System;
using System.Diagnostics;
using System.Xml;
public class program
{
    public static void Main(string[] args)
    {
        // dersde yazdim codeni windows from acilmadi(admin parol isteyirdi) ona gorem app da yazdim 
        Thread.CurrentThread.Name = "Task_Lesson_1";
        Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId} ");
        //Console.WriteLine(Thread.CurrentThread.Name);
        Process[] systemProcesses = Process.GetProcessesByName("");
        if (systemProcesses.Length > 0)
        {
            Process Proc = systemProcesses[0];
            Console.WriteLine($"Process Name: {Proc.ProcessName}");
            Console.WriteLine($"Process ID : {Proc.Id}");
            Console.WriteLine($"Handle Count: {Proc.HandleCount}");
        }
        else
        {
            Console.WriteLine("Error: System NOt founded !!!!");
        }

        Thread t = new Thread(() =>
         {
             Console.WriteLine("System islyir ."); 
         });
        t.Start();
        Process Proces1 = Process.GetCurrentProcess();
        int threadCount = Proces1.Threads.Count;
        Console.WriteLine($"Proces name : {Proces1.ProcessName}");
        Console.WriteLine($"Thread count : {threadCount}");
        t.Join();


        Console.Write("\n1.Add\n2.Delete\nSecim: ");
        int choise = Convert.ToInt32( Console.ReadLine() );

        if (choise == 1)
        {
            //Console.WriteLine(t.ManagedThreadId); // Yeni 1 thread yarandi

            Console.Write("Start Process name: ");
            var choice = Console.ReadLine();
            var datas = Process.Start(choice);
            // var datas = Process.Start("calc"); Misal olaraq 
        }
        else if (choise == 2)
        {
            var data = Process.GetProcessById(choise);
            data.Kill();
            data.WaitForExit();
            data.Dispose();
        }

    }
}