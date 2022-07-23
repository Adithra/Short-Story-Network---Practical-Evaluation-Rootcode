namespace Short_Story_Network___Practical_Evaluation_Rootcode
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Follower")]
    public partial class Follower
    {
        [Key]
        public int UniqID { get; set; }

        [Column("UserID")]
        [Required]
        public int ActiveUserID { get; set; }

        [Column("FollwingID")]
        [Required]
        public int Id { get; set; }

        public virtual UserInfo UserInfos { get; set; }
    }
}