using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class SistemaDecimal : Numeracion
    {
        internal double ValorNumerico { get => base.valorNumerico; }

        public SistemaDecimal(string valor) : base(valor) { }

        private bool EsSistemaDecimalValido(string valor)
        {
            double valorDouble;
            bool esValido = double.TryParse(valor, out valorDouble);
            return esValido;
        }

        public override Numeracion CambiarSistemaDeNumeracion(ESistema sistema)
        {
            if(sistema == ESistema.Decimal)
            {
                return this;
            }
            else
            {
                return this.DecimalABinario();
            }
        }

        private SistemaBinario DecimalABinario()
        {
            SistemaBinario decimalABinario = new SistemaBinario(this.valor);
            int valor = (int)this.valorNumerico;
            if (this.valorNumerico >= 0)
            {
                if (this.valorNumerico == 0)
                {
                    return decimalABinario;
                }

                string binario = "";

                while (this.valorNumerico > 0)
                {
                    int aux = valor % 2;
                    binario = aux + binario;
                    valor /= 2;
                }
                SistemaBinario decimalABinarioConverido = new SistemaBinario(binario);

                return decimalABinarioConverido;
            }
            else
            {
                SistemaBinario decimalABinarioError = new SistemaBinario(this.msgError);
                return decimalABinarioError;
            }
        }

        protected bool EsNumeracionValida(string valor)
        {
            return this.EsNumeracionValida(valor) && this.EsSistemaDecimalValido(valor);
        }

        public static implicit operator SistemaDecimal(string valor)
        {
            SistemaDecimal sistemaDecimal = new SistemaDecimal(valor);
            return sistemaDecimal;
        }

        public static implicit operator SistemaDecimal(double valor)
        {
            SistemaDecimal sistemaDecimal = new SistemaDecimal(valor.ToString());
            return sistemaDecimal;
        }
    }
}
