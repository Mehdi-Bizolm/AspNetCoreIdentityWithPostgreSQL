using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace MyDAClass.DataAccess
{
    [Table(name: "MyMasterTBL")]
    public class AlternativMyDAClassTBL
    {
        public enum MyFieldStatusMethod
        {
            [Description("A a new MyField")]
            AAA = 1,
            [Description("B an exist MyField")]
            BBB = 2
        }

        public MyMasterTBL()
        {
            // This Somewhere has Relation (FK) :: part 1
            HisMyTable = new HashSet<HisMyTableTBL>();
        }

        [Key]
        [Column("myfieldid", Order = 0, TypeName = "serial")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MyFieldID { get; set; }

        [Column("myfieldtitle", Order = 1)]
        [Display(Name = "MyField")]
        [StringLength(100, MinimumLength = 2)]
        [Required]
        public string MyFieldTitle { get; set; }

        [Column("myfieldisenable", Order = 8)]
        [Display(Name = "Visible")]
        [Required]
        public bool MyFieldIsEnable { get; set; }

        [Column("myfieldid", Order = 20)]
        [Required]
        public int MyfieldID { get; set; }

        // Reference from FK-Table(s)
        public MyTableTBL MyTable { get; set; }

        // This Somewhere has Relation (FK) :: part 2
        public ICollection<HisMyTableTBL> HisMyTable { get; set; }
    }
}
