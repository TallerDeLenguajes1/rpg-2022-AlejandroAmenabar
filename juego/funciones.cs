using System.Net;
using System.Text.Json;
using System.Text.Json.Serialization;
namespace juego
{
    static class funciones
    {
        //----API------------
        public static List<Caracther> DescargarApi()
        {
            List<Caracther> personajesGot;
            var url = $"https://thronesapi.com/api/v2/Characters";
            var request = (HttpWebRequest) WebRequest.Create(url);
            request.Method = "GET";
            request.ContentType = "application/json";
            request.Accept = "application/json";
            try{
                using(WebResponse respuesta = request.GetResponse()){
                    using(Stream StreamReader = respuesta.GetResponseStream()){
                        if (StreamReader != null)
                        {
                            using (StreamReader objReader = new StreamReader(StreamReader))
                            {
                                string responseBody = objReader.ReadToEnd();
                                personajesGot = JsonSerializer.Deserialize<List<Caracther>>(responseBody);
                            }
                            return personajesGot;   
                        }else
                        {
                            Console.WriteLine("No Responde");
                            return null;
                        }
                    }
                }
                
            }catch(WebException e){
                    Console.WriteLine(e.ToString());
                    return null;
            }
        }
        //------INICIALIZANDO-------
        public static List<personajes> crearLista(List<Caracther> personajesGot)
        {
            List<personajes> Personajes = new List<personajes>();

            for (int i = 1; i < 11; i++)
            {
                personajes personaje = new personajes();
                Console.WriteLine("\n\nPERSONAJE "+i+":");
                personaje.cargarDatosAleatorios(personajesGot);
                Console.WriteLine("\tDatos del personaje "+ i + ":");
                personaje.mostrarDatos(personaje);
                personaje.cargarCaracteristicasAleatorias();
                Console.WriteLine("\tCaracteristicas del personaje "+ i + ":");
                personaje.mostrarCaracteristicas(personaje);
                Personajes.Add(personaje); //agrego el personaje creado a la lista de personajes
            }

            return Personajes;
        }
        //---------COMBATE-----------
        public static List<personajes> Combate(List<personajes> Personajes)
        {
            var rnd = new Random();
            int techo = Personajes.Count;
            
            for (int i = 0; i < techo-1; i++) 
            {
                var numero1 = rnd.Next(0,Personajes.Count); //no necesito 0
                int numero2;
                do
                {
                    numero2=rnd.Next(0,Personajes.Count); //para que no se repita el personaje
                } while (numero1==numero2);

                personajes luchador1 = Personajes[numero1];
                luchador1.generarDatosCombate(luchador1);

                personajes luchador2 = Personajes[numero2];
                luchador2.generarDatosCombate(luchador2);

                for (int j = 0; j < 3; j++)
                {
                    luchador1.Combate(luchador1,luchador2);
                }

                System.Console.WriteLine("\n\nResultados del Combate "+i); 
                System.Console.WriteLine("\nluchador 1");
                luchador1.mostrarCaracteristicas(luchador1);
                luchador1.mostrarDatos(luchador1);
                
                System.Console.WriteLine("\nluchador 2");
                luchador2.mostrarCaracteristicas(luchador2);
                luchador2.mostrarDatos(luchador2);

                if(luchador1.salud > luchador2.salud){
                    Personajes.Remove(luchador2);
                    Console.WriteLine("\n El ganador es: " + luchador1.nombre);
                    luchador1.beneficiosGanador(luchador1);
                }else{
                    Personajes.Remove(luchador1);
                    Console.WriteLine("\n El ganador es: " + luchador2.nombre);
                    luchador2.beneficiosGanador(luchador2);
                }
                Console.ReadKey(true);
                //agregar pausa al final de cada batalla; 
            }

            System.Console.WriteLine("\nEl GANADOR de todos los combates es: \n ");
            Personajes[0].mostrarDatos(Personajes[0]);

            return Personajes;
        }

        //-------CREAR FILE CSV
        public static void CrearFileCSV(List<personajes> Personajes)
        {
            string ruta = @"C:\Users\Alejandro\Documents\INGENIERIA\3ero\Taller1\rpg-2022-AlejandroAmenabar";

            string archivo = ruta + @"\ganadores.csv";
            FileStream FS;
            if(!File.Exists(archivo)){
                FS=File.Create(archivo);
                FS.Close();
            }

            using(StreamWriter lectura = File.AppendText(archivo)) //con el using ya no dependo del close
            { 
                lectura.WriteLine(Personajes[0].nombre + ";"+ Personajes[0].fuerza +";"+ Personajes[0].salud);
            } 
        }

        //------CREAR FILE JSON ------------
        public static void CrearFileJson(List<personajes> Personajes)
        {
            string ruta = @"C:\Users\Alejandro\Documents\INGENIERIA\3ero\Taller1\rpg-2022-AlejandroAmenabar";
            if(Directory.Exists(ruta))
            {
                string nombreArchivo = ruta + @"\jugadores.json";
                FileStream FS;
                if(!File.Exists(nombreArchivo)){
                    FS=File.Create(nombreArchivo);
                    FS.Close();
                } 
                string json; //string para lo  que devuelva el stream serialize
                
                FileStream filestreamJson = new FileStream(nombreArchivo, FileMode.Open);           
                StreamWriter streamWriterJson = new StreamWriter(filestreamJson);

                json =  JsonSerializer.Serialize(Personajes); //serializa la lista
                
                    
                streamWriterJson.WriteLine(json); //escribo en el json

                streamWriterJson.Close();//cierro
                filestreamJson.Close();
            }
        }

    }
}