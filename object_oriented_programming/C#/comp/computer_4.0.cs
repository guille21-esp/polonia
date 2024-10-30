/******************************************************************************

Welcome to GDB Online.
GDB online is an online compiler and debugger tool for C, C++, Python, Java, PHP, Ruby, Perl,
C#, OCaml, VB, Swift, Pascal, Fortran, Haskell, Objective-C, Assembly, HTML, CSS, JS, SQLite, Prolog.
Code, Compile, Run and Debug online from anywhere in world.

*******************************************************************************/
using System;

public class Computer
{
    private string _IpAddress;
    private string _BiosName; 
    private string _Name; 
    private static int _counter=0;

    public Computer(string ipAddress, string biosName, string name)
    {
        _IpAddress = ipAddress;
        _BiosName = biosName;
        _Name = name;
        
        _counter ++;
    }
    
    public Computer(){}
    
        public string IpAddress{
        get {return this._IpAddress;}
        set {this._IpAddress= value;}
    }
    
    public string BiosName{
        get {return this._BiosName;}
        set {this._BiosName= value;}
    }
    
    public string Name{
        get {return this._Name;}
        set {this._Name= value;}
    }
}

public class Program
{
    public static void Main()
    {
        Computer[]net= new Computer[4];
        
        for(int i=0; i< net.Length; i++){
            net[i]= new Computer(randomIP(), "bios_" + i.ToString(), "comp_"+i.ToString() );
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

