using System;

namespace TaskApp.Photos.Data.Shared
{
    public interface IEntity
    {
        /// <summary>
        /// Date when the object was created
        /// </summary>
        public DateTime DateCreated { get; set; }

        /// <summary>
        /// Date when the object was modified
        /// </summary>
        public DateTime DateModified { get; set; }
    }
}