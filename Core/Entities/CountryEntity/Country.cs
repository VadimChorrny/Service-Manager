﻿using System.ComponentModel.DataAnnotations;

namespace Core.Entities.CountryEntity
{
    public class Country
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Flag { get; set; }
        public virtual ICollection<PhoneCode> PhoneCodes { get; set; } = new HashSet<PhoneCode>();
    }
}
