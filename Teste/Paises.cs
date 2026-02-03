using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;

namespace Teste
{
    public partial class Paises : Form
    {
        public Paises()
        {
            InitializeComponent();
        }
        SqlConnection sqlCon = null;
        string strCon = ConfigurationManager.ConnectionStrings["MinhaConexao"].ConnectionString;
        private string strSql = string.Empty;
        private void button1_Click(object sender, EventArgs e)
        {
            strSql = "insert into paises (cod_pais, nome, populacao, area_total) values(@cod_pais, @nome, @populacao, @area_total)";
            sqlCon = new SqlConnection(strCon);
            SqlCommand comando = new SqlCommand(strSql, sqlCon);

            comando.Parameters.Add(@"cod_pais", SqlDbType.Int).Value = textBox1.Text;
            comando.Parameters.Add(@"nome", SqlDbType.VarChar).Value = textBox3.Text;
            comando.Parameters.Add(@"populacao", SqlDbType.Int).Value = textBox2.Text;
            comando.Parameters.Add(@"area_total", SqlDbType.Decimal).Value = textBox4.Text;

            try
            {
                sqlCon.Open();
                comando.ExecuteNonQuery();
                MessageBox.Show("Cadastro realizado com sucesso!");
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                sqlCon.Close();
            }
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            strSql = "select * from paises where cod_pais=@cod_pais";
            sqlCon = new SqlConnection(strCon);
            SqlCommand comando = new SqlCommand(strSql, sqlCon);

            comando.Parameters.Add("@cod_pais", SqlDbType.Int).Value = textBox5.Text;


            try
            {
                if (textBox5.Text == string.Empty)
                {
                    throw new Exception("Você precisa digitar algo");
                }
                sqlCon.Open();


                SqlDataReader dr = comando.ExecuteReader();

                if (dr.Read()) 
                {
                    textBox1.Text = Convert.ToString(dr["cod_pais"]);
                    textBox2.Text = Convert.ToString(dr["populacao"]);
                    textBox3.Text = Convert.ToString(dr["nome"]);
                    textBox4.Text = Convert.ToString(dr["area_total"]);

                }
                else
                {
                    throw new Exception("Não encontrado");
                }

              
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                sqlCon.Close(); 
            }
            
                
        }
        
        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja realmente excluir este país?", "CUIDADO", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No) 
            {
                MessageBox.Show("Operação cancelada!");
            }
            else


            {
                strSql = "delete from paises where cod_pais =@cod_pais";
                sqlCon = new SqlConnection(strCon);
                SqlCommand comando = new SqlCommand(strSql, sqlCon);

                comando.Parameters.Add("@cod_pais", SqlDbType.Int).Value = textBox1.Text;

                try
                {
                    sqlCon.Open();
                    comando.ExecuteNonQuery();
                    MessageBox.Show("País excluído com sucesso!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    sqlCon.Close();
                }
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
            }
                
        }

        private void Paises_Load(object sender, EventArgs e)
        {
           
            // TODO: esta linha de código carrega dados na tabela 'crudpaisesDataSet1.paises'. Você pode movê-la ou removê-la conforme necessário.
            this.paisesTableAdapter.Fill(this.crudpaisesDataSet1.paises);

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            strSql = "update paises set cod_pais =@cod_pais, nome=@nome, populacao=@populacao, area_total=@area_total where cod_pais = @id_pais";
            sqlCon = new SqlConnection(strCon);
            SqlCommand comando = new SqlCommand(strSql, sqlCon);




            comando.Parameters.Add("@id_pais",SqlDbType.Int).Value = textBox1.Text;  

            comando.Parameters.Add(@"cod_pais", SqlDbType.Int).Value = textBox1.Text;
            comando.Parameters.Add(@"nome", SqlDbType.VarChar).Value = textBox3.Text;
            comando.Parameters.Add(@"populacao", SqlDbType.Int).Value = textBox2.Text;
            comando.Parameters.Add(@"area_total", SqlDbType.Decimal).Value = textBox4.Text;


            try
            {
                sqlCon.Open();
                comando.ExecuteNonQuery();
                MessageBox.Show("Cadastro atualizado com sucesso!");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                sqlCon.Close(); 
            }
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
        }
    }
}
