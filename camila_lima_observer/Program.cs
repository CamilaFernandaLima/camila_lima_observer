using System;
using System.Reflection.Metadata;
using System.Security.Cryptography.X509Certificates;
using static PCD;

public abstract class Subject
{
    private List<IObserver> observers = new List<IObserver>();

    public void AddObserver(IObserver observer)
    { 
        observers.Add(observer);
    }
    public void RemoveObserver(IObserver observer)
    {
        observers.Remove(observer);
    }
    public void NotifyObservers()
    {
        foreach (var observer in observers)
        {
            observer.Update(this);
        }
    }
}

public interface IObserver
{
    void Update(Subject s);
}

public class  PCD : Subject
{
    public string nomeRio { get; set; }

    private double ph;
    private double temperatura;
    private double umidade;
    private double pressao;

    public PCD(string nome)
    {
        this.nomeRio = nome;
    }
    public string GetNomeRio()
    {
        return nomeRio;
    }

    public double GetPh()
    {
        return ph;
    }
    public void SetPh(double ph)
    {
        this.ph = ph;
        NotifyObservers();
    }
    public double GetTemperatura()
    {
        return temperatura;
    }
    public void SetTemperatura(double temperatura)
    {
        this.temperatura = temperatura;
        NotifyObservers();
    }
    public double GetUmidade()
    {
        return umidade;
    }
    public void SetUmidade(double umidade)
    {
        this.umidade = umidade;
        NotifyObservers();
    }
    public double GetPressao()
    {
        return pressao;
    }
    public void SetPressao(double pressao)
    {
        this.pressao = pressao;
        NotifyObservers();
    }
    
    public class Universidade : IObserver
    {
        private string nomeUni;
        public Universidade(string nome)
        {
            this.nomeUni = nome;
        }

        public void Update(Subject s)
        {
            PCD pcd = (PCD)s;
            Console.WriteLine($"[NOTIFICAÇÃO] {nomeUni} detectou mudança no {pcd.GetNomeRio()}.");
            Console.WriteLine($"Temp: {pcd.GetTemperatura()}°C, pH: {pcd.GetPh()}, Umidade: {pcd.GetUmidade()}%, Pressão: {pcd.GetPressao()} hPa");
        }
    }
}

public class Program 
{
    public static void Main()
    {
        List<Universidade> universidades = new List<Universidade>
        {
            new Universidade("UFSC"),
            new Universidade("UFPR"),
            new Universidade("UNIFESP"),
            new Universidade("USP"),
            new Universidade("UNICAMP"),
            new Universidade("UFRJ"),
            new Universidade("UFMG"),
            new Universidade("UFV")
        };

        List<PCD> rios = new List<PCD>
        {
            new PCD("Rio Amazonas"),
            new PCD("Rio Negro"),
            new PCD("Rio Solimões"),
            new PCD("Rio Madeira"),
            new PCD("Rio Tapajós"),
        };
    }
}
