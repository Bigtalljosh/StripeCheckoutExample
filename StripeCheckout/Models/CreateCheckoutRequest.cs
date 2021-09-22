
namespace StripeCheckout.Models;
public class CreateCheckoutRequest
{
    public string CustomerId { get; set; }
    public string PriceId { get; set; }
}
