using Microsoft.EntityFrameworkCore;
using RockLife.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockLife.Repository
{
    public class CartItemRepository
    {
        private readonly MyAppContext _context;

        public CartItemRepository(MyAppContext context)
        {
            _context = context;
        }

        public async Task AddCartItem(CartItem cartItem)
        {
            _context.CartItems.Add(cartItem); 
            await _context.SaveChangesAsync(); 
        }

        public async Task<List<(int productId, int quantity)>> GetProductsAndQuantitiesByUserIdAsync(int userId)
        {
            // Здесь мы используем асинхронный LINQ-запрос для получения нужной информации из бд
            var result = await _context.CartItems
                .Where(cartItem => cartItem.UserId == userId) // Фильтруем элементы корзины по ID пользователя
                .Select(cartItem => new { cartItem.ProductId, cartItem.Quantity }) // Выбираем интересующие нас поля
                .ToListAsync(); // Выполняем запрос асинхронно и получаем результат

            // Преобразуем анонимный тип в кортеж для возврата
            return result.Select(item => (item.ProductId, item.Quantity)).ToList();
        }

        public async Task<List<CartProductDetails>> GetCartProductDetailsByUserIdAsync(int userId)
        {
            var productsInCart = await _context.CartItems
                .Include(cartItem => cartItem.Product) // Подгружаем информацию о продуктах
                .Where(cartItem => cartItem.UserId == userId)
                .Select(cartItem => new CartProductDetails
                {
                    Type = cartItem.Product.Type,
                    Fabricator = cartItem.Product.Fabricator,
                    Name = cartItem.Product.Name,
                    Price = cartItem.Product.Price,
                    Quantity = cartItem.Quantity
                })
                .ToListAsync();

            return productsInCart;
        }
    }
}
