<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <div style="width:100%;background-color:cornflowerblue;color:white;">
       <br />
       <h2>My First App</h2> 
       
    </div>
    <form id="form1" runat="server">
        <div>
            <hr />
            <div style="text-align:center;width:70%;color:gray" ><h3>Person Details<asp:FileUpload ID="FileUpload1" runat="server" OnDataBinding="FileUpload1_DataBinding" />
                </h3></div>
            <hr />
            <br />
             
            <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
           
            
            <asp:Button ID="Button2" runat="server" Text="Search" OnClick="Button2_Click1" BackColor="#0066CC" Font-Bold="True" ForeColor="White" Width="82px" />
             <hr />  <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"
                  Width="75%" Height="179px" OnRowCommand="GridView1_RowCommand">
                <AlternatingRowStyle BackColor="#CCCCCC" />
                <Columns>
                    <asp:BoundField DataField="FirstName" HeaderText="FirstName" />
                    <asp:BoundField DataField="LastName" HeaderText="LastName" />
                    <asp:BoundField DataField="Age" HeaderText="Age" />
                    <asp:BoundField DataField="Marks" HeaderText="Marks" />
                    <asp:BoundField DataField="ID" HeaderText="ID" />
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Button ID="Button5" runat="server" CommandName="Select" BackColor="#006699"
                             Font-Bold="True" ForeColor="White" Text="Select" CommandArgument="<%# Container.DataItemIndex %>" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <HeaderStyle BackColor="#666699" ForeColor="White" />
            </asp:GridView>
          
            <br />
              <hr />
            <asp:HiddenField ID="HiddenField1"  runat="server" />
            
           <asp:Label ID="Label2" runat="server" Text="FirstName"></asp:Label>
            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
             <asp:Label ID="Label1" runat="server" Text="LastName"></asp:Label>
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
           <asp:Label ID="Label3" runat="server" Text="Age"></asp:Label>  
            <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
          <asp:Label ID="Label4" runat="server" Text="Marks"></asp:Label>
            <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
           
            
            <asp:Button ID="Button1" runat="server" Text="Save" OnClick="Button1_Click" BackColor="#0066CC" Font-Bold="True" ForeColor="White" Width="82px" />
            <asp:Button ID="Button3" runat="server" Text="Delete" OnClick="Button3_Click" BackColor="#0066CC" Font-Bold="True" ForeColor="White" Width="82px" />
            
            <asp:Button ID="Button4" runat="server" Text="Update" OnClick="Button4_Click" BackColor="#0066CC" Font-Bold="True" ForeColor="White" Width="82px" />
            
            <br />
            <hr />
        </div>
        <p>
            &nbsp;</p>
    </form>
</body>
</html>
