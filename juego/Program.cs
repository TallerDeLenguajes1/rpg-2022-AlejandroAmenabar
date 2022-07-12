using System.IO;
using System;
using System.Net;
using System.Text.Json;
using System.Text.Json.Serialization;
using juego;

public class program{
    public static string rutaJson = @"C:\Users\Alejandro\Documents\INGENIERIA\3ero\Taller1\rpg-2022-AlejandroAmenabar\jugadores.json";
    public static void Main(String[] args){

        List<personajes> Personajes = new List<personajes>();

        Console.WriteLine("\nDesea crear participantes nuevos? 1-si 0-no");
        int opcion = Convert.ToInt32(Console.ReadLine());
        if (opcion == 0)
        {
            if (!File.Exists(rutaJson))
            {
                Console.WriteLine("No existe un Json de participantes. Creando nuevos participantes...");
                opcion = 1;
            }else{ 
                StreamReader sr = new StreamReader(rutaJson);
                string datoJson = sr.ReadLine();
            
                Personajes = JsonSerializer.Deserialize<List<personajes>>(datoJson);

                sr.Close();
            }
        }
        if (opcion == 1)                                      
        {
            if (File.Exists(rutaJson))                                               
            {
                FileStream filestreamJson = new FileStream(rutaJson, FileMode.Open);           
                filestreamJson.SetLength(0);
                filestreamJson.Close(); 
            }                                      
            //---API----
            List<Caracther> personajesGot = funciones.DescargarApi();
            //------INICIALIZANDO
            Personajes = funciones.crearLista(personajesGot);
            //--------FILES JSON--------
            funciones.CrearFileJson(Personajes);
        }

        //-----COMBATE-----
        //fijarme si esta bien la cantidad de combates
        //revisar las formulas de los ataques
        //revisar el remove de la lista cuando pierde
        //de ahi en mas creo que todo bien
        funciones.Combate(Personajes);

        //-------FILES-------------
        funciones.CrearFileCSV(Personajes);
    }
}














