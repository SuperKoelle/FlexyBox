class BumperCar : Vehicle
{
    /// <summary>
    /// Create an instance of a bumper car. MaxSpeed is 100 km/h for bumpercars and they are motorized.
    /// </summary>
    public BumperCar()
    {
        this.maxSpeed = 100; // Max speed taken from world record: https://www.livescience.com/58534-fastest-bumper-car-guinness-world-records.html
        this.motorized = true;
        this.numberOfWheels = 3;
    }
}