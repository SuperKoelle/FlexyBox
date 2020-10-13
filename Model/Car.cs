class Car : Vehicle
{
    /// <summary>
    /// Create an instance of a car. MaxSpeed is 150 km/h for cars and they are motorized.
    /// </summary>
    public Car()
    {
        this.maxSpeed = 150; // Max speed given by FlexyBox
        this.motorized = true;
        this.numberOfWheels = 4;
    }
}