using Negocio.Mantenedor;

namespace API
{
    public record DepartamentoDTO(int id, string nombre, int id_sucursal);
    public record SucursalDTO(int id, string nombre, string direccion, string telefono, string rut);
    public record AdministradorDTO(string rut, string nombre, string apellido, string email);
    public record RegionesDTO(int id, string nombre, string provincias, string comunas, string ciudades)
    {
        public static implicit operator RegionesDTO(RegionesBL v)
        {
            throw new NotImplementedException();
        }
    }
}
