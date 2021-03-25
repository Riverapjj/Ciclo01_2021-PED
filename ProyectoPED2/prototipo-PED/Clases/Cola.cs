using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prototipo_PED.Clases
{
    class Cola
    {
        public Nodo inicio;
        public int tam;
        public Cola()
        {
            inicio = null;
            tam = 0;
        }
        public void Insertar(Soli item)
        {
            Nodo auxiliar = new Nodo();
            auxiliar.Datos = item;
            auxiliar.siguiente = null;

            if (inicio == null)
            {
                inicio = auxiliar;
            }
            else
            {
                Nodo puntero;
                puntero = inicio;
                while (puntero.siguiente != null)
                {
                    puntero = puntero.siguiente;
                }
                puntero.siguiente = auxiliar;
            }
            tam++;
        }
        public void Eliminar()
        {
            if (inicio == null)
            {
                Console.WriteLine("Lista vacía, no se puede eliminar elemento");
            }
            else
            {
                inicio = inicio.siguiente;
                tam--;
            }
        }
        public List<Soli> Mostrar()
        {
            List<Soli> nueva = new List<Soli>();

            if (inicio != null)
            {
                Nodo puntero = inicio;
                while (puntero != null)
                {
                    nueva.Add(puntero.Datos);
                    puntero = puntero.siguiente;
                }
            }
            return nueva;
        }
    }
}
