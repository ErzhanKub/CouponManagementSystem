﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Shared
{
    internal interface IUnitOfWork 
    {
        Task CommitAsync();
    }
}