using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataBase;

namespace Business
{
    public class evento : Base
    {

        [OpcoesBase(ChavePrimaria = true, UsarNoBancoDeDados = true, UsarParaBuscar = true)]
        public int id_evento { get; set; }

        [OpcoesBase(UsarNoBancoDeDados = true)]
        public string nome_evento { get; set; }

        [OpcoesBase(UsarNoBancoDeDados = true)]
        public string categoria_evento { get; set; }

        [OpcoesBase(UsarNoBancoDeDados = true)]
        public string local_evento { get; set; }

        [OpcoesBase(UsarNoBancoDeDados = true)]
        public string data_inicio { get; set; }

        [OpcoesBase(UsarNoBancoDeDados = true)]
        public string data_final { get; set; }

        [OpcoesBase(UsarNoBancoDeDados = true)]
        public string hora_inicio { get; set; }

        [OpcoesBase(UsarNoBancoDeDados = true)]
        public string hora_final { get; set; }

        [OpcoesBase(UsarNoBancoDeDados = true)]
        public string publico_estimado { get; set; }

        [OpcoesBase(UsarNoBancoDeDados = true)]
        public string descricao_evento { get; set; }

        [OpcoesBase(UsarNoBancoDeDados = true)]
        public int id_empresa { get; set; }

        public new List<evento> Todos()
        {

            var evt = new List<evento>();
            foreach (var ibase in base.Todos())
            {
                evt.Add((evento)ibase);
            }

            return evt;

        }
    }
}
