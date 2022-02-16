using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Collections.Generic;
using LeerTxt.Data;

namespace LeerTxt
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int pos_igual;
            int pos_inicial;            
            string horarios;
            string dia;
            int hora_inicio;
            int minuto_inicio;
            int hora_fin;
            int minuto_fin;
            int numeroHoras;
            int pagoPorDia;
            int pagoTotal;
            string line;
            string listatotal;    
            
            Logica l = new Logica();
            List<string> elementos = new List<string>();

            try
            {
                StreamReader sr = new StreamReader(@"C:\Prueba.txt");
                line = sr.ReadToEnd();
                listatotal = line.ToString();
             
              
                List<string> listaRegistros = new List<string>();
                listaRegistros = l.DividirCadena(listatotal);
                List<string> listaHorarios = new List<string>();

                foreach (var item in listaRegistros)
                {
                    pagoTotal = 0;
                    Console.WriteLine(item);
                    elementos = l.ExtraerNombre(item).ToList();
                    //Console.WriteLine("NOMBRE: "+elementos[0]);
                    //Console.WriteLine("Longitud: " + item.Length);
                    pos_igual = item.IndexOf('=');
                    //Console.WriteLine("El = es la posicion " + pos_igual);
                    pos_inicial = pos_igual+1;                    
                    horarios = item.Substring(pos_inicial);
                    //Console.WriteLine("HORARIOS " + horarios);
                    //Console.WriteLine("Longitud de horarios " + horarios.Length);
                    listaHorarios = l.DividirHorarios(horarios);
                        for (int i=0; i < listaHorarios.Count; i++)
                        {
                        //Console.WriteLine(listaHorarios[i]);
                        //Console.WriteLine("longitud: " + listaHorarios[i].Length);
                        dia = listaHorarios[i].Substring(0, 2);
                        hora_inicio = Convert.ToInt32(listaHorarios[i].Substring(2, 2));
                        minuto_inicio = Convert.ToInt32(listaHorarios[i].Substring(5, 2));
                        hora_fin = Convert.ToInt32(listaHorarios[i].Substring(8, 2));
                        minuto_fin = Convert.ToInt32(listaHorarios[i].Substring(11, 2));
                        //Console.WriteLine("dia " + dia);
                        //Console.WriteLine("hora inicio " + hora_inicio);
                        //Console.WriteLine("minuto inicio " + minuto_inicio);
                        hora_fin = (hora_fin == 00) ? 24 : Convert.ToInt32(listaHorarios[i].Substring(8, 2));
                        //Console.WriteLine("hora fin " + hora_fin);
                        //Console.WriteLine("minuto fin " + minuto_fin);
                        numeroHoras = hora_fin - hora_inicio;
                        //Console.WriteLine("#horas: " + numeroHoras); 
                        pagoPorDia = l.PagoPorDia(dia, hora_inicio, minuto_inicio, hora_fin, minuto_fin) * numeroHoras;
                        pagoTotal = pagoTotal + pagoPorDia;
                        //Console.WriteLine("El señor" + elementos[0] + "se le paga " + pagoPorDia);
                        if(i==listaHorarios.Count - 1) { Console.WriteLine("The amount to pay " + elementos[0] + " es " + pagoTotal); }                        
                    }

                    Console.WriteLine("\n");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            finally
            {
                Console.WriteLine("Executing finally block.");
            }
        }        
    }
}