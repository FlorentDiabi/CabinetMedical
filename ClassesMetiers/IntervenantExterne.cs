// <copyright file="IntervenantExterne.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CabinetMedical.ClassesMetier
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class IntervenantExterne : Intervenant
    {
        private string specialite;
        private string adresse;
        private string tel;

        public string Specialite { get => this.specialite; }

        public string Adresse { get => this.adresse; }

        public string Tel { get => this.tel; }

        public IntervenantExterne(string nom, string prenom, string specialite, string adresse, string tel)
            : base(nom, prenom)
        {
            this.specialite = specialite;
            this.adresse = adresse;
            this.tel = tel;
        }
    }
}