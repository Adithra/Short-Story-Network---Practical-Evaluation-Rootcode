namespace Short_Story_Network___Practical_Evaluation_Rootcode
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Post")]
    public partial class Post
    {
        public int PostId { get; set; }

        public int UserId { get; set; }

        [Column("Post")]
        [Required]
        public string Post1 { get; set; }
    }
}
