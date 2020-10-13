class Bicycle : Vehicle
{
    /// <summary>
    /// Create an instance of a bicycle. MaxSpeed is 100 km/h for bicycles and they are not motorized.
    /// </summary>
    /// <param name="Model">The name of the production model.</param>
    /// <param name="Brand">The name of the company that produced the bicycle.</param>
    public Bicycle(string Model, string Brand)
    {
        this.maxSpeed = 100; // Max speed taken from world record: https://en.wikipedia.org/wiki/Bicycle_performance
        this.motorized = false;
        this.model = Model;
        this.brand = Brand;
    }
}