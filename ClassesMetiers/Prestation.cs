// <copyright file="Prestation.cs" company="PlaceholderCompany">
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

    public class Prestation
    {
        private string libelle;
        private DateTime dateHeureSoin;
        private Intervenant intervenant;

        public Intervenant Intervenant { get => this.intervenant; }

        public string Libelle { get => this.libelle; }

        public DateTime DateHeureSoin { get => this.dateHeureSoin; }

        public Prestation(string libelle, DateTime dateHeureSoin, Intervenant intervenant)
        {
            this.libelle = libelle;
            this.intervenant = intervenant;
            if (dateHeureSoin < DateTime.Now)
            {
                this.dateHeureSoin = dateHeureSoin;
            }
            else
            {
                throw new CabinetMedicalException("La date de prestation doit être inférieure à la date du jour");
            }
        }

        public static string GetInfoPresta(Prestation prestation)
        {
            return "\t Libelle " + prestation.Libelle + " - " + prestation.DateHeureSoin + " - Intervenant " + GetInfoIntervenant(prestation.intervenant);
        }

        public static string GetInfoIntervenant(Intervenant intervenant)
        {
            if (intervenant is IntervenantExterne intervenantExterne)
            {
                return intervenantExterne.Nom + " " + intervenantExterne.Prenom + "Specialité : " + intervenantExterne.Specialite + " Adresse : " + intervenantExterne.Adresse
                    + " Tel : " + intervenantExterne.Tel;
            }
            else
            {
                return intervenant.Nom + " " + intervenant.Prenom;
            }
        }

        public static int CompareTo(Prestation prestation1, Prestation prestation2)
        {
            return DateTime.Compare(prestation1.dateHeureSoin.Date, prestation2.dateHeureSoin.Date);
        }
    }
}