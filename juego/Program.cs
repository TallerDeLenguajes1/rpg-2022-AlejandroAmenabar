using juego;
// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

List<personajes> Personajes = new List<personajes>();

for (int i = 1; i < 10; i++)
{
    personajes personaje = new personajes();
    Console.WriteLine("\n\nPERSONAJE "+i+":");
    personaje.cargarDatosAleatorios();
    Console.WriteLine("\tDatos del personaje "+ i + ":");
    personaje.mostrarDatos(personaje);
    personaje.cargarCaracteristicasAleatorias();
    Console.WriteLine("\tCaracteristicas del personaje "+ i + ":");
    personaje.mostrarCaracteristicas(personaje);
    Personajes.Add(personaje); //agrego el personaje creado a la lista de personajes
}
//hasta aca todo bien 

//-----COMBATE-----
var rnd = new Random();
personajes luchador1 = Personajes[rnd.Next(0,Personajes.Count)];
luchador1.generarDatosCombate(luchador1);

personajes luchador2 = Personajes[rnd.Next(0,Personajes.Count)];
luchador2.generarDatosCombate(luchador2);

for (int i = 0; i < 3; i++)
{
    luchador1.Combate(luchador1,luchador2);
}

System.Console.WriteLine("\n\nResultados del Combate"); //revisar no me da bien todavia
System.Console.WriteLine("\nluchador 1");
luchador1.mostrarCaracteristicas(luchador1);
luchador1.mostrarDatos(luchador1);
System.Console.WriteLine("\nluchador 2");
luchador1.mostrarCaracteristicas(luchador2);
luchador1.mostrarDatos(luchador2);





