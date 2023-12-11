using System;
using System.Collections.Generic;




public class EHumanBuilder : IHumanBuilder
{
    private Human _human = new Human();

    public void CreateHumanAd()
    {
        _human.HumanAd = new HumanAd { Name = "Soyhan" };
    }

    public void CreateHumanSoyad()
    {
        _human.HumanSoyad = new HumanSoyad { SurName = "Zafer" };
    }

    public void CreateHumanId()
    {
        _human.HumanId = new HumanId { Id = "2" };
    }

    public void CreateHumanBoy()
    {
        _human.HumanBoy = new HumanBoy { Boy = "215" };
    }

    public void CreateHumanKilo()
    {
        _human.HumanKilo = new HumanKilo { Kilo = "55" };
    }

    public Human GetHuman()
    {
        return _human;
    }
}

public interface IHumanHandler
{
    void SetNext(IHumanHandler handler);
    bool Handle();
}


public class ActionInfo
{
    public Action Action { get; set; }
    public bool Executed { get; set; }
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

public class Human
{
    public HumanAd HumanAd { get; set; }
    public HumanSoyad HumanSoyad { get; set; }
    public HumanId HumanId { get; set; }
    public HumanBoy HumanBoy { get; set; }
    public HumanKilo HumanKilo { get; set; }
}

public interface IHumanBuilder
{
    void CreateHumanAd();
    void CreateHumanSoyad();
    void CreateHumanId();
    void CreateHumanBoy();
    void CreateHumanKilo();
    Human GetHuman();
}

public abstract class BaseHumanHandler : IHumanHandler
{
    private IHumanHandler _next;
    private readonly IHumanBuilder _builder;

    private Dictionary<string, ActionInfo> Actions { get; set; } = new Dictionary<string, ActionInfo>();

    protected BaseHumanHandler(IHumanBuilder builder)
    {
        _builder = builder;
        InitializeActions();
    }

    protected virtual void InitializeActions()
    {
        // Varsa başlangıç action'ları burada ekleyin
    }

    public virtual bool Handle()
    {
        return _next?.Handle() ?? true;
    }

    public void SetNext(IHumanHandler handler)
    {
        _next = handler;
    }

    protected void AddAction(Action action)
    {
        Actions.Add(action.Method.Name, new ActionInfo { Action = action });
    }

    public void ExecuteAction()
    {
        foreach (var actionInfo in Actions.Values)
        {
            if (!actionInfo.Executed)
            {
                actionInfo.Executed = true;
                actionInfo.Action.Invoke();
            }
        }
    }

    public IHumanBuilder GetBuilder()
    {
        return _builder;
    }
}

public class Step1 : BaseHumanHandler
{
    public Step1(IHumanBuilder builder) : base(builder)
    {
    }

    protected override void InitializeActions()
    {
        AddAction(GetBuilder().CreateHumanSoyad);
    }

    public override bool Handle()
    {
        base.ExecuteAction();
        var human = GetBuilder().GetHuman();

        if (human.HumanSoyad.SurName == "Mehmet")
        {
            Console.WriteLine("Step1 handled the request.");
            return false;
        }

        return base.Handle();
    }
}

public class Step2 : BaseHumanHandler
{
    public Step2(IHumanBuilder builder) : base(builder)
    {
    }

    protected override void InitializeActions()
    {
        AddAction(GetBuilder().CreateHumanAd);
    }

    public override bool Handle()
    {
        base.ExecuteAction();
        var human = GetBuilder().GetHuman();

        if (human.HumanAd.Name == "Ali")
        {
            Console.WriteLine("Step2 handled the request.");
            return false;
        }

        return base.Handle();
    }
}

public class Step3 : BaseHumanHandler
{
    public Step3(IHumanBuilder builder) : base(builder)
    {
    }

    protected override void InitializeActions()
    {
        AddAction(GetBuilder().CreateHumanKilo);
    }

    public override bool Handle()
    {
        base.ExecuteAction();
        var human = GetBuilder().GetHuman();

        if (human.HumanKilo.Kilo == "100")
        {
            Console.WriteLine("Step3 handled the request.");
            return false;
        }

        return base.Handle();
    }
}

public class Programs
{
    public void asdsad()
    {
        IHumanBuilder builder = new EHumanBuilder();

        IHumanHandler handler1 = new Step1(builder);
        IHumanHandler handler2 = new Step2(builder);
        IHumanHandler handler3 = new Step3(builder);

        handler1.SetNext(handler2);
        handler2.SetNext(handler3);

        Console.WriteLine("Processing human:");
        handler1.Handle();
    }
}
