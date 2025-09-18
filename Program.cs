namespace RodrigoBaldiniEjercicioObligatorio5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }
    public abstract class MaquinaVirtual
    {
        public string Nombre;
        public string SistemaOperativo;
        public string version;
        public bool Estado;

        public virtual void Levantar()
        {
            this.Estado = true;
        }
        public virtual void Bajar()
        {
            this.Estado = false;
        }
    }
    public class MaquinaVirtualProceso: MaquinaVirtual
    {
        string datosOrigen;
        string datosFin;

        public void ClonarBaseDatos() 
        {
            Console.WriteLine("Clonando base de datos...");
        }
        public void filtrarBaseDatos()
        {
            Console.WriteLine("Filtrando base de datos...");
        }
        public void AlmacenarBaseDatos(string datosOrigen,string datosFin)
        {
            Console.WriteLine($"acceso correcto a {datosOrigen} y a {datosFin}...");
        }
    }
    public class MaquinaVirtualAplicacion: MaquinaVirtual
    {

        public void InstalarAplicacion(string nombreApp)
        {
            Console.WriteLine($"Instalando aplicacion {nombreApp}...");
        }
        public void DesinstalarAplicacion(string nombreApp)
        {
            Console.WriteLine($"Desinstalando aplicacion {nombreApp}...");
        }
        public void ActualizarAplicacion(string nombreApp)
        {
            Console.WriteLine($"Actualizando aplicacion {nombreApp}...");
        }
    }
}
