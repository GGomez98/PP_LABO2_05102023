using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Calculadora
    {
        private string nombreAlumno;
        private List<string> operaciones;
        private Numeracion primerOperando;
        private Numeracion segundoOperando;
        private Numeracion resultado;
        private static ESistema sistema;

        public string NombreAlumno { get => nombreAlumno; set => nombreAlumno = value; }
        public List<string> Operaciones { get => operaciones; }
        public Numeracion PrimerOperando { get => primerOperando; set => primerOperando = value; }
        public Numeracion SegundoOperando { get => segundoOperando; set => segundoOperando = value; }
        public Numeracion Resultado { get => resultado; }
        public static ESistema Sistema { get => sistema; set => sistema = value; }

        public Calculadora() 
        {
            this.nombreAlumno = "";
            this.operaciones = new List<string>();
            this.primerOperando = new SistemaDecimal("");
            this.segundoOperando = new SistemaDecimal("");
            this.resultado = new SistemaDecimal("");
            sistema = ESistema.Decimal;
        }

        public Calculadora(string nombreAlumno) :this() 
        {
            this.nombreAlumno = nombreAlumno;
        }

        public void Calcular(char operador)
        {
        }
    }
}
