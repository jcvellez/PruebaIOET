using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeerTxt.Data
{
    public class Logica
    {
        //Con esto dividimos la cadena entera
        public List<string> DividirCadena(string cadena)
        {          
            List<string> list = new List<string>();
            list = cadena.Split('\n').ToList();            
            return list;
        }

        public List<string> ExtraerNombre(string cadena)
        {
            List<string> list = new List<string>();
            list = cadena.Split('=').ToList();
            return list;
        }
        public List<string> DividirHorarios(string cadena)
        {
            List<string> list = new List<string>();
            list = cadena.Split(',').ToList();
            return list;
        }

        public int PagoPorDia(string dia, int hora_inicio, int minuto_inicio, int hora_fin, int minuto_fin)
        {
            int valor=0;

            valor = (dia == "MO" || dia == "TU" || dia == "WE" || dia == "TH" || dia == "FR")                
                ? (hora_inicio >= 0 && hora_fin <= 9)
                   ? valor = 25 :
                   (hora_inicio >= 9 && hora_fin <= 18)
                   ? valor = 15 :
                   (hora_inicio >= 18 && hora_fin <= 24)
                   ? valor = 20 : valor = 0


                : (dia == "SA" || dia == "SU")          
                 ? (hora_inicio >= 0 && hora_fin <= 9)
                   ? valor = 30:
                   (hora_inicio >= 9 && hora_fin <= 18)
                   ? valor = 20 :
                   (hora_inicio >= 18 && hora_fin <= 24)
                   ? valor = 25 : valor =0
                 
                 : valor=0;   
            
            return valor;           
        }

        public int PagoTotal(string dia, int hora_inicio, int minuto_inicio, int hora_fin, int minuto_fin)
        {
            int valor = 0;
            valor = PagoPorDia(dia,hora_inicio,minuto_inicio,hora_fin,minuto_fin) + valor;
            return valor;
        }
    }
}
