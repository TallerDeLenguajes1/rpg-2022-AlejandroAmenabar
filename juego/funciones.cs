namespace juego
{
    static class funciones
    {
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
    }
}