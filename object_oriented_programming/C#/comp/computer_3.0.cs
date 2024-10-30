/******************************************************************************

Welcome to GDB Online.
GDB online is an online compiler and debugger tool for C, C++, Python, Java, PHP, Ruby, Perl,
C#, OCaml, VB, Swift, Pascal, Fortran, Haskell, Objective-C, Assembly, HTML, CSS, JS, SQLite, Prolog.
Code, Compile, Run and Debug online from anywhere in world.

*******************************************************************************/
using System;

public class Computer
{
    public string IpAddress { get; set; }
    public string BiosName { get; set; }
    public string Name { get; set; }

    public Computer(string ipAddress, string biosName, string name)
    {
        IpAddress = ipAddress;
        BiosName = biosName;
        Name = name;
    }
    
    public Computer(){}
}

public class Program
{
    public static void Main()
    {
        Computer[]net= new Computer[4];
        
        for(int i=0; i< net.Length; i++){
            net[i]= new Computer(randomIP(), "bios_" + i.ToString(), "comp_"+i.ToString() );
        }

        for(int i=0; i< net.Length; i++){
            Console.WriteLine(net[i].IpAddress);
            Console.WriteLine(net[i].Name);
            Console.WriteLine(net[i].BiosName);
        }
    }
    
    static string randomIP(){
        Random rnd= new Random();
        
        int a= rnd.Next(0,255);
        int b= rnd.Next(0,255);
        int c= rnd.Next(0,255);
        int d= rnd.Next(0,255);
        
        return $"{a}.{b}.{c}.{d}";
    }
}

