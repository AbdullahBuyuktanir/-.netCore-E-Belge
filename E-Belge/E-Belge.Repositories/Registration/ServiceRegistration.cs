using Core.DataAccess.Abstract;
using Core.DataAccess.Concrete;
using E_Belge.Repositories.Abstract;
using E_Belge.Repositories.Concrete;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Belge.Repositories.Registration
{
  public static class RepositoryServiceRegistration
  {
    public static void RegisterRepositories(this IServiceCollection serviceCollection)
    {
      serviceCollection.AddSingleton<IGenericRepository, RepositoryBase>();
      serviceCollection.AddSingleton<IGibUserListRepository, GibUserListRepository>();
      serviceCollection.AddSingleton<ICustomerRepository, CustomerRepository>();
    }
  }
}
