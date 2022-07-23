using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Short_Story_Network___Practical_Evaluation_Rootcode
{
    public partial class ShortStoryNetworkContext : DbContext
    {
        public ShortStoryNetworkContext()
            : base("name=ShortStoryNetwork")
        {
        }

        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<StatVowel> StatVowels { get; set; }
        public virtual DbSet<UserInfo> UserInfoes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
