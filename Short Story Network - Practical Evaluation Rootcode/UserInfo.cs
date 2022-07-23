namespace Short_Story_Network___Practical_Evaluation_Rootcode
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("UserInfo")]
    public partial class UserInfo
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        [StringLength(100)]
        public string PasswordHash { get; set; }

        [Required]
        [StringLength(100)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(100)]
        public string LastName { get; set; }

        [Required]
        [StringLength(1017)]
        public string EmailAddress { get; set; }

        [Required]
        [StringLength(50)]
        public string UserRole { get; set; }

        public bool IsEditor { get; set; }

        public bool IsBanned { get; set; }
    }
}
