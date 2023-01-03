using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConLaFarmacia.Clases
{
    //Felipe Aguilera Rut:1577715275
    public class Producto
    {
        //Atributos
        private string tipo;
        private string codigo;
        private double precioBase;
        private string nombre;

        //Propiedades
        public string Tipo
        {
            get { return tipo; }
            set { tipo = value; }
        }
        public string Codigo
        { 
            get { return codigo; }
            set { codigo = value; } 
        }
        public double PrecioBase
        {
            get { return precioBase; }
            set 
            {
                if (value > 0) //Mayor a cero
                {
                    precioBase = value;
                }
            }
        }
        public string Nombre
        {
            get { return nombre; }
            set
            {
                if(value.Length> 2) //largo minimo 3 calacteres
                {
                    nombre = value;
                }
            }
        }

        //Constructores
        public Producto()
        {
            this.tipo = string.Empty;
            this.codigo = string.Empty;
            this.precioBase= 0;
            this.nombre= string.Empty;
        }
        public Producto(string tipo, string codigo, double precioBase, string nombre)
        {
            this.tipo = tipo;
            this.codigo = codigo;
            this.precioBase = precioBase;
            this.nombre = nombre;
        }
        public Producto(string producto)
        {
            string[] campo = producto.Split(',');
            this.tipo = campo[0];
            this.codigo = campo[1];
            this.precioBase = double.Parse(campo[2]);
            this.nombre = campo[3];
        }
        public Producto(Producto p)
        {
            this.tipo = p.Tipo;
            this.codigo = p.Codigo;
            this.precioBase=(double)p.PrecioBase;
            this.nombre = p.Nombre;
        }

        //ToString
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("\n Tipo (medicamento o suplemento):  ");
            sb.Append(this.tipo);
            sb.Append("\n Codigo del Producto:  ");
            sb.Append(this.codigo);
            sb.Append("\n Precio Base del Producto:  ");
            sb.Append(this.precioBase);
            sb.Append("\n Nombre del Producto:  ");
            sb.Append(this.nombre);

            return sb.ToString();
        }

        public virtual string Mostrar()
        {
            return this.ToString();
        }
        public virtual bool Descontar(string dia)
        {
            return false;
        }
    }
}
