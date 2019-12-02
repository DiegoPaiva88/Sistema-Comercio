using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CamadaNegocio;


namespace CamadaApresentacao
{
    public partial class frmApresentacao : Form
    {

        private bool eNovo = false;
        private bool eEditar = false;

        public frmApresentacao()
        {
            InitializeComponent();
            this.ttMensagem.SetToolTip(this.txtNome, "Insira o nome da Apresentação");
        }

        //Mostar menssagem de configuraçaõ
        private void MensagemOK(string mensagem)
        {
            MessageBox.Show(mensagem, "Sistema Comércio ", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        //Mostar menssagem de erro
        private void MensagemErro(string mensagem)
        {
            MessageBox.Show(mensagem, "Sistema Comércio ", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }


        //Limpar Campos
        private void Limpar()
        {
            this.txtNome.Text = string.Empty;
            this.txtIdApresentacao.Text = string.Empty;
            this.txtDescricao.Text = string.Empty;
        }

        //Habilitar os text Box
        private void Habilitar(bool valor)
        {
            this.txtNome.ReadOnly = !valor;
            this.txtIdApresentacao.ReadOnly = !valor;
            this.txtDescricao.ReadOnly = !valor;
        }

        //Habilitar os botoes
        private void Botoes()
        {
            if (this.eNovo || this.eEditar)
            {
                this.Habilitar(true);
                this.btnNovo.Enabled = false;
                this.btnSalvar.Enabled = true;
                this.btnEditar.Enabled = false;
                this.btnCancelar.Enabled = true;

            }
            else
            {
                this.Habilitar(false);
                this.btnNovo.Enabled = true;
                this.btnSalvar.Enabled = false;
                this.btnEditar.Enabled = true;
                this.btnCancelar.Enabled = false;
            }

        }

        //Ocultar as colunas do grid
        private void OcultarColunas()
        {
            this.dataLista.Columns[0].Visible = false;
            this.dataLista.Columns[1].Visible = false;
        }

        //Mostar no data Grid
        private void Mostar()
        {
            this.dataLista.DataSource = NApresentacao.Mostrar();
            this.OcultarColunas();
            lblTotal.Text = dataLista.Rows.Count.ToString();
            lblTotal.Text = "Quantidade de registros: " + Convert.ToString(dataLista.Rows.Count);
        }


        //Buscar pelo Nome
        private void BuscarNome()
        {
            this.dataLista.DataSource = NApresentacao.BuscarNome(this.txtBuscar.Text);
            this.OcultarColunas();
            lblTotal.Text = "Quantidade de registros: " + Convert.ToString(dataLista.Rows.Count);
        }

        private void frmApresentacao_Load(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Left = 0;
            this.Mostar();
            this.Habilitar(false);
            this.Botoes();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            this.BuscarNome();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            this.BuscarNome();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            this.eNovo = true;
            this.eEditar = false;
            this.Botoes();
            this.Limpar();
            this.Habilitar(true);
            this.txtNome.Focus();
            this.txtIdApresentacao.Enabled = false;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                string resp = "";
                if (txtNome.Text == string.Empty)
                {
                    MensagemErro("Preencha todos os campos");
                    errorIcone.SetError(txtNome, "Insira o nome");

                }
                else
                {
                    if (this.eNovo)
                    {
                        resp = NApresentacao.Inserir(txtNome.Text.Trim().ToUpper(), txtDescricao.Text.Trim());
                    }
                    else
                    {
                        resp = NApresentacao.Editar(Convert.ToInt32(this.txtIdApresentacao.Text),
                                                    txtNome.Text.Trim().ToUpper(),
                                                    txtDescricao.Text.Trim());
                    }
                    if (resp.Equals("OK"))
                    {
                        if (this.eNovo)
                        {
                            this.MensagemOK("Registro salvo com sucesso");
                        }
                        else
                        {
                            this.MensagemOK("Registro editado com sucesso");
                        }
                    }
                    else
                    {
                        this.MensagemErro(resp);
                    }
                    this.eNovo = false;
                    this.eEditar = false;
                    this.Botoes();
                    this.Limpar();
                    this.Mostar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void dataLista_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.txtIdApresentacao.Text = Convert.ToString(this.dataLista.CurrentRow.Cells["idapresentacao"].Value);
            this.txtNome.Text = Convert.ToString(this.dataLista.CurrentRow.Cells["nome"].Value);
            this.txtDescricao.Text = Convert.ToString(this.dataLista.CurrentRow.Cells["descricao"].Value);

            this.tabControl1.SelectedIndex = 1;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (this.txtIdApresentacao.Text.Equals(""))
            {
                this.MensagemErro("Selecione um registro");
            }
            else
            {
                this.eEditar = true;
                this.Botoes();
                this.Habilitar(true);

            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.eNovo = false;
            this.eEditar = false;
            this.Botoes();
            this.Habilitar(false);
            this.Limpar();
        }

        private void chkDeletar_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDeletar.Checked)
            {
                this.dataLista.Columns[0].Visible = true;
            }
            else
            {
                this.dataLista.Columns[0].Visible = false;
            }
        }

        private void dataLista_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataLista.Columns["Deletar"].Index)
            {
                DataGridViewCheckBoxCell ChkDeletar = (DataGridViewCheckBoxCell)dataLista.Rows[e.RowIndex].Cells["Deletar"];
                ChkDeletar.Value = !Convert.ToBoolean(ChkDeletar.Value);
            }
        }

        private void btnDeletar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult Opcao;
                Opcao = MessageBox.Show("Realmente deseja apagar os Registros", "Sistema Comércio", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (Opcao == DialogResult.OK)
                {
                    string Codigo;
                    string Resp = "";

                    foreach (DataGridViewRow row in dataLista.Rows)
                    {
                        if (Convert.ToBoolean(row.Cells[0].Value))
                        {
                            Codigo = row.Cells[1].Value.ToString(); //caso erro trocar
                            Resp = NApresentacao.Excluir(Convert.ToInt32(Codigo));
                            if (Resp.Equals("OK"))
                            {
                                this.MensagemOK("Registro excluido com sucesso");
                            }
                            else
                            {
                                this.MensagemErro(Resp);
                            }
                        }
                    }
                    this.Mostar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        
    }
}
