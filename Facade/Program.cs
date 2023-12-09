﻿class Drive
{
    public event EventHandler driveevent;
    private string twist;
    public string Twist
    {
        get { return twist; }
        set
        {
            twist = value;
            if (driveevent != null)
                driveevent(this, new EventArgs());
        }
    }
    public Drive()
    {
        Twist = "исходная позиция";
    }
    public void TurlLeft()
    {
        Twist = "Поверот налево";
    }
    public void TurlRight()
    {
        Twist = "Поверот направо";
    }
    public void Stop()
    {
        Twist = "Стоп";
    }
    public override string ToString()
    {
        string s = String.Format("Привод: {0}", Twist);
        return s;
    }
}
class Power
{
    public event EventHandler powerevent;
    private int _power;
    public int MicrowavePower
    {
        get { return _power; }
        set
        {
            _power = value;
            if (powerevent != null)
                powerevent(this, new EventArgs());

        }
    }
    public override string ToString()
    {
        string s = String.Format("Задана мощность {0}w ", MicrowavePower);
        return s;
    }
}
class Notification
{
    public event EventHandler notificationevent;
    private string mess;
    public string MessageFin
    {
        get { return mess; }
        set
        {
            mess = value;
            if (notificationevent != null)
                notificationevent(this, new EventArgs());
        }
    }
    public void StartNotification()
    {
        MessageFin = "Операция началась";
    }
    public void StopNotification()
    {
        MessageFin = "Операция завершена";
    }
    public override string ToString()
    {
        string s = String.Format("Информация: {0}", MessageFin);
        return s;
    }
}
class Microwave
{
    private Drive _drive;
    private Power _power;
    private Notification _notification;
    public Microwave(Drive drive, Power power, Notification notification)
    {
        _drive = drive;
        _power = power;
        _notification = notification;
    }
    public void Defrost()
    {
        _notification.StartNotification();
        _power.MicrowavePower = 1000;
        _drive.TurlRight();
        _drive.TurlRight();
        _power.MicrowavePower = 500;
        _drive.Stop();
        _drive.TurlLeft();
        _drive.TurlLeft();
        _power.MicrowavePower = 200;
        _drive.Stop();
        _drive.TurlRight();
        _drive.TurlRight();
        _drive.Stop();
        _power.MicrowavePower = 0;
        _notification.StopNotification();
    }
    public void Cooking()
    {
        _notification.StartNotification();
        _power.MicrowavePower = 400;
        _drive.TurlRight();
        _drive.TurlLeft();
        _drive.Stop();
        _power.MicrowavePower = 700;
        _drive.TurlLeft();
        _drive.TurlRight();
        _drive.Stop();
        _power.MicrowavePower = 1000;
        _drive.TurlRight();
        _drive.TurlLeft();
        _drive.Stop();
        _power.MicrowavePower = 0;
        _notification.StopNotification();
    }
}
class Program
{
    static void Main(string[] args)
    {
        var drive = new Drive();
        var power = new Power();
        var notification = new Notification();
        var microwave = new Microwave(drive, power, notification);
        power.powerevent += power_powerevent;
        drive.driveevent += drive_driveevent;
        notification.notificationevent += notification_notificationevent;
        //Console.WriteLine("Разморозка");
        //microwave.Defrost();

        Console.WriteLine("Приготовление продукта");
        microwave.Cooking();





        static void notification_notificationevent(object sender, EventArgs e)
        {
            Notification n = (Notification)sender;
            Console.WriteLine(n.ToString());
        }
        static void drive_driveevent(object sender, EventArgs e)
        {
            Drive d = (Drive)sender;
            Console.WriteLine(d.ToString());
        }
        static void power_powerevent(object sender, EventArgs e)
        {
            Power p = (Power)sender;
            Console.WriteLine(p.ToString());
        }
    }
}

/* Фасад — это структурный паттерн проектирования, который предоставляет
 * простой интерфейс к сложной системе классов, библиотеке или фреймворку.
 * Применение большинства паттернов приводит к появлению меньших классов,
 * но в большем количестве. Такую подсистему проще повторно использовать, 
 * настраивая её каждый раз под конкретные нужды, но вместе с тем, применять
 * подсистему без настройки становится труднее. 
 * 
 * Фасад предоставляет возможность быстро настроить систему, обращаясь к
 * классу-фасаду, а не к каждому компоненту системы отдельно. 
 */