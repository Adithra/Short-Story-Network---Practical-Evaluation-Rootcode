namespace Short_Story_Network___Practical_Evaluation_Rootcode
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Comments")]
    public partial class Comment
    {
        [Key]
        public int CommentID { get; set; }

        [Column("Comment")]
        [Required]
        public string Comment1 { get; set; }

        [Column("CreatedBy")]
        [Required]
        public int CreatedBy { get; set; }

        [Column("PostID")]
        [Required]
        public int PostID { get; set; }
    }
}
