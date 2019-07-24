using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyDAClass.DataAccess
{
    [Table(name: "MyTable")]
    public class MyTable
    {
        public class MyResource : IDisposable
        {
            private IntPtr handle;
            private bool disposed = false;
            private Component component = new Component();

            public MyResource(IntPtr handle)
            {
                this.handle = handle;
            }

            public void Dispose()
            {
                this.Dispose(true);
                GC.SuppressFinalize(this);
                throw new NotImplementedException();
            }

            protected virtual void Dispose(bool disposing)
            {
                if (!this.disposed)
                {
                    if (disposing)
                    {
                        component.Dispose();
                    }

                    CloseHandle(handle);
                    handle = IntPtr.Zero;
                    disposed = true;
                }
            }

            [System.Runtime.InteropServices.DllImport("Kernel32")]
            private extern static Boolean CloseHandle(IntPtr handle);

            ~MyResource()
            {
                Dispose(false);
            }
        }

        public MyTable()
        {
            // This Somewhere has Relation (FK) :: part 1
            HasRelationWith = new HashSet<HasRelationWithTBL>();
        }

        [Key]
        [Column("myfieldid", Order = 0, TypeName = "serial")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MyFieldID { get; set; }

        [Column("myfieldname", Order = 1)]
        [Display(Name = "MyField")]
        [StringLength(50, MinimumLength = 3)]
        [Required]
        public string MyFieldName { get; set; }

        [Column("myfieldisenable", Order = 2)]
        [Display(Name = "Status")]
        public bool MyFieldIsEnable { get; set; }

        [Column("createddate", Order = 3)]
        [Display(Name = "Date of Created")]
        [DisplayFormat(DataFormatString = "{0:MM-dd-yyyy HH:mm}")]
        public DateTime? CreatedDate { get; set; }

        [Column("modifieddate", Order = 4)]
        [Display(Name = "Date of Modified")]
        [DisplayFormat(DataFormatString = "{0:MM-dd-yyyy HH:mm}")]
        public DateTime? ModifiedDate { get; set; }

        [Column("createduserid", Order = 5)]
        public int? CreatedUserID { get; set; }

        [Column("modifieduserid", Order = 6)]
        public int? ModifiedUserID { get; set; }

        // This Somewhere has Relation (FK) :: part 2
        public ICollection<HasRelationWithTBL> HasRelationWith { get; set; }
    }
}
