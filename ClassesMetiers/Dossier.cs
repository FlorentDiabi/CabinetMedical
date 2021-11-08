// <copyright file="Dossier.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CabinetMedical.ClassesMetier
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using CabinetMedical.Exceptions;

    /// <summary>
    /// gngngn.
    /// </summary>
    public class Dossier
    {
        private string nom;
        private string prenom;
        private DateTime dateNaissance;
        private List<Prestation> prestations;
        private DateTime dateCreation;

        /// <summary>
        /// Gets the name.
        /// </summary>
        public string Nom { get => this.nom; }

        /// <summary>
        /// Gets the surname.
        /// </summary>
        public string Prenom { get => this.prenom; }

        /// <summary>
        /// Gets the birth.
        /// </summary>
        public DateTime DateNaissance { get => this.dateNaissance; }

        /// <summary>
        /// Gets the Prestation.
        /// </summary>
        public List<Prestation> Prestations { get => this.prestations; }

        /// <summary>
        /// Gets the Creation date.
        /// </summary>
        public DateTime DateCreation { get => this.dateCreation; }

        /// <summary>S
        /// Initializes a new instance of the <see cref="Dossier"/> class.
        /// </summary>
        /// <param name="nom">nom</param>
        /// <param name="prenom">prenom</param>
        /// <param name="dateNaissance">datebirth</param>
        public Dossier(string nom, string prenom, DateTime dateNaissance)
            : this(nom, prenom, dateNaissance, DateTime.Now)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Dossier"/> class.
        /// </summary>
        /// <param name="nom">nom</param>
        /// <param name="prenom"></param>
        /// <param name="dateNaissance"></param>
        /// <param name="dateCreation"></param>
        public Dossier(string nom, string prenom, DateTime dateNaissance, DateTime dateCreation)
        {
            this.nom = nom;
            this.prenom = prenom;
            this.prestations = new List<Prestation>();
            if (dateNaissance < DateTime.Now)
            {
                this.dateNaissance = dateNaissance;
            }
            else
            {
                throw new CabinetMedicalException("La date de naissance ne peut être supérieure à la date du jour.");
            }

            if (dateCreation > DateTime.Now)
            {
                throw new CabinetMedicalException("La date de création du dossier ne peut être supérieure à la date du jour.");
            }
            else
            {
                this.dateCreation = dateCreation;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Dossier"/> class.
        /// </summary>
        /// <param name="nom">nom</param>
        /// <param name="prenom">prenom</param>
        /// <param name="dateNaissance">datenaissance</param>
        /// <param name="prestations">prestations</param>
        public Dossier(string nom, string prenom, DateTime dateNaissance, List<Prestation> prestations)
            : this(nom, prenom, dateNaissance)
        {
            this.prestations = prestations;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Dossier"/> class.
        /// </summary>
        /// <param name="nom">nom</param>
        /// <param name="prenom">prenom</param>
        /// <param name="dateNaissance">datenaissance</param>
        /// <param name="prestations">prestations</param>
        /// <param name="dateCreation">dateceration</param>
        public Dossier(string nom, string prenom, DateTime dateNaissance, List<Prestation> prestations, DateTime dateCreation)
            : this(nom, prenom, dateNaissance, prestations)
        {
            this.dateCreation = dateCreation;
        }

        /// <summary>
        /// Ajoute une prestation.
        /// </summary>
        /// <param name="prestation">prestation</param>
        public void AjoutePrestation(Prestation prestation)
        {
            if (prestation.DateHeureSoin > this.dateCreation)
            {
                this.prestations.Add(prestation);
            }
            else
            {
                throw new CabinetMedicalException("La date de prestation doit être postérieure à celle de création du dossier");
            }
        }

        /// <summary>
        /// Ajoute prestation.
        /// </summary>
        /// <param name="libelle">libelle</param>
        /// <param name="dateHeureSoin">dateheuresoin</param>
        /// <param name="intervenant">intervenant</param>
        public void AjoutePrestation(string libelle, DateTime dateHeureSoin, Intervenant intervenant)
        {
            this.AjoutePrestation(new Prestation(libelle, dateHeureSoin, intervenant));
        }

        /// <summary>
        /// Obtient le nb PrestationsExternes.
        /// </summary>
        /// <returns>rien</returns>
        public int GetNbPrestationsExternes()
        {
            int nbPrestaExt = 0;
            foreach (Prestation prestation in this.prestations)
            {
                if (prestation.Intervenant is IntervenantExterne)
                {
                    nbPrestaExt++;
                }
            }

            return nbPrestaExt;
        }

        /// <summary>
        /// GetNbPrestations.
        /// </summary>
        /// <returns>void</returns>
        public int GetNbPrestations()
        {
            return this.prestations.Count();
        }

        /// <summary>
        /// GetNbJoursSoinsV1.
        /// </summary>
        /// <returns>void</returns>
        public int GetNbJoursSoinsV1()
        {
            int nbPresta = this.prestations.Count();

            for (int i = 0; i < this.prestations.Count() - 1; i++)
            {
                for (int a = i + 1; a < this.prestations.Count(); a++)
                {
                    if (Prestation.CompareTo(this.prestations[i], this.prestations[a]) == 0)
                    {
                        nbPresta--;
                        i++;
                    }
                }
            }

            return nbPresta;
        }

        /// <summary>
        /// GetNbJoursSoinsV2.
        /// </summary>
        /// <returns>void</returns>
        public int GetNbJoursSoinsV2()
        {
            List<DateTime> dates = new List<DateTime>();

            foreach (Prestation prestation in this.prestations)
            {
                if (!dates.Contains(prestation.DateHeureSoin.Date))
                {
                    dates.Add(prestation.DateHeureSoin.Date);
                }
            }

            return dates.Count();
        }

        /// <summary>
        /// GetNbJoursSoinsV3.
        /// </summary>
        /// <returns>void</returns>
        public int GetNbJoursSoinsV3()
        {
            int nbJoursSoins = this.prestations.Count();
            List<DateTime> dates = new List<DateTime>();
            foreach (Prestation prestation in this.prestations)
            {
                dates.Add(prestation.DateHeureSoin.Date);
            }

            dates.Sort();
            for (int i = 0; i < dates.Count; i++)
            {
                if (i != (dates.Count() - 1) && dates[i] == dates[i + 1])
                {
                    nbJoursSoins--;
                }
            }

            return nbJoursSoins;
        }
    }
}