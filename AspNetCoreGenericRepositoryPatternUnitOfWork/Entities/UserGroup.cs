﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AspNetCoreGenericRepositoryPatternUnitOfWork.Entities
{
    [Table("USER_GROUPS")]
    public partial class UserGroup
    {
        public UserGroup()
        {
            UserAuthorizations = new HashSet<UserAuthorization>();
            Users = new HashSet<User>();
        }

        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Required]
        [Column("NAME")]
        [StringLength(50)]
        public string Name { get; set; }
        [Column("RANK")]
        [StringLength(50)]
        public string Rank { get; set; }
        [Column("ISAUTOMATIC_CATEGORY")]
        public bool? IsautomaticCategory { get; set; }
        [Column("ISACTIVE")]
        public bool? Isactive { get; set; }
        [Column("ISDELETE")]
        public bool? Isdelete { get; set; }

        [InverseProperty(nameof(UserAuthorization.Group))]
        public virtual ICollection<UserAuthorization> UserAuthorizations { get; set; }
        [InverseProperty(nameof(User.Group))]
        public virtual ICollection<User> Users { get; set; }
    }
}