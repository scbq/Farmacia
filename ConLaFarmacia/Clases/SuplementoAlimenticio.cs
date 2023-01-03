using ConLaFarmacia.Colection;
using ConLaFarmacia.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConLaFarmacia.Clases
{
    //Felipe Aguilera Rut:1577715275
    public class SuplementoAlimenticio:Producto, IControlable
    {
        //Atributos
        private int cantidadVitaminas;
        private string informacionVitaminas;

        //Propiedades
        public int CantidadVitaminas
        {
            get { return cantidadVitaminas; }
            set { cantidadVitaminas = value; }
        }
        public string InformacionVitaminas
        {
            get { return informacionVitaminas; }
            set { informacionVitaminas = value; }
        }

        //Constructores
        public SuplementoAlimenticio():base()
        {
            this.cantidadVitaminas = 0;
            this.informacionVitaminas=string.Empty;
        }
        public SuplementoAlimenticio(string tipo, string codigo, double precioBase, string nombre,int cantidadVitaminas, string informacionVitaminas):base(tipo,codigo,precioBase,nombre)
        {
            this.cantidadVitaminas = cantidadVitaminas;
            this.informacionVitaminas = informacionVitaminas;
        }
        public SuplementoAlimenticio(string suplemento) : base(suplemento)
        {
            string[] campo = suplemento.Split(',');
            this.cantidadVitaminas = int.Parse(campo[4]);
            this.informacionVitaminas = campo[7];
        }

        public SuplementoAlimenticio(SuplementoAlimenticio s):base(s) 
        {
            this.cantidadVitaminas = s.cantidadVitaminas;
            this.informacionVitaminas = s.InformacionVitaminas;
        }

        //ToString
        public override string ToString()
        {
            return base.ToString() + "\n Cantidad de Vitaminas:  " + this.cantidadVitaminas + "\n Informacion de Vitaminas:  " + this.informacionVitaminas;
        }

        public override bool Descontar(string dia)
        {
            if (dia.Contains("Lunes"))
            {
                Console.WriteLine("Descueno de un 15% al Precio");
                return true;
            }
            else
            {
                Console.WriteLine("El Precio se mantiene");
                return false;
            }
        }

        public override string Mostrar()
        {
            return this.ToString();
        }
    }
}
