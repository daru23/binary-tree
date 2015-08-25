/**
 * Daniela Ruiz 06-40273
 * Universidad Simon Bolivar
 * Algoritmos 3
 * Proyecto 1
 **/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arbol_Binario
{
    /// <summary>
    /// Clase Arbol Binario
    /// </summary>
    class ArbolBinario
    {
        /// <summary>
        /// Clase Nodo
        /// Los nodos componen el Arbol Binario
        /// </summary>
        public class Nodo
        {
            public int dato;
            public Nodo izq, der;
        }

        public Nodo raiz;

        /// <summary>
        /// Contructor del Arbol Binario
        /// </summary>
        public ArbolBinario() 
        {   
            raiz=null;
        }

        /// <summary>
        /// Funcion para Insertar Nodos en el Arbol Binario
        /// </summary>
        /// <param name="dato">Dato que se quiere insertar en el Nodo</param>
        public void Insertar (int dato)
        {
            // Creo un nuevo nodo con el dato a insertar con hijo vacios
            Nodo nuevo;
            nuevo = new Nodo ();
            nuevo.dato = dato;
            nuevo.izq = null;
            nuevo.der = null;

            int comparar;

            // Guardo el padre del Arbol Binario
            Nodo actual = raiz;
            Nodo padre = null;

            while (actual != null) 
            {
                comparar = dato.CompareTo(actual.dato);
                if (comparar.Equals(0))
                {
                    return;
                }
                else if (comparar > 0) 
                {
                    // Insertar a la izquierda del Arbol Binario
                    padre = actual;
                    actual = actual.izq;
                }
                else if (comparar < 0) 
                {
                    // Insertar a la derecha del Arbol Binario
                    padre = actual;
                    actual = actual.der;
                }
           }
           // Ahora insertamos el Nodo 
           if (padre == null)
           {
                raiz = nuevo;
            }
            else 
            {
                int resultado = dato.CompareTo(padre.dato);
                if (resultado > 0)
                     padre.izq = nuevo;
                else
                     padre.der = nuevo;
            }
        }

        /// <summary>
        /// Devuelve True si el dato esta en el Arbol Binario
        /// Devuelve False si no esta el dato en el Arbol Binario
        /// </summary>
        /// <param name="dato">Nodo que se quiere verificar</param>
        /// <returns></returns>
        public bool Contiene(int dato) 
        {
            Nodo actual = raiz;
            int resultado;
            while (actual != null) 
            {
                resultado = dato.CompareTo(actual.dato);
                if (resultado == 0)
                    return true;
                else if (resultado > 0)
                    actual = actual.izq;
                else if (resultado < 0)
                    actual = actual.der;

            }
            return false;
        }

        /// <summary>
        /// Elimina un Nodo del Arbol Binario
        /// </summary>
        /// <param name="dato">Nodo que se quiere eliminar</param>
        /// <returns></returns>
        public bool Eliminar(int dato) 
        {
            // Revisamos si el Arbol Binario esta vacio
            if (raiz == null)
                return false;
            Nodo actual = raiz;
            Nodo padre = null;

            int comparar = dato.CompareTo(actual.dato);

            while (comparar != 0)
            {
                if (comparar > 0)
                {
                    padre = actual;
                    actual = actual.izq;
                }

                else if (comparar < 0) 
                {
                    padre = actual;
                    actual = actual.der;
                }

                if (actual == null)
                    return false;
                else
                    comparar = dato.CompareTo(actual.dato);                    
            }

            // Caso 1: Si el hijo derecho del actual no tiene hijo derecho entonces
            // el hijo izquierdo del actual se convierte en el padre
            if (actual.der == null) 
            {
                if (padre == null)
                    raiz = actual.izq;
                else
                {
                    comparar = dato.CompareTo(actual.dato);
                    if (comparar > 0)
                        padre.izq = actual.izq;
                    else
                        padre.der = actual.der;

                }    
            }
            // Caso 2: Si el hijo derecho del actual no tiene hijo derecho entonces
            // el hijo derecho del actual se convierte en el padre
            else if (actual.der.izq == null)
            {
                actual.der.izq = actual.izq;

                if (padre == null)
                    raiz = actual.der;
                else
                {
                    comparar = dato.CompareTo(actual.dato);
                    if (comparar > 0)
                        padre.izq = actual.der;
                    else
                        padre.der = actual.der;

                }
            }
            // Caso 3: Si el hijo derecho del actual  tiene hijo izquierdo entonces
            // reemplazas el actual con el hijo izquiero del actual derecho mas descente
            else
            {
                Nodo mejorizq = actual.der.izq;
                Nodo lpadre = actual.der;
                
                while (mejorizq.izq != null)
                {
                    lpadre = mejorizq;
                    mejorizq = mejorizq.izq;
                }

                lpadre.izq = mejorizq.der;

                mejorizq.izq = actual.izq;
                mejorizq.der = actual.der;

                
                if (padre == null)
                    raiz = mejorizq;
                else
                {
                    comparar = actual.dato.CompareTo(padre.dato);
                    if (comparar > 0)
                        padre.izq = mejorizq;
                    else if (comparar < 0)
                        padre.der = mejorizq;
                }
            }

            return true;
        }

        /// <summary>
        /// Devuelve la cantidad de Nodos del Arbol Binario
        /// </summary>
        /// <param name="n">Nodo Raiz</param>
        /// <returns></returns>
        public int Nodos (Nodo n) 
        {
            int resultado = 0; 
            if (n != null)
            {
                resultado++;
                resultado = resultado + Nodos(n.izq);
                resultado = resultado + Nodos(n.der);
            }
            return resultado;
        }

        /// <summary>
        /// Devuelve la Altura del Arbol Binario
        /// </summary>
        /// <param name="n">Nodo Raiz</param>
        /// <returns></returns>
        public int Altura(Nodo n)
        {
            int resultado = 0;
            if (n != null)
            {
                resultado++;
                int r1 = resultado + Altura(n.izq);
                int r2 = resultado + Altura(n.der);
                if (r1 > r2)
                    return r1;
                else
                    return r2;
            }
            return resultado;
        }

        /// <summary>
        /// Imprime el Arbol en Pre Orden 
        /// </summary>
        /// <param name="actual">Nodo que se va a imprimir</param>
        public void ImprimirPreOrden(Nodo actual)
        {
            if (actual != null)
            {
                Console.Write(actual.dato + " ");
                ImprimirPreOrden(actual.der);
                ImprimirPreOrden(actual.izq);
            }
        }
        
        /// <summary>
        /// Imprime el Arbol en Entre Orden 
        /// </summary>
        /// <param name="actual">Nodo que se va a imprimir</param>
        public void ImprimirEntreOrden(Nodo actual)
        {
            if (actual != null)
            {
                ImprimirEntreOrden(actual.der);
                Console.Write(actual.dato + " ");
                ImprimirEntreOrden(actual.izq);
            }
        }

        /// <summary>
        /// Imprime el Arbol en Post Orden 
        /// </summary>
        /// <param name="actual">Nodo que se va a imprimir</param>
        public void ImprimirPostOrden(Nodo actual)
        {
            if (actual != null)
            {
                ImprimirPostOrden(actual.der);
                ImprimirPostOrden(actual.izq);
                Console.Write(actual.dato + " ");
            }
        }
    
    }
}
