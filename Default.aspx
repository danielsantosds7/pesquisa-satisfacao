<%@ Page Title="Home Page" Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Pesquisa_Votacao_NP._Default" %>

<!doctype html>
<html lang="en">
<head>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <title>Bootstrap demo</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha1/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-GLhlTQ8iRABdZLl6O3oVMWSktQOp6b7In1Zl3/Jr59b6EGGoI1aFkw7cmDA6j6gD" crossorigin="anonymous">
</head>

<body>
    <h1>Pesquisa de Satisfação</h1>

    <form id="form1" runat="server">

        <div class="form-check">
            <asp:RadioButton ID="Btn1" runat="server" Text="Muito Satisfeito" GroupName="Votacao" />
            <asp:RadioButton ID="Btn2" runat="server" Text="Satisfeito" GroupName="Votacao" />
            <asp:RadioButton ID="Btn3" runat="server" Text="Indiferente" GroupName="Votacao" />
            <asp:RadioButton ID="Btn4" runat="server" Text="Insatisfeito" GroupName="Votacao" />
            <asp:RadioButton ID="Btn5" runat="server" Text="Muito Insatisfeito" GroupName="Votacao" />
        </div>

        <div>
            <asp:Button Text="Votar" runat="server" class="btn btn-info" OnClick="Submit" />
        </div>

        <div>
            <asp:GridView ID="g1" runat="server" AutoGenerateColumns="False" DataSourceID="ConnectionString" class="table table-hover" GridLines="None" >
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:BoundField DataField="RESPOSTA1" HeaderText="Tipos de Respostas" />
                    <asp:BoundField DataField="TOTALRESPOSTA" HeaderText="Total de respostas" />
                    <asp:BoundField DataField="PERCENTUALRESPOSTA" HeaderText="Percentual das respostas" />
                    
                </Columns>
            </asp:GridView>
            <asp:SqlDataSource ID="ConnectionString" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT * FROM VW_RESULTADOS"></asp:SqlDataSource>
        </div>


        <h2>Distribuição dos votos</h2>

        <div>
            <%= resp1 %>
        </div>

    </form>   
               

    <script src="https://cdn.jsdelivr.net/npm/@popperjs/core@2.11.6/dist/umd/popper.min.js" integrity="sha384-oBqDVmMz9ATKxIep9tiCxS/Z9fNfEXiDAYTujMAeBAsjFuCZSmKbSSUnQlmh/jp3" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha1/dist/js/bootstrap.min.js" integrity="sha384-mQ93GR66B00ZXjt0YO5KlohRA5SY2XofN4zfuZxLkoj1gXtW8ANNCe9d5Y3eG5eD" crossorigin="anonymous"></script>
</body>

</html>


