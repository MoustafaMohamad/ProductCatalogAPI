namespace ProductCatalogAPI.Common.Middlewares
{
    public class TransactionMiddleware : IMiddleware
    {
        private readonly Context _context;
        public TransactionMiddleware(Context context)
        {
            _context = context;
        }
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            string method = context.Request.Method.ToUpper();
            Console.WriteLine($"_context.GetHashCode() in TransactionMiddleware {_context.GetHashCode()}"); ;

            if (method == "POST" || method == "PUT" || method == "DELETE")
            {
                var transaction = await _context.Database.BeginTransactionAsync();
                try
                {
                    await next(context);
                    await transaction.CommitAsync();
                    await _context.SaveChangesAsync();

                }
                catch (Exception)
                {
                    await transaction.RollbackAsync();
                    throw;
                }
            }
            else
            {
                await next(context);
            }
        }
    }
}
