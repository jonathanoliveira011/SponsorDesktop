using System;
using System.Collections.Generic;
using System.Reflection;
using MySql.Data.MySqlClient;
using System.Data;




namespace DataBase
{
    public class Base : IBase
    {

        MySqlConnection conexao = new MySqlConnection("server=localhost;User Id=root;database=bd_sponsor; password=2701");

        public int Key
        {
            get
            {
                foreach (PropertyInfo pi in this.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance))
                {
                    OpcoesBase opcoes = (OpcoesBase)pi.GetCustomAttribute(typeof(OpcoesBase));
                    if (opcoes != null && opcoes.ChavePrimaria)
                    {
                        return Convert.ToInt32(pi.GetValue(this));
                    }
                }
                return 0;
            }
        }

      


        public virtual void Salvar()
        {
            using (MySqlConnection conexao = new MySqlConnection("server=localhost;User Id=root;database=bd_sponsor; password=2701"))
            {
                List<string> campos = new List<string>();
                List<string> valores = new List<string>();
                foreach (PropertyInfo pi in this.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance))
                {
                    OpcoesBase opcoes = (OpcoesBase)pi.GetCustomAttribute(typeof(OpcoesBase));
                    if (opcoes != null && opcoes.UsarNoBancoDeDados && !opcoes.ChavePrimaria)
                    {
                        if (this.Key == 0)
                        {
                            if (!opcoes.ChavePrimaria)
                            {
                                campos.Add(pi.Name);
                                valores.Add("'" + pi.GetValue(this) + "'");
                            }
                        }
                        else
                        {
                            if (!opcoes.ChavePrimaria)
                            {
                                valores.Add(" " + pi.Name + "='" + pi.GetValue(this) + "'");
                            }
                        }
                    }
                }
                string mysql = null;
                if (this.Key == 0)
                {
                    mysql = "insert into tb_" + this.GetType().Name + " (" + string.Join(", ", campos.ToArray()) + ")" +
                        " values (" + string.Join(", ", valores.ToArray()) + ");";
                }
                else
                {
                    mysql = "update tb_" + this.GetType().Name + " set" + string.Join(", ", valores.ToArray()) + " where id_" + this.GetType().Name + " = " + this.Key + ";";
                }
                MySqlCommand command = new MySqlCommand(mysql, conexao);
                command.Connection.Open();
                command.ExecuteNonQuery();

            }
        }

        public virtual void ExcluirEmpresa()
        {
            using (MySqlConnection conexao = new MySqlConnection("server=localhost;User Id=root;database=bd_sponsor; password=2701"))
            {

                string queryString = "delete from tb_" + this.GetType().Name + " where id_" + this.GetType().Name + " = " + this.Key + "; ";
                string queryString2 = "delete from tb_usuario where id_empresa = " + this.Key +";";
                string queryString3 = "delete from tb_evento where id_empresa = " + this.Key + ";";
                MySqlCommand mysqlcommand2 = new MySqlCommand(queryString2, conexao);
                MySqlCommand mysqlcommand = new MySqlCommand(queryString, conexao);
                MySqlCommand mysqlcommand3 = new MySqlCommand(queryString3, conexao);
                mysqlcommand.Connection.Open();
                mysqlcommand2.ExecuteNonQuery();
                mysqlcommand.ExecuteNonQuery();
                mysqlcommand3.ExecuteNonQuery();
                
            }

            
        }

        public virtual void Excluir()
        {

            using (MySqlConnection conexao = new MySqlConnection("server=localhost;User Id=root;database=bd_sponsor; password=2701"))
            {

                string queryString = "delete from tb_" + this.GetType().Name + " where id_" + this.GetType().Name + " = " + this.Key + "; ";
                MySqlCommand mysqlcommand = new MySqlCommand(queryString, conexao);
                mysqlcommand.Connection.Open();
                mysqlcommand.ExecuteNonQuery();

            }

        }

        public List<IBase> Busca()
        {
            var list = new List<IBase>();
            using (MySqlConnection conexao = new MySqlConnection("server=localhost;User Id=root;database=bd_sponsor; password=2701"))
            {
                List<string> where = new List<string>();
                string chavePrimaria = string.Empty;
                foreach (PropertyInfo pi in this.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance))
                {
                    OpcoesBase opcoesBase = (OpcoesBase)pi.GetCustomAttribute(typeof(OpcoesBase));
                    if (opcoesBase != null)
                    {
                        if (opcoesBase.ChavePrimaria)
                        {
                            chavePrimaria = pi.Name + "=" + pi.GetValue(this);
                        }
                        if (opcoesBase.UsarNoBancoDeDados )
                        {
                            if (pi.GetValue(this) != null)
                            {
                                var valor = pi.GetValue(this);
                                if (valor != null)
                                {
                                    where.Add(pi.Name + " = '" + valor + "'");
                                
                                }
                            }
                        }
                    }
                }
                string queryString = "select *  from tb_" + this.GetType().Name + " where" + chavePrimaria + " is not null";
                if (where.Count > 0)
                {
                    queryString += "and" + string.Join("and", where.ToArray());
                }
                    

                MySqlCommand mysqlCommand = new MySqlCommand(queryString, conexao);
                mysqlCommand.Connection.Open();
                MySqlDataReader reader = mysqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    var obj = (IBase)Activator.CreateInstance(this.GetType());
                    setProperty(ref obj, reader);
                    list.Add(obj);
                }
            }

            return list;
        }

       

        public virtual List<IBase> Todos()
        {
            var list = new List<IBase>();
            using (MySqlConnection conexao = new MySqlConnection("server=localhost;User Id=root;database=bd_sponsor; password=2701"))
            {
                string queryString = "select * from tb_" + this.GetType().Name;
                MySqlCommand mysqlcommand = new MySqlCommand(queryString, conexao);
                mysqlcommand.Connection.Open();
                MySqlDataReader reader = mysqlcommand.ExecuteReader();
                while (reader.Read())
                {
                    var obj = (IBase)Activator.CreateInstance(this.GetType());
                    setProperty(ref obj, reader);
                    list.Add(obj);
                }
            }
            return list;
        }

        private void setProperty (ref IBase obj, MySqlDataReader reader)
        {
            foreach (PropertyInfo pi in obj.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance))
            {
                OpcoesBase opcoes = (OpcoesBase)pi.GetCustomAttribute(typeof(OpcoesBase));
                if (opcoes != null && opcoes.UsarNoBancoDeDados)
                {
                    pi.SetValue(obj, reader[pi.Name]);
                }

            }
           
        }

    }
}
