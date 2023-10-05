namespace Entidades
{
    public enum ESistema
    {
        Binario,
        Decimal
    }
    public abstract class Numeracion
    {
        protected string msgError;
        protected string valor;

        public string Valor { get => valor; }
        protected double valorNumerico { get => (double)this; }

        private Numeracion()
        {
            this.msgError = "Numero Invalido";
        }
        protected Numeracion(string valor): this()
        {
            this.InicializarValor(valor);
        }

        private void InicializarValor(string valor)
        {
            if (this.EsNumeracionValida(valor))
            {
                this.valor = valor;
            }
            else
            {
                this.valor = this.msgError;
            }
        }

        public abstract Numeracion CambiarSistemaDeNumeracion(ESistema sistema);

        protected bool EsNumeracionValida(string valor)
        {
            if(valor is not null && !valor.Contains(" "))
            {
                return true;
            }
            return false;
        }

        public static explicit operator double(Numeracion numeracion)
        {
            double valorNumerico;
            double.TryParse(numeracion.Valor, out valorNumerico);
            return valorNumerico;
        }

        public static bool operator == (Numeracion n1, Numeracion n2)
        {
            return (n1 is not null && n2 is not null) && n1.GetType() == n2.GetType();
        }

        public static bool operator !=(Numeracion n1, Numeracion n2)
        {
            return (n1 is null || n2 is null) || n1.GetType() != n2.GetType();
        }
    }
}