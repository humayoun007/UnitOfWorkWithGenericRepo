using System;
using System.ComponentModel.DataAnnotations;

namespace TestProject
{
    public class Notification
    {
        //This line below will generate error as for generic constraint like in repository where T : class, new()
        //string _id;
        //public Notification(string id)
        //{
        //    _id = id;
        //}

        [Key]
        public string UserId { get; internal set; }
        [Required]
        public bool IsRead { get; internal set; }
        [Required]
        public DateTime DateCreated { get; internal set; }

        public static Notification Create(string text, string userId)
        {
            throw new NotImplementedException();
        }
    }
}