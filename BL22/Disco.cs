using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL22
{
    public class Disco
    {


            public ML.Result GetAll()
            {
                ML.Result result = new ML.Result();

                try
                {
                    using (DL.YAlfaroProgramacionNCapasEntities2 context = new DL.YAlfaroProgramacionNCapasEntities2())
                    {
                        var filasAf = context.GetAll().ToList();
                        result.Objects = new List<object>();

                        if (filasAf != null)
                        {
                            foreach (var obj in filasAf)
                            {
                                ML.Disco disco = new ML.Disco();
                                disco.Titulo = obj.Titulo;
                                disco.Artista = obj.Artista;
                                disco.GeneroMusical = obj.GeneroMusical;
                                disco.Duracion = TimeSpan.Parse(obj.Duracion.ToString());
                                disco.Año = int.Parse(obj.Año.ToString());
                                disco.Distribuidora = obj.Distribuidora;
                                disco.Ventas = int.Parse(obj.Ventas.ToString());
                                disco.Disponibilidad = int.Parse(obj.Disponibilidad.ToString());

                                result.Objects.Add(disco);


                            }
                            result.Correct = true;

                        }
                        else
                        {
                            result.Correct = false;
                            result.ErrorMessage = "No hay registros de discos";
                        }
                    }

                }
                catch (Exception e)
                {
                    result.Correct = false;
                    result.ErrorMessage = e.Message;
                    result.Ex = e;

                    throw;
                }
                return result;



            }
        
    }
}
