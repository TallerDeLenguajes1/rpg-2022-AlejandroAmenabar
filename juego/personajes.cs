
namespace juego
{
    public class personajes 
    {
        
        //-----------------CARACTERISTICAS----------------
        public int velocidad;
        public int destreza;
        public int fuerza;
        public int nivel;
        public int armadura;

        

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
        //string[] tipo = {"pony","caballo","burro"};
        string ? tipo;
        List<string> tipos = new List<string>()
        {
            "WhiteWalkers",
            "Lannister",
            "Dothraki",
            "Stark",
            "Baratheon",
            "Targaryen",
            "Snow",
            "Tyrell",
        };
        //string[] nombre = {"pepita","pepito","juancito","pablito"};
        public string ? nombre;
        List<string> nombres = new List<string>()
        {
            "pepita",
            "Carlos",
            "griselda",
            "Jon",
            "Aegon",
            "Daenerys",
            "Sansa",
            "Arya",
        };

        //string[] apodo = {"piper","elbromas","azucar"};
        string ? apodo;
        List<string> apodos = new List<string>()
        {
            "piper",
            "elbromas",
            "azucar",
            "caniche",
            "mocho",
            "calvin",
            "Cuasimodo",
            "llaverito",
        };

        DateTime fechaNacimiento;
        int edad;
        public int salud;        
        public void cargarDatosAleatorios()
        {
            var rnd1 = new Random();
            nombre = nombres[rnd1.Next(0,nombres.Count)];
            tipo = tipos[rnd1.Next(0,tipos.Count)];
            apodo = apodos[rnd1.Next(0,apodos.Count)];

            fechaNacimiento = new DateTime(rnd1.Next(1780, 2005), rnd1.Next(1, 13),rnd1.Next(1, 29));//mostrar año con los 4 numeros
            DateTime Actual = DateTime.Today;
            edad = Convert.ToInt32(Actual.Year - fechaNacimiento.Year);

            salud=100;        
        }
        public void mostrarDatos(personajes personaje)
        {
            Console.WriteLine("Nombre: "+ personaje.nombre); 
            Console.WriteLine("Apodo: "+ personaje.apodo); 
            Console.WriteLine("Tipo: "+ personaje.tipo); 
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
            maximoDanio = 20;
            danioProvocado = ((valorDeAtaque - poderDefensa)/maximoDanio); //le saque el *100 y efectividadDeDisparo
        } //si no los hago public no puedo llamarlos desde program, pero si los hago public no los deberia usar en la funcion, hice una funcion de combate directamente

        public void Combate(personajes luchador1, personajes luchador2)
        {
            luchador1.salud = Convert.ToInt32(luchador1.salud - luchador2.danioProvocado);
            luchador2.salud = Convert.ToInt32(luchador2.salud - luchador1.danioProvocado);
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