namespace CepsaMigration.Data.TypeSafeEnum
{
    /// <summary>
    /// The data type type safe enum class.
    /// </summary>
    public sealed class DataType
    {
        private readonly string _name;

        /// <summary>
        /// Initializes a new instance of the <see cref="DataType"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        private DataType(string name)
        {
            _name = name;
        }

        public static readonly DataType StudyPrograms = new DataType("Programas de Estudio");

        /// <summary>
        /// Gets the type of the data.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        public static DataType GetDataType(string name)
        {
            if (name == StudyPrograms.ToString())
            {
                return StudyPrograms;
            }

            return null;
        }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return _name;
        }
    }
}
