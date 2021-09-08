using System.Windows.Forms;

namespace SADI_Desktop_v1
{
    class ConexionString
    {
        //Microsoft.Jet.OLEDB.4.0
        //public string ConString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=D:\\MartinRod\\Proyectos\\SADI Desktop\\SADI Desktop v1\\DBSADI.mdb";

        //Microsoft.ACE.OLEDB.12.0 Sin Contraseña.-
        static string VarPath = Application.StartupPath.ToString();
        static string VarDBName = "\\DBSADI.accdb";  //puede ser mdb tambien.-
        public string ConString = "Provider = Microsoft.ACE.OLEDB.12.0; Data Source =" + (VarPath + VarDBName);
        //public string ConString = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source =" + (VarPath + VarDBName);
    }
}