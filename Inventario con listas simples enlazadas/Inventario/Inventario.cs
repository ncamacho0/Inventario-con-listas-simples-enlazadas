using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventario
{
    class Inventario
    {
        private Producto inicio,final;
        public Inventario()
        {
            this.inicio = null;
            this.final = null;
        }
        public void AgregarEnInicio(Producto p)
        {
            if (inicio != null)
            {
                p.siguiente = inicio;
                inicio = p;
            }
            else
            {
                inicio = p;
                final = p;     
            }
        }

        public void agregar(Producto p)
        {
             if (inicio != null)
             {
                final.siguiente = p;
                final = p;
             }
             else
             {
                inicio = p;
                final = p;             
            }
        }

        public Producto buscar(string nombre)
        {
            Producto actual=inicio;
            bool encontrado = false;

            if (inicio != null)
            {
                while (actual != null && encontrado == false)
                {
                    if (actual.nombre == nombre)
                        encontrado = true;
                    else
                        actual = actual.siguiente;
                }
            }
            return actual;
        }
        public void eliminar(string nombre)
        {
            Producto actual=inicio,anteriorTemporal=null;
            bool encontrado = false;
            if (inicio != null)
            {
                while (actual != null && encontrado == false)
                {
                    if (actual.nombre == nombre)
                    {
                        if (actual == inicio)
                            inicio = inicio.siguiente;
                        else if (actual == final)
                        {
                            anteriorTemporal.siguiente = null;
                            final = anteriorTemporal;
                        }
                        else
                            anteriorTemporal.siguiente = actual.siguiente;
                        encontrado = true;
                    }
                    else
                    {
                        anteriorTemporal = actual;
                        actual = actual.siguiente;
                    }
                }
            }
        }

        public string reporte()
        {
            Producto actual;
            actual = inicio;
            string contenidoLista = null;
            if (inicio != null)
            {
                while (actual != null) 
                {
                    contenidoLista += Environment.NewLine+ actual.ToString()+ Environment.NewLine + "-----------";
                    actual = actual.siguiente;
                }
            }
            else 
                 contenidoLista = "No exiten Productos";
         return contenidoLista;
        }

        public void insertar(Producto p,int posI)
        {
            int bandera = 2;
            Producto actual=inicio;
            bool encontrado = false;
            if (inicio != null)
            {
                if (posI == 1)
                    AgregarEnInicio(p);            
                else
                {
                    while (actual != null && encontrado == false)
                    {
                        if (bandera == posI)
                        {
                            p.siguiente = actual.siguiente;
                            actual.siguiente = p;
                            encontrado = true;
                        }
                        else
                        {
                            actual = actual.siguiente;
                            bandera++;
                        }
                    }
                 }
             }       
          }

    }
}
