using ConLaFarmacia.Colection;
using ConLaFarmacia.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ConLaFarmacia.Clases
{
    //Felipe Aguilera Rut:1577715275
    public class Medicamento:Producto,IControlable
    {
        //Atributos
        private string generico;
        private string contraindicaciones;

        //Propiedades
        public string Generico
        {
            get { return generico; }
            set { generico = value; }
        }
        public string Contraindicaciones
        {
            get { return contraindicaciones; }
            set { contraindicaciones = value; }
        }

        //Constructores
        public Medicamento() : base()
        {
            this.generico = string.Empty;
            this.contraindicaciones= string.Empty;
        }
        public Medicamento(string tipo, string codigo, double precioBase, string nombre, string generico, string contraindicaciones) : base(tipo,codigo,precioBase,nombre)
        {
            this.generico = generico;
            this.contraindicaciones = contraindicaciones;
        }
        public Medicamento(string medicamento) : base(medicamento)
        {
            string[] campo = medicamento.Split(',');
            this.Generico = campo[4];
            this.contraindicaciones = campo[5];
        }
        public Medicamento(Medicamento m):base(m)
        {
            this.generico = m.Generico;
            this.contraindicaciones = m.Contraindicaciones;
        }

        //ToString
        public override string ToString()
        {
            return base.ToString() + "\n Es generico:  " + this.generico + "\n Contraindicaciones:  " + this.contraindicaciones;
        }

        public override bool Descontar(string dia)
        {
            Console.WriteLine("Ingrese el dia de la semana: ");
            dia=Console.ReadLine();

            if(dia.Contains("Lunes"))
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
