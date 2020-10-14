namespace FlexyBox
{
class Bicycle : Vehicle
{
    /// <summary>
    /// Create an instance of a bicycle. MaxSpeed is 100 km/h for bicycles and they are not motorized.
    /// </summary>
    public Bicycle()
    {
        this.maxSpeed = 100; // Max speed taken from world record: https://en.wikipedia.org/wiki/Bicycle_performance
        this.motorized = false;
        this.numberOfWheels = 2;
    }
}
}