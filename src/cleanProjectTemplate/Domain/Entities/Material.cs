using Core.Persistence.Repositories;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;

public class Material: Entity<Guid>
{
    public string Name { get; set; }
    public string Code { get; set; }
    public string? Engine { get; set; }
    public string? Year { get; set; }
    public double Price { get; set; }

    public virtual ICollection<Model> Models { get; set; }

    public virtual ICollection<Stock> Stocks { get; set; }
}
