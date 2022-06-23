namespace RPG;


public class Personaje{
    public Personaje(){}
    public int Velocidad{get; set;}
    public int Destreza{get; set;}
    public int Fuerza{get; set;}
    public int Nivel{get; set;}
    public int Armadura{get; set;}
    public string Tipo{get; set;}
    public string Nombre{get; set;}
    public string Apodo{get; set;}
    public DateTime Nacimiento{get; set;}
    public int Edad{get; set;}
    public int Salud{get; set;}

    public void MostrarPersonajeDatos(){
        Console.WriteLine("-------------Datos-------------");
        Console.WriteLine("Nombre: "+ this.Nombre);
        Console.WriteLine("Apodo: "+ this.Apodo);
        Console.WriteLine("Edad: "+ this.Edad);
        Console.WriteLine("Fecha de nacimiento: "+ this.Nacimiento.ToLongDateString());
        Console.WriteLine("Clase: "+ this.Tipo);
    }

    public void MostrarPersonajeCaracteristicas(){
        Console.WriteLine("-------------Caracteristicas-------------");
        Console.WriteLine("Nivel: "+ this.Nivel);
        Console.WriteLine("Velocidad: "+ this.Velocidad);
        Console.WriteLine("Destreza: "+ this.Destreza);
        Console.WriteLine("Fuerza: "+ this.Fuerza);
        Console.WriteLine("Armadura: "+ this.Armadura);
    }
}