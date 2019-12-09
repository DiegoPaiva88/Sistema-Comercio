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
    public partial class frmFornecedor : Form
    {

        private bool eNovo = false;
        private bool eEditar = false;

        public frmFornecedor()
        {
            InitializeComponent();
            this.ttMensagem.SetToolTip(this.txtEmpresa, "Insira o nome da Empresa");
            this.ttMensagem.SetToolTip(this.txtEndereco, "Insira o Endereço");
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
            this.txtIdFornecedor.Text = String.Empty;
            this.txtEmpresa.Text = string.Empty;
            this.txtNumDocumento.Text = string.Empty;
            this.txtEmail.Text = string.Empty;
            this.txtEndereco.Text = string.Empty;
            this.txtTelefone.Text = string.Empty;
            this.txtUrl.Text = string.Empty;
        }

        //Habilitar os text Box
        private void Habilitar(bool valor)
        {
            //this.txtIdFornecedor.ReadOnly = !valor;
            this.txtEmpresa.ReadOnly = !valor;
            this.txtNumDocumento.ReadOnly = !valor;
            this.txtEmail.ReadOnly = !valor;
            this.txtEndereco.ReadOnly = !valor;
            this.txtTelefone.ReadOnly = !valor;
            this.txtUrl.ReadOnly = !valor;
            this.cbSetorComercial.Enabled = valor;
            this.cbTipoDoc.Enabled = valor;
            
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
            this.dataLista.DataSource = NFornecedor.Mostrar();
            this.OcultarColunas();
            lblTotal.Text = dataLista.Rows.Count.ToString();
            lblTotal.Text = "Quantidade de registros: " + Convert.ToString(dataLista.Rows.Count);
        }

        //Buscar pelo Nome
        private void BuscarNome()
        {
            this.dataLista.DataSource = NFornecedor.BuscarNome(this.txtBuscar.Text);
            this.OcultarColunas();
            lblTotal.Text = "Quantidade de registros: " + Convert.ToString(dataLista.Rows.Count);
        }

        //Buscar pelo Num Documento
        private void BuscarDocumento()
        {
            this.dataLista.DataSource = NFornecedor.BuscarDocumento(this.txtBuscar.Text);
            this.OcultarColunas();
            lblTotal.Text = "Quantidade de registros: " + Convert.ToString(dataLista.Rows.Count);
        }



        private void frmFornecedor_Load(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Left = 0;
            this.Mostar();
            this.Habilitar(false);
            this.Botoes();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            if (chkNome.Checked)
            {
                this.BuscarNome();
            }
            else if (chkDocumento.Checked)
            {
                this.BuscarDocumento();
            }
           
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            this.BuscarDocumento();
            this.BuscarNome();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            this.eNovo = true;
            this.eEditar = false;
            this.Botoes();
            this.Limpar();
            this.Habilitar(true);
            this.txtEmpresa.Focus();
            this.txtIdFornecedor.Enabled = false;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                string resp = "";
                if (txtEmpresa.Text == string.Empty)
                {
                    MensagemErro("Preencha todos os campos");
                    errorIcone.SetError(txtEmpresa, "Insira o nome da empresa !!");

                }
                else
                {
                    if (this.eNovo)
                    {
                        resp = NFornecedor.Inserir(this.txtEmpresa.Text.Trim().ToUpper(), cbSetorComercial.Text, cbTipoDoc.Text, 
                                                     this.txtNumDocumento.Text.Trim().ToUpper(), this.txtEndereco.Text,
                                                     this.txtTelefone.Text,this.txtEmail.Text ,this.txtUrl.Text);
                    }
                    else
                    {
                        resp = NFornecedor.Editar(Convert.ToInt32(this.txtIdFornecedor.Text),
                                                    txtEmpresa.Text.Trim().ToUpper(),
                                                    this.cbSetorComercial.Text, this. cbTipoDoc.Text, this.txtNumDocumento.Text.Trim().ToUpper(),
                                                    this.txtEndereco.Text.Trim(), this.txtTelefone.Text, this.txtEmail.Text ,  this.txtUrl.Text);
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

        private void dataLista_DoubleClick(object sender, EventArgs e)
        {
            this.txtIdFornecedor.Text = Convert.ToString(this.dataLista.CurrentRow.Cells["idfornecedor"].Value);
            this.txtEmpresa.Text = Convert.ToString(this.dataLista.CurrentRow.Cells["empresa"].Value);
            this.cbSetorComercial.Text = Convert.ToString(this.dataLista.CurrentRow.Cells["setor_comercial"].Value);
            this.cbTipoDoc.Text = Convert.ToString(this.dataLista.CurrentRow.Cells["tipo_documento"].Value);
            this.txtNumDocumento.Text = Convert.ToString(this.dataLista.CurrentRow.Cells["num_documento"].Value);
            this.txtEndereco.Text = Convert.ToString(this.dataLista.CurrentRow.Cells["endereco"].Value);
            this.txtTelefone.Text = Convert.ToString(this.dataLista.CurrentRow.Cells["telefone"].Value);
            this.txtEmail.Text = Convert.ToString(this.dataLista.CurrentRow.Cells["email"].Value);
            this.txtUrl.Text = Convert.ToString(this.dataLista.CurrentRow.Cells["url"].Value);

            this.tabControl1.SelectedIndex = 1;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (this.txtIdFornecedor.Text.Equals(""))
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
                            Resp = NFornecedor.Excluir(Convert.ToInt32(Codigo));
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
