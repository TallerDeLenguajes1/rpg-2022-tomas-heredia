using System;
using RPG;
public class program
{
    public static string[] Nombres = {"Tomas", "Irina","Gonsalo","Maria"};
     public static string[] Apodos = {"Aniquilador", "Fachero","TuNoMeteCabraSarabanbichuie","Pablo"};
    public static void Main(String[] args){
        //creo personajes
        Personaje personaje1 = new Personaje(); 
        Personaje personaje2 = new Personaje();
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



        return null;
    }
}

