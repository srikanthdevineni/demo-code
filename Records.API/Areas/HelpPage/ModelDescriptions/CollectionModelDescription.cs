using System.Diagnostics.CodeAnalysis;
namespace Records.API.Areas.HelpPage.ModelDescriptions
{
    [ExcludeFromCodeCoverage]
    public class CollectionModelDescription : ModelDescription
    {
        public ModelDescription ElementDescription { get; set; }
    }
}