
namespace juego
{
    public class personajes 
    {
        
        //caracteristicas
        public int velocidad;
        public int destreza;
        public int fuerza;
        public int nivel;
        public int armadura;

        //datos
        //string[] tipo = {"pony","caballo","burro"};
        string ? tipo;
        List<string> tipos = new List<string>()
        {
            "tipo1",
            "tipo2",
            "tipo3",
        };
        //string[] nombre = {"pepita","pepito","juancito","pablito"};
        string ? nombre;
        List<string> nombres = new List<string>()
        {
            "pepita",
            "pepito",
            "griselda",
        };

        //string[] apodo = {"piper","elbromas","azucar"};
        string ? apodo;
        List<string> apodos = new List<string>()
        {
            "piper",
            "elbromas",
            "azucar",
        };

        DateTime fechaNacimiento;
        int edad;
        int salud;

        public void cargarCaracteristicasAleatorias()
        {
            Random rnd = new Random();
            velocidad = rnd.Next(1,11);
            destreza = rnd.Next(1,11);
            fuerza = rnd.Next(1,11);
            nivel = rnd.Next(1,11);
            armadura = rnd.Next(1,11);
        }

        
        public void cargarDatosAleatorios()
        {
            var rnd1 = new Random();
            nombre = nombres[rnd1.Next(0,nombres.Count)];
            tipo = tipos[rnd1.Next(0,tipos.Count)];
            apodo = apodos[rnd1.Next(0,apodos.Count)];

            DateTime nacimiento = new DateTime(rnd1.Next(1780, 2005), rnd1.Next(1, 13),rnd1.Next(1, 28));
            edad = rnd1.Next(0,301);//no seas pete ale, buscar la funcion del tp6 y restar fecha de nacimiento y actual

            salud=100;
            
        }
    }
    
}