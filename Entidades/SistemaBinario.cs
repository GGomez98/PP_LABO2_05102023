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

        private bool EsSistemaBinarioValido(string valor)
        {
            foreach (char caracter in valor)
            {
                if (caracter != '0' && caracter != '1')
                {
                    return false;
                }
            }
            return true;
        }

        public override Numeracion CambiarSistemaDeNumeracion(ESistema sistema)
        {
            if (sistema == ESistema.Binario)
            {
                return this;
            }
            else
            {
                return this.BinarioADecimal();
            }
        }

        protected bool EsNumeracionValida(string valor)
        {
            return valor is not null && this.EsSistemaBinarioValido(valor);
        }

        private SistemaDecimal BinarioADecimal()
        {
            if(Valor == this.msgError)
            {
                return double.MinValue;
            }
            else
            {
                double numDecimal = Convert.ToInt32(Valor, 2);
                SistemaDecimal decimalABinario = new SistemaDecimal(numDecimal.ToString());
                return decimalABinario;
            }
            
        }

        public static implicit operator SistemaBinario(string valor)
        {
            SistemaBinario sistemaBinario = new SistemaBinario(valor);
            return sistemaBinario;
        }
    }
}
