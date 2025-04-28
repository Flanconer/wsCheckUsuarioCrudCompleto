using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace wsCheckUsuario
{
    public partial class mpPrincipal : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //validacion de la secion activa
            if (Session["nomUsuario"].ToString()==""&&
                Session["usuUsuario"].ToString() == "" &&
                Session["urlUsuario"].ToString() == "" &&
                Session["rolUsuario"].ToString() == "" )
            {
                //mensage de acceso denegado 
                Response.Write("<script laguage='javascript'>" + "alert('acceso denegado');" + "</script");
                Response.Write("<script language='javascript'>" + "document.location.href='wsAcceso.aspx';" + "</script>");
            }
            //Actualizacion de etiquetas
            Label1.Text = Application["nomEmpresa"].ToString();
            Label6.Text = Session["nomUsuario"].ToString()+"("+
                Session["usuUsuario"].ToString()+") - "+
                Session["rolUsuario"].ToString();
            //Configuracion de la foto de la imagen
            Image2.ImageUrl = Session["urlUsuario"].ToString();

        
        }
       

        protected void ImageButton4_Click1(object sender, ImageClickEventArgs e)
        {
            Session["nomUsuario"] = "";
            Session["urlUsuario"] = "";
            Session["usuUsuario"] = "";
            Session["rolUsuario"] = "";

            Response.Write("<script languaje= 'javascript'>" +
                            "alert ('Sesión cerrada exitosamente !'); " +
                           "</script>");

            Response.Write("<script language='javascript'>" +
                            "document.location.href='wsAcceso.aspx';" +
                            "</script");
        }
    }
        }
    
