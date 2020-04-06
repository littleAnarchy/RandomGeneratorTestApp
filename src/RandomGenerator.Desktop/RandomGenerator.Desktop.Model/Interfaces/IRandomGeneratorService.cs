using System.Threading.Tasks;

namespace RandomGenerator.Desktop.Model.Interfaces
{
    public interface IRandomGeneratorService
    {
        Task<int> GetRandomValueAsync();
    }
}
