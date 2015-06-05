namespace SwaggerDemoApi.Models
{
    /// <summary>
    /// Superhero model to use for POST
    /// </summary>
    public class PostSuperheroModel
    {
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