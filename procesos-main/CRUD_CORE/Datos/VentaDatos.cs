using CRUD_CORE.Models;
using System.Data.SqlClient;
using System.Data;
using System.Web;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Azure;
using iTextSharp;


namespace CRUD_CORE.Datos
{
    public class VentaDatos
    {
        public List<VentaModel> Listar()
        {
            var oLista = new List<VentaModel>();
            var cn = new Conexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_Listar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oLista.Add(new VentaModel()
                        {
                            idVenta = Convert.ToInt32(dr["idVenta"]),
                            Nombre = Convert.ToString(dr["Nombre"]),
                            Precio = Convert.ToInt32(dr["Precio"]),
                            DiaVenta = Convert.ToDateTime(dr["DiaVenta"])
                        });
                    }
                }
            }
            return oLista;
        }

        public DataTable dtVenta()
        {
            DataTable dt = new DataTable();
            var cn = new Conexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_Listar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
                adapter.Dispose();
            }
            return dt;
        }
        public List<VentaModel> ListarDia()
        {
            var oLista = new List<VentaModel>();
            var cn = new Conexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("VentaDia1", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oLista.Add(new VentaModel()
                        {
                            idVenta = Convert.ToInt32(dr["idVenta"]),
                            Nombre = Convert.ToString(dr["Nombre"]),
                            Precio = Convert.ToInt32(dr["Precio"]),
                            DiaVenta = Convert.ToDateTime(dr["DiaVenta"])
                        });
                    }
                }
            }
            return oLista;
        }

        public VentaModel Obtener(int idVenta)
        {
            var oVenta = new VentaModel();
            var cn = new Conexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_Obtener", conexion);
                cmd.Parameters.AddWithValue("idVenta", idVenta);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oVenta.idVenta = Convert.ToInt32(dr["idVenta"]);
                        oVenta.Nombre = Convert.ToString(dr["Nombre"]);
                        oVenta.Precio = Convert.ToInt32(dr["Precio"]);
                        oVenta.DiaVenta = Convert.ToDateTime(dr["DiaVenta"]);
                    }
                }
            }
            return oVenta;
        }

        public bool Guardar(VentaModel oventa)
        {
            bool rpta;
            try
            {

                var cn = new Conexion();
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_Guardar1", conexion);
                    cmd.Parameters.AddWithValue("Nombre", oventa.Nombre);
                    cmd.Parameters.AddWithValue("Precio", oventa.Precio);
                    cmd.Parameters.AddWithValue("DiaVenta", oventa.DiaVenta);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                rpta = true;
            }
            catch (Exception e)
            {
                string error = e.Message;
                rpta = false;
            }
            return rpta;
        }
        public bool Eliminar(int idVenta)
        {
            bool rpta;
            try
            {

                var cn = new Conexion();
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_Eliminar", conexion);
                    cmd.Parameters.AddWithValue("idVenta", idVenta);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                rpta = true;
            }
            catch (Exception e)
            {
                string error = e.Message;
                rpta = false;
            }
            return rpta;
        }

        public bool Editar(VentaModel oventa)
        {
            bool rpta;
            try
            {

                var cn = new Conexion();
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_Editar2", conexion);
                    cmd.Parameters.AddWithValue("idVenta", oventa.idVenta);
                    cmd.Parameters.AddWithValue("Nombre", oventa.Nombre);
                    cmd.Parameters.AddWithValue("Precio", oventa.Precio);
                    cmd.Parameters.AddWithValue("DiaVenta", oventa.DiaVenta);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                rpta = true;
            }
            catch (Exception e)
            {
                string error = e.Message;
                rpta = false;
            }
            return rpta;
        }
        public void GenerarPDF()
        {
            // Creamos el documento PDF
            Document pdfDoc = new Document(PageSize.A4, 50, 50, 25, 25);
            string filePath = "ventas.pdf";

            // Creamos un writer de PDF para escribir en el archivo
            PdfWriter.GetInstance(pdfDoc, new FileStream(filePath, FileMode.Create));

            // Abrimos el documento para escribir
            pdfDoc.Open();

            // Creamos una tabla con los encabezados de columna
            PdfPTable table = new PdfPTable(4);
            table.WidthPercentage = 100;
            table.DefaultCell.Border = Rectangle.NO_BORDER;
            table.DefaultCell.Padding = 5;
            table.AddCell("ID");
            table.AddCell("Nombre");
            table.AddCell("Precio");
            table.AddCell("Fecha");

            // Iteramos a través de los datos de la lista y agregamos cada fila a la tabla
            foreach (var venta in Listar())
            {
                table.AddCell(venta.idVenta.ToString());
                table.AddCell(venta.Nombre);
                table.AddCell(venta.Precio.ToString());
                table.AddCell(venta.DiaVenta.ToString());
            }

            // Agregamos la tabla al documento
            pdfDoc.Add(table);

            // Cerramos el documento
            pdfDoc.Close();
        }
    }
}
