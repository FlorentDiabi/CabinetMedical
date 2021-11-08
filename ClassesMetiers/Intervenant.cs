// <copyright file="Intervenant.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CabinetMedical.ClassesMetier
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Intervenant
    {
        private string nom;
        private string prenom;
        private List<Prestation> prestations;

        /// <summary>
        /// Initializes a new instance of the <see cref="Intervenant"/> class.
        /// </summary>
        /// <param name="nom">nom</param>
        /// <param name="prenom">prenom</param>
        public Intervenant(string nom, string prenom)

        {
            this.nom = nom;
            this.prenom = prenom;
            this.prestations = new List<Prestation>();
        }

        /// <summary>
        /// Gets the name.
        /// </summary>
        public string Nom { get => this.nom; }

        /// <summary>
        /// Gets the surname.
        /// </summary>
        public string Prenom { get => this.prenom; }

        /// <summary>
        /// Gets the Prestation.
        /// </summary>
        public List<Prestation> Prestations { get => this.prestations; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Intervenant"/> class.
        /// </summary>
        /// <param name="nom">nom</param>
        /// <param name="prenom">prenom</param>


        public void AjoutePrestation(Prestation prestation)
        {
            this.prestations.Add(prestation);
        }

        public int GetNbPrestations()
        {
            return this.prestations.Count();
        }
    }
}