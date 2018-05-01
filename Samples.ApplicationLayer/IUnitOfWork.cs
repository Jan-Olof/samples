namespace Samples.ApplicationLayer
{
    public interface IUnitOfWork
    {
        /// <summary>
        /// Store all changes made in a data store.
        /// </summary>
        int Store();
    }
}