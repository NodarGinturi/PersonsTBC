namespace Persons.Api
{
    public static class ApiEndpoints
    {
        private const string ApiBase = "api";

        public static class Persons
        {
            private const string Base = $"{ApiBase}/person";
            public const string Create = Base;
            public const string GetAll = Base;
            public const string Get = $"{Base}/{{id}}";
            public const string Update = $"{Base}/{{id}}";
            public const string Delete = $"{Base}/{{id}}";

            private const string RelatedPerson = $"{ApiBase}/relatedPerson";
            public const string RelatedCreate = RelatedPerson;
            public const string RelatedDelete = $"{RelatedPerson}/{{id}}";
            public const string RelatedUpdate = $"{RelatedPerson}/{{id}}";
            public const string RelatedGetAll = Base;
            public const string RelatedGet = $"{Base}/{{id}}";
        }
    }
}
