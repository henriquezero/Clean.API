using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Clean.Infra.Attributes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class InjectableAttribute : Attribute
    {
        public Type? Abstraction { get; }
        public LifeTime LifeTime { get; }

        public InjectableAttribute(Type abstraction, LifeTime lifetime = LifeTime.Scoped)
        {
            Abstraction = abstraction;
            LifeTime = lifetime;
        }

        public InjectableAttribute(LifeTime lifeTime = LifeTime.Scoped)
        {
            Abstraction = null;
            LifeTime = lifeTime;
        }
    }

    public enum LifeTime
    {
        Scoped,
        Singleton,
        Transient,
    }

    public static class InjectableExtensions
    {
        public static void AddServicesFrom(this IServiceCollection services, string[] assemblies)
        {
            var types = assemblies.Select(a => Assembly.Load(a)).SelectMany(a => a.DefinedTypes);

            foreach (var type in types)
            {
                var attrs = type.GetCustomAttributes<InjectableAttribute>(true);

                foreach (var attr in attrs)
                {
                    switch (attr.LifeTime)
                    {
                        case LifeTime.Scoped:
                            if (attr.Abstraction is null)
                                services.AddScoped(type, type);
                            else
                                services.AddScoped(attr.Abstraction, type);
                            break;

                        case LifeTime.Singleton:
                            if (attr.Abstraction is null)
                                services.AddSingleton(type, type);
                            else
                                services.AddSingleton(attr.Abstraction, type);
                            break;

                        case LifeTime.Transient:
                            if (attr.Abstraction is null)
                                services.AddTransient(type, type);
                            else
                                services.AddTransient(attr.Abstraction, type);
                            break;

                        default:
                            throw new NotImplementedException();
                    }
                }
            }
        }
    }
}
