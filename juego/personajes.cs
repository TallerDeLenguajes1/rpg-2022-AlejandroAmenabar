using System.Net;
using System.Text.Json;
using System.Text.Json.Serialization;
namespace juego
{
    public class Caracther
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("firstName")]
        public string ? FirstName { get; set; }

        [JsonPropertyName("lastName")]
        public string ? LastName { get; set; }

        [JsonPropertyName("fullName")]
        public string ? FullName { get; set; }

        [JsonPropertyName("title")]
        public string ? Title { get; set; }

        [JsonPropertyName("family")]
        public string ? Family { get; set; }

        [JsonPropertyName("image")]
        public string ? Image { get; set; }

        [JsonPropertyName("imageUrl")]
        public string ? ImageUrl { get; set; }
    }

    public class personajes 
    {   
        
        //-----------------CARACTERISTICAS----------------
        public int velocidad{get;set;}
        public int destreza{get;set;}
        public int fuerza{get;set;}
        public int nivel{get;set;}
        public int armadura{get;set;}
        
        public void cargarCaracteristicasAleatorias()
        {
            Random rnd = new Random();
            velocidad = rnd.Next(1,11);
            destreza = rnd.Next(1,11);
            fuerza = rnd.Next(1,11);
            nivel = rnd.Next(1,11);
            armadura = rnd.Next(1,11);
        }

        public void mostrarCaracteristicas(personajes personaje)
        {
            Console.WriteLine("Velocidad: "+ personaje.velocidad); 
            Console.WriteLine("Destreza: "+ personaje.destreza); 
            Console.WriteLine("Fuerza: "+ personaje.fuerza); 
            Console.WriteLine("Nivel: "+ personaje.nivel); 
            Console.WriteLine("Armadura: "+ personaje.armadura); 
        }

        //-----------------DATOS-----------------------
        public string ? tipo{get;set;}

        public string ? nombre{get;set;}
        public string ? apodo{get;set;}
        DateTime fechaNacimiento{get;set;}
        public int edad{get;set;}
        public int salud{get;set;}        
        public void cargarDatosAleatorios(List<Caracther> personajesGot)
        {
            var rnd1 = new Random();
            int i = rnd1.Next(0,personajesGot.Count);
            nombre = personajesGot[i].FullName;
            tipo = personajesGot[i].Family;
            apodo = personajesGot[i].Title;

            fechaNacimiento = new DateTime(rnd1.Next(1780, 2005), rnd1.Next(1, 13),rnd1.Next(1, 29));//mostrar año con los 4 numeros
            DateTime Actual = DateTime.Today;
            edad = Convert.ToInt32(Actual.Year - fechaNacimiento.Year);

            salud=100;        
        }
        public void mostrarDatos(personajes personaje)
        {
            Console.WriteLine("Nombre: "+ personaje.nombre); 
            Console.WriteLine("Apodo: "+ personaje.apodo); 
            Console.WriteLine("Familia: "+ personaje.tipo); 
            Console.WriteLine("Fecha de Nacimiento: "+ fechaNacimiento.ToString("MM/dd/yyyy")); 
            Console.WriteLine("Edad: "+ personaje.edad); 
            Console.WriteLine("Salud: "+ personaje.salud); 

        }

        //--------------COMBATE-----------------
        int poderDisparo;
        int efectividadDisparo;
        int valorDeAtaque;
        int poderDefensa;
        int maximoDanio;
        float danioProvocado;
        public void generarDatosCombate(personajes personaje)
        {
            poderDisparo = personaje.destreza * personaje.fuerza * personaje.nivel;
            Random rnd = new Random();
            efectividadDisparo = rnd.Next(1,101); //asi o 0.01 a 0.9
            valorDeAtaque = poderDisparo * efectividadDisparo /100; //agregue el /100
            poderDefensa = personaje.armadura * personaje.velocidad;
            maximoDanio = 10;
            danioProvocado = ((valorDeAtaque - poderDefensa)/maximoDanio); //le saque el *100 y efectividadDeDisparo
        } 

        public void Combate(personajes luchador1, personajes luchador2)
        {
            if(luchador1.danioProvocado>0) {
                luchador2.salud = Convert.ToInt32(luchador2.salud - luchador1.danioProvocado);
            }
            if(luchador2.danioProvocado>0){
                luchador1.salud = Convert.ToInt32(luchador1.salud - luchador2.danioProvocado);
            }
        }
        public void beneficiosGanador(personajes luchador)
        {
            if(luchador.nivel<5){
                luchador.nivel++;
            }
            if(luchador.salud<80){
                luchador.salud+=10;
                luchador.fuerza+=2;
            }
        }
    }
    
}