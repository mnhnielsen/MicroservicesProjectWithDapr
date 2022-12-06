namespace sample.microservice.service1.State
{
    public class OrderState
    {
        public DateTime CreatedOn { get; set; }

        public Order? Order { get; set; }

        public string? Status { get; set; }
    }
}
