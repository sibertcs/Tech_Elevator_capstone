using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleApi.Models
{
    public class APIModel
    {

        public class RootObject
        {
            public Foodsearchcriteria foodSearchCriteria { get; set; }
            public int totalHits { get; set; }
            public int currentPage { get; set; }
            public int totalPages { get; set; }
            public Food[] foods { get; set; }
        }

        public class Foodsearchcriteria
        {
            public string query { get; set; }
            public string generalSearchInput { get; set; }
            public int pageNumber { get; set; }
            public bool requireAllWords { get; set; }
        }

        public class Food
        {
            public int fdcId { get; set; }
            public string description { get; set; }
            public string dataType { get; set; }
            public string gtinUpc { get; set; }
            public string publishedDate { get; set; }
            public string brandOwner { get; set; }
            public string ingredients { get; set; }
            public Foodnutrient[] foodNutrients { get; set; }
            public string allHighlightFields { get; set; }
            public float score { get; set; }
            public string additionalDescriptions { get; set; }
            public string foodCode { get; set; }
            public string ndbNumber { get; set; }
            public string scientificName { get; set; }
        }

        public class Foodnutrient
        {
            public int nutrientId { get; set; }
            public string nutrientName { get; set; }
            public string nutrientNumber { get; set; }
            public string unitName { get; set; }
            public string derivationCode { get; set; }
            public string derivationDescription { get; set; }
            public float value { get; set; }
        }

    }
}
