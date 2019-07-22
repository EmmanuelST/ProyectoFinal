using DAL;
using Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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

        public override Ventas Buscar(int id)
        {
            db = new Contexto();
            Ventas venta;

            try
            {
                venta = db.Venta.Find(id);
                if (venta != null)
                    venta.Detalles.Count();
                

            }catch(Exception)
            {
                throw;
            }


            return venta;
        }

        public override bool Modificar(Ventas entity)
        {
            bool paso = false;
            db = new Contexto();
            Contexto db2 = new Contexto();
            RepositorioBase<Productos> dbP = new RepositorioBase<Productos>();
            RepositorioBase<VentaDetalles> dbV = new RepositorioBase<VentaDetalles>();

            try
            {
                var temp = db2.Venta.Find(entity.IdVenta);

                foreach(var item in temp.Detalles)
                {
                    if(!entity.Detalles.Any(D => D.IdVentaDetalle == item.IdVentaDetalle))
                    {
                        Productos producto = dbP.Buscar(item.IdProducto);
                        producto.Existencia += item.Cantidad;
                        dbP.Modificar(producto);
                        dbV.Elimimar(item.IdVentaDetalle);

                    }

                }

                foreach(var item in entity.Detalles)
                {

                    if (item.IdVentaDetalle == 0)
                    {
                        item.IdVenta = entity.IdVenta;
                        dbV.Guardar(item);
                    }
                    else
                    {
                        dbV.Modificar(item);
                    }
                }

                db.Entry(entity).State = EntityState.Modified;
                paso = db.SaveChanges() > 0;



            }catch(Exception)
            {
                throw;
            }


            return paso;
        }

        public override bool Elimimar(int id)
        {
            bool paso = false;
            db = new Contexto();
            RepositorioBase<Productos> dbP = new RepositorioBase<Productos>();
            RepositorioBase<VentaDetalles> dbV = new RepositorioBase<VentaDetalles>();

            try
            {
                Ventas eliminar = db.Venta.Find(id);
                
                

                if (eliminar != null)
                {
                    List<VentaDetalles> lista = dbV.GetList(V => V.IdVenta == id);
                    db.Entry(eliminar).State = EntityState.Deleted;
                    paso = db.SaveChanges() > 0;
                    

                    foreach (var item in lista)
                    {
                        Productos producto = dbP.Buscar(item.IdProducto);
                        producto.Existencia += item.Cantidad;
                        dbP.Modificar(producto);
                    }
                }
                else
                    return paso;

            }
            catch(Exception)
            {
                throw;
            }


            return paso;
        }


    }
}
