using System.ComponentModel.DataAnnotations.Schema;

namespace Library.API.Models.Entities
{
    public class Circulation
    {
        public int Id { get; set; }
        public required int BookId { get; set; }
        public Book Book { get; set; } 
        public required int UserId { get; set; }
        public User User { get; set; }
        public required DateTime BorrowedDate { get; set; }
        public required DateTime DueDate { get; set; }
        public DateTime? ReturnedDate { get; set; }
        [NotMapped]
        public string Status
        {
            get
            {
                if (ReturnedDate.HasValue)
                {
                    if (ReturnedDate.Value <= DueDate)
                    {
                        return "Returned on time";
                    }
                    else
                    {
                        TimeSpan over = ReturnedDate.Value - DueDate;
                        return $"Returned overdue by {(int)over.TotalDays} days, {over.Hours} hours, {over.Minutes} minutes";
                    }
                }
                else if (DueDate < DateTime.Now)
                {
                    TimeSpan over = DateTime.Now - DueDate;
                    return $"Overdue by {(int)over.TotalDays} days, {over.Hours} hours, {over.Minutes} minutes";
                }
                else
                {
                    TimeSpan timeLeft = DueDate - DateTime.Now;
                    return $"Borrowed - {(int)timeLeft.TotalDays} days, {timeLeft.Hours} hours, {timeLeft.Minutes} minutes remaining";
                }
            }
        }
    }
}
