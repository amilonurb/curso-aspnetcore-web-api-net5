using MyAPI.Business.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace MyAPI.Business.Notificacoes
{
    public class Notificador : INotificador
    {
        private readonly List<Notificacao> _notificacoes = new();

        public void Handle(Notificacao notificacao) => _notificacoes.Add(notificacao);

        public List<Notificacao> ObterNotificacoes() => _notificacoes;

        public bool TemNotificacao() => _notificacoes.Any();
    }
}