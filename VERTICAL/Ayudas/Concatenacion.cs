namespace VERTICAL.Ayudas
{
    public class Concatenacion
    {
        public static string ConcatDescripcion(string descripcion, string color, bool bilateral)
        {
            if (bilateral)
            {
                //recodificar
                return descripcion + " " + color;
            }
            else
            {
                return descripcion + " " + color;
            }
        }
        public static string ConcatSerie(int s1,int s2,int s3)
        {
            const string punto = ".";
            string _s1 = "x", _s2 = "x", _s3 = "x";
            if (s1 > 0)
            {
                _s1 = string.Format("{0:000}",s1);
            }
            if (s2 > 0)
            {
                _s2 = string.Format("{0:000}", s2);
            }
            if (s3 > 0)
            {
                _s3 = string.Format("{0:000}", s3);
            }
            return _s1 + punto + _s2 + punto + _s3;
        }
    }
}
