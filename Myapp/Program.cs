using System;
using RPG;
public class program
{
    public static string[] Nombres = {"Tomas", "Irina","Gonsalo","Maria"," Pepe", "juanita","Tulio"};
    public static string[] Apodos = {"Aniquilador", "Fachero","TuNoMeteCabraSarabanbichuie","Pablito","Muchitastico","Frijolito","EL maestro del surf"};

    public static void Main(String[] args){
        //lista de participantes
        Console.WriteLine("Bienvenido al super torneo de peleas luchonas");
        //creo personajes
        Personaje[] Participantes = new Personaje[3];
        Personaje personaje1 = new Personaje();
        Participantes[0] = personaje1; 
        Personaje personaje2 = new Personaje();
        Participantes[1] = personaje2; 
        Personaje personaje3 = new Personaje();
        Participantes[2] = personaje3; 
        Personaje personaje4 = new Personaje();
        Participantes[3] = personaje4; 

        for (int i = 0; i < Participantes.Length; i++)
        {
            MostrarPersonajeDatos(Participantes[i]);
            MostrarPersonajeCaracteristicas(Participantes[i]);
        }
    }

    public static Personaje CreacionAleatoria(){
        
        Random rand = new Random();
        Personaje personajeAux = new Personaje();
        personajeAux.Salud = 100;
        personajeAux.Armadura = rand.Next(1,10);
        personajeAux.Destreza = rand.Next(1,10);
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

    public static void MostrarPersonajeDatos(Personaje P){
        Console.WriteLine("Nombre: "+ P.Nombre);
        Console.WriteLine("Apodo: "+ P.Apodo);
        Console.WriteLine("Edad: "+ P.Edad);
        Console.WriteLine("Fecha de nacimiento: "+ P.Nacimiento);
        Console.WriteLine("Tipo: "+ P.tipo);
    }

    public static void MostrarPersonajeCaracteristicas(Personaje P){
        Console.WriteLine("-------------Caracteristicas-------------");
        Console.WriteLine("Nivel: "+ P.Nivel);
        Console.WriteLine("Velocidad: "+ P.Velocidad);
        Console.WriteLine("Destreza: "+ P.Destreza);
        Console.WriteLine("Fuerza: "+ P.Fuerza);
        Console.WriteLine("Armadura: "+ P.Armadura);
    }
    public static int Combate(Personaje P1,Personaje P2){
        return 1;
    }
}

