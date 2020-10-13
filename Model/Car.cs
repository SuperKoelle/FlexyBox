class Car : Vehicle
{
    /// <summary>
    /// Create an instance of a car. MaxSpeed is 150 km/h for cars and they are motorized.
    /// </summary>
    /// <param name="Model">The name of the production model.</param>
    /// <param name="Brand">The name of the company that produced the car.</param>
    public Car(string Model, string Brand)
    {
        this.maxSpeed = 150; // Max speed given by FlexyBox
        this.motorized = true;
        this.model = Model;
        this.brand = Brand;
    }
}