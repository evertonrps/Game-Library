using GameLibrary.Domain.Core;
using System;

namespace GameLibrary.Domain.Entities.Usuario
{
    public class Usuario : Entity<Usuario>
    {

        public string NomeUsuario { get; private set; }
        public string Email { get; private set; }
        public string CPF { get; private set; }
        public string SenhaHash { get; private set; }
        public DateTime? DataUltimoAcesso { get; private set; }
        public bool Bloqueado { get; private set; }
        public int? Tentativas { get; private set; }
        public bool Ativo { get; private set; }

        private Usuario(string nomeUsuario, string email, string cpf, string senhaHash, bool ativo, DateTime? dataUltimoAcesso, bool bloqueado, int? tentativas)
        {
            NomeUsuario = nomeUsuario;
            Email = email;
            SenhaHash = senhaHash;
            Ativo = ativo;
            DataUltimoAcesso = dataUltimoAcesso;
            Bloqueado = bloqueado;
            Tentativas = tentativas;
            CPF = cpf;
        }

        protected Usuario()
        {

        }

        public static Usuario Factory(string nomeUsuario, string email, string cpf, string senhaHash, bool ativo, DateTime? dataUltimoAcesso, bool bloqueado, int? tentativas)
        {
            Usuario usuario = new Usuario(nomeUsuario, email, cpf, senhaHash, ativo, dataUltimoAcesso, bloqueado, tentativas);
            //usuario.Validate(new Usua);
            return usuario;
        }

        /// <summary>
        /// Incrementa ou zera o número de tentativas falhas de login
        /// </summary>
        /// <param name="zerar">Se for verdadeiro, zera o número de tentativas</param>
        public void AlterarNumeroTentativas(bool zerar = false)
        {
            if (zerar)
                Tentativas = 0;
            else
                Tentativas++;
        }

        /// <summary>
        /// Bloqueia ou desbloqueia o usuário
        /// </summary>
        public void AlterarSituacaoBloqueio()
        {
            Bloqueado = !Bloqueado;
        }

        public void AtualizarDataUltimoAcesso()
        {
            DataUltimoAcesso = DateTime.Today;
        }

        public void SetNomeUsuario(string nomeUsuario)
        {
            NomeUsuario = nomeUsuario;
        }
        //public override bool IsValid()
        //{
        //    return true;
        //}
    }
}
