using Microsoft.Win32;
using System;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
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
        int next=0,nuevo = 0, registros = 0, totalprocesar = 0, progreso = 0, porciento = 0, _msg0 = 0, contador = 0, _msg1 = 0, _msg2 = 0, _msg3 = 0, _msg4 = 0, _msg5 = 0, _msg6 = 0;
        DataTable dtbNew = new DataTable();
        DataTable dtbdatos = new DataTable();
        DataSet dts = new DataSet();
        DataRow dtr;
        BackgroundWorker bg = new BackgroundWorker();
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {

            for (int col = 0; col < 19; col++)
                dtbNew.Columns.Add(new DataColumn("Column" + (col + 1).ToString()));
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
                                //FunGrabarData(campos);
                                dtbdatos = FunGrabarDataTable(campos);
                            }
                            next++;
                        }
                        dts.Tables.Add(dtbdatos);
                        Leer.Close();

                        if (dts.Tables[0].Rows.Count > 0)
                        {
                            registros = dts.Tables[0].Rows.Count;

                            bg.WorkerReportsProgress = true;
                            bg.ProgressChanged += backgroundWorker1_ProgressChanged;
                            bg.DoWork += backgroundWorker1_DoWork;
                            bg.RunWorkerCompleted += backgroundWorker1_RunWorkerCompleted;
                            bg.RunWorkerAsync();
                        }

                           
                        //txtInsert.Text = next.ToString();
                        //dtx= new Conexion().FunEstadoTitulares(coneccionString);
                        //string estActivo = dtx.Tables[0].Rows[0][0].ToString();
                        //txtActivos.Text = estActivo;
                        //int sumaActivos = int.Parse(dtx.Tables[0].Rows[0][0].ToString());
                        //string estInactivo = dtx.Tables[1].Rows[0][0].ToString();
                        //txtInactivos.Text = estInactivo;
                        //int Sumainactivos = int.Parse(dtx.Tables[1].Rows[0][0].ToString());
                        //int suma = sumaActivos + Sumainactivos;
                        //string totalbase = Convert.ToString(suma);
                        //txtTotal.Text = totalbase;
                        //txtNuevos.Text = nuevo.ToString();
                    }

                    //FunEnviarMail(rutaLog);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private DataTable FunGrabarDataTable(string[] campos)
        {
            try
            {
                dtr = dtbNew.NewRow();
                dtbNew.Rows.Add(campos);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "PRESTASALUD", MessageBoxButtons.OK);
            }
            return dtbNew;
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

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            totalprocesar = dts.Tables[0].Rows.Count;
            foreach (DataRow drfila in dts.Tables[0].Rows)
            {
                contador++;
                string Cedula = drfila[0].ToString().TrimStart().TrimEnd();
                string Nombre1 = drfila[1].ToString().TrimStart().TrimEnd();
                string Nombre2 = drfila[2].ToString().TrimStart().TrimEnd();
                string Apellido1 = drfila[3].ToString().TrimStart().TrimEnd();
                string Apellido2 = drfila[4].ToString().TrimStart().TrimEnd();
                string Genero = drfila[5].ToString().TrimStart().TrimEnd();
                string Direccion = drfila[6].ToString().TrimStart().TrimEnd();
                string Nacimiento = drfila[7].ToString().TrimStart().TrimEnd();
                string TelCasa = drfila[8].ToString().TrimStart().TrimEnd();
                string TelOfi = drfila[9].ToString().TrimStart().TrimEnd();
                string Celular = drfila[10].ToString().TrimStart().TrimEnd();
                string Email = drfila[11].ToString().TrimStart().TrimEnd();
                string Tipocliente = drfila[12].ToString().TrimStart().TrimEnd();
                string Parentesco = drfila[13].ToString().TrimStart().TrimEnd();
                string FechaIniCober = drfila[14].ToString().TrimStart().TrimEnd();
                string FechaFinCober = drfila[15].ToString().TrimStart().TrimEnd();
                string TipoPolisa = drfila[16].ToString().TrimStart().TrimEnd();
                string Producto = drfila[17].ToString().TrimStart().TrimEnd();

                string nombrescompletos = Nombre1 + " " + Nombre2 + " " + Apellido1 + " " + Apellido2;

                if (Cedula == "")
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

                    if (_respuesta != "NUEVO" || _respuesta != "ACTUALIZADO")
                    {
                        FunCrearTXT(rutaLog, Cedula, nombrescompletos, _respuesta);
                    }

                    if (_respuesta == "NUEVO")
                    {
                        nuevo++;
                    }

                }
                progreso++;
                porciento = Convert.ToInt16((((double)progreso / (double)totalprocesar) * 100.00));
                Thread.Sleep(5);
                bg.ReportProgress(porciento);
            }
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            try
            {
                ProgressBar1.Refresh();
                if (e.ProgressPercentage > 100) ProgressBar1.Value = 100;
                else ProgressBar1.Value = e.ProgressPercentage;
                ProgressBar1.Step = 1;
                ProgressBar1.Style = ProgressBarStyle.Continuous;
                ProgressBar1.Minimum = 0;
                ProgressBar1.Maximum = 100;
                if (e.ProgressPercentage > 100)
                {
                    //LblProgreso.Text = "100%";
                    ProgressBar1.Value = ProgressBar1.Maximum;
                }
                else
                {
                    switch (e.ProgressPercentage)
                    {
                        case 0:
                            if (_msg0 == 0)
                            {
                                TxtCommandLine.Text = "Iniciando Proceso de Lectura.." +
                                                        Environment.NewLine + Environment.NewLine;
                                _msg0 = 1;
                            }
                            break;
                        case 5:
                            if (_msg1 == 0)
                            {
                                TxtCommandLine.Text += "Insertando datos.." +
                                    Environment.NewLine + Environment.NewLine;
                                _msg1 = 1;
                            }
                            break;
                        case 10:
                            if (_msg2 == 0)
                            {
                                TxtCommandLine.Text += "Procesando espere..." + Environment.NewLine + Environment.NewLine;
                                _msg2 = 1;
                            }
                            break;
                        case 95:
                            if (_msg3 == 0)
                            {
                                TxtCommandLine.Text += "Finalizando Proceso..." + Environment.NewLine + Environment.NewLine;
                                _msg3 = 1;
                            }
                            break;
                    }
                    ProgressBar1.Value = ProgressBar1.Maximum;
                    LblProceso.Text = "Registros " + contador.ToString() + " De " + totalprocesar.ToString();
                    //LblProgreso.Text = Convert.ToString(e.ProgressPercentage) + "%";
                    ProgressBar1.Value = e.ProgressPercentage;

                    using (Graphics gr = ProgressBar1.CreateGraphics())
                    {
                        gr.DrawString(e.ProgressPercentage.ToString() + "%", SystemFonts.DefaultFont,
                            Brushes.Black, new PointF(ProgressBar1.Width / 2 - (gr.MeasureString(e.ProgressPercentage.ToString() + "%",
                            SystemFonts.DefaultFont).Width / 2.0F), ProgressBar1.Height / 2 - (gr.MeasureString(e.ProgressPercentage.ToString() + "%",
                            SystemFonts.DefaultFont).Height / 2.0F)));
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "GS-BPO", MessageBoxButtons.OK);
            }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {

                txtInsert.Text = contador.ToString();
                dtx = new Conexion().FunEstadoTitulares(coneccionString);
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

                MessageBox.Show("Se han procesado: " + contador.ToString() + " Registros","SALUD Y VIDA PROTEGIDA", MessageBoxButtons.OK);
                //LblProgreso.Text = "%";
                ProgressBar1.Value = 0;
                bg.DoWork -= backgroundWorker1_DoWork;
                bg.RunWorkerCompleted -= backgroundWorker1_RunWorkerCompleted;
                dts.Clear();
                dts.Tables.Remove(dtbdatos);
                progreso = 0;
                totalprocesar = 0;
                contador = 0;
                registros = 0;
                LblProceso.Text = "Registros 0";
                ProgressBar1.Value = 0;
                TxtCommandLine.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "GS-BPO", MessageBoxButtons.OK);
            }
        }


    }
}
