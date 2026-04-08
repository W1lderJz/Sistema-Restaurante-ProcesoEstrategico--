using System.IO;
using System.Linq;
using System.Collections.Generic;

public static class ConexionBD
{
    private static string rutaArchivo = @"C:\SistemaArchivos\Conexion\ConexionesSQL.txt";

    private static string BaseDeDatos = "GloriaRestaurant";

    private static Dictionary<string, string> datosConexion = new Dictionary<string, string>();

    private static void LeerArchivo()
    {
        if (!File.Exists(rutaArchivo))
            throw new FileNotFoundException("No se encontró el archivo de conexión.");

        datosConexion.Clear();

        var lineas = File.ReadAllLines(rutaArchivo);

        var lineaDefecto = lineas.Reverse().FirstOrDefault(l => l.Split('|').Length >= 4 && l.Split('|')[3] == "1");

        if (lineaDefecto == null)
        {
            MessageBox.Show("No se encontró una conexion por defecto.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        
        var partes = lineaDefecto.Split('|');

        datosConexion["Servidor"] = partes[0];
        datosConexion["Usuario"] = partes[1];
        datosConexion["Contrasena"] = partes[2];
    }

    public static string ConexionSQL()
    {
        LeerArchivo();

        string servidor = datosConexion.ContainsKey("Servidor") ? datosConexion["Servidor"] : "";
        string usuario = datosConexion.ContainsKey("Usuario") ? datosConexion["Usuario"] : "";
        string contrasena = datosConexion.ContainsKey("Contrasena") ? datosConexion["Contrasena"] : "";

        return $"Server={servidor};Database={BaseDeDatos};User Id={usuario};Password={contrasena};";
    }
}
