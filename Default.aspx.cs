using System;
using System.Data;
using System.IO;
using System.Text;
using Microsoft.VisualBasic.FileIO;

public partial class _Default : System.Web.UI.Page 
{
    private string CVSCam = @"C:\Users\Diogo\Desktop\MyFlixWF\CSV\movies.csv";
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            CarregGrid();
        }
        catch { }   
    }

    private void CarregGrid()
    {
        DataTable dt = new DataTable();
        bool Cabecalho = true;
        //Array para adicionar cada linha
        string[] AdicCol = new string[] { "" };
        using (TextFieldParser FichCSV = new TextFieldParser(CVSCam))
        {
            FichCSV.TrimWhiteSpace = true;
            FichCSV.TextFieldType = FieldType.Delimited;
            FichCSV.SetDelimiters(";");
            if (Cabecalho)
            {
                AdicCol = FichCSV.ReadFields();
                foreach (string Col in AdicCol)
                {
                    DataColumn Linhas = new DataColumn(Col, Type.GetType("System.String"));
                    dt.Columns.Add(Linhas);
                }
            }
            while (true)
            {
                if (Cabecalho == false)
                {
                    string[] parts = FichCSV.ReadFields();
                    if (parts == null)
                    {
                        break;
                    }
                    //Adiciona a linha do filme
                    dt.Rows.Add(parts);
                }
                Cabecalho = false;
            }

        }
        grdList.DataSource = dt;
        grdList.DataBind();
    }
    protected void btnDispRemote_Click(object sender, EventArgs e)
    {
        try
        {
            CriaFilme();
        }
        catch
        {
        }
    }
    private void CriaFilme()
    {    //Criar ficheiro caso n exista
        if (!File.Exists(CVSCam))
        {
            File.Create(CVSCam).Dispose();
            //Criar o arquivo, 
            //using para fazer o Dispose automático do arquivo após criá-lo.
            using (FileStream fs = File.Create(CVSCam)) { }
        }
        using (StreamWriter sw = File.AppendText(CVSCam))
        {
            //método Write para escrever algo em nosso arquivo texto
            sw.WriteLine(txtimdb_id.Text + ";" + txtTitle.Text + ";" + txtYear.Text);
        }
        CarregGrid();
    }
    protected void BtnRemFilme_Click(object sender, EventArgs e)
    {
        try
        {
            File_DeleteLine(txtRemFilme.Text);
        }
        catch { }
    }
    void File_DeleteLine(string NmFilmeElim)
    {
        string LinhaaElim = NmFilmeElim;

        if (File.Exists(CVSCam))
        {
            string[] lines = File.ReadAllLines(CVSCam);

            using (StreamWriter sw = new StreamWriter(CVSCam, false))
            {
                foreach (string line in lines)
                {
                    string[] parts = line.Split(';');
                    if (parts[0] != LinhaaElim)
                    {
                        sw.WriteLine(line);
                    }
                    else
                    {
                        lblRemFilme.Text=("Filme " + LinhaaElim + " foi eliminado");
                    }
                }
            }
            CarregGrid();
        }
        else
        {
            lblRemFilme.Text=("Ficheiro não existe");
        }
    }
    protected void PesqFilme()
    {
        StreamReader sr = new StreamReader(CVSCam);
        StringBuilder sb = new StringBuilder();
        DataTable dt = CreateTable();
        DataRow dr;
        string s;
        while (!sr.EndOfStream)
        {
            s = sr.ReadLine();

            string[] str = s.Split(';');

            dr = dt.NewRow();
            string str1 = str[0].ToString();
            if (!str1.Equals("imdb_id"))
            {
                //Filtrar pelo filme colocado na textbox de pesquias de filmes
                if (str[1] == txtPesqFilme.Text)
                {
                    dr["imdb_id"] = str[0].ToString();
                    dr["Title"] = str[1].ToString();
                    dr["Year"] = str[2].ToString();
                    dt.Rows.Add(dr);
                }
            }
        }
        grdList.DataSource = dt;
        grdList.DataBind();
    }
    protected DataTable CreateTable()
    {
        // Criar novo DataTable.
        DataTable table = new DataTable("MyFlix");

        DataColumn column;

//Criar 1 coluna
        column = new DataColumn();
        column.DataType = Type.GetType("System.String");
        column.ColumnName = "imdb_id";
        column.ReadOnly = true;
        column.Unique = true;
        // Adicionar a 1 coluna
        table.Columns.Add(column);

        //Criar 2 coluna
        column = new DataColumn();
        column.DataType = Type.GetType("System.String");
        column.ColumnName = "Title"; 
        column.ReadOnly = true;
        column.Unique = false;
        // Adicionar a 2 coluna
        table.Columns.Add(column);

        //Criar 3 coluna
        column = new DataColumn();
        column.DataType = Type.GetType("System.String");
        column.ColumnName = "Year";
        column.ReadOnly = true;
        column.Unique = false;
        // Adicionar a 3 coluna
        table.Columns.Add(column);

        return table;
    }
    protected void btnPesqFilme_Click1(object sender, EventArgs e)
    {
        try
        {
            PesqFilme();
        }
        catch
        { }
    }
}
