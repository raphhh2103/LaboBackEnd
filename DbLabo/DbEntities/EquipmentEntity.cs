﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbLabo.DbEntities
{
    public class EquipmentEntity
    {
        public int IdEquipment { get; set; }
        public string Type { get; set; }

        public string Effect { get; set; }

        public int NbPartsRequired { get; set; }
    }
}
