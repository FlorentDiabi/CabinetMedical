// <copyright file="CabinetMedicalException.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CabinetMedical.Exceptions
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Security.Principal;
    using System.Text;
    using System.Threading.Tasks;

    public class CabinetMedicalException : Exception
    {
        public CabinetMedicalException(string message)
            : base("Erreur : " + message)
        {

        }

    }
}