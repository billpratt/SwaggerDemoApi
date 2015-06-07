using System;

namespace SwaggerDemoApi.Models
{
    /// <summary>
    /// Superhero
    /// </summary>
    public class Superhero
    {
        /// <summary>
        /// Guid id of the superhero
        /// </summary>
        public Guid Id { get; set; }
        
        /// <summary>
        /// Superhero name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Superhero real name
        /// </summary>
        public string RealName { get; set; }
        
        /// <summary>
        /// Which comic book universe does the superhero belong to
        /// </summary>
        public Universe Universe { get; set; }
    }
}