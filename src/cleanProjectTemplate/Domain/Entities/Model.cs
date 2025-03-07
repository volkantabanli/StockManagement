﻿using Core.Persistence.Repositories;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;

public class Model : Entity<Guid>
{
    public string Name { get; set; }
    public Guid MaterialId { get; set; }
    public virtual Material? Material { get; set; }
}
