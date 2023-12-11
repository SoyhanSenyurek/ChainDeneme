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
//        _human.HumanSoyad = new HumanSoyad { SurName = "Mehmet" };
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
//}

//public class Step1 : BaseHumanHandler
//{
//    public Step1(IHumanBuilder builder) : base(builder)
//    {
//    }

//    public override bool Handle()
//    {
//        IHumanBuilder builder = GetBuilder();
//        builder.CreateHumanAd();
//        builder.CreateHumanSoyad();
//        builder.CreateHumanKilo();

//        var human = builder.GetHuman();


//        if (human.HumanSoyad.SurName == "Mehmet")
//        {
            
//            Console.WriteLine("Step1 handled the request.");
//            return false;
//        }

//        return base.Handle();
//    }
//}

//public class Step2 : BaseHumanHandler
//{
//    public Step2(IHumanBuilder builder) : base(builder)
//    {
//    }

//    public override bool Handle()
//    {
//        IHumanBuilder builder = GetBuilder();
//        builder.CreateHumanAd();

//        var human = builder.GetHuman();

//        if (human.HumanAd.Name == "Ali")
//        {
            
//            Console.WriteLine("Step2 handled the request.");
//            return false;
//        }

//        return base.Handle();
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

//        Human human1 = new Human { HumanSoyad = new HumanSoyad { SurName = "Mehmet" } };
//        Human human2 = new Human { HumanAd = new HumanAd { Name = "Ali" } };

//        Console.WriteLine("Processing human1:");
//        handler1.Handle();

//        Console.WriteLine("\nProcessing human2:");
//        handler1.Handle();

//        Console.WriteLine("\nResulting Human from builder:");
//        Human resultingHuman = builder.GetHuman();
//        Console.WriteLine($"Ad: {resultingHuman.HumanAd.Name}, Soyad: {resultingHuman.HumanSoyad.SurName}, Kilo: {resultingHuman.HumanKilo.Kilo}");
//    }
//}

