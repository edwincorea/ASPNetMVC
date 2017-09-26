namespace EjemploUsoSessionYAjax.Core
{
    public class ProveedorDeMensaje : IProveedorDeMensaje
    {
        public string ObtenerMensaje()
        {
            return string.Format("Mensaje de {0}", this.GetType());
        }
    }
}