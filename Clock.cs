using System;

public class Clock{
    public int hour;
    public int minute;
    public Clock(int hours, int minutes){
        TimeSpan span1 = TimeSpan.Zero;
        int m=minutes,h=hours;
        int x=(h*60)+m;
        while (x<0)
        {
            x=(24*60)+x;
        }
        span1=TimeSpan.FromMinutes(x);
        Console.WriteLine(Math.Abs(span1.Hours)+ ":"+ Math.Abs(span1.Minutes));
        hour = Math.Abs(span1.Hours);
        minute = Math.Abs(span1.Minutes);
    }
    public Clock Add(int minutesToAdd){
        return new Clock(hour,minute + minutesToAdd);
    }
    public Clock Subtract(int minutesToSubtract){
       return new Clock(hour, minute - minutesToSubtract);
    }
    
    public override string ToString()
    {
        DateTime d = new DateTime(1,1,1,hour, minute,0);
        return d.ToString("HH:mm");
    }

    public override bool Equals(object obj)
    {
        if (obj == null || GetType() != obj.GetType())
        {
            return false;
        }
        var clock2 = (Clock)obj;
        var clock1 = (Clock)this;
        int clk1=clock1.GetHashCode();
        int clk2=clock2.GetHashCode();
        if(clk1 == clk2)
        {
            return true;
        }
        else
        {
            return false;
        }
       // return hour == clock2.hour && minute == clock2.minute;
    }
    public override int GetHashCode()
    {        
        int x=hour.GetHashCode();
        int y=minute.GetHashCode();
        return hour.GetHashCode() ^ minute.GetHashCode();
    }
}