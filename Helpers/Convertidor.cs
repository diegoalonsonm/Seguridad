using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helpers
{
    public class Convertidor
    {
        public static TModeloEntrada Clonar<TModeloEntrada>(TModeloEntrada elemento) where TModeloEntrada : class, new() => Convertidor.Convertir<TModeloEntrada, TModeloEntrada>(elemento);

        public static TModeloSalida Convertir<TModeloEntrada, TModeloSalida>(TModeloEntrada elementoBase, Action<TModeloEntrada, TModeloSalida> 
            reglaTransformacion = null) where TModeloEntrada : class where TModeloSalida : new()
        {
            return Mappeador.MapearObjetos<TModeloEntrada, TModeloSalida>(elementoBase, reglaTransformacion);
        }

        public static IEnumerable<TModeloSalida> ConvertirLista<TModeloEntrada, TModeloSalida>(IEnumerable<TModeloEntrada> elementos, Action<TModeloEntrada, 
            TModeloSalida> reglaTransformacion = null) where TModeloEntrada : class where TModeloSalida : new()
        {
            return (IEnumerable<TModeloSalida>) elementos.Select<TModeloEntrada, TModeloSalida>((Func<TModeloEntrada, TModeloSalida>)(elementoBase => Mappeador.MapearObjetos<TModeloEntrada, TModeloSalida>(elementoBase, reglaTransformacion))).ToList<TModeloSalida>();
        }
    }
}
