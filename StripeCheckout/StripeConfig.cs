
namespace StripeCheckout;
public class StripeConfig
{
    public string SecretApiKey { get; set; }
    public string PaymentSuccessUrl { get; set; }
    public string PaymentCancelUrl { get; set; }
    public string PriceId { get; set; }
    public string CustomerId { get; set; }
}