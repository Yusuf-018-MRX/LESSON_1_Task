using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Xml;
public class program
{
    public static void Create1()
    {
        try
        {
            Console.Write("Start Process name: ");
            var choice2 = Console.ReadLine();
            var datas = Process.Start(choice2);
            // var datas = Process.Start("calc"); Misal olaraq 
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex}");
        }
    }
    //----------------------------------
    public static void Delete()
    {
        try
        {
            Console.Write("Delete Process name: ");
            int choise3 = Convert.ToInt32(Console.ReadLine());
            var data = Process.GetProcessById(choise3);
            data.Kill();
            data.WaitForExit();
            data.Dispose();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex}");
        }
    }

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
        //0000000000000000000000000000000000000000000000    
        while (true)
        {
            Console.Write("\n1.Add\n2.Delete\nSecim: ");
            int choise1 = Convert.ToInt32(Console.ReadLine());
            if (choise1 == 1)
            {
                Create1();
            }
            else if (choise1 == 2)
            {
                Delete();
            }
            else
            {
                Console.WriteLine("Error: Secim duzgun daxil edin !!!");
            }
        }



    }
}
