using System;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.IO;
using System.Net.Mail;
using System.Threading;
using System.Windows.Forms;
using System.Xml.Linq;

namespace SubirArchivos
{
    public partial class Form1 : Form
    {
        string coneccionString = ConfigurationManager.ConnectionStrings["ConexionBDD"].ConnectionString;
        string rutaarchivo = "C:\\subir\\"; //ConfigurationManager.AppSettings["RutaArchivo"];
        int errores = 0;
        string rutaLog = "";
        string name = "";
        string _mensaje = "";
        DataSet dtx = new DataSet();
        int nuevo = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void txtRutaArchivo_MouseClick(object sender, MouseEventArgs e)
        {
            DateTime fechaActual = DateTime.Now;
            name = fechaActual.Day.ToString("00") + fechaActual.Month.ToString("00") + fechaActual.Year.ToString("0000") + ".csv";

            openDialog.InitialDirectory = @"C:\subir";
            openDialog.RestoreDirectory = true;
            openDialog.FilterIndex = 1;
            openDialog.Filter = "csv files (*.csv)|*.csv";
            openDialog.FileName = "VSP_" + name;

            if(openDialog.ShowDialog() == DialogResult.OK)
            {
                txtRutaArchivo.Text = openDialog.FileName;
            }

        }

        private void btnProcesar_Click(object sender, EventArgs e)
        {
            try
            {
                //DESACTIVAR TODOS LOS TITUALRES DE ESE PRODUCTO

                string _resultado = new Conexion().FunDesactivarTitulares(coneccionString);

                //string rutaCompleta = "D:\\subir\\VSP_23102024.csv";
                 DateTime fechaname = DateTime.Now;
                //name = fechaname.Day.ToString("00") + fechaname.Month.ToString("00") + fechaname.Year.ToString("0000") + ".csv";
                //string rutaCompleta = rutaarchivo + "\\" + "VSP_" + name;
                rutaLog = rutaarchivo + "\\" + "LOG_" + fechaname.Day.ToString("00") + fechaname.Month.ToString("00") + fechaname.Year.ToString("0000") + ".txt";

                if (File.Exists(txtRutaArchivo.Text))
                {
                    //string ext = Path.GetExtension(rutaCompleta);
                    using (StreamReader Leer = new StreamReader(txtRutaArchivo.Text))
                    {
                        String Linea;
                        int next = 0;
                        //if (delimitado == "t") delimitado = "\t";
                        string delimitado = ";";
                        while ((Linea = Leer.ReadLine()) != null)
                        {
                            if (next != 0)
                            {
                                string[] campos = Linea.Split(char.Parse(delimitado));
                                //new Conexion().funGetCargasFTP(next, 119, campos[0].ToString(), coneccionString);
                                    FunGrabarData(campos);
                            }
                            next++;
                        }
                        Leer.Close();

                        //MessageBox.Show("Filas Insertadas " + next.ToString());
                        txtInsert.Text = next.ToString();
                        dtx= new Conexion().FunEstadoTitulares(coneccionString);
                        string estActivo = dtx.Tables[0].Rows[0][0].ToString();
                        txtActivos.Text = estActivo;
                        int sumaActivos = int.Parse(dtx.Tables[0].Rows[0][0].ToString());
                        string estInactivo = dtx.Tables[1].Rows[0][0].ToString();
                        txtInactivos.Text = estInactivo;
                        int Sumainactivos = int.Parse(dtx.Tables[1].Rows[0][0].ToString());
                        int suma = sumaActivos + Sumainactivos;
                        string totalbase = Convert.ToString(suma);
                        txtTotal.Text = totalbase;
                        txtNuevos.Text = nuevo.ToString();
                    }

                    //FunEnviarMail(rutaLog);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        protected void FunGrabarData(string[] strcampos)
        {
            string Cedula = "";
            string nombrescompletos = "";
            try
            {
                Cedula = strcampos[0].ToString().Trim();
                string Nombre1 = strcampos[1].ToString().Trim();
                string Nombre2 = strcampos[2].ToString().Trim();
                string Apellido1 = strcampos[3].ToString().Trim();
                string Apellido2 = strcampos[4].ToString().Trim();
                string Genero = strcampos[5].ToString().Trim();
                string Direccion = strcampos[6].ToString().Trim();
                string Nacimiento = strcampos[7].ToString().Trim();
                string TelCasa = strcampos[8].ToString().Trim();
                string TelOfi = strcampos[9].ToString().Trim();
                string Celular = strcampos[10].ToString().Trim();
                string Email = strcampos[11].ToString().Trim();
                string Tipocliente = strcampos[12].ToString().Trim();
                string Parentesco = strcampos[13].ToString().Trim();
                string FechaIniCober = strcampos[14].ToString().Trim();
                string FechaFinCober = strcampos[15].ToString().Trim();
                string TipoPolisa = strcampos[16].ToString().Trim();
                string Producto = strcampos[17].ToString().Trim();

                nombrescompletos = Nombre1 + " " + Nombre2 + " " + Apellido1 + " " + Apellido2;

                if(Cedula == "")
                {
                    FunCrearTXT(rutaLog, "SIN CEDULA", nombrescompletos, "CAMPO CEDULA VACIO");
                    return;
                }

                int continuar = 1;

                int carcater = Cedula.Length;
                if (carcater == 9)
                {
                    Cedula = '0' + Cedula;
                }
                int carcac = Celular.Length;
                if (carcac == 9)
                {
                    Celular = '0' + Celular;
                }

                if (carcater == 0)
                {
                    continuar = 0;
                }

                DataSet ds = new Conexion().FunConsultarId(Producto, coneccionString);
                int codProd = int.Parse(ds.Tables[0].Rows[0][0].ToString());

                if (codProd == 0)
                {
                    continuar = 0;
                }

                if (continuar == 1)
                {
                    string _respuesta = new Conexion().InsertPersona(Cedula, Nombre1, Nombre2, Apellido1, Apellido2, Genero, Direccion,
                            Nacimiento, TelCasa, TelOfi, Celular, Email, Tipocliente, Parentesco, FechaIniCober, FechaFinCober, TipoPolisa, codProd, coneccionString);

                    if(_respuesta != "NUEVO" || _respuesta != "ACTUALIZADO")
                    {
                        FunCrearTXT(rutaLog, Cedula, nombrescompletos, _respuesta);
                    }

                    if(_respuesta == "NUEVO")
                    {
                        nuevo++;
                    }

                }
            }
            catch (Exception ex)
            {                
                FunCrearTXT(rutaLog, Cedula, nombrescompletos, "ERROR FUN_GRABAR_DATA");
                //MessageBox.Show(ex.ToString());
            }
        }
        protected void FunCrearTXT(string ruta, string cedula, string nombres, string mensaje )
        {
            errores++;
            StreamWriter escribir = File.AppendText(ruta);
            escribir.WriteLine("CEDULA" + "|" + "NOMBRES" + "|" + "ERROR" );
            escribir.WriteLine(cedula + "|" + nombres + "|" + mensaje);
            escribir.Close();
        }

        protected void FunEnviarMail(string rutalog)
        {
            string _host = ConfigurationManager.AppSettings["Host"];
            string _port = ConfigurationManager.AppSettings["Port"];
            string _enablessl = ConfigurationManager.AppSettings["EnableSSL"];
            string _user = ConfigurationManager.AppSettings["User"];
            string _pass = ConfigurationManager.AppSettings["Pass"];

            string ePathLogo = "";
            string ePathBody = "";

            if (errores > 0)
            {
                try
                {
                    string body = "Adjunto errores, Revisar El archivo : " + "VSP_" + name;

                    string _mensaje = SendHtmlEmail("vroldan@prestasalud.com", "ealvear@prestasalud.com", "ERRORES - ARCHIVO DE CARGA DE NOVA", body, _host, int.Parse(_port), bool.Parse(_enablessl), _user, _pass, rutalog, ePathLogo,
                        ePathBody);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private string SendHtmlEmail(string mail1, string mail2, string subject, string body, string ehost, int eport, bool eEnableSSL,
            string eusername, string epassword, string pathAttach, string pathLogo, string pathBody)
        {
            using (MailMessage mailMessage = new MailMessage())
            {
                try
                {
                    Attachment archivo = new Attachment(pathAttach);
                    AlternateView htmlView = AlternateView.CreateAlternateViewFromString(body, null, "text/html");
                    mailMessage.AlternateViews.Add(htmlView);
                    mailMessage.From = new MailAddress(eusername);
                    mailMessage.Subject = subject;
                    mailMessage.IsBodyHtml = true;
                    mailMessage.Body = body;
                    //mailMessage.IsBodyHtml = true;

                    if (!string.IsNullOrEmpty(mail1))
                    {
                        mailMessage.To.Add(new MailAddress(mail1));
                    }

                    if (!string.IsNullOrEmpty(mail2))
                    {
                        mailMessage.To.Add(new MailAddress(mail2));
                    }

                    mailMessage.Attachments.Add(archivo);
                    System.Net.NetworkCredential NetworkCred = new System.Net.NetworkCredential();
                    {
                        NetworkCred.UserName = eusername;
                        NetworkCred.Password = epassword;
                    }

                    SmtpClient smtp = new SmtpClient();
                    {
                        //smtp.UseDefaultCredentials = false;
                        smtp.Credentials = NetworkCred;
                        smtp.Host = ehost;
                        smtp.Port = eport;
                        smtp.EnableSsl = eEnableSSL;
                        smtp.Send(mailMessage);
                    }
                    _mensaje = "OK";
                }
                catch (Exception ex)
                {
                    _mensaje = ex.Message;
                  
                }
                return _mensaje;
            }
        }

        private void ProgressBar1_Click(object sender, EventArgs e)
        {
            BackgroundWorker bg = new BackgroundWorker();
        }
    }
}
