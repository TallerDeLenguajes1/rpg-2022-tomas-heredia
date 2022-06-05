using System;
using RPG;
public class program
{
    public static int total = 4;
    public static int Restantes = total;
    public static string[] Nombres = {"Tomas", "Irina","Gonsalo","Maria"," Pepe", "juanita","Tulio"};
    public static string[] Apodos = {"Aniquilador", "Fachero","TuNoMeteCabraSarabanbichuie","Pablito","Muchitastico","Frijolito","EL maestro del surf"};
    public static string[] Tipos  = {"Guerrero","Ladron","Paladin"};
    public static void Main(String[] args){
        //lista de participantes
        Console.WriteLine("Bienvenido al super torneo de peleas luchonas");
        //creo personajes
        Personaje[] Participantes = new Personaje[4];

        for (int i = 0; i < total; i++)
        {
            Personaje personaje = new Personaje();
            personaje = CreacionAleatoria();
            Participantes[i] = personaje; 
        }

        
        for (int i = 0; i < total; i++)
        {
            MostrarPersonajeDatos(Participantes[i]);
            MostrarPersonajeCaracteristicas(Participantes[i]);
        }
        //array con los participantes que ganan;
        Personaje[] EnCarrera = new Personaje[total/2];
        for (int i = 0; i < total; i = i + 2)
        {
            Personaje Ganador = new Personaje();
            Ganador = Combate(Participantes[i], Participantes[i+1]);

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
        personajeAux.Apodo = Apodos[rand.Next(0,Apodos.Length)];
        personajeAux.Nacimiento = CrearFechaAleatoria();
        DateTime FActual = DateTime.Now;
        personajeAux.Edad = FActual.Year - personajeAux.Nacimiento.Year;
        personajeAux.Tipo = Tipos[rand.Next(0,Tipos.Length)];



        return personajeAux;
    }

    public static DateTime CrearFechaAleatoria()
    {
        Random aleatorio = new Random();
        return new DateTime(aleatorio.Next(1980, 2005), aleatorio.Next(1, 13), aleatorio.Next(1, 28), aleatorio.Next(25), aleatorio.Next(60), aleatorio.Next(60));
    }

    public static void MostrarPersonajeDatos(Personaje P){
        Console.WriteLine("-------------Datos-------------");
        Console.WriteLine("Nombre: "+ P.Nombre);
        Console.WriteLine("Apodo: "+ P.Apodo);
        Console.WriteLine("Edad: "+ P.Edad);
        Console.WriteLine("Fecha de nacimiento: "+ P.Nacimiento);
        Console.WriteLine("Tipo: "+ P.Tipo);
    }

    public static void MostrarPersonajeCaracteristicas(Personaje P){
        Console.WriteLine("-------------Caracteristicas-------------");
        Console.WriteLine("Nivel: "+ P.Nivel);
        Console.WriteLine("Velocidad: "+ P.Velocidad);
        Console.WriteLine("Destreza: "+ P.Destreza);
        Console.WriteLine("Fuerza: "+ P.Fuerza);
        Console.WriteLine("Armadura: "+ P.Armadura);
    }
    public static Personaje Combate(Personaje P1,Personaje P2){
        int P1Salud = P1.Salud;
        int P2Salud = P2.Salud; 
        for (int i = 0; i < 4; i++)
        {   if (P1.Salud>0 && P2.Salud>0)
            {

                if (Turnos(P1,P2) == 1)
                {
                    P2.Salud = P2.Salud - ((ValorAtaque(P1)-ValorDefenza(P2))/50000)*100;
                    if (P2.Salud > 0)
                    {
                        P1.Salud = P1.Salud - ((ValorAtaque(P2)-ValorDefenza(P1))/50000)*100;
                    }
                }
            }
        }
        if (P1.Salud > P2.Salud)
        {
            P1.Salud = P1Salud;
            return P1;
        }else
        {
            if (P1.Salud < P2.Salud)
            {   
                P2.Salud = P2Salud;
                return P2;
            }else
            {
                return null;
            }
        }
    }

    //determina quien va preimero en cada ronda, 1 D20 + destreza
    public static int Turnos(Personaje P1, Personaje P2){
        
        if ((P1.Destreza + D20())>(P2.Destreza + D20()))
        {
            return 1;
        }else
        {
            if ((P1.Destreza + D20())<(P2.Destreza + D20()))
            {
               return 2; 
            }else
            {
                return 1;
            }
        }
    }
    
    //calculo el calor de ataque
    public static int ValorAtaque(Personaje P){
        Random aleatorio = new Random();
        int PoderDisparo = P.Destreza*P.Fuerza*P.Nivel;
        int Eficiencia = aleatorio.Next(100);
        int ValorAaque = PoderDisparo*Eficiencia/100;
        return ValorAaque;
    }

    //Calculo el valro de defenza
    public static int ValorDefenza(Personaje P){
        return P.Armadura*P.Velocidad;
    }

    // un dado de 20 caras, si, esto sera calabosos y dragones
    public static int D20(){
        Random aleatorio = new Random();
        return aleatorio.Next(1,20);
    }

    //calculo de los aumentos por victoria
    public static Personaje bonus(Personaje P){
        Random aleatorio = new Random();
        switch (aleatorio.Next(1,6))
        {
            case 1:
                P.Salud += 10;
                break;
            case 2:
                P.Velocidad += P.Velocidad*aleatorio.Next(5,10)/100;
                break;
            case 3:
                P.Destreza += P.Destreza*aleatorio.Next(5,10)/100;
                break;
            case 4:
                P.Fuerza += P.Fuerza*aleatorio.Next(5,10)/100;
                break;
            case 5:
                P.Nivel += 1;
                break;
            case 6:
                P.Armadura += P.Armadura*aleatorio.Next(5,10)/100;
                break;
        }
        return P;
    }
}

