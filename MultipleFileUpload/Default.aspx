<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>

     <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.7.1/jquery.min.js"></script>

   <title>Multiple File Upload</title>
   
</head>
<body>
     <form id="form1" runat="server">   
        <div id="divFile">
            <h3>Upload de Multiplos Arquivos</h3>  
            
            <p>
                <asp:FileUpload ID="fileUpload" multiple="true" runat="server" />   
            </p>
            <p>
                <asp:Button ID="btUpload" Text ="Upload Files" 
                    OnClick="Upload_Files" runat="server" />
            </p>

            <%--SHOW UPLOAD MESSAGE--%>
            <p><asp:label id="lblFileList" runat="server"></asp:label></p>
            <p><asp:Label ID="lblUploadStatus" runat="server"></asp:Label></p>
            <p><asp:Label ID="lblFailedStatus" runat="server"></asp:Label></p>
        </div>
    </form>
</body>
    <script>
        $('#btUpload').click(function() { 
            if (fileUpload.value.length == 0) {    // CHECK IF FILE(S) SELECTED.
                alert('Nenhum arquivo selecionado.');        
                return false; 
            } 
        });
    </script>


</html>
