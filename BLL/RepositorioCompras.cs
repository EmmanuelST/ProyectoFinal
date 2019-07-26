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
    public class RepositorioCompras : RepositorioBase<Compras>
    {
        internal Contexto db;

        public override bool Guardar(Compras entity)
        {
            bool paso = false;
            db = new Contexto();
            RepositorioBase<Agricultores> dbA = new RepositorioBase<Agricultores>();
            Contexto dbP = new Contexto();

            try
            {
                Agricultores agriculto = dbA.Buscar(entity.IdAgricultor);
                agriculto.Balance += entity.Total;
                dbA.Modificar(agriculto);

                db.Compra.Add(entity);
                paso = db.SaveChanges() > 0;

                var producto = dbP.Producto.Where(P=> P.Descripcion.Equals("Arroz Cascara")).FirstOrDefault<Productos>();

                if(producto != null)
                {
                    producto.Existencia += entity.CantidadSacos;
                    dbP.Entry(producto).State = EntityState.Modified;
                    dbP.SaveChanges();
                }
                

            }
            catch (Exception)
            {
                throw;
            }
            

            return paso;
        }

        public override bool Modificar(Compras entity)
        {
            bool paso = false;
            db = new Contexto();
            Contexto db2 = new Contexto();
            Contexto dbP = new Contexto();
            RepositorioBase<Agricultores> dbA = new RepositorioBase<Agricultores>();

            try
            {
                var anterior = db2.Compra.Find(entity.IdCompra);

                var producto = dbP.Producto.Where(P => P.Descripcion.Equals("Arroz Cascara")).FirstOrDefault<Productos>();

                if (producto != null)
                {
                    producto.Existencia -= anterior.CantidadSacos;
                    producto.Existencia += entity.CantidadSacos;
                    dbP.Entry(producto).State = EntityState.Modified;
                    dbP.SaveChanges();
                }

                Agricultores agriculto = dbA.Buscar(entity.IdAgricultor);
                agriculto.Balance -= anterior.Total;

                agriculto.Balance += entity.Total;

                dbA.Modificar(agriculto);

                db.Entry(entity).State = EntityState.Modified;
                paso = db.SaveChanges() > 0;

            }
            catch (Exception)
            {
                throw;
            }


            return paso;
        }

        public override bool Elimimar(int id)
        {
            db = new Contexto();
            Contexto dbP = new Contexto();
            RepositorioBase<Agricultores> dbA = new RepositorioBase<Agricultores>();
            bool paso = false;

            try
            {
                var eliminar = db.Compra.Find(id);
                var agricultor = dbA.Buscar(eliminar.IdAgricultor);
                agricultor.Balance -= eliminar.Total;
                dbA.Modificar(agricultor);

                var producto = dbP.Producto.Where(P => P.Descripcion.Equals("Arroz Cascara")).FirstOrDefault<Productos>();

                if (producto != null)
                {
                    producto.Existencia -= eliminar.CantidadSacos;
                    dbP.Entry(producto).State = EntityState.Modified;
                    dbP.SaveChanges();
                }

                db.Entry(eliminar).State = EntityState.Modified;
                paso = db.SaveChanges() > 0;

                


            }
            catch(Exception)
            {
                throw;
            }


            return paso;
        }


    }
}
