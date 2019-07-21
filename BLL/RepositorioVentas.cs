using DAL;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class RepositorioVentas : RepositorioBase<Ventas>
    {
        internal Contexto db; 

        public override bool Guardar(Ventas entity)
        {

            db = new Contexto();
            bool paso = false;
            RepositorioBase<Productos> dbP = new RepositorioBase<Productos>();
            Productos producto = new Productos();
            
            foreach(var item in entity.Detalles)
            {
                producto = dbP.Buscar(item.IdProducto);
                producto.Existencia -= item.Cantidad;
                dbP.Modificar(producto);

            }

            try
            {
                if(db.Venta.Add(entity) != null)
                {
                    paso = db.SaveChanges() > 0;
                }

            }catch(Exception)
            {
                throw;
            }


            return paso ;
        }

        

    }
}
