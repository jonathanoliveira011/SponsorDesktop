using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DataBase;


namespace Business
{
    public class empresa : Base
    {

        [OpcoesBase(ChavePrimaria = true, UsarNoBancoDeDados = true, UsarParaBuscar = true)]
        public int id_empresa { get; set; }

        [OpcoesBase(UsarNoBancoDeDados = true)]
        public string nome_responsavel { get; set; }

        [OpcoesBase(UsarNoBancoDeDados = true)]
        public string cpf_responsavel { get; set; }

        [OpcoesBase(UsarNoBancoDeDados = true)]
        public string cnpj { get; set; }

        [OpcoesBase(UsarNoBancoDeDados = true)]
        public string telefone { get; set; }

        [OpcoesBase(UsarNoBancoDeDados = true)]
        public string razao_social { get; set; }

        [OpcoesBase(UsarNoBancoDeDados = true)]
        public string descricao_empresa { get; set; }

        [OpcoesBase(UsarNoBancoDeDados = true)]
        public string rua { get; set; }

        [OpcoesBase(UsarNoBancoDeDados = true)]
        public string numero { get; set; }

        [OpcoesBase(UsarNoBancoDeDados = true)]
        public string bairro { get; set; }

        [OpcoesBase(UsarNoBancoDeDados = true)]
        public string cidade { get; set; }

        [OpcoesBase(UsarNoBancoDeDados = true)]
        public string estado { get; set; }

        [OpcoesBase(UsarNoBancoDeDados = true)]
        public string pais { get; set; }

        [OpcoesBase(UsarNoBancoDeDados = true)]
        public string cep { get; set; }

        public new List<empresa> Todos()
        {

            var emp = new List<empresa>();
            foreach (var ibase in base.Todos())
            {
                emp.Add((empresa)ibase);
            }

            return emp;

        }


    }
}
