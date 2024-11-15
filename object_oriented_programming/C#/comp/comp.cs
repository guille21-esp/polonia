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
    
    public virtual void StartComputer(string ip){  // computer turns on, ip visible
        _IpAddress=ip;
    }
    
    public virtual void ShutDownComputer(string ip){  // computer turns off, ip not visible
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
        IpAddress= ip+ "10";
    }
    
    public override void ShutDownComputer(string ip){
        Console.WriteLine("Are you sure you want to shut down the server? (y/n)");
        string sure= Console.ReadLine();
        if(sure == "y" || sure == "n"){
            if(sure =="y"){
                IpAddress=null;
                Console.WriteLine("Server shut off");
            }else{
                Console.WriteLine("Server still on");
            }
        }else{
            Console.WriteLine("invalid option");
        }
    }
}

public class Program
{
    private static Computer[]net= new Computer[4];
    public static void Main()
    {
        Server server= new Server();
        server.BiosName= "DHCP";
        server.IpAddress= "1.1.1.1";
        server.Name= "server_one";
        server.Type= "net_server";
        
        net[0] = server;
        
        for(int i=1; i< net.Length; i++){
            net[i]= new Computer( "bios_" + i.ToString(), "computer_"+i.ToString() );
            net[i].StartComputer(randomIP());
        }
        
        Console.WriteLine("available computers: ");
        
        Console.WriteLine(net[0].IpAddress);
        Console.WriteLine(net[1].IpAddress);
        Console.WriteLine(net[2].IpAddress);
        Console.WriteLine(net[3].IpAddress);
        
        
        
        Menu();
        
        
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

    static void Menu(){
        
        bool quit= false;
        
        while(!quit){
            Console.WriteLine("Menu: ");
            Console.WriteLine("1. Start server");
            Console.WriteLine("2. Start computers");
            Console.WriteLine("3. Display computers");
            Console.WriteLine("4. Shut down computers");
            Console.WriteLine("5. Shut down all computers");
            Console.WriteLine("6. See the log");
            Console.WriteLine("7. Shut down server");
            Console.WriteLine("8. Quit");
        
            Console.WriteLine("Choose option: ");
        
            if(int.TryParse(Console.ReadLine(), out int option)){
        
                switch(option){
                    case 1:
                        Console.WriteLine("not implemented yet");
                        break;
                    case 2: 
                        Console.WriteLine("how many computers do you want to switch on:");
                        if(int.TryParse(Console.ReadLine(), out int num_computers_turned_on)){
                            for(int i=0; i<num_computers_turned_on; i++){
                                net[i].StartComputer(randomIP());
                                Console.WriteLine($"{net[i].Name} turned on with IP: {net[i].IpAddress}");
                            }
                        }
                        break;
                    case 3:
                        DisplayComputers(net);
                        break;
                    case 4: 
                        Console.WriteLine("Enter the IP address of the computer you want to shut down:");
                        string ip_to_shut_down = Console.ReadLine();

                        bool computerFound = false;
                        foreach (var computer in net){
                            if (computer.IpAddress == ip_to_shut_down)
                            {
                                computer.ShutDownComputer(ip_to_shut_down); 
                                Console.WriteLine($"Computer {computer.Name} with IP {ip_to_shut_down} has been shut down.");
                                computerFound = true;
                                break;
                            }
                        }

                        if (!computerFound){
                            Console.WriteLine($"No computer found with IP {ip_to_shut_down}.");
                        }
                        break;
                    case 5:
                        foreach(var computer in net){
                            if(computer.IpAddress != null){
                                computer.ShutDownComputer(computer.IpAddress);
                                Console.WriteLine($"computer {computer.Name} has been shut donw");
                            }
                            else{
                                Console.WriteLine($"computer {computer.Name} is already shut down");
                            }
                            
                        }
                        Console.WriteLine("all computers are shut down");
                        break;
                    case 6:
                        Console.WriteLine("not implemented yet");
                        break;
                    case 7:
                        Console.WriteLine("Enter the IP address of the server you want to shut down:");
                        string ipp_to_shut_down = Console.ReadLine();

                        bool serverFound = false;
                        foreach (var computer in net){
                            if(computer is Server server){
                                if (computer.IpAddress == ipp_to_shut_down)
                                {
                                    server.ShutDownComputer(ipp_to_shut_down); 
                                    Console.WriteLine($"Server {server.Name} with IP {ipp_to_shut_down} has been shut down.");
                                    serverFound = true;
                                    break;
                                }
                            }else{
                                Console.WriteLine("server not found");
                            }
                        }
                        
                        
                        
                        break;
                    case 8:
                        quit=true;
                        break;
                        
                } 
            }
        }
    }
    
    static void DisplayComputers(Computer[]net){
        Console.WriteLine("Computers in net: ");
        foreach(var comp in net){
            Type type1= comp.GetType();
            string stringType = type1.ToString();
            Console.Write("{0}\t\t{1}\t\t{2}\t\t{3}\t", comp.Name, comp.IpAddress, comp.BiosName, type1);
            
            
            if(stringType == "Server"){
                Server serv = (Server) comp;
                System.Console.WriteLine("\t{0}", serv.Type);
            }else{
                Console.WriteLine();
            }


            
        }
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