﻿namespace ModelLayer.Models.AddressModels
{
    using System;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public class AddressPutModel
    {
        [Required]
        [DefaultValue("0")]
        public int AddressId { get; set; }

        [Required]
        [DefaultValue("1")]
        [Range(1, 3, ErrorMessage = "Choose Address Types As 1 : Home , 2 : Office , 3 : Other")]
        public int AddressType { get; set; }

        [Required]
        [DefaultValue("")]
        public string FullAddress { get; set; }

        [Required]
        [DefaultValue("")]
        public string City { get; set; }

        [Required]
        [DefaultValue("")]
        public string State { get; set; }
    }
}
