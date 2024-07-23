using ExperienciaTecno.BackEnd.Core.Especificationes.Models;
using ExperienciaTecno.BackEnd.Core.Especificationes.Repositories;
using ExperienciaTecno.BackEnd.Data.EF.Common.Repositories;

namespace ExperienciaTecno.BackEnd.Data.EF.Repositories;

public class EspecificationRepository(BackEndDbContext dbContext)
    : GenericEfRepository<Especification, BackEndDbContext>(dbContext), IEspecificationRepository
{

}
