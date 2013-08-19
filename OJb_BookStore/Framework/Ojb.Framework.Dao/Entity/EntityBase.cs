﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ojb.Framework.Dao.Entity
{
    public abstract class EntityBase
    {
        public int Id { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
