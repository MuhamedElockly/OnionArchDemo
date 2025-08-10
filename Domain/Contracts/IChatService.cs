using System.Threading.Tasks;

namespace Domain.Contracts
{
    public interface IChatService
    {
        Task<string> GetChatHistoryAsync(string userId);
        Task<bool> SaveChatMessageAsync(string userId, string message);
    }
}
