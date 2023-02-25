namespace Engine.FuelLine
{
    public class FuelLine
    {
        public FuelTank Tank { get; set; }
        public FuelPump Pump { get; set; }
        public FuelValve Valve { get; set; }
        public Nozzle Nozzle { get; set; }

        public FuelLine(FuelTank fuelTank, FuelPump fuelPump, FuelValve fuelValve, Nozzle nozzle)
        {
            Tank = fuelTank;
            Pump = fuelPump;
            Valve = fuelValve;
            Nozzle = nozzle;
        }
    }
}
