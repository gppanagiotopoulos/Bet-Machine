using System.Linq.Expressions;

namespace BetMachine.Domain.Interfaces
{
    /// <summary>
    /// Represents an entity repository with repository pattern
    /// </summary>  
    public interface IRepository<T> where T : class
    {
        /// <summary>
        /// Get an entity entry from database by the id
        /// </summary>  
        /// <param name="id">The id of the entry we are looking for</param>
        /// <returns>Asynchronously returns the entry we are looking if it exists </returns>
        Task<T?> GetAsync(int id);

        /// <summary>
        /// Get all entries of an entity 
        /// </summary>  
        /// <returns>Asynchronously returns a list with the all records of the entity </returns>
        Task<IEnumerable<T>> GetAllAsync();

        /// <summary>
        /// Add an entity entry 
        /// </summary>  
        /// <param name="entity">Asynchronously returns an entity entry</param>
        Task AddAsync(T entity);

        /// <summary>
        /// Add entity entries 
        /// </summary>  
        /// <param name="entities">Asynchronously returns a list of entity entries</param>
        Task AddRangeAsync(IEnumerable<T> entities);

        /// <summary>
        /// Delete an entity entry 
        /// </summary>  
        /// <param name="entity">Entity entry</param>
        void Delete(T entity);

        /// <summary>
        /// Delete entity entries 
        /// </summary>  
        /// <param name="entities">A list of entity entries</param>
        void DeleteRange(IEnumerable<T> entities);

        /// <summary>
        /// Update an entity entry 
        /// </summary>  
        /// <param name="entity">Entity entry</param>
        void Update(T entity);

        /// <summary>
        /// Update entity entries 
        /// </summary>  
        /// <param name="entities">Asynchronously returns a list of entity entries</param>
        void UpdateRange(IEnumerable<T> entities);

        /// <summary>
        /// Find all entities which matches to predicate expression
        /// </summary>
        /// <param name="predicate">Represents a strongly typed lambda expression as a data structure in the form of an expression tree</param>
        /// <returns>Asynchronously returns a List with entities</returns>
        Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// Asynchronously find the only element of a sequence, or a default value that satisfies the predicate expression
        /// </summary>
        /// <param name="predicate">Represents a strongly typed lambda expression as a data structure in the form of an expression tree</param>
        /// <returns>Asynchronously returns an element</returns>
        Task<T?> SingleOrDefaultAsync(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// Asynchronously checks if any elements in the source sequence pass the test in the specified predicate;
        /// </summary>
        /// <param name="predicate">Represents a strongly typed lambda expression as a data structure in the form of an expression tree</param>
        /// <returns>Asynchronously returns a boolean with the result operation</returns>
        Task<bool> AnyAsync(Expression<Func<T, bool>> predicate);
    }
}