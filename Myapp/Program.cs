using System;
using RPG;
using System.Text.Json;
using System.Text.Json.Serialization;
public class program
{
    public static int total = 4;
   
    public static string NombreArchivoJson = @"C:\Users\usuario\Documents\1er2022\taller1\ganadores\Participantes.json";  //ubicacion del json
    
    public static string[] Nombres = {"Tomas", "Irina","Gonsalo","Maria"," Pepe", "juanita","Tulio"};
    public static string[] Apodos = {"Aniquilador", "Fachero","TuNoMeteCabraSarabanbichuie","Pablito","Muchitastico","Frijolito","EL maestro del surf"};
    public static string[] Tipos  = {"Guerrero","Ladron","Paladin"};
    public static void Main(String[] args){
        
        //lista de participantes
        Console.WriteLine("Bienvenido al super torneo de peleas luchonas");
        //creo personajes
        List<Personaje> Participantes = new List<Personaje>();

        Console.WriteLine("1_Crear participantes nuevos. ");
        Console.WriteLine("2_ Usar personajes viejos.");
        string texto = Console.ReadLine();
        int eleccion = Int32.Parse(texto);
        if (eleccion == 2)
        {
            if (!File.Exists(NombreArchivoJson))
            {
                Console.WriteLine("No existe un Json de participantes. Creando nuevos participantes...");
                eleccion = 1;
            }else       // aqui habro el json de participantes y  los deserealiso en la lista de participantes
            {
                StreamReader sr = new StreamReader(NombreArchivoJson);
                string datoJson = sr.ReadLine();
            
                Participantes = JsonSerializer.Deserialize<List<Personaje>>(datoJson);

                sr.Close();
            }
        }

        if (eleccion == 1)
        {
            for (int i = 0; i < total; i++)
            {
                Personaje personaje = new Personaje();
                personaje = CreacionAleatoria();
                Participantes.Add(personaje); 
            }
            
        }
            
        guardarParticipantes(Participantes);
        
        for (int i = 0; i < Participantes.Count; i++)
        {
            Participantes[i].MostrarPersonajeDatos();
            Participantes[i].MostrarPersonajeCaracteristicas();
        }

        while (Participantes.Count > 1)
        {
            Participantes = clasificaciones(Participantes);
        }
        //1er round
       
        //2do round
        

        if (Participantes.Count == 1 && Participantes[0] != null)
        {
            Console.WriteLine("---------¡¡¡¡GANADOR!!!!------------");
            Participantes[0].MostrarPersonajeDatos();
            guardado(Participantes[0]);

        }else
        {
            Console.WriteLine("Todos perdieron");
        }
        
        
        
    }

    public static Personaje CreacionAleatoria(){
        
        Random rand = new Random();
        Personaje personajeAux = new Personaje();
        personajeAux.Nombre = Nombres[rand.Next(0,Nombres.Length)];
        personajeAux.Apodo = Apodos[rand.Next(0,Apodos.Length)];
        personajeAux.Salud = 100;
        personajeAux.Armadura = rand.Next(1,10);
        personajeAux.Destreza = rand.Next(1,10);
        personajeAux.Fuerza = rand.Next(1,10);
        personajeAux.Nivel = rand.Next(1,10);
        personajeAux.Velocidad = rand.Next(1,10);
        personajeAux.Nacimiento = CrearFechaAleatoria();
        DateTime FActual = DateTime.Now;
        personajeAux.Edad = FActual.Year - personajeAux.Nacimiento.Year;
        personajeAux.Tipo = Tipos[rand.Next(0,Tipos.Length)];



        return personajeAux;
    }

    public static DateTime CrearFechaAleatoria()
    {
        Random aleatorio = new Random();
        return new DateTime(aleatorio.Next(1980, 2005), aleatorio.Next(1, 12), aleatorio.Next(1, 28));
    }

    

    
    public static Personaje Combate(Personaje P1,Personaje P2){
        int P1Salud = P1.Salud;
        int P2Salud = P2.Salud; 
        for (int i = 0; i < 4; i++)
        {   if (P1.Salud>0 && P2.Salud>0)
            {

                if (Turnos(P1,P2) == 1)
                {
                    P2.Salud = P2.Salud - normalizador(((ValorAtaque(P1)-ValorDefenza(P2))/50)*100);
                    if (P2.Salud > 0)
                    {
                        P1.Salud = P1.Salud - normalizador(((ValorAtaque(P2)-ValorDefenza(P1))/50)*100);
                    }
                }else
                {
                    P1.Salud = P1.Salud - normalizador(((ValorAtaque(P2)-ValorDefenza(P1))/50)*100);
                    if (P1.Salud > 0)
                    {
                        P2.Salud = P2.Salud - normalizador(((ValorAtaque(P1)-ValorDefenza(P2))/50)*100);
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
    public static Personaje Bonus(Personaje P){
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

    public static int normalizador(int valor){
        if (valor < 0)
        {
            return 0;
        }else
        {
            return valor;
        }
    }

    //guardado de archivo
    public static void guardado(Personaje Ganador){
        string NombreArchivo = @"C:\Users\usuario\Documents\1er2022\taller1\ganadores\ListaGanadores.csv";

        if(!File.Exists(NombreArchivo)){
            File.Create(NombreArchivo);
        }
        FileStream filestream = new FileStream(NombreArchivo, FileMode.Open);
        StreamWriter streamWriter = new StreamWriter(filestream);

        streamWriter.WriteLine(Ganador.Nombre +"; "+Ganador.Apodo+ "; "+Ganador.Tipo+"; "+"Lv: "+ Ganador.Nivel+";");
        streamWriter.Close();
        filestream.Close();
    }

    public static void guardarParticipantes(List<Personaje> Participantes){
        

        if (!File.Exists(NombreArchivoJson))                                                //si no existe el archivo lo crea
        {
            
            File.Create(NombreArchivoJson);
            
        }
        string json;                                                                    //string para lo  que devuelva el stream serialize
        

        FileStream filestreamJson = new FileStream(NombreArchivoJson, FileMode.Open);           
        StreamWriter streamWriterJson = new StreamWriter(filestreamJson);

        json =  JsonSerializer.Serialize(Participantes);                            //serializa la lista
            
        streamWriterJson.WriteLine(json);                                           //escribo en el json

        streamWriterJson.Close();                                                       //cierro
        filestreamJson.Close();
    }

    public static List<Personaje> clasificaciones(List<Personaje> Participantes){
        List<Personaje> EnCarrera = new List<Personaje>(); 
        Personaje Ganador = new Personaje();
        int restantes = Participantes.Count;   
        int total = restantes;
        for (int i = 0; i < total; i = i + 2)
        {
            
            Ganador = Combate(Participantes[i], Participantes[i+1]);
            if (Ganador != null)
            {
                Ganador = Bonus(Ganador);
                EnCarrera.Add(Ganador);
                restantes -= 1;
            }else
            {
                restantes -= 2;
            }
        }
        return EnCarrera;
    }
}

