﻿using BO.Base;
using BO.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BO.Models
{
    public class Person : BaseOV
    {
        [MaxLength(50)]
        public virtual string FirstName { get; set; }

        [MaxLength(50)]
        public virtual string LastName { get; set; }

        [DataType(DataType.PhoneNumber)]
        public virtual string PhoneNumber { get; set; }

        public virtual DateTime BirthDate { get; set; }

        public virtual DisplayConfiguration DisplayConfiguration { get; set; }

        public virtual List<Race> Races { get; set; }

        // user ID from AspNetUser table.
        public string OwnerID { get; set; }

        public Person()
        {
            Initialize();
        }

        public override void Initialize()
        {
            base.Initialize();

            Races = new List<Race>();
        }
    }
}