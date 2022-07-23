namespace Short_Story_Network___Practical_Evaluation_Rootcode
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("StatVowel")]
    public partial class StatVowel
    {
        public int Id { get; set; }

        [Column(TypeName = "date")]
        public DateTime Date { get; set; }

        public int PairVowelCount { get; set; }

        public int TotalWordCount { get; set; }
    }
}
