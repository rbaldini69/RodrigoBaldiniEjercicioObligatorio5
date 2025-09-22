using System;

namespace RodrigoBaldiniEjercicioObligatorio5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MaquinaVirtualAplicacion maquinaVirtual1 = new MaquinaVirtualAplicacion("MV1", "Linux", "1.0", false, "C#", "9.0", "http://baseVM1");
            MaquinaVirtualAplicacion maquinaVirtual2 = new MaquinaVirtualAplicacion("MV2", "Windows", "11.0", false,"javascript", "9.0", "http://baseVM2");
            MaquinaVirtualProceso maquinaVirtual3 = new MaquinaVirtualProceso("MV3", "Linux", "1.0", false, "http://origenVM3", "http://finVM3");
            MaquinaVirtualProceso maquinaVirtual4 = new MaquinaVirtualProceso("MV4", "Windows", "11.0", false, "", "http://finVM4");//sin datos de origen

            MaquinaVirtual[] maquinas = new MaquinaVirtual[] { maquinaVirtual1, maquinaVirtual2,maquinaVirtual3,maquinaVirtual4 };
            Console.WriteLine("Levantando todas las maquinas virtuales:");
            foreach (var maquina in maquinas)
            {
                maquina.Levantar();
            }
            Console.WriteLine("\n Bajando algunas maquinas virtuales:");
            maquinaVirtual3.Bajar();

            
            Console.WriteLine("\n Listado de maquinas virtuales:");
            foreach (var maquina in maquinas)
            {
                if (maquina is MaquinaVirtualAplicacion)
                {
                    maquina.Listar();
                }
                else if(maquina is MaquinaVirtualProceso){
                    maquina.Listar();
                }
            }

        }
    }
    public abstract class MaquinaVirtual
    {
        protected string Nombre;
        protected string SistemaOperativo;
        protected string version;
        protected bool Estado;
        public MaquinaVirtual(string Nombre, string SistemaOperativo, string version, bool Estado)
        {
            this.Nombre = Nombre;
            this.SistemaOperativo = SistemaOperativo;
            this.version = version;
            this.Estado = Estado;
        }
        public virtual void Levantar()
        {
            this.Estado = true;
            
            Console.WriteLine($"\n Maquina virtual {this.Nombre} levantada correctamente");
        }
        public virtual void Bajar()
        {
            this.Estado = false;
            Console.WriteLine($"\n Maquina virtual {this.Nombre} Bajada correctamente");
        }
       public abstract void Listar();
    }
    public class MaquinaVirtualProceso: MaquinaVirtual
    {
        private string datosOrigen;
        private string datosFin;
        public MaquinaVirtualProceso(string Nombre, string SistemaOperativo, string version, bool estado, string datosOrigen, string datosFin)
            : base(Nombre, SistemaOperativo, version, estado) 
        {
            this.datosOrigen = datosOrigen;
            this.datosFin = datosFin;
        }
        public override void Levantar()
        {
            if (!verificarBases(this))
            {
                Console.WriteLine($"Error:No se pudo levantar {this.Nombre} Datos incompletos");
                return;
            }
            base.Levantar();
            Console.WriteLine($" datos origen: {datosOrigen}\n datos fin: {datosFin}");
            return;
        }
        public bool verificarBases(MaquinaVirtualProceso MVP)
        {
            if (string.IsNullOrEmpty(MVP.datosOrigen)||string.IsNullOrEmpty(MVP.datosFin))
            {
                return false;
            }
            for (int i = 0; i < 50; i++)
            {
                Console.Write("-");
            }
            Console.WriteLine("\n Verificando bases de datos...");
            Console.WriteLine("Resultado OK con acceso a datos de origen y fin!");
            return true;
        }
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
        public override void Listar()
        {
            Console.WriteLine($"Maquina Virtual de Proceso: {this.Nombre}, SO: {this.SistemaOperativo}, Version: {this.version}, Estado: {(this.Estado ? "Levantada" : "Bajada")}");
        }
    }
    public class MaquinaVirtualAplicacion: MaquinaVirtual
    {
        private string lenguajeDeProgramación;
        private string VersionDelLenguaje;
        private string BaseDeDatos;

        public MaquinaVirtualAplicacion(string Nombre, string SistemaOperativo, string version, bool estado,
                                        string lenguajeDeProgramacion, string versionDelLenguaje,string baseDeDatos)
            : base(Nombre, SistemaOperativo, version, estado)
        {
            this.lenguajeDeProgramación= lenguajeDeProgramacion;
            this.VersionDelLenguaje= versionDelLenguaje;
            this.BaseDeDatos= baseDeDatos;
        }
        public override void Levantar()
        {
            if (!verificarDatos(this))
            {
                Console.WriteLine($"Error:No se pudo levantar {this.Nombre} Datos incompletos");
                return;
            }
            base.Levantar();
            Console.WriteLine($" lenguaje: {lenguajeDeProgramación}\n version: {VersionDelLenguaje}\n BD:{BaseDeDatos}");
            return;
        }

        public bool verificarDatos(MaquinaVirtualAplicacion MVA)
        {
            if (string.IsNullOrEmpty(MVA.lenguajeDeProgramación)||string.IsNullOrEmpty(MVA.VersionDelLenguaje)||string.IsNullOrEmpty(MVA.BaseDeDatos))
            {
                return false;
            }
            for (int i = 0; i < 50; i++)
            {
                Console.Write("-");
            }
            Console.WriteLine("\n Verificando datos...");
            Console.WriteLine("Resultado OK!");
            return true;
        }
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
        public override void Listar()
        {
            Console.WriteLine($"Maquina Virtual de Aplicacion: {this.Nombre}, SO: {this.SistemaOperativo}, Version: {this.version}, Estado: {(this.Estado ? "Levantada" : "Bajada")}");
        }
    }
}
