﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex12.Entities.Interfaces.Entities
{
    public interface IEntity
    {
        Guid Id { get; set; }

        public byte[] RowVersion { get; set; }
    }
}