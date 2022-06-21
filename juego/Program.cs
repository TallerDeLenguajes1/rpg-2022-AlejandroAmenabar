using juego;
using System.IO;

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

List<personajes> Personajes = funciones.crearLista();


//hasta aca todo bien 

//-----COMBATE-----

//fijarme si esta bien la cantidad de combates
//revisar las formulas de los ataques
//revisar el remove de la lista cuando pierde
//de ahi en mas creo que todo bien

funciones.Combate(Personajes);

//-------FILES-------------

string ruta = @"C:\Users\Alejandro\Documents\INGENIERIA\3ero\Taller1\rpg-2022-AlejandroAmenabar";

string archivo = ruta + @"\ganadores.csv";
FileStream FS;
if(!File.Exists(archivo)){
    FS=File.Create(archivo);
    FS.Close();
}

using(StreamWriter lectura = File.AppendText(archivo)) //con el using ya no dependo del close
{ 
    //controlar si ya estan creados o no cuadno ya existe el archivo  
    lectura.WriteLine("Personajes Ganadores"+";"+"Fuerza"+";"+"Salud"+"\n" );
    lectura.WriteLine(Personajes[0].nombre + ";"+ Personajes[0].fuerza +";"+ Personajes[0].salud);
} 













