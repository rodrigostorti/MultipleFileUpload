using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }



    protected void Upload_Files(object sender, EventArgs e)
    {
        if (fileUpload.HasFile)     // verifica se há arquivos selecionados
        {
            int iUploadedCnt = 0;
            int iFailedCnt = 0;
            HttpFileCollection hfc = Request.Files;
            lblFileList.Text = "Selecionado <b>" + hfc.Count + "</b> arquivos(s)";

            if (hfc.Count <= 10)    // limite de 10 arquivos
            {
                for (int i = 0; i <= hfc.Count - 1; i++)
                {
                    HttpPostedFile hpf = hfc[i];
                    if (hpf.ContentLength > 0)
                    {
                        if (!File.Exists(Server.MapPath("CopyFiles\\") + Path.GetFileName(hpf.FileName)))
                        {
                            DirectoryInfo objDir =  new DirectoryInfo(Server.MapPath("CopyFiles\\"));

                            string sFileName = Path.GetFileName(hpf.FileName);
                            string sFileExt = Path.GetExtension(hpf.FileName);

                            // verifica duplicações
                            FileInfo[] objFI = objDir.GetFiles(sFileName.Replace(sFileExt, "") + ".*");

                            if (objFI.Length > 0)
                            {
                                // verifica se há arquivos com o mesmo nome
                                foreach (FileInfo file in objFI)
                                {
                                    string sFileName1 = objFI[0].Name;
                                    string sFileExt1 = Path.GetExtension(objFI[0].Name);

                                    if (sFileName1.Replace(sFileExt1, "") ==   sFileName.Replace(sFileExt, ""))
                                    {
                                        iFailedCnt += 1;        // não aceita duplicações
                                        break;
                                    }
                                }
                            }
                            else
                            {
                                // salvando arquivo  nas pasta 
                                hpf.SaveAs(Server.MapPath("CopyFiles\\") +  Path.GetFileName(hpf.FileName));
                                iUploadedCnt += 1;
                            }
                            }
                        }
                    }
                    lblUploadStatus.Text = "<b>" + iUploadedCnt + "</b> arquivos(s) salvo.";
                                    lblFailedStatus.Text = "<b>" + iFailedCnt + 
                                        "</b> arquivos duplicados não serão salvos.";
            }
            else lblUploadStatus.Text = "Max. 10 arquivos permitido.";
        }
        else lblUploadStatus.Text = "Nenhum arquivo selecionado.";
    }






}

