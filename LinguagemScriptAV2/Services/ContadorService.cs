using System.Collections.Concurrent;

namespace LinguagemScriptAV2.Services
{
    public class ContadorService
    {
        private readonly ConcurrentDictionary<string, int> _contagens = new ConcurrentDictionary<string, int>();
        public int IncrementarEObterContagem(string valor)
        {
            return _contagens.AddOrUpdate(valor, 1, (chave, contagemExistente) => contagemExistente + 1);
        }

        public int? ObterContagem(string valor)
        {
            if (_contagens.TryGetValue(valor, out int contagem))
            {
                return contagem;
            }
            return null;
        }

        public IReadOnlyDictionary<string, int> ObterTodasAsContagens()
        {
            return _contagens;
        }

        public void AtualizarContagem(string valor, int novaContagem)
        {
            if (novaContagem < 0)
            {
                throw new ArgumentException("A contagem não pode ser negativa.", nameof(novaContagem));
            }
            _contagens[valor] = novaContagem;
        }

        public bool RemoverContagem(string valor)
        {
            return _contagens.TryRemove(valor, out _);
        }
    }
}
