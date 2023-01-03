using ConLaFarmacia.Clases;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConLaFarmacia.Colection
{
    //Felipe Aguilera Rut:1577715275
    public class Farmacia
    {
        //Atributos    
        private string nombre;
        //Lista
        public List<Producto> producList;
        //Propiedades
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        //Constructortes
        public Farmacia()
        {
            this.nombre = "Buena Salud";
            producList = new List<Producto>();
        }
        public Farmacia(string nombre,string archivo)
        {
            this.nombre = nombre;
            producList= new List<Producto>();
            CargaArchivo(archivo);
        }

        //Metodo cargar archivo

        private bool CargaArchivo(string arch)
        {
            try
            {
                FileStream f = new FileStream(arch, FileMode.Open, FileAccess.Read);
                StreamReader rf = new StreamReader(f);
                char tipo;
                string linea;
                Medicamento med;
                SuplementoAlimenticio sup;

                while (!rf.EndOfStream)
                {
                    linea = rf.ReadLine();
                    tipo = linea[0];

                    switch (tipo)
                    {
                        case 'S':
                            sup = new SuplementoAlimenticio(linea);
                            producList.Add(sup);
                            break;

                        case 'M':
                            med = new Medicamento(linea);
                            producList.Add(med);
                            break;
                    }
                }
                rf.Close();
                f.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        //ToString
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Nombre de la Farmacia:  " + nombre);
            sb.Append("\n");
            foreach (Producto pro in producList)
            {
                sb.Append(pro.ToString());
                sb.Append("\n");
            }
            return sb.ToString();
        }

        public double Recarga()
        {
            double impuesto;
            double nuevoPrecio = 0;


            for (int i = 0; i < producList.Count; i++)
            {
                if (producList[i] is Medicamento)
                {
                    Console.WriteLine("---Medicamentos---");
                    Medicamento medica = (Medicamento)producList[i];
                    if (medica.Generico.Contains("NO"))
                    {
                        impuesto = medica.PrecioBase * (0.2);
                        Console.WriteLine("Medicamento NO Generico nuevo precio: " + (medica.PrecioBase + impuesto));
                    }
                    else
                    {
                        Console.WriteLine("Medicamento Generico se mantiene el precio: " + medica.PrecioBase);
                    }
                }

                else if (producList[i] is SuplementoAlimenticio)
                {
                    Console.WriteLine("---Suplementos---");
                    SuplementoAlimenticio suple = (SuplementoAlimenticio)producList[i];
                    Console.WriteLine("Nuevo precio suplementos: " + suple.PrecioBase * 1.02);
                }
            }
            return nuevoPrecio;
        }

        public int ListarProductos()
        {
            ArrayList LISTAR = new ArrayList();
            int total = 0;

            foreach (Producto P in producList)
            {
                if (P.PrecioBase>15000)
                {
                    Console.WriteLine(P.Nombre + " " + P.PrecioBase);
                    LISTAR.Add(P);
                    total++;
                }
            }
            return total;
        }

        public int Eliminar()
        {
            int cont = 0;
                
            for (int i = 0; i < producList.Count; i++)
            {
                if (producList[i].PrecioBase <= 1000)
                {
                    producList.Remove(producList[i]);
                    cont++;
                }
            }
            return cont;
        }
        public void Mostrar(string mos)
        {
            bool existe = false;
            for (int i = 0; i < producList.Count; i++)
            {
                if (producList[i].Codigo.Equals(mos))
                {
                    existe = true;
                    Console.WriteLine(producList[i].Mostrar());
                    break;
                }
            }
            if(!existe)
            {
                Console.WriteLine("No existe, ingrese el codigo una vez mas");
            }
        }

        public void SumarDescuento()
        {
            for (int i = 0; i < producList.Count; i++)
            {
                if (producList[i] is Medicamento)
                {
                    Medicamento medi = (Medicamento)producList[i];
                    Console.WriteLine("Tipo:  " + medi.Tipo);
                    Console.WriteLine("Es Generico:  " + medi.Generico);
                    Console.WriteLine("Precio Base:  " + medi.PrecioBase);
                    if (medi.Generico.ToUpper().Contains("SI"))
                    {
                        medi.PrecioBase -= medi.PrecioBase * 0.15;
                        Console.WriteLine("Precio con Descuento: " + medi.PrecioBase);
                    }
                    else
                    {
                        Console.WriteLine("El precio se mantiene");
                    }
                }
                
                else if (producList[i] is SuplementoAlimenticio)
                {
                    SuplementoAlimenticio suple = new SuplementoAlimenticio();
                    Console.WriteLine("Tipo:  " + suple.Tipo);
                    Console.WriteLine("Precio Base:  " + suple.PrecioBase);
                    suple.PrecioBase -= suple.PrecioBase * 0.15;
                    Console.WriteLine("Precio con Descuento:  " + suple.PrecioBase);
                }
            }
        }
    }
}
