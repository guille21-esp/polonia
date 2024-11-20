using System;
using System.Collections.Generic;

namespace libcomp{

    public abstract class Device{
        protected string _Name;

        public Device(string name){
            _Name=name;
        }
        public Device(){
            
        }

        public abstract void StartComputer(string ip);
        public abstract void ShutDownComputer(string ip);
    }
    public class Computer : Device
{
    private string _IpAddress;
    private string _BiosName; 
    private static int _counter=0;

    public Computer(string ipAddress, string biosName, string name): base(name)
    {
        _IpAddress = ipAddress;
        _BiosName = biosName;
        
        _counter ++;
    }
    
    public Computer(string biosName, string name): base(name){  //constructor without ip
        _BiosName= biosName;
    }
    
    public Computer(): base(){  // default constructor   commented because error with abstract class
        _counter++;
    }
    
    public override void StartComputer(string ip){  // computer turns on, ip visible
        _IpAddress=ip;
    }
    
    public override void ShutDownComputer(string ip){  // computer turns off, ip not visible
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
}          //end of class computer

public class Server : Computer{
    
    private string _type;
    
    public Server(string ipAddress, string biosName, string name, string type) : base(ipAddress, biosName, name){
        this.Type = type;                   
    }
    
    public Server(){
    }
    
    public string Type{
        get { return _type;}
        set { _type = value; }
    }
    
    public override void StartComputer(string ip){
        IpAddress= ip;
    }
    
    public override void ShutDownComputer(string ip){
        Console.WriteLine("Are you sure you want to shut down the server? (y/n)");
        string sure= Console.ReadLine();
        if(sure == "y" || sure == "n"){
            if(sure =="y"){
                IpAddress=null;
            }else{
                Console.WriteLine("Server still on");
            }
        }else{
            Console.WriteLine("invalid option");
        }
    }
}         //end of class server


}