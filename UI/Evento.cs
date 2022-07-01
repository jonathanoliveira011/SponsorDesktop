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
using DataBase;

namespace moninterprise_tcc
{
    public partial class Evento : Form
    {
        public Evento()
        {
            InitializeComponent();
        }

        private void LimpaCampos()
        {

            txtId_Evt.Clear();
            txtNomeEvt.Clear();
            txtLocalEvt.Clear();
            txtDtInicio.Clear();
            txtDtFinal.Clear();
            txtHoraInicio.Clear();
            txtHoraFinal.Clear();
            txtPublico.Clear();
            txtDescricao.Clear();
            txtId_Emp.Clear();
            lblCategoria.Text = ".................";
            btnAlterar.Text = "Cadastrar";
            txtDescricao.MaxLength = 300;

        }
        private void CarregaGrid()
        {
            GridEvento.Columns.Clear();
            GridEvento.AutoGenerateColumns = false;
            GridEvento.DataSource = new evento().Todos();

            DataGridViewTextBoxColumn id_evento = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn nome_evento = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn categoria_evento = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn local_evento = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn data_inicio = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn data_final = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn hora_inicio = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn hora_final = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn publico_estimado = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn descricao_evento = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn id_empresa = new DataGridViewTextBoxColumn();

            id_evento.Name = "Id Evento";
            id_evento.DataPropertyName = "id_evento";
            id_evento.ReadOnly = true;

            nome_evento.Name = "Nome do Evento";
            nome_evento.DataPropertyName = "nome_evento";
            nome_evento.ReadOnly = true;

            categoria_evento.Name = "Categoria";
            categoria_evento.DataPropertyName = "categoria_evento";
            categoria_evento.ReadOnly = true;

            local_evento.Name = "Local do Evento";
            local_evento.DataPropertyName = "local_evento";
            local_evento.ReadOnly = true;

            data_inicio.Name = "Data Inicial";
            data_inicio.DataPropertyName = "data_inicio";
            data_inicio.ReadOnly = true;

            data_final.Name = "Data Final";
            data_final.DataPropertyName = "data_final";
            data_final.ReadOnly = true;

            hora_inicio.Name = "Hora Inicial";
            hora_inicio.DataPropertyName = "hora_inicio";
            hora_inicio.ReadOnly = true;

            hora_final.Name = "Hora Final";
            hora_final.DataPropertyName = "hora_final";
            hora_final.ReadOnly = true;

            publico_estimado.Name = "Publico Estimado";
            publico_estimado.DataPropertyName = "publico_estimado";
            publico_estimado.ReadOnly = true;

            descricao_evento.Name = "Descrição";
            descricao_evento.DataPropertyName = "descricao_evento";
            descricao_evento.ReadOnly = true;

            id_empresa.Name = "Id Empresa";
            id_empresa.DataPropertyName = "id_empresa";
            id_empresa.ReadOnly = true;

            GridEvento.Columns.Add(id_evento);
            GridEvento.Columns.Add(nome_evento);
            GridEvento.Columns.Add(categoria_evento);
            GridEvento.Columns.Add(local_evento);
            GridEvento.Columns.Add(data_inicio);
            GridEvento.Columns.Add(data_final);
            GridEvento.Columns.Add(hora_inicio);
            GridEvento.Columns.Add(hora_final);
            GridEvento.Columns.Add(publico_estimado);
            GridEvento.Columns.Add(descricao_evento);
            GridEvento.Columns.Add(id_empresa);

        }

        private void Evento_Load(object sender, EventArgs e)
        {

            CarregaGrid();
            txtId_Evt.Enabled = false;

        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {

            evento evt = new evento();
            if (txtId_Evt.Text != "")
            {
                evt.id_evento = int.Parse(txtId_Evt.Text);
            }
            evt.nome_evento = txtNomeEvt.Text;
            evt.categoria_evento = cmbCategoriaEvt.Text;
            evt.local_evento = txtLocalEvt.Text;
            evt.data_inicio = txtDtInicio.Text;
            evt.data_final = txtDtFinal.Text;
            evt.hora_inicio = txtHoraInicio.Text;
            evt.hora_final = txtHoraFinal.Text;
            evt.publico_estimado = txtPublico.Text;
            evt.descricao_evento = txtDescricao.Text;
            evt.id_empresa = Convert.ToInt32(txtId_Emp.Text);
            evt.Salvar();
            MessageBox.Show("Evento cadastrado/alterado com sucesso");
            CarregaGrid();
            LimpaCampos();


        }

        private void GridEvento_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {



        }

        private void GridEvento_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            evento evt = ((evento)GridEvento.Rows[e.RowIndex].DataBoundItem);
            txtId_Evt.Text = Convert.ToString(evt.id_evento);
            txtNomeEvt.Text = evt.nome_evento;
            lblCategoria.Text = evt.categoria_evento;
            txtLocalEvt.Text = evt.local_evento;
            txtDtInicio.Text = evt.data_inicio;
            txtDtFinal.Text = evt.data_final;
            txtHoraInicio.Text = evt.hora_inicio;
            txtHoraFinal.Text = evt.hora_final;
            txtPublico.Text = evt.publico_estimado;
            txtDescricao.Text = evt.descricao_evento;
            txtId_Emp.Text = Convert.ToString(evt.id_empresa);
            btnAlterar.Text = "Alterar";

        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {

            var retorno = MessageBox.Show("Tem certeza que deseja excluir", "Excluir", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (retorno.Equals(DialogResult.Yes))
            {
                foreach (DataGridViewCell cell in GridEvento.SelectedCells)
                {
                    evento evt = ((evento)GridEvento.Rows[cell.RowIndex].DataBoundItem);
                    evt.Excluir();
                }
                foreach (DataGridViewRow row in GridEvento.SelectedRows)
                {
                    evento evt = ((evento)row.DataBoundItem);
                    evt.Excluir();
                }
            }

            LimpaCampos();
            CarregaGrid();

        }

        private void label5_Click(object sender, EventArgs e)
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
