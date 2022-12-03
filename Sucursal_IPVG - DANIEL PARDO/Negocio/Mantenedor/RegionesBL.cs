using Modelos.Mantenedor;
using Modelos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Mantenedor
{
    public class RegionesBL : ICrud<Regiones>
    {
        ResponseExec resp = new ResponseExec();

        public ResponseExec Create(Regiones o)
        {
            try
            {
                resp.error = !o.Data.execData("INSERT  INTO Regiones (id, provincias, comunas, ciudades ) VALUES('" + o.id + "','" + o.provincias + "', '" + o.comunas + "', '" + o.ciudades + "', '" + "')");
                resp.mensaje = "ok";
            }
            catch (Exception e)
            {
                resp.error = true;
                resp.mensaje = e.Message;

            }
            return resp;

        }

        public ResponseExec Delete(Regiones o)
        {
            try
            {
                resp.error = !o.Data.execData("DELETE FROM Regiones WHERE ID='" + o.id + "'");
                resp.mensaje = "ok";
            }
            catch (Exception e)
            {
                resp.error = true;
                resp.mensaje = e.Message;

            }
            return resp;
        }

        public List<Regiones> Get(Regiones o)
        {
            return convertToList(o.Data.queryData("SELECT * FROM Regiones"));

        }

        public Regiones GetById(Regiones o)
        {
            return convertToList(o.Data.queryData("SELECT * FROM Regiones WHERE ID='" + o.id + "'")).FirstOrDefault();

        }

        public List<Regiones> GetQuery(Regiones o)
        {
            return convertToList(o.Data.queryData("SELECT * FROM Regiones WHERE NOMBRE='" + o.nombre + "'"));
        }

        public ResponseExec Update(Regiones o)
        {
            try
            {
                resp.error = !o.Data.execData("UPDATE Regiones SET nombre='" + o.nombre + "', provincias='" + o.provincias + "', comunas='" + o.comunas + "', ciudades='" + o.ciudades + "' WHERE ID='" + o.id + "'");
                resp.mensaje = "ok";
            }
            catch (Exception e)
            {
                resp.error = true;
                resp.mensaje = e.Message;

            }
            return resp;
        }

        public List<Regiones> convertToList(DataTable dt)
        {
            List<Regiones> listado = new List<Regiones>();

            foreach (DataRow item in dt.Rows)
            {
                Regiones o = new Regiones();
                o.id = int.Parse(item.ItemArray[0].ToString());
                o.nombre = item.ItemArray[1].ToString();
                o.provincias = item.ItemArray[2].ToString();
                o.comunas = item.ItemArray[3].ToString();
                o.ciudades = item.ItemArray[4].ToString();

                listado.Add(o);
            }

            return listado;
        }
              
    }
}
