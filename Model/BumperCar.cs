class BumperCar : Vehicle
{
    public BumperCar(string Model, string Brand)
    {
        this.maxSpeed = 100; // Max speed taken from world record: https://www.livescience.com/58534-fastest-bumper-car-guinness-world-records.html
        this.motorized = false;
        this.model = Model;
        this.brand = Brand;
    }
}