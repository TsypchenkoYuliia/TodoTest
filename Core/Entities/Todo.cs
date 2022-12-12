using SharedCore;
using SharedCore.Enums;

namespace Core.Entities
{
    public class Todo
    {
        public Todo(string title, string text)
        {
            Title = title; 
            Text = text;
            Status = (int)TodoStatusEnum.Active;
            CreatedDate = DateTime.UtcNow;
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public int Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? DeactivationDate { get; set; }
    }
}
