using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormsApplication1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            popularCBO();
        }

        public void popularCBO() {
            SqlConnection conexao = new SqlConnection();
            conexao.ConnectionString = Program.conexao;
            conexao.Open();

            string comandoSQL = "select * from tb_estados";
            SqlCommand estadosSQL = new SqlCommand(comandoSQL, conexao);

            SqlDataAdapter sda = new SqlDataAdapter(estadosSQL);

            DataTable dtestadosBD = new DataTable();

            sda.Fill(dtestadosBD);

            cboEstado.DataSource = null;
            cboEstado.DataSource = dtestadosBD;
            cboEstado.DisplayMember = "nome";
        }

        private void cboEstado_SelectedValueChanged(object sender, EventArgs e)
        {
            SqlConnection conexao = new SqlConnection();
            conexao.ConnectionString = Program.conexao;
            conexao.Open();
            string estado = cboEstado.SelectedIndex.ToString();

            string comandoSQL = "select * from tb_municipio where id_estado = '"+estado+"' ";
            SqlCommand cidadeSQL = new SqlCommand(comandoSQL, conexao);

            SqlDataAdapter sda = new SqlDataAdapter(cidadeSQL);

            DataTable dtcidadeBD = new DataTable();

            sda.Fill(dtcidadeBD);

            cboCidade.DataSource = null;
            cboCidade.DataSource = dtcidadeBD;
            cboCidade.DisplayMember = "nome";


        }

       
    }
}
