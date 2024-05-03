namespace Bethanypieshop.Models
{
    public class OrderRepository : IOrderRepository
    {
        public BethanypieshopDbContext _bethanypieshopDbContext { get; set; }
        public IShoppingCart  _shoppingCart { get; set; }
        public OrderRepository(BethanypieshopDbContext bethanypieshopDbContext,IShoppingCart shoppingCart)
        {
            _bethanypieshopDbContext=bethanypieshopDbContext;
            _shoppingCart=shoppingCart;

        }
        public void CreateOrder(Order order)
        {
            order.OrderPlaced = DateTime.Now;
            order.OrderDetails = new List<OrderDetail>();
            order.OrderTotal = _shoppingCart.GetShoppingCartTotal();
            List<ShoppingCartItem> shoppingCartItem = _shoppingCart.ShoppingCartItems;
            
            foreach(var shopitem in shoppingCartItem)
            {
               var orderDetail=new OrderDetail
               {

                   PieId = shopitem.Pie.PieId,
                   Amount = shopitem.Amount,
                   Price = shopitem.Pie.Price

               };

                order.OrderDetails.Add(orderDetail);
            }
            _bethanypieshopDbContext.Orders.Add(order);
            _bethanypieshopDbContext.SaveChanges();
            
        }
    }
}
