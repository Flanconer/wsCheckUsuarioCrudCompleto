using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using wsCheckUsuario.Models;

namespace wsCheckUsuario
{
    public partial class Formulario_web1 : System.Web.UI.Page
    {
        protected async void Page_Load(object sender, EventArgs e)
        {

            //Configurar el evento del gridview1
            GridView1.PageIndexChanging += GridView1_PageIndexChanging;
            await CargaDatosApi();

        }

        private void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            //Actualizar el indice de pagina del Gridview1 
            //Actualizar los datosA
            GridView1.PageIndex = e.NewPageIndex;
            GridView1.DataBind();

        }

        //metodo asincrono para ejecutar:vwRptUsuario
        private async Task CargaDatosApi()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string apiUrl = "";
                    clsApiStatus objRespuesta = new clsApiStatus();
                    DataTable dtFinal = new DataTable();


                    apiUrl = "https://localhost:44370/check/usuario/vwRptUsuario?filtro=" + TextBox1.Text;
                    HttpResponseMessage respuesta = await client.GetAsync(apiUrl);

                    if (respuesta.IsSuccessStatusCode)
                    {
                        string resultado = await respuesta.Content.ReadAsStringAsync();
                        objRespuesta = JsonConvert.DeserializeObject<clsApiStatus>(resultado);
                        JArray jsonArray = (JArray)objRespuesta.datos["vwRptUsuario"];
                        DataTable dt = JsonConvert.DeserializeObject<DataTable>(jsonArray.ToString());
                        dtFinal.Merge(dt); // Se agrega al DataTable final
                    }

                    // Filtro por usuario
                    apiUrl = "https://localhost:44370/check/usuario/vwRptUsuariofiltro?filtro=" + TextBox1.Text;
                    HttpResponseMessage respuesta1 = await client.GetAsync(apiUrl);

                    if (respuesta1.IsSuccessStatusCode)
                    {
                        string resultado1 = await respuesta1.Content.ReadAsStringAsync();
                        objRespuesta = JsonConvert.DeserializeObject<clsApiStatus>(resultado1);
                        JArray jsonArray1 = (JArray)objRespuesta.datos["vwRptUsuario"];
                        DataTable dt1 = JsonConvert.DeserializeObject<DataTable>(jsonArray1.ToString());
                        dtFinal.Merge(dt1); // Se agrega también al DataTable final
                    }

                    // Mostrar resultados combinados en el GridView

                    if (dtFinal.Rows.Count > 0)
                    {
                        GridView1.DataSource = dtFinal;
                        GridView1.DataBind();
                    }
                    else
                    {
                        Response.Write("<script language='javascript'>alert('No se encontraron resultados.');</script>");
                    }
                }
            }

            catch (Exception ex)
            {
                Response.Write("<script language='javascript'>alert('Error inesperado ...');</script>");
            }
        }
    }
}
       
