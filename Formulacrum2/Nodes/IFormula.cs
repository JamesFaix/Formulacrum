namespace Formulacrum {

    /// <summary>
    /// Type that can be rendered as an Excel formula.
    /// </summary>
    public interface IFormula {

        /// <summary>
        /// Returns the instance rendered as an Excel formula.
        /// </summary>
        /// <param name="outline">If <c>true</c>, formula will be rendered as an outline,
        /// with each node on a new line and each child node indented past its parent.
        /// If <c>false</c>, formula is rendered with no line breaks or indentation.</param>
        /// <returns>Rendered formula.</returns>
        string Render(bool outline);

    }
}