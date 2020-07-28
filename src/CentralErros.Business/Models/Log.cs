using System;

namespace CentralErros.Business.Models
{
    public class Log : Entity
    {
        public string Origem { get; set; }
        public int Ambiente { get; set; }
        public int Level { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public int Evento { get; set; }
        public bool Arquivar { get; set; }
        public DateTime DataCadastro { get; set; }
        public string NomeUsuario { get; set; }
    }
}
