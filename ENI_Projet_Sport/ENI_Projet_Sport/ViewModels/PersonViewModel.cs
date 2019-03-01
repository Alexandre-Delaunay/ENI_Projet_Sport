using BO.Base;
using System;
using System.Collections.Generic;

namespace ENI_Projet_Sport.ViewModels
{
    public class PersonViewModel : BaseViewModel
    {
        public virtual int Id { get; set; }
        public virtual DateTime DateMAJ { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual string PhoneNumber { get; set; }

        public virtual DateTime BirthDate { get; set; }

        public virtual DisplayConfigurationViewModel DisplayConfiguration { get; set; }

        public PersonViewModel()
        {
            Initialize();
        }
    }
}