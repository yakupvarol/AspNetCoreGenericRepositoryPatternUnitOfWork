﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AspNetCoreGenericRepositoryPatternUnitOfWork.Entities
{
    public partial class VUsergroup
    {
        [Required]
        [Column("NAME")]
        [StringLength(50)]
        public string Name { get; set; }
        [Column("ID")]
        public int Id { get; set; }
        [Column("userid")]
        public int Userid { get; set; }
        [Required]
        [Column("EMAIL")]
        [StringLength(50)]
        public string Email { get; set; }
        [Required]
        [Column("LAST_NAME")]
        [StringLength(50)]
        public string LastName { get; set; }
    }
}