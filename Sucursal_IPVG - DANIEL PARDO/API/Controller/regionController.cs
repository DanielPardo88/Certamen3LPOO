using API;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Modelos.Mantenedor;
using Negocio.Mantenedor;

namespace API.Controller
{

    [ApiController]
    public class RegionController : ControllerBase
    {
        Regiones reg = new Regiones();
        RegionesDTO regBL = new RegionesBL();
        ErrorResponse error;
        [HttpPost]
        [Route("api/v1/regiones/nuevo")]
        public ActionResult Create(RegionesDTO o)
        {
            try
            {
                reg.id = o.id;
                reg.nombre = o.nombre;
                reg.provincias = o.provincias;
                reg.comunas = o.comunas;
                reg.ciudades = o.ciudades;

                return Ok(regBL.Create(reg));
            }
            catch (Exception ex)
            {
                error = new ErrorResponse(ex);
                return StatusCode(500, error);
            }

        }

        [HttpGet]
        [Route("api/v1/regiones/listar")]
        public ActionResult Listar()
        {
            try
            {
                return Ok(convertList(regBL.Get(reg)));
            }
            catch (Exception ex)
            {
                error = new ErrorResponse(ex);
                return StatusCode(500, error);
            }

        }
        [HttpGet]
        [Route("api/v1/regiones/buscar_id")]
        public ActionResult BuscarId(int id)
        {
            try
            {
                reg.id = id;
                return Ok(convert(regBL.GetById(reg)));
            }
            catch (Exception ex)
            {
                error = new ErrorResponse(ex);
                return StatusCode(500, error);
            }

        }
        [HttpGet]
        [Route("api/v1/regiones/buscar_nombre")]
        public ActionResult BuscarNombre(string nombre)
        {
            try
            {
                reg.nombre = nombre;
                return Ok(convertList(regBL.GetQuery(reg)));
            }
            catch (Exception ex)
            {
                error = new ErrorResponse(ex);
                return StatusCode(500, error);
            }

        }

        [HttpDelete]
        [Route("api/v1/regiones/eliminar")]
        public ActionResult Eliminar(RegionesDTO o)
        {
            try
            {
                reg.id = o.id;
                return Ok(regBL.Delete(reg));
            }
            catch (Exception ex)
            {
                error = new ErrorResponse(ex);
                return StatusCode(500, error);
            }

        }

        [HttpPut]
        [Route("api/v1/regiones/actualizar")]
        public ActionResult Actualizar(RegionesDTO o)
        {
            try
            {
                reg.id = o.id;
                reg.nombre = o.nombre;
                reg.provincias = o.provincias;
                reg.comunas = o.comunas;
                reg.ciudades = o.ciudades;

                return Ok(regBL.Update(reg));
            }
            catch (Exception ex)
            {
                error = new ErrorResponse(ex);
                return StatusCode(500, error);
            }

        }

        private List<RegionesDTO> convertList(List<Regiones> lista)
        {
            List<RegionesDTO> list = new List<RegionesDTO>();
            foreach (var item in lista)
            {
                RegionesDTO el = new RegionesDTO(item.id, item.nombre, item.provincias, item.comunas, item.ciudades);
                list.Add(el);

            }
            return list;

        }
        private RegionesDTO convert(Regiones item)
        {
            RegionesDTO obj = new RegionesDTO(item.id, item.nombre, item.provincias, item.comunas, item.ciudades);
            return obj;

        }
    }
}