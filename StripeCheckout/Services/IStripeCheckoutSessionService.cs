using Stripe.Checkout;

namespace StripeCheckout.Services;
public interface IStripeCheckoutSessionService
{
    Task<Session> CreateCheckoutSession(string customerId, string priceId);
}
