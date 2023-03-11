using Microsoft.Extensions.DependencyInjection;

namespace OnlineLibrary.Core.Utilities.IoC
{
    public interface ICoreModule
    {
        void Load(IServiceCollection serviceCollection);
    }
}
