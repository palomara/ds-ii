using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace CadastroPessoa
{
    public partial class Form1 : Form
    {
        private List<Funcionario> listaFuncionario = new List<Funcionario>();
        
         public Form1()
        {
            InitializeComponent();
        }

         private void Form1_Load(object sender, EventArgs e)
         {
             SqlConnection conexao = new SqlConnection();
                conexao.ConnectionString = Program.conexaoBD;
                conexao.Open();

                string comandoSQL = "select * from tb_funcionario";
                SqlCommand funconarioSQL = new SqlCommand(comandoSQL, conexao);

                SqlDataAdapter sda = new SqlDataAdapter(funconarioSQL);

                DataTable dtFuncionariosBD = new DataTable();

                sda.Fill(dtFuncionariosBD);

                cboNmFuncionario.DataSource = dtFuncionariosBD;
                cboNmFuncionario.DisplayMember = "nmFuncionario";
         }

        private void btnSalvarOff_Click(object sender, EventArgs e)
        {
            Funcionario Func = new Funcionario();

            Func.nmFuncionario = txtNmFuncionario.Text;
            Func.email = txtEmail.Text;
            Func.endereco = txtEndereco.Text;
            Func.telefone = txtTelefone.Text;
                listaFuncionario.Add(Func);
                dgvFuncionarioMemoria.DataSource = null;
                dgvFuncionarioMemoria.DataSource = listaFuncionario;
        }

        private void btnSalvarOnline_Click(object sender, EventArgs e)
        {
            foreach (Funcionario item in listaFuncionario)
            {
                SqlConnection conexao = new SqlConnection();
                conexao.ConnectionString = Program.conexaoBD;
                conexao.Open();

                string comandoSQL = "insert into tb_funcionario(nmFuncionario,email,endereco,telefone) values('" + item.nmFuncionario + "','" + item.email + "','" + item.endereco + "','" + item.telefone + "')";
                SqlCommand funconarioSQL = new SqlCommand(comandoSQL, conexao);
                funconarioSQL.ExecuteNonQuery();
                conexao.Close();

               listaFuncionario = new List<Funcionario>();

               dgvFuncionarioMemoria.DataSource = null;
                
            }

            MessageBox.Show("Enviado com sucesso!");
        }

        private void cboNmFuncionario_SelectedValueChanged(object sender, EventArgs e)
        {
            SqlConnection conexao = new SqlConnection();
            conexao.ConnectionString = Program.conexaoBD;
            conexao.Open();

            string comandoSQL = "select * from tb_funcionario  where nmFuncionario = '"+cboNmFuncionario.Text+"'";
            SqlCommand funconarioSQL = new SqlCommand(comandoSQL, conexao);

            SqlDataAdapter sda = new SqlDataAdapter(funconarioSQL);

            DataTable dtFuncionariosBD = new DataTable();

            sda.Fill(dtFuncionariosBD);

            dgvFuncionarioMemoria.DataSource = null;
            dgvFuncionarioMemoria.DataSource = dtFuncionariosBD;
        }
    }
}
