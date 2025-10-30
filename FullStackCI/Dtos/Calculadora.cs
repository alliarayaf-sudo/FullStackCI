namespace FullStackCI.Dtos
{
    public class Calculadora
    {
        //Crea los metodos de una calculadora sumar, restar, dividir, multiplicar
        public int Numero1 { get; set; }
        public int Numero2 { get; set; }
        public string Operacion { get; set; } = string.Empty;
        public double Resultado { get; set; }
        public double Calcular()
        {
            switch (Operacion)
            {
                case "sumar":
                    return Resultado = Numero1 + Numero2;
                    break;
                case "restar":
                    return Resultado = Numero1 - Numero2;
                    break;
                case "multiplicar":
                    return Resultado = Numero1 * Numero2;
                    break;
                case "dividir":
                    if (Numero2 != 0)
                    {
                        return Resultado = (double)Numero1 / Numero2;
                    }
                    else
                    {
                        throw new DivideByZeroException("No se puede dividir por cero");
                    }
                    break;
                default:
                    throw new InvalidOperationException("Operación no válida");
            }
        }

        public double Sumar (double n1, double n2)
        {
            return n1 + n2;
        }

        public double Restar(double n1, double n2)
        {
            return n1 - n2;
        }

        public double Multiplicar(double n1, double n2)
        {
            return n1 * n2;
        }

        public double Dividir(double n1, double n2)
        {
            return n1 / n2;
        }
    }
}
