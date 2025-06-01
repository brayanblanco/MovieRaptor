using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace MovieRaptor.Application
{
    public class ApplicationAssemblyReference
    {
        internal static readonly Assembly Assembly = typeof(ApplicationAssemblyReference).Assembly;
    }
}
