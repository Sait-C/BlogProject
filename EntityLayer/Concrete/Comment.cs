using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Comment
    {
        [Key] //Hangi sütunun birincil anahtar olarak tanimlandigini belirtmemizi saglar
        public int Id { get; set; }
        public string CommentUserName { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CommentDate { get; set; }
        public bool Status { get; set; }

        //Blog entitysinin primary key ismi de BlogId olmak zorunda
        public int BlogId { get; set; }
        public Blog Blog { get; set; }
    }
}
