using System;

namespace EjemploUsoSessionYAjax.ViewModels
{
    public class ItemViewModel
    {
        public int Id { get; set; }

        public string Nombre { get; set; }

        public string FechaConsulta
        {
            get
            {
                return DateTime.Now.ToShortDateString();
            }
        }
    }
}