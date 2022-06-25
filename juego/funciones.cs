using System.Text.Json;
namespace juego
{
    static class funciones
    {
        //------INICIALIZANDO-------
        public static List<personajes> crearLista()
        {
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

            return Personajes;
        }
        //---------COMBATE-----------
        public static List<personajes> Combate(List<personajes> Personajes)
        {
            var rnd = new Random();
            
            for (int i = 0; i < Personajes.Count; i++) 
            {
                var numero1 = rnd.Next(0,Personajes.Count);
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

                System.Console.WriteLine("\n\nResultados del Combate"+i); //revisar no me da bien todavia
                System.Console.WriteLine("\nluchador 1");
                luchador1.mostrarCaracteristicas(luchador1);
                luchador1.mostrarDatos(luchador1);
                
                System.Console.WriteLine("\nluchador 2");
                luchador2.mostrarCaracteristicas(luchador2);
                luchador2.mostrarDatos(luchador2);

                if(luchador1.salud > luchador2.salud){
                    Personajes.Remove(luchador2);
                }else{
                    Personajes.Remove(luchador1);
                }
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
                //controlar si ya estan creados o no cuadno ya existe el archivo  
                lectura.WriteLine("Personajes Ganadores"+";"+"Fuerza"+";"+"Salud"+"\n" );
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