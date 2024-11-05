using System;
using System.Collections.Generic;

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
    
    public Computer(string biosName, string name){  //constructor without ip
        _BiosName= biosName;
        _Name=name;
    }
    
    public Computer(){  // default constructor
        _counter++;
    }
    
    public void StartComputer(string ip){  // computer turns on, ip visible
        _IpAddress=ip;
    }
    
    public void ShutDownComputer(){  // computer turns off, ip not visible
        _IpAddress= null;
    }
    
    public static int getcompsNum(){ // shows number of computers
        return _counter;
    }
    
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
            net[i]= new Computer( "bios_" + i.ToString(), "comp_"+i.ToString() );
            net[i].StartComputer(randomIP());
        }
        
        Console.WriteLine("available computers: ");
        
        Console.WriteLine(net[0].IpAddress);
        Console.WriteLine(net[1].IpAddress);
        Console.WriteLine(net[2].IpAddress);
        Console.WriteLine(net[3].IpAddress);
        
        Console.WriteLine("introduce ip adress to ping: ");
        
        string pinged_ip = Console.ReadLine();
        
        pinging(pinged_ip, net);
        
    }
    
    static string randomIP()
    {
        // Static variable to track generated IPs across function calls
        HashSet<string> generatedIPs = new HashSet<string>();
        Random rnd = new Random();
        string ip;

        do
        {
            int a = rnd.Next(0, 256);
            int b = rnd.Next(0, 256);
            int c = rnd.Next(0, 256);
            int d = rnd.Next(0, 256);

            ip = $"{a}.{b}.{c}.{d}";
        } while (!generatedIPs.Add(ip)); 

        return ip; 
    }
    
    static void pinging(string ip, Computer[]net){
        bool encontrado=false;
        for(int i=0; i< 4; i++){
            if(ip == net[i].IpAddress){
                encontrado= true;
                Console.WriteLine("pinging...");
                break;
            }
        }
        if(encontrado == false){
            Console.WriteLine("connection lost");
        }
    }
}
