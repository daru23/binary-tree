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
using Arbol_Binario;

namespace Arbol_Binario
{
    class Program
    {
        static void Main(string[] args)
        {
            ArbolBinario abo = new ArbolBinario();

           
                Console.WriteLine("WELCOME TO MY BINARY TREE PROGRAM");
                Console.WriteLine("These are the options:");
                Console.WriteLine("1. Insert a node");
                Console.WriteLine("2. Delete a node");
                Console.WriteLine("3. Search a node");
                Console.WriteLine("4. Deep of the Binary Tree");
                Console.WriteLine("5. How many node have the Binary Tree");
                Console.WriteLine("6. Print Pre Order");
                Console.WriteLine("7. Print In Order");
                Console.WriteLine("8. Print Post Order");
                Console.WriteLine("9. Exit");
                Console.WriteLine();

                string entrada;
                int i = 0;
                
                do{     
                        try{

                            Console.Write("Option: ");
                            entrada = Console.ReadLine();
                            
                            int.TryParse(entrada, out i);
                            if (int.TryParse(entrada, out i))
                            {

                                if (i.Equals(1))
                                {
                                    Console.Write("Insert node: ");
                                    string ent_nodo = Console.ReadLine();
                                    int nodo;
                                    if (int.TryParse(ent_nodo, out nodo))
                                        abo.Insertar(nodo);
                                    else
                                        Console.WriteLine("Please insert a number");
                                }
                                else if (i.Equals(2))
                                {
                                    Console.Write("Delete node: ");
                                    string ent_nodo = Console.ReadLine();
                                    int nodo;
                                    if (int.TryParse(ent_nodo, out nodo))
                                    {
                                        Console.WriteLine("Are you sure yo want to delete this node? yes/no");
                                        string desicion = Console.ReadLine();
                                        if (desicion == "yes")
                                            abo.Eliminar(nodo);
                                    }
                                    else
                                        Console.WriteLine("Please insert a number");
                                }
                                else if (i.Equals(3))
                                {
                                    Console.Write("Search node: ");
                                    string ent_nodo = Console.ReadLine();
                                    int nodo;
                                    if (int.TryParse(ent_nodo, out nodo))
                                        Console.WriteLine(abo.Contiene(nodo));
                                    else
                                        Console.WriteLine("Please insert a number");
                                }
                                else if (i.Equals(4))
                                {
                                    int altura = abo.Altura(abo.raiz);
                                    Console.WriteLine("   This Binary Tree has " + altura + " levels");
                                    
                                }
                                else if (i.Equals(5))
                                {
                                    int nodos = abo.Nodos(abo.raiz);
                                    Console.WriteLine("   This Binary Tree has " + nodos + " levels");

                                }
                                else if (i.Equals(6))
                                {
                                    abo.ImprimirPreOrden(abo.raiz);
                                    Console.WriteLine();
                                }
                                else if (i.Equals(7))
                                {
                                    abo.ImprimirEntreOrden(abo.raiz);
                                    Console.WriteLine();
                                }
                                else if (i.Equals(8))
                                {
                                    abo.ImprimirPostOrden(abo.raiz);
                                    Console.WriteLine();
                                }
                            }
                        }
                        catch (OverflowException e) 
                        {
                            Console.WriteLine("{0} Value read = {1}.", e.Message);
                        }
                    
                    } while (i != 9);

        }
    }
}
