using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class SistemaBinario : Numeracion
    {
        internal double ValorNumerico { get => base.valorNumerico; }

        public SistemaBinario(string valor) : base(valor) { }
    }
}
