using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cidi.Model
{
    public class UsuarioCidiModel
    {
        public String CUIL { get; set; }
        public String CuilFormateado { get; set; }
        public String NroDocumento { get; set; }
        public String Apellido { get; set; }
        public String Nombre { get; set; }
        public String NombreFormateado { get; set; }
        public String FechaNacimiento { get; set; }
        public String Id_Sexo { get; set; }
        public String PaiCodPais { get; set; }
        public int Id_Numero { get; set; }
        public int? Id_Estado { get; set; }
        public String Estado { get; set; }
        public String Email { get; set; }
        public String TelArea { get; set; }
        public String TelNro { get; set; }
        public String TelFormateado { get; set; }
        public String CelArea { get; set; }
        public String CelNro { get; set; }
        public String CelFormateado { get; set; }
        public String Empleado { get; set; }
        public String Id_Empleado { get; set; }
        public String FechaRegistro { get; set; }
        public String FechaBloqueo { get; set; }
        public String IdAplicacionOrigen { get; set; }
        public String TieneRepresentados { get; set; }
        public Afip Afip { get; set; }
        public Domicilio Domicilio { get; set; }
        public Representado Representado { get; set; }
        public Respuesta Respuesta { get; set; }
        public string foto { get; internal set; }

        public static String CiDi_OK
        {
            get
            {
                return "OK";
            }
        }
        public UsuarioCidiModel()
        {
            Afip = new Afip();
            Domicilio = new Domicilio();
            Representado = new Representado();
            Respuesta = new Respuesta();
        }
    }
    public class Domicilio
    {
        public String IdPais { get; set; }
        public String Pais { get; set; }
        public String IdProvincia { get; set; }
        public String Provincia { get; set; }
        public int IdDepartamento { get; set; }
        public String Departamento { get; set; }
        public int IdLocalidad { get; set; }
        public String Localidad { get; set; }
        public int IdBarrio { get; set; }
        public String Barrio { get; set; }
        public String Calle { get; set; }
        public String Altura { get; set; }
        public String CodigoPostal { get; set; }
        public String Piso { get; set; }
        public String Depto { get; set; }
        public String Torre { get; set; }
        public String Manzana { get; set; }
        public String Lote { get; set; }
    }

    public class Representado
    {
        public String RdoCuilCuit { get; set; }
        public String RdoNombre { get; set; }
        public String RdoDenominacion { get; set; }
        public String RdoTipo { get; set; }
        public int? RdoIdEstado { get; set; }
    }
    public class Respuesta
    {
        public String Resultado { get; set; }
        public String CodigoError { get; set; }
        public String ExisteUsuario { get; set; }
        public String SesionHash { get; set; }
    }
    public class Afip
    {
        public String Login { get; set; }
        public String Fecha { get; set; }
    }

}