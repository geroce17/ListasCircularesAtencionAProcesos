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
            nuevo.ciclos = ciclos.Next(2, 6);
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
                nuevo.anterior = final;
                nuevo.anterior.siguiente = nuevo;
                final = nuevo;
                inicio.anterior = final;
            }
        }
        public void eliminarProceso()
        {
            //----------Se resta en uno los ciclos de cada instancia----------------------------------
            actual = inicio;
            actual.ciclos--;
            actual = actual.siguiente;
            while (actual != inicio)
            {
                actual.ciclos--;
                actual = actual.siguiente;
            }

            //---------------Se inicia a eliminar las instancias con ciclos en ceros-----------------

            actual = inicio;
            if (inicio.ciclos == 0)
            {
                completed++;
                if (inicio == final)
                {
                    inicio = null;
                    final = inicio;
                    actual = inicio;
                }
                else
                {
                    actual = actual.siguiente;
                    while (actual.ciclos == 0 && actual != inicio)
                    {
                        actual = actual.siguiente;
                        completed++;
                    }
                    if (actual == final)
                    {
                        inicio = actual;
                        inicio.siguiente = inicio;
                        inicio.anterior = inicio;
                        final = inicio;
                    }
                    else
                    {
                        inicio = actual;
                        inicio.anterior = final;
                        final.siguiente = inicio;
                        actual = actual.siguiente;
                    }
                }
            }
            else
                actual = actual.siguiente;

            while (actual != null && actual!=inicio)
            {
                if (actual.ciclos == 0)
                {
                    if (inicio == final)
                    {
                        inicio = null;
                        final = inicio;
                        actual = inicio;
                    }
                    else
                    {
                        if (actual == final)
                        {
                            final = final.anterior;
                            final.siguiente = inicio;
                            inicio.anterior = final;
                        }
                        else
                        {
                            actual.siguiente.anterior = actual.anterior;
                            actual.anterior.siguiente = actual.siguiente;
                        }
                    }
                    completed++;
                }
                if (actual != null)
                    actual = actual.siguiente;
            }
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
