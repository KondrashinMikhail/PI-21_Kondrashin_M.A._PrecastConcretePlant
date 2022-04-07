namespace PrecastConcretePlantContracts.BindingModels
{
    public class CreateOrderBindingModel
    {
        public int ReinforcedId { get; set; }
        public int ClientId { get; set; }
        public int Count { get; set; }
        public decimal Sum { get; set; }
    }
}
