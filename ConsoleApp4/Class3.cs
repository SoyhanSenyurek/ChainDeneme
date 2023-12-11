//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace ConsoleApp4;

//public class Class2
//{
//}


//public class Human
//{
//    public HumanAd HumanAd { get; set; }
//    public HumanSoyad HumanSoyad { get; set; }
//    public HumanId HumanId { get; set; }
//    public HumanBoy HumanBoy { get; set; }
//    public HumanKilo HumanKilo { get; set; }
//}

//public class HumanAd
//{
//    public string Name { get; set; }
//}

//public class HumanSoyad
//{
//    public string SurName { get; set; }
//}

//public class HumanId
//{
//    public string Id { get; set; }
//}

//public class HumanBoy
//{
//    public string Boy { get; set; }
//}

//public class HumanKilo
//{
//    public string Kilo { get; set; }
//}

//public interface IHumanBuilder
//{
//    void CreateHumanAd();
//    void CreateHumanSoyad();
//    void CreateHumanId();
//    void CreateHumanBoy();
//    void CreateHumanKilo();
//    Human GetHuman();
//}

//public class EHumanBuilder : IHumanBuilder
//{
//    private Human _human = new Human();

//    public void CreateHumanAd()
//    {
//        _human.HumanAd = new HumanAd { Name = "Soyhan" };
//    }

//    public void CreateHumanSoyad()
//    {
//        if (_human.HumanSoyad != null)
//            _human.HumanSoyad = new HumanSoyad { SurName = "Zafer" };
//        else
//            _human.HumanSoyad = new HumanSoyad { SurName = "Zafer" };
//    }

//    public void CreateHumanId()
//    {
//        _human.HumanId = new HumanId { Id = "2" };
//    }

//    public void CreateHumanBoy()
//    {
//        _human.HumanBoy = new HumanBoy { Boy = "215" };
//    }

//    public void CreateHumanKilo()
//    {
//        _human.HumanKilo = new HumanKilo { Kilo = "55" };
//    }

//    public Human GetHuman()
//    {
//        return _human;
//    }
//}

//public interface IHumanHandler
//{
//    void SetNext(IHumanHandler handler);
//    bool Handle();
//    void Build();

//    Human GetHuman();
//}

//public abstract class BaseHumanHandler : IHumanHandler
//{
//    private IHumanHandler next;
//    private IHumanBuilder builder;

//    public BaseHumanHandler(IHumanBuilder builder)
//    {
//        this.builder = builder;
//    }

//    public virtual bool Handle()
//    {
//        if (next != null)
//        {
//            return next.Handle();
//        }

//        return true;
//    }

//    public void SetNext(IHumanHandler handler)
//    {
//        next = handler;
//    }

//    public void SetBuilder(IHumanBuilder newBuilder)
//    {
//        builder = newBuilder;
//    }

//    public IHumanBuilder GetBuilder()
//    {
//        return builder;
//    }

//    public virtual void Build()
//    {
//        builder.CreateHumanAd();
//    }

//    public Human GetHuman()
//    {
//        return builder.GetHuman();
//    }
//}

//public class Step1 : BaseHumanHandler
//{
//    public Step1(IHumanBuilder builder) : base(builder)
//    {

//    }

//    public override bool Handle()
//    {
//        Build();

//        var human = base.GetHuman();

//        if (human.HumanSoyad.SurName == "Mehmet")
//        {

//            Console.WriteLine("Step1 handled the request.");
//            return false;
//        }

//        return base.Handle();
//    }

//    public override void Build()
//    {
//        IHumanBuilder builder = GetBuilder();
//        builder.CreateHumanSoyad();


//        base.Build();
//    }
//}

//public class Step2 : BaseHumanHandler
//{
//    public Step2(IHumanBuilder builder) : base(builder)
//    {
//    }

//    public override bool Handle()
//    {
//        Build();
//        var human = base.GetHuman();

//        if (human.HumanAd.Name == "Ali")
//        {
//            Console.WriteLine("Step2 handled the request.");
//            return false;
//        }

//        return base.Handle();
//    }

//    public override void Build()
//    {
//        IHumanBuilder builder = GetBuilder();
//        builder.CreateHumanAd();
//        base.Build();
//    }
//}

//public class Programs
//{
//    public void asdsad()
//    {
//        IHumanBuilder builder = new EHumanBuilder();

//        IHumanHandler handler1 = new Step1(builder);
//        IHumanHandler handler2 = new Step2(builder);

//        handler1.SetNext(handler2);

//        Console.WriteLine("Processing human1:");
//        handler1.Handle();
//    }
//}

