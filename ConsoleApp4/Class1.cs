using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4;

public class Class1
{
    public void asdsad()
    {
        var human = new Human() { HumanAd = new HumanAd() {Name = "Mehmet" }, HumanSoyad = new HumanSoyad() { SurName = "Hasan" } };
        var step1 = new Step1();
        var step2 = new Step2();

        step1.SetNext(step2);

        step1.Handle(human);
    }
}

public class Step1 : BaseHumanHandler
{
    public override bool Handle(Human human)
    {
        if (human.HumanSoyad.SurName == "Soyhan")
            return false;

        return base.Handle(human);
    }
}

public class Step2 : BaseHumanHandler
{
    public override bool Handle(Human human)
    {
        if (human.HumanAd.Name == "Ali")
            return false;

        return base.Handle(human);
    }
}

public interface IHumanHandler
{
    void SetNext(IHumanHandler handler);
    bool Handle(Human human);
    
}

public abstract class BaseHumanHandler : IHumanHandler
{
    private IHumanHandler next;
    public virtual bool Handle(Human human)
    {
        if (next != null)
        {
            return next.Handle(human);
        }

        return true;
    }

    public void SetNext(IHumanHandler handler)
    {
        next = handler;
    }
}


public class Human
{
    public HumanAd HumanAd { get; set; }

    public HumanSoyad HumanSoyad { get; set; }

    public HumanId HumanId { get; set; }

    public HumanBoy HumanBoy { get; set; }

    public HumanKilo HumanKilo { get; set; }
}


public class HumanAd
{
    public string Name { get; set; }
}

public class HumanSoyad
{
    public string SurName { get; set; }
}

public class HumanId 
{
    public string Id { get; set; }
}

public class HumanBoy 
{
    public string Boy { get; set; }
}


public class HumanKilo 
{
    public string Kilo { get; set; }
}

