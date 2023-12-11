//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace ConsoleApp4;


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

//public class Human
//{
//    public HumanAd HumanAd { get; set; } = new HumanAd { Name = "Soyhan" };
//    public HumanSoyad HumanSoyad { get; set; } = new HumanSoyad { SurName = "Zafer" };
//    public HumanId HumanId { get; set; } = new HumanId { Id = "2" };
//    public HumanBoy HumanBoy { get; set; } = new HumanBoy { Boy = "215" };
//    public HumanKilo HumanKilo { get; set; } = new HumanKilo { Kilo = "55" };
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
//        // Başlangıç değeri zaten atanmış, bu nedenle ekstra bir işlem gerekmiyor.
//    }

//    public void CreateHumanSoyad()
//    {
//        // Başlangıç değeri zaten atanmış, bu nedenle ekstra bir işlem gerekmiyor.
//    }

//    public void CreateHumanId()
//    {
//        // Başlangıç değeri zaten atanmış, bu nedenle ekstra bir işlem gerekmiyor.
//    }

//    public void CreateHumanBoy()
//    {
//        // Başlangıç değeri zaten atanmış, bu nedenle ekstra bir işlem gerekmiyor.
//    }

//    public void CreateHumanKilo()
//    {
//        // Başlangıç değeri zaten atanmış, bu nedenle ekstra bir işlem gerekmiyor.
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
//    Human GetHuman(List<Action> actions);
//}

//public abstract class BaseHumanHandler : IHumanHandler
//{
//    private IHumanHandler next;
//    private IHumanBuilder builder;

//    public virtual List<Action> Actions { private get; set; }

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

//    public Human GetHuman(List<Action> actions)
//    {
//        foreach (Action action in actions)
//        {
//            action.Invoke();
//        }
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
//        IHumanBuilder builder = GetBuilder();
//        List<Action> methods = new List<Action>() { builder.CreateHumanSoyad };

//        var human = GetHuman(methods);

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
//        List<Action> methods = new List<Action>() { builder.CreateHumanAd };

//        var human = GetHuman(methods);

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

//        Console.WriteLine("Processing human1:");
//        handler1.Handle();
//    }
//}
