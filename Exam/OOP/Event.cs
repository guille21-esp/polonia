using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Event{
    public string Name { get; set; }
    public DateTime Date { get; set; }
    
    public Event(string name, DateTime date){
        Name = name;
        Date = date;
    }
    
    public virtual void GetInfo(){
        Console.WriteLine($"Event: {Name} Date: {Date}");
    }
}

class PaidEvent : Event{
    public int Price { get; set; }
    
    public PaidEvent(string name, DateTime date, int price) : base(name, date){
        Price = price;
    }
    
    public override void GetInfo(){
        Console.WriteLine($"Event: {Name} Date: {Date} Price: {Price}");
    }
}

class Program {
    static void DisplayEvents(List<Event> events){
        foreach(var evnt in events){
            evnt.GetInfo();
        }
    }
    
    static void WriteToFile(List<Event> events, string filename){
        if (!File.Exists("log.txt"))
        {
            File.Create("log.txt").Close();
        }
        
        StreamWriter writer = new StreamWriter(filename);
        foreach (var evnt in events)
        {
            writer.WriteLine($"{evnt.Name}, {evnt.Date:yyyy-MM-dd}");
        }
        writer.Close();
    }
    
    static void MonthlyEvents(List<Event> events){
        var eventsmonth = events.GroupBy(e => e.Date.Month)
                                .Select(g => new { Month = g.Key, Count = g.Count() });
                                
        foreach(var month in eventsmonth){
            Console.WriteLine($"In month {month.Month} there are {month.Count} events");
        }
    }

    static void Main() {
        List<Event> events = new List<Event>
        {
            new Event("Concert", new DateTime(2025, 6, 15)),
            new Event("Tech Conference", new DateTime(2025, 7, 10)),
            new Event("Football Game", new DateTime(2025, 8, 5)),
            new PaidEvent("Art Exhibit", new DateTime(2025, 6, 20), 20),
            new PaidEvent("Comedy Show", new DateTime(2025, 7, 25), 30)
        };

        DisplayEvents(events);

        WriteToFile(events, "log.txt");

        MonthlyEvents(events);
  }
}
