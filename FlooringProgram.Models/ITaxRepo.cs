﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringProgram.Models
{
    public interface ITaxRepo
    {
        List<Tax> LoadTaxRate();
    }
}
