using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B_L
{
    public class Disco
    {

        public ML_2.Result GetAll()
        {
            ML_2.Result result = new ML_2.Result();

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
                            ML_2.Disco disco = new ML_2.Disco();
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
        public ML_2.Result Delete(int Disco)
        {
            ML_2.Result result = new ML_2.Result();

            try
            {
                using (DL.YAlfaroProgramacionNCapasEntities2 context = new DL.YAlfaroProgramacionNCapasEntities2())
                {
                  
                    var query = context.DeleteDisco(disco);
                    if (query > 0)
                  
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Usuario no eliminado";
                    }
                }
            }
            catch (Exception ex)
            {

                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }

    }
}
