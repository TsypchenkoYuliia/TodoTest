using SharedCore.Enums;

namespace WebApi.ApiModels
{
    public class TodoDTO
    {
        public TodoDTO(int id, string title, string text, TodoStatusEnum status, DateTime createdDate, DateTime? deactivationDate)
        {
            Id = id;
            Title = title;
            Text = text;
            Status = status;
            CreatedDate = createdDate;
            DeactivationDate = deactivationDate;
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public TodoStatusEnum Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? DeactivationDate { get; set; }
    }
}
