using System;
using System.Collections.Generic;
using System.Threading;
using System.IO;

using libcomp;

public class Program
{
    private static Computer[]net= new Computer[10];      //creating net array of computers
    static StreamWriter log;

    public static void Main()
    {
        log= new StreamWriter("log.txt", true);

        Server server= new Server();     //creating server
        server.BiosName= "DHCP";
        server.IpAddress= "255.255.255.255";
        server.Name= "server_one";
        server.Type= "net_server";
        
        net[0] = server;
        
        for(int i=1; i< net.Length; i++){
            net[i]= new Computer("bios_" + i.ToString(), "computer_"+i.ToString());    //creating computers
            net[i].StartComputer(randomIP());
        }

        
        Menu();
        log.Close();   //closing log
    }                    //end of main
    
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
    }             //end of class randomIP

    static void Menu(){               
        
        bool quit= false;

        
        
        while(!quit){
            Console.WriteLine(" ");
            Console.WriteLine("Available devices: ");
            for(int i=0; i<net.Length; i++){
                Type t= net[i].GetType();
                Console.WriteLine($"{t}  {net[i].IpAddress}");
            }
            Console.WriteLine(" ");
            Console.WriteLine("*---------Menu-----------*");
            Console.WriteLine("1. Start server");
            Console.WriteLine("2. Start computers");
            Console.WriteLine("3. Display Devices");
            Console.WriteLine("4. Shut down computer");
            Console.WriteLine("5. Shut down all computers");
            Console.WriteLine("6. See the log");
            Console.WriteLine("7. Shut down server");
            Console.WriteLine("8. Ping computer");
            Console.WriteLine("9. Quit");
            Console.WriteLine("*------------------------*");
            Console.WriteLine("Choose option: ");
        
            if(int.TryParse(Console.ReadLine(), out int option)){
        
                switch(option){
                    case 1:   
                        
                        Console.WriteLine("Available servers: ");
                        bool serversAvailable=false;
                        foreach(var computer in net){
                            if(computer is Server && computer.IpAddress == null){
                                Console.WriteLine(computer.Name);
                                serversAvailable=true;
                            }
                        }

                        if(!serversAvailable){
                            Console.WriteLine("All servers are turned on");
                            break;
                        }

                        Console.WriteLine("Which server do you want to turn on?");
                        string server_turned_on = Console.ReadLine();
                        bool server_found=false;

                        foreach(var computer in net){
                            if(server_turned_on == computer.Name && computer is Server){
                                computer.StartComputer(randomIP());
                                Console.WriteLine($"Server {computer.Name} was turned on");
                                log.WriteLine($"[{DateTime.Now}] Server {computer.Name} was turned on with ip {computer.IpAddress}");
                                server_found=true;
                                break;
                            }
                        }

                        if(!server_found){
                            Console.WriteLine("No server matches the name");
                        }
                        //Console.WriteLine("Not implemented yet");
                        //log.WriteLine("server turned on");  //{DateTime.Now}
                        break;
                    case 2:
                        int cont_comp=0;
                        for(int i=0; i<net.Length; i++){
                            if(net[i] is Server){
                                continue;
                            }else{
                                cont_comp++;
                            }
                        }
                        Console.WriteLine("How many computers do you want to switch on:");
                        if(int.TryParse(Console.ReadLine(), out int num_computers_turned_on)){
                            if(num_computers_turned_on <= cont_comp){
                                int cont_turned_on=0;
                                for(int i=0; i<net.Length && cont_turned_on < num_computers_turned_on; i++){
                                    if(net[i] is Server){
                                        continue;
                                    }
                                
                                    if(net[i].IpAddress == null){
                                        net[i].StartComputer(randomIP());
                                        Console.WriteLine($"{net[i].Name} turned on with IP: {net[i].IpAddress}");
                                        cont_turned_on++;
                                    }else{
                                        Console.WriteLine($"{net[i].Name} is already turned on");
                                    }
                                }
                            }else{
                                Console.WriteLine($"Only {cont_comp} computers in the net");
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
                            if (computer.IpAddress == ip_to_shut_down){
                                if(computer is Server){
                                    Console.WriteLine($"Device {computer.Name} is not a computer, couldn't turn off");
                                    computerFound = true;
                                    break;
                                }else{
                                    computer.ShutDownComputer(ip_to_shut_down); 
                                    Console.WriteLine($"Computer {computer.Name} with IP {ip_to_shut_down} has been shut down.");
                                    computerFound = true;
                                    break;
                                }
                            }
                        }

                        if (!computerFound){
                            Console.WriteLine($"No computer found with IP {ip_to_shut_down}.");
                        }
                        break;
                    case 5:
                        foreach(var computer in net){
                            if(computer is Server){
                            }else{
                                if(computer.IpAddress != null){
                                    computer.ShutDownComputer(computer.IpAddress);
                                    Console.WriteLine($"Computer {computer.Name} has been shut down");
                                }
                                else{
                                    Console.WriteLine($"Computer {computer.Name} is already shut down");
                                }
                            }
                        }
                        Console.WriteLine("All computers are shut down");
                        break;
                    case 6:
                        seeLog();
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
                                    log.WriteLine($"[{DateTime.Now}] Server {server.Name} was turned off");
                                    
                                    break;
                                }else{
                                    Console.WriteLine("Couldn't find server with ip provided");
                                }
                            }
                        }
                        
                        break;
                    case 8: 
                        Console.WriteLine("Write IP of computer you want to ping: ");
                        string ip_pinged= Console.ReadLine();
                        pinging(ip_pinged, net);
                        break;
                    case 9:
                        quit=true;
                        break;
                        
                } 
            }
        }
    }                        //end of class menu
    
    static void DisplayComputers(Computer[]net){
        Console.WriteLine("Devices in net: ");
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
    }     //end of class DisplayComputers
    
    static void pinging(string ip, Computer[]net){
        bool encontrado=false;
        
        Random ping_times = new Random();

        int cont_ping=0;
        
        for(int i=0; i< 4; i++){
            if(ip == net[i].IpAddress){
                encontrado= true;
                Console.WriteLine("pinging will start in 3 seconds, write q when you want to stop");
                Thread.Sleep(3000);
                Console.WriteLine($"PING {net[i].IpAddress} (waw02s14-in-x0e.1e100.net (2a00:1450:401b:805::200e)) 56 data bytes");
                string quit= "";
                while(quit != "q"){
                    int ttl = ping_times.Next(100,120);
                    double time = Math.Round(ping_times.NextDouble()*(80-10)+10,2);
                    Console.WriteLine($"64 bytes from waw02s14-in-x0e.1e100.net (2a00:1450:401b:805::200e): icmp_seq={cont_ping} ttl={ttl} time={time} ms");
                    cont_ping++;
                    Thread.Sleep(1000);
                    if(Console.KeyAvailable){
                        quit= Console.ReadLine();
                    }
                }
                break;
            }
        }
        if(encontrado == false){
            Console.WriteLine("connection couldn't be established, try again");
        }
    }          //end of class pinging

    public static void seeLog(){
        log.Flush();
        Console.WriteLine("log saved to log.txt");

        try{
            string[] logContents = File.ReadAllLines("log.txt");
            foreach(var line in logContents){
                Console.WriteLine(line);
            }
        }catch{
            Console.WriteLine("error");
        }
    }
    
}