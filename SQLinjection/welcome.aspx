 <%@ Page Language="C#" AutoEventWireup="true" CodeBehind="welcome.aspx.cs" Inherits="SQLinjection.welcome" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <p> Hello World</p>
        <p> 
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Back" />
        </p>
    </div>
    </form>
</body>
</html>
