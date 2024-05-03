
using Microsoft.EntityFrameworkCore;

namespace Bethanypieshop.Models
{
    public class ShoppingCart : IShoppingCart
    {
        private BethanypieshopDbContext _BethanypiesDbContext { get; set; }
        public string? ShoppingCartId { get; set; }
        public List<ShoppingCartItem> ShoppingCartItems
        {
            get;
            set;
        } = default!;

        public ShoppingCart(BethanypieshopDbContext BethanyDbContext)
        {
            _BethanypiesDbContext = BethanyDbContext;
        }
        public void AddToCart(Pie pie)
        {
            var shoppingCartItem = _BethanypiesDbContext.ShoppingCartItems.SingleOrDefault(s => s.ShoppingCartId == ShoppingCartId && pie.PieId == s.Pie.PieId);
            if (shoppingCartItem == null)
            {
                shoppingCartItem = new ShoppingCartItem
                {
                    ShoppingCartId = ShoppingCartId,
                    Pie = pie,
                    Amount = 1

                };

                _BethanypiesDbContext.ShoppingCartItems.Add(shoppingCartItem);
            }
            else
            {
                shoppingCartItem.Amount++;
            }
            _BethanypiesDbContext.SaveChanges();



        }

        public void ClearCart()
        {
            var cartItems = _BethanypiesDbContext.ShoppingCartItems.Where(c => c.ShoppingCartId == ShoppingCartId);
            _BethanypiesDbContext.ShoppingCartItems.RemoveRange(cartItems);
            _BethanypiesDbContext.SaveChanges();
        }

        public List<ShoppingCartItem> GetShoppingCartItems()
        {
            return _BethanypiesDbContext.ShoppingCartItems.Where(s => s.ShoppingCartId == ShoppingCartId).Include(s => s.Pie).ToList();
        }

        public int RemoveFromCart(Pie pie)
        {
            var shoppingCartItem = _BethanypiesDbContext.ShoppingCartItems.SingleOrDefault(s => s.ShoppingCartId == ShoppingCartId && pie.PieId == s.Pie.PieId);
            var localAmount = 0;
            if (shoppingCartItem != null)
            {
                if (shoppingCartItem.Amount > 1)
                {
                    shoppingCartItem.Amount--;
                    localAmount = shoppingCartItem.Amount;

                }
                else
                {
                    _BethanypiesDbContext.ShoppingCartItems.Remove(shoppingCartItem);
                }
                _BethanypiesDbContext.SaveChanges();
            }
            return localAmount;

        }
        public decimal GetShoppingCartTotal()
        {
            decimal total=_BethanypiesDbContext.ShoppingCartItems.Where(s=>s.ShoppingCartId==ShoppingCartId).Select(p=>p.Pie.Price*p.Amount).Sum();
            return total;
        }


        public static ShoppingCart GetCart(IServiceProvider services)
        {
            ISession? session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext?.Session;

            BethanypieshopDbContext context = services.GetService<BethanypieshopDbContext>() ?? throw new Exception("Error Initializing");

            string cartId = session?.GetString("CartId") ?? Guid.NewGuid().ToString();           
           
            session?.SetString("CartId", cartId);

            return new ShoppingCart(context) { ShoppingCartId = cartId };
            

        }
    }
}
