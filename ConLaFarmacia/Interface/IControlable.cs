using ConLaFarmacia.Colection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConLaFarmacia.Interface
{
    //Felipe Aguilera Rut:1577715275
    public interface IControlable
    {
        bool Descontar(string dia);
        string Mostrar();
    }
}
