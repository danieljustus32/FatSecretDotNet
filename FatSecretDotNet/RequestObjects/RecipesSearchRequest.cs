using System.Collections.Generic;

namespace FatSecretDotNet.RequestObjects
{
    public class RecipesSearchRequest : IFatSecretRequest
    {
        private readonly string _method = "recipes.search.v3";
        public string SearchExpression { get; set; }
        public string RecipeTypes { get; set; }  // Updated to match API name
        public bool? RecipeTypesMatchAll { get; set; }  // Nullable bool to allow optional parameter
        public bool MustHaveImages { get; set; }
        public long? CaloriesFrom { get; set; }
        public long? CaloriesTo { get; set; }
        public long? CarbPercentageFrom { get; set; }
        public long? CarbPercentageTo { get; set; }
        public long? ProteinPercentageFrom { get; set; }
        public long? ProteinPercentageTo { get; set; }
        public long? FatPercentageFrom { get; set; }
        public long? FatPercentageTo { get; set; }
        public long? PrepTimeFrom { get; set; }
        public long? PrepTimeTo { get; set; }
        public int PageNumber { get; set; } = 0;  // Zero-based offset
        public int MaxResults { get; set; } = 20;  // Default max results
        public string SortBy { get; set; }
        public string Format { get; set; } = "xml";  // Default response format

        public List<(string, string)> GetParameters(bool isPremier)
        {
            var headers = new List<(string, string)>();
            headers.Add(("method", _method));
            headers.Add(("search_expression", SearchExpression));
            headers.Add(("recipe_types", RecipeTypes));

            if (RecipeTypesMatchAll.HasValue)
                headers.Add(("recipe_types_matchall", RecipeTypesMatchAll.Value ? "true" : "false"));

            headers.Add(("must_have_images", MustHaveImages ? "true" : "false"));

            if (CaloriesFrom.HasValue)
                headers.Add(("calories.from", CaloriesFrom.ToString()));

            if (CaloriesTo.HasValue)
                headers.Add(("calories.to", CaloriesTo.ToString()));

            if (CarbPercentageFrom.HasValue)
                headers.Add(("carb_percentage.from", CarbPercentageFrom.ToString()));

            if (CarbPercentageTo.HasValue)
                headers.Add(("carb_percentage.to", CarbPercentageTo.ToString()));

            if (ProteinPercentageFrom.HasValue)
                headers.Add(("protein_percentage.from", ProteinPercentageFrom.ToString()));

            if (ProteinPercentageTo.HasValue)
                headers.Add(("protein_percentage.to", ProteinPercentageTo.ToString()));

            if (FatPercentageFrom.HasValue)
                headers.Add(("fat_percentage.from", FatPercentageFrom.ToString()));

            if (FatPercentageTo.HasValue)
                headers.Add(("fat_percentage.to", FatPercentageTo.ToString()));

            if (PrepTimeFrom.HasValue)
                headers.Add(("prep_time.from", PrepTimeFrom.ToString()));

            if (PrepTimeTo.HasValue)
                headers.Add(("prep_time.to", PrepTimeTo.ToString()));

            headers.Add(("page_number", PageNumber.ToString()));
            headers.Add(("max_results", MaxResults.ToString()));

            if (!string.IsNullOrEmpty(SortBy))
                headers.Add(("sort_by", SortBy));

            headers.Add(("format", Format));

            return headers;
        }
    }
}
