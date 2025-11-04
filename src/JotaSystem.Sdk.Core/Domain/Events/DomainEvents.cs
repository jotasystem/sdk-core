namespace JotaSystem.Sdk.Core.Domain.Events
{
    /// <summary>
    /// Classe estática para gerenciar eventos de domínio
    /// </summary>
    public static class DomainEvents
    {
        private static readonly List<IDomainEvent> _events = new();
        private static readonly object _lock = new(); // garante thread safety

        /// <summary>
        /// Adiciona um ou mais eventos ao controle centralizado
        /// </summary>
        public static void Raise(params IDomainEvent[] events)
        {
            if (events == null || events.Length == 0) return;

            lock (_lock)
            {
                _events.AddRange(events);
            }
        }

        /// <summary>
        /// Retorna todos os eventos acumulados
        /// </summary>
        public static IReadOnlyCollection<IDomainEvent> GetEvents()
        {
            lock (_lock)
            {
                return _events.ToList().AsReadOnly(); // retorna cópia segura
            }
        }

        /// <summary>
        /// Limpa todos os eventos
        /// </summary>
        public static void Clear()
        {
            lock (_lock)
            {
                _events.Clear();
            }
        }
    }
}