using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class StartupSetup
    {
        public static void AddTodoContext(this IServiceCollection services, string connectionString) =>
            services.AddDbContext<TodoDbContext>(options =>
                options.UseSqlServer(connectionString));
    }
}
