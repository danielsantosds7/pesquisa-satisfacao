using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using Microsoft.Ajax.Utilities;
using System.Globalization;
using System.Data;
using System.Security.Cryptography.X509Certificates;

namespace Pesquisa_Votacao_NP
{
    public partial class _Default : Page
    {
        int ? resposta = null;
        DateTime dt = DateTime.Now;
        public string resp1, resp2, resp3, resp4, resp5;
        public int resp6 = 0;                
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                CarregaDados2();                
            }
        }
        protected void Submit(object sender, EventArgs e)
        {
            if (Btn1.Checked)
            {
                resposta = 1;
            }
            else if (Btn2.Checked)
            {
                resposta = 2;
            }
            else if (Btn3.Checked)
            {
                resposta = 3;
            }
            else if (Btn4.Checked)
            {
                resposta = 4;
            }
            else if (Btn5.Checked)
            {
                resposta = 5;
            }

            string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("INSERT INTO ZNWPESQUISASATISFACAO (IDPERGUNTA, DATAEVENTO, RESPOSTA) VALUES(@IDPERGUNTA, @DATAEVENTO, @RESPOSTA)"))
                {
                    cmd.Connection = con;
                    cmd.Parameters.AddWithValue("@IDPERGUNTA", 1);                    
                    cmd.Parameters.AddWithValue("@DATAEVENTO", dt);
                    cmd.Parameters.AddWithValue("@RESPOSTA", resposta);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
        }
        /*

        protected void CarregaDados()
        {
            string resposta1 = string.Empty;
            string resposta2 = string.Empty;
            string resposta3 = string.Empty;
            string resposta4 = string.Empty;
            string resposta5 = string.Empty;

           

            try
            {
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SELECT PERCENTUALRESPOSTA FROM VW_RESULTADOS WHERE RESPOSTA1 BETWEEN 1 AND 5", connection))
                    {                        
                        connection.Open();
                        
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            
                            while (reader.Read())
                            {
                                
                                resposta1 = reader[0].ToString();                                
                                resposta2 = reader[1].ToString();
                                resposta3 = reader[2].ToString();
                                resposta4 = reader[3].ToString();
                                resposta5 = reader[4].ToString();

                                resp1 = resposta1;
                                resp2 = resposta2;
                                resp3 = resposta3;
                                resp4 = resposta4;
                                resp5 = resposta5;
                                
                            }
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                //Error handling
            }          
        }
        */
        public string CarregaDados2()
        {
            string resposta1 = string.Empty;
            string resposta2 = string.Empty;
            string resposta3 = string.Empty;
            string resposta4 = string.Empty;
            string resposta5 = string.Empty;

            try
            {
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SELECT PERCENTUALRESPOSTA FROM VW_RESULTADOS WHERE RESPOSTA1 BETWEEN 1 AND 5", connection))
                    {
                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {

                                    resposta1 = reader[0].ToString();

                                    resp1 = resposta1;


                                }
                            } 
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                //Error handling
            }


            return resp1;            
        }
    }
}