namespace CompanyMediaTests.Urls
{
    internal class CompanyMediaWebUrls
    {
        internal static string LogInPageUrl { get; }
        internal static string MainPageUrl { get; }
        internal static string SystemStructureUrl { get; }        
        internal static string OrganizationUrl { get; }
        internal static string OrganizationsDataBookUrl { get; }
        internal static string PersonsDataBookUrl { get; }
        internal static string ClassifiersUrl { get; }
        internal static string AgentsUrl { get; }

        static CompanyMediaWebUrls()
        {
            LogInPageUrl = @"http://192.168.0.110:8080/cm5div6/";
            MainPageUrl = @"http://192.168.0.110:8080/cm5div6/BusinessUniverse.html)";            
            SystemStructureUrl = @"http://192.168.0.110:8080/cm5div6/BusinessUniverse.html#link=SS_Module;";            
            OrganizationUrl = @"http://192.168.0.110:8080/cm5div6/BusinessUniverse.html#link=SO_OrgSystemhierarchy;";
            OrganizationsDataBookUrl = @"http://192.168.0.110:8080/cm5div6/BusinessUniverse.html#link=SO_OrgDescriptionNonsys_Org;";
            PersonsDataBookUrl = @"http://192.168.0.110:8080/cm5div6/BusinessUniverse.html#link=SO_PersonNonsysOrg;";
            ClassifiersUrl = @"http://192.168.0.110:8080/cm5div6/BusinessUniverse.html#link=ClassifierType;";
            AgentsUrl = @"http://192.168.0.110:8080/cm5div6/BusinessUniverse.html#link=Agents;";
        }
    }
}