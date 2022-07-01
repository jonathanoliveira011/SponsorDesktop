using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataBase;

namespace moninterprise_tcc
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Logar()
        {

            MySqlConnection conexao = new MySqlConnection("server=localhost;User Id=root;database=bd_sponsor; password=2701");
            MySqlCommand comando = new MySqlCommand("select * from tb_usuario where email = '" + txtEmail.Text + "' and senha = '" + txtSenha.Text + "' and categoria_usuario = 'Administrador'", conexao);
            DataTable tabela = new DataTable();
            try
            {
                conexao.Open();
                MySqlDataReader rd = comando.ExecuteReader();
                if (rd.Read())
                {

                    Principal prn = new Principal();
                    prn.Show();
                    this.Hide();

                } else {

                    MessageBox.Show("Usuário ou senha inválidos!");
                    txtEmail.Clear();
                    txtSenha.Clear();
                    txtEmail.Focus();

                }

            }
            finally
            {
                conexao.Close();
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {

            Logar();

        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
