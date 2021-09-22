using Stripe;
using Stripe.Checkout;

namespace StripeCheckout.Services;
public class StripeCheckoutSessionService : IStripeCheckoutSessionService
{
    private readonly StripeConfig _config;

    public StripeCheckoutSessionService(StripeConfig config)
    {
        _config = config;
        StripeConfiguration.ApiKey = _config.SecretApiKey;
    }

    public async Task<Session> CreateCheckoutSession(string customerId, string priceId)
    {
        var options = new SessionCreateOptions
        {
            Customer = customerId,
            PaymentMethodTypes = new List<string>
            {
                "card"
            },
            LineItems = new List<SessionLineItemOptions>
            {
                new SessionLineItemOptions
                {
                    Price = priceId,
                    Quantity = 1,
                }
            },
            SuccessUrl = _config.PaymentSuccessUrl,
            CancelUrl = _config.PaymentCancelUrl,
            Mode = "payment",
            AllowPromotionCodes = true
        };

        var service = new SessionService();
        return await service.CreateAsync(options);
    }
}
