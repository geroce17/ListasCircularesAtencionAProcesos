using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LC___Atencion_a_procesos
{
    class Procesador
    {
        private int NoProceso = 0;
        public Proceso inicio { get; set; }
        private Proceso final;
        private Proceso actual;
        private static Random ciclos = new Random();
        public int Pen { get; set; }
        public int suma { get; set; }
        public int _completed { get { return completed; } }
        private int completed;

        public void crearProceso()
        {
            NoProceso++;
            Proceso nuevo = new Proceso();
            nuevo.nombre = Convert.ToString("Proceso " + NoProceso);
            nuevo.ciclos = ciclos.Next(4,12);
            if (inicio == null)
            {
                nuevo.siguiente = nuevo;
                nuevo.anterior = nuevo;
                inicio = nuevo;
                final = nuevo;
            }
            else
            {
                actual = inicio.siguiente;
                while (actual != inicio)
                {
                    actual = actual.siguiente;
                }
                nuevo.siguiente = inicio;
                nuevo.anterior = inicio.anterior;
                nuevo.anterior.siguiente = nuevo;
                final = nuevo;
                inicio.anterior = final;
            }
        }
        public void eliminarProceso()
        {
            if (inicio != null)
            {
                inicio.ciclos--;

                if (inicio.ciclos == 0)
                {
                    if (inicio.siguiente != inicio)
                    {
                        inicio.siguiente.anterior = inicio.anterior;
                        inicio.anterior.siguiente = inicio.siguiente;
                        inicio = inicio.siguiente;
                    }
                    completed++;
                }
            }
            inicio = inicio.siguiente;
        }

        public void pendientesSuma()
        {
            if (inicio == null)
            {
                Pen = 0;
                suma = 0;
            }
            else
            {
                actual = inicio;
                Pen++;
                suma = suma + actual.ciclos;
                actual = actual.siguiente;
                while (actual != inicio)
                {
                    Pen++;
                    suma = suma + actual.ciclos;
                    actual = actual.siguiente;
                }
            }
        }

    }
}
