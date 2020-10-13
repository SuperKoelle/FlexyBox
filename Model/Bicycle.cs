class Bicycle : Vehicle
{
    public Bicycle(string Model, string Brand)
    {
        this.maxSpeed = 100; // Max speed taken from world record: https://en.wikipedia.org/wiki/Bicycle_performance
        this.motorized = false;
        this.model = Model;
        this.brand = Brand;
    }
}