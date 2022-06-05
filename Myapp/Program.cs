using System;
using RPG;
public class program
{
    public static string[] Nombres = {"Tomas", "Irina","Gonsalo","Maria"," Pepe", "juanita","Tulio"};
    public static string[] Apodos = {"Aniquilador", "Fachero","TuNoMeteCabraSarabanbichuie","Pablito","Muchitastico","Frijolito","EL maestro del surf"};
    //public static DateTime[] Edades = {"10/04/2001", "Fachero","TuNoMeteCabraSarabanbichuie","Pablo"};

    public static void Main(String[] args){
        //lista de participantes
        Console.WriteLine("Bienvenido al super torneo de peleas luchonas");
        //creo personajes
        Personaje personaje1 = new Personaje(); 
        Personaje personaje2 = new Personaje();
        Personaje personaje3 = new Personaje();
        Personaje personaje4 = new Personaje();
    }

    public static Personaje CreacionAleatoria(){
        
        Random rand = new Random();
        Personaje personajeAux = new Personaje();
        personajeAux.Salud = 100;
        personajeAux.Armadura = rand.Next(1,10);
        personajeAux.Destresa = rand.Next(1,10);
        personajeAux.Fuerza = rand.Next(1,10);
        personajeAux.Nivel = rand.Next(1,10);
        personajeAux.Velocidad = rand.Next(1,10);
        personajeAux.Nombre = Nombres[rand.Next(0,Nombres.Length)];
        personajeAux.Apodo = Apodos[rand.Next(0,Nombres.Length)];
        personajeAux.Nacimiento = CrearFechaAleatoria();
        DateTime FActual = DateTime.Now;
        personajeAux.Edad = FActual.Year - personajeAux.Nacimiento.Year;



        return personajeAux;
    }

    public static DateTime CrearFechaAleatoria()
    {
        Random aleatorio = new Random();
        return new DateTime(aleatorio.Next(1980, 2005), aleatorio.Next(1, 13), aleatorio.Next(1, 28), aleatorio.Next(25), aleatorio.Next(60), aleatorio.Next(60));
    }

    public static int Combate(Personaje P1,Personaje P2){
        return 1;
    }
}

