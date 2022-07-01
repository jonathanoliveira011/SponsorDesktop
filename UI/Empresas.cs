using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business;
using MySql.Data.MySqlClient;

namespace moninterprise_tcc
{
    public partial class Empresas : Form
    {
        public Empresas()
        {
            InitializeComponent();
        }
        
        private void LimpaCampos()
        {

            txtBuscar.Clear();
            txtNomeResp.Clear();
            txtCPF.Clear();
            txtCNPJ.Clear();
            txtRazaoSocial.Clear();
            txtTelefone.Clear();
            txtRua.Clear();
            txtNumero.Clear();
            txtCEP.Clear();
            txtBairro.Clear();
            txtCidade.Clear();
            txtEstado.Clear();
            txtPais.Clear();
            txtDescricao.Clear();
            btnAlterar.Text = "Cadastrar";
        }

        private void CarregaGrid()
        {
            GridEmpresa.Columns.Clear();
            GridEmpresa.AutoGenerateColumns = false;
            GridEmpresa.DataSource = new empresa().Todos();

            DataGridViewTextBoxColumn id = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn resp = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn cpf = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn cnpj = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn telefone = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn razao = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn descricao = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn rua = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn numero = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn bairro = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn cidade = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn estado = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn pais = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn cep = new DataGridViewTextBoxColumn();

            id.Name = "Id Empresa";
            id.DataPropertyName = "id_empresa";
            id.ReadOnly = true;

            resp.Name = "Responsável";
            resp.DataPropertyName = "nome_responsavel";
            resp.ReadOnly = true;

            cpf.Name = "CPF";
            cpf.DataPropertyName = "cpf_responsavel";
            cpf.ReadOnly = true;

            cnpj.Name = "CNPJ";
            cnpj.DataPropertyName = "cnpj";
            cnpj.ReadOnly = true;

            telefone.Name = "Telefone";
            telefone.DataPropertyName = "telefone";
            telefone.ReadOnly = true;

            razao.Name = "Razão Social";
            razao.DataPropertyName = "razao_social";
            razao.ReadOnly = true;

            descricao.Name = "Descrição";
            descricao.DataPropertyName = "descricao_empresa";
            descricao.ReadOnly = true;

            rua.Name = "Rua";
            rua.DataPropertyName = "rua";
            rua.ReadOnly = true;

            numero.Name = "Número";
            numero.DataPropertyName = "numero";
            numero.ReadOnly = true;

            bairro.Name = "Bairro";
            bairro.DataPropertyName = "bairro";
            bairro.ReadOnly = true;

            cidade.Name = "Cidade";
            cidade.DataPropertyName = "cidade";
            cidade.ReadOnly = true;

            estado.Name = "Estado";
            estado.DataPropertyName = "estado";
            estado.ReadOnly = true;

            pais.Name = "País";
            pais.DataPropertyName = "pais";
            pais.ReadOnly = true;

            cep.Name = "CEP";
            cep.DataPropertyName = "cep";
            cep.ReadOnly = true;

            GridEmpresa.Columns.Add(id);
            GridEmpresa.Columns.Add(resp);
            GridEmpresa.Columns.Add(cpf);
            GridEmpresa.Columns.Add(cnpj);
            GridEmpresa.Columns.Add(telefone);
            GridEmpresa.Columns.Add(razao);
            GridEmpresa.Columns.Add(descricao);
            GridEmpresa.Columns.Add(rua);
            GridEmpresa.Columns.Add(numero);
            GridEmpresa.Columns.Add(bairro);
            GridEmpresa.Columns.Add(estado);
            GridEmpresa.Columns.Add(pais);
            GridEmpresa.Columns.Add(cep);

        }

        private void Empresas_Load(object sender, EventArgs e)
        {

            CarregaGrid();
                
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {

            empresa emp = new empresa();
            if (txtBuscar.Text != "")
            {
                emp.id_empresa = int.Parse(txtBuscar.Text);
            }
            emp.nome_responsavel = txtNomeResp.Text;
            emp.cpf_responsavel = txtCPF.Text;
            emp.cnpj = txtCNPJ.Text;
            emp.telefone = txtTelefone.Text;
            emp.razao_social = txtRazaoSocial.Text;
            emp.descricao_empresa = txtDescricao.Text;
            emp.rua = txtRua.Text;
            emp.numero = txtNumero.Text;
            emp.bairro = txtBairro.Text;
            emp.cidade = txtCidade.Text;
            emp.estado = txtEstado.Text;
            emp.pais = txtPais.Text;
            emp.cep = txtCEP.Text;
            emp.Salvar();
            MessageBox.Show("Cliente cadastrado/alterado com sucesso");
            CarregaGrid();
            LimpaCampos();

        }

        private void GridEmpresa_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void GridEmpresa_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            empresa emp = ((empresa)GridEmpresa.Rows[e.RowIndex].DataBoundItem);
            txtBuscar.Text = Convert.ToString(emp.id_empresa);
            txtNomeResp.Text = emp.nome_responsavel;
            txtCPF.Text = emp.cpf_responsavel;
            txtCNPJ.Text = emp.cnpj;
            txtTelefone.Text = emp.telefone;
            txtRazaoSocial.Text = emp.razao_social;
            txtDescricao.Text = emp.descricao_empresa;
            txtRua.Text = emp.rua;
            txtNumero.Text = emp.numero;
            txtBairro.Text = emp.bairro;
            txtCidade.Text = emp.cidade;
            txtEstado.Text = emp.estado;
            txtPais.Text = emp.pais;
            txtCEP.Text = emp.cep;
            btnAlterar.Text = "Alterar";

        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (txtBuscar.Text != "" || txtBuscar.Text != null)
            {
                var retorno = MessageBox.Show("Tem certeza que deseja excluir", "Excluir", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (retorno.Equals(DialogResult.Yes))
                {
                    foreach (DataGridViewCell cell in GridEmpresa.SelectedCells)
                    {
                        empresa emp = ((empresa)GridEmpresa.Rows[cell.RowIndex].DataBoundItem);
                        emp.ExcluirEmpresa();
                    }
                    foreach (DataGridViewRow row in GridEmpresa.SelectedRows)
                    {
                        empresa emp = ((empresa)row.DataBoundItem);
                        emp.ExcluirEmpresa();
                    }
                }
             } else { MessageBox.Show("Selecione uma empresa!"); }
            LimpaCampos();
            CarregaGrid();

        }

        private void txtCidade_TextChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void voltarToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Principal princ = new Principal();
            princ.Show();
            this.Hide();

        }
    }
}
