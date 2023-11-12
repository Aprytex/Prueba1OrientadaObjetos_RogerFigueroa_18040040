public class Empleado
{
    public string Cedula { get; set; }
    public string Nombre { get; set; }
    public bool Activo { get; set; }

    public Empleado() 
    {
        Cedula = "";
        Nombre = "";
        Activo = true;
    }

    public Empleado(string cedula, string nombre, bool activo) 
    {
        Cedula = cedula;
        Nombre = nombre;
        Activo = activo;
    }

    public virtual double CalcularSalario()
    {

        return 0.0;
    }

    public override string ToString()
    {
        return $"Cédula: {Cedula}, Nombre: {Nombre}, Activo: {(Activo ? "Si" : "No")}";
    }

    public class EmpleadoAsalariado : Empleado
    {
        public double SalarioMensual { get; set; }

        public EmpleadoAsalariado()
        {
            SalarioMensual = 0.0;
        }

        public EmpleadoAsalariado(string cedula, string nombre, bool activo, double salarioMensual) : base(cedula, nombre, activo) 
        {
            SalarioMensual = salarioMensual;
        }

        public override double CalcularSalario()
        {
            return SalarioMensual;
        }

        public override string ToString()
        {
            return $"Tipo: Asalariado, {base.ToString()}, Salario Mensual: {SalarioMensual:C}";
        }
    }

    public class EmpleadoPorHora : Empleado
    {
        public double PrecioHora { get; set; }
        public int HorasTrabajadas { get; set; }

        public EmpleadoPorHora()
        {
            PrecioHora = 0.0;
            HorasTrabajadas = 0;
        }

        public EmpleadoPorHora(string cedula, string nombre, bool activo, double precioHora, int horasTrabajadas) : base(cedula, nombre, activo) 
        {
            PrecioHora = precioHora;
            HorasTrabajadas = horasTrabajadas;
        }

        public override double CalcularSalario()
        {
            return PrecioHora * HorasTrabajadas;
        }

        public override string ToString()
        {
            return $"Tipo: Por Hora, {base.ToString()}, Precio por Hora: {PrecioHora:C}, Horas Trabajadas: {HorasTrabajadas}, Salario: {CalcularSalario():C}";
        }
    }

    public class EmpleadoPorComision : Empleado
    {
        public double VentasMensuales { get; set; }
        public double PorcentajeComision { get; set; }

        public EmpleadoPorComision()
        {
            VentasMensuales = 0.0;
            PorcentajeComision = 0.0;
        }

        public EmpleadoPorComision(string cedula, string nombre, bool activo, double ventasMensuales, double porcentajeComision) : base(cedula, nombre, activo)
        {
            VentasMensuales = ventasMensuales;
            PorcentajeComision = porcentajeComision;
        }

        public override double CalcularSalario()
        {
            return VentasMensuales * (PorcentajeComision / 100);
        }

        public override string ToString()
        {
            return $"Tipo: Por Comisión, {base.ToString()}, Ventas Mensuales: {VentasMensuales:C}, Porcentaje de Comisión: {PorcentajeComision}%, Salario: {CalcularSalario():C}";
        }
    }
}