using E_Belge.Business.Abstract;
using E_Belge.Business.Concrete;
using Microsoft.Extensions.DependencyInjection;

namespace E_Belge.Business.Registration;

public static class ServiceRegistration
{
  public static void RegisterServices(this IServiceCollection serviceCollection)
  {
    serviceCollection.AddSingleton<IGibUserListService, GibUserListManager>();
    serviceCollection.AddSingleton<ICustomerService, CustomerManager>();
  }
}
