using CakeShop.Entites;

namespace CakeShop.Repositories
{
    public interface IPieRepository
    {
        Task<IEnumerable<Pie>> GetAllpies();
        Task<IEnumerable<Pie>> PiesOfTheWeek();
        Task<Pie?> GetPieById(int pieId);
        Task<Pie?> CreatePie(Pie pie);
        Task<Pie?> UpdatePie(int pieId, Pie pie);
        Task<bool> DeletePie(int pieId);
    }
}
