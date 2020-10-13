class BumperCar : Vehicle
{
    /// <summary>
    /// Create an instance of a bumper car. MaxSpeed is 100 km/h for bumpercars and they are motorized.
    /// </summary>
    /// <param name="Model">The name of the production model.</param>
    /// <param name="Brand">The name of the company that produced the bumpercar.</param>
    public BumperCar(string Model, string Brand)
    {
        this.maxSpeed = 100; // Max speed taken from world record: https://www.livescience.com/58534-fastest-bumper-car-guinness-world-records.html
        this.motorized = true;
        this.model = Model;
        this.brand = Brand;
    }
}