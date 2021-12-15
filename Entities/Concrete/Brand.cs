
using Core.Entities;
using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Brand:BaseEntity
    {
        public int BrandId { get; set; }
        public string BrandName { get; set; }

    }
}
//dotnet tool install --global dotnet-ef
//dotnet ef dbcontext scaffold "Server=(localdb)\mssqllocaldb;Database=RentACar;Trusted_Connection=true" Microsoft.EntityFrameworkCore.SqlServer --context "RentACarContext" --context-namespace=" DataAccess.Concrete.EntityFramework" --output-dir "..\Entities\test"  --namespace "Entities.test" startup-project "..\WebAPI" --verbose