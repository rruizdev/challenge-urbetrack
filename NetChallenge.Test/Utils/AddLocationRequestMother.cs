using NetChallenge.Dto.Input;

namespace NetChallenge.Test.Utils
{
    public static class AddLocationRequestMother
    {
        public static AddLocationRequest Default => new AddLocationRequest { Name = "Default", Neighborhood = "Default" };
        public static AddLocationRequest Central => Default.WithName("Central").WithNeighborhood("Almagro");
        public static AddLocationRequest Almagro => Default.WithName("Sucursal Almagro 2").WithNeighborhood("Almagro");
        public static AddLocationRequest Palermo => Default.WithName("Sucursal Palermo").WithNeighborhood("Palermo");

        public static AddLocationRequest WithName(this AddLocationRequest request, string name)
        {
            request.Name = name;
            return request;
        }

        public static AddLocationRequest WithNeighborhood(this AddLocationRequest request, string neighborhood)
        {
            request.Neighborhood = neighborhood;
            return request;
        }
    }
}