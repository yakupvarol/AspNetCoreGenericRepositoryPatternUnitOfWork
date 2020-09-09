﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AspNetCoreGenericRepositoryPatternUnitOfWork.Entities
{
    [Table("BACKEND_MENUS")]
    public partial class BackendMenu
    {
        public BackendMenu()
        {
            UserAuthorizations = new HashSet<UserAuthorization>();
        }

        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Column("MENU_GROUP_NUMBER")]
        public int? MenuGroupNumber { get; set; }
        [Column("NAME")]
        [StringLength(50)]
        public string Name { get; set; }
        [Column("LINK")]
        [StringLength(50)]
        public string Link { get; set; }
        [Column("PICTURE")]
        [StringLength(50)]
        public string Picture { get; set; }
        [Column("ISMANAGER")]
        public bool? Ismanager { get; set; }
        [Column("ISACTIVE")]
        public bool? Isactive { get; set; }

        [InverseProperty(nameof(UserAuthorization.BakendMenu))]
        public virtual ICollection<UserAuthorization> UserAuthorizations { get; set; }
    }
}