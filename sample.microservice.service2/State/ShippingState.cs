namespace sample.microservice.service2.State
{
    public class ShippingState
    {
        public DateTime CreatedOn { get; set; }
        public Guid OrderId { get; set; }

        public Guid ShipmentId { get; set; }
    }
}
