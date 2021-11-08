// <copyright file="TempException.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CabinetMedical.Exceptions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class TempException
    {
        public string Message { get; set; }

        public DateTime Date { get; set; }

        public string ApplicationException { get; set; }

        public string ClasseException { get; set; }

        public string UserException { get; set; }

        public string UserMachine { get; set; }
    }
}