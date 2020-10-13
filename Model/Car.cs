class Car : Vehicle
{
    public Car(string Model, string Brand)
    {
        this.maxSpeed = 150; // Max speed given by FlexyBox
        this.motorized = true;
        this.model = Model;
        this.brand = Brand;
    }
}