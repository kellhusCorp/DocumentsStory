using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DocumentsStory.Domain
{
    /// <summary>
    /// Представляет сущность "Документ".
    /// </summary>
    public class Document
    {
        /// <summary>
        /// Необходим для EF.
        /// </summary>
        public Document()
        {
        }

        /// <summary>
        /// Создает инстанс документа.
        /// </summary>
        /// <param name="number">Номер документа.</param>
        /// <param name="createdAt">Дата создания.</param>
        /// <param name="lastUpdateAt">Дата последнего редактирования.</param>
        public Document(int number, DateTime createdAt, DateTime? lastUpdateAt = null)
        {
            Number = number;
            CreatedAt = createdAt;
            LastUpdateAt = lastUpdateAt;
        }

        /// <summary>
        /// Идентификатор.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Номер документа. 
        /// </summary>
        public int Number { get; set; }

        /// <summary>
        /// Дата создания.
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Дата последнего обновления.
        /// </summary>
        public DateTime? LastUpdateAt { get; set; }

        // Предположил, что дата апдейта может быть null, так посчитал, ввиду того, что могут существовать новые документы (ещё не обновленные ни разу).
        // Если не так, то выкинуть проверку на null.
        // Если каким-то образом, LastUpdateAt > DateTime.Now, то документ не актуален.
        // Ну, а вообще триггер на вставку, либо валидация серверная при создании.
        /// <summary>
        /// Признак актуальности.
        /// </summary>
        [NotMapped]
        public bool IsActual
        {
            get
            {
                var currentDate = DateTime.Now;
                return LastUpdateAt != null && LastUpdateAt < currentDate && (currentDate - LastUpdateAt).Value.TotalDays < 60;
            }
        }
    }
}