using System.Collections.Generic;
using System.Threading.Tasks;
using RepositoryLayer.Entity;

namespace BusinessLayer.Interface
{
    public interface IAddressBookBL
    {
        Task<List<AddressBookEntry>> GetAllContactsAsync();
        Task<AddressBookEntry?> GetContactByIdAsync(int id);
        Task AddNewContactAsync(AddressBookEntry entry);
        Task UpdateContactAsync(AddressBookEntry entry);
        Task DeleteContactByIdAsync(int id);
        Task<List<AddressBookEntry>> GetAddressBookEntries(int id);
    }
}
