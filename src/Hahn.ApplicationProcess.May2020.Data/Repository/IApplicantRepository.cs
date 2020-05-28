using System.Threading.Tasks;

namespace Hahn.ApplicationProcess.May2020.Data.Repository
{
    /// <summary>
    ///     Repository for the specified type.
    /// </summary>
    /// <typeparam name="T">Any model type</typeparam>
    public interface IApplicantRepository<T>
    {
        /// <summary>
        ///     Create a new item.
        /// </summary>
        /// <param name="item">Item to be created.</param>
        /// <returns>Created item.</returns>
        Task<T> Create(T item);

        /// <summary>
        ///     Update a given item.
        /// </summary>
        /// <param name="item">Item to be updated.</param>
        /// <returns>Updated item.</returns>
        Task<T> Update(T item);

        /// <summary>
        ///     Get an item by id.
        /// </summary>
        /// <param name="id">Id of the item.</param>
        /// <returns>Item with the specified Id.</returns>
        T Get(int id);

        /// <summary>
        ///     Delete an item.
        /// </summary>
        /// <param name="id">Id of the item.</param>
        /// <returns>Whether the delete was successful or not.</returns>
        Task<bool> Delete(int id);
    }
}