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

    public Computer(string ipAddress, string biosName)
    {
        IpAddress = ipAddress;
        BiosName = biosName;
    }
    
    public Computer(){}
}

public class Program
{
    public static void Main()
    {
        Computer computer1 = new Computer("192.168.1.10", "BIOS_A");
        Computer computer2 = new Computer("192.168.1.11", "BIOS_B");
        
        Console.WriteLine(computer1.IpAddress + " " + computer1.BiosName);
        Console.WriteLine(computer2.IpAddress + " " + computer2.BiosName);

    }
}

