using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace MyPersonal
{
    [Table("StaffMans")]
    public class StaffMan
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int IndexMan { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Patronimyc { get; set; }
        public string DateOfBirth { get; set; }
        public string Adress { get; set; }
        public string Unit { get; set; }
        public string Image { get; set; }
        public byte[] ImageByte { get; set; }
    }
}
