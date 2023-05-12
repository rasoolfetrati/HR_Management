﻿using System;
using System.ComponentModel.DataAnnotations;

namespace HR_Management.Domain.Common
{
    public abstract class BaseDomainEntity
    {
        [Key]
        public int Id { get; set; }
        public DateTime DateCreated { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime LastModifiedDate { get; set; }
        public string? LastModifiedBy { get; set; }


    }
}
