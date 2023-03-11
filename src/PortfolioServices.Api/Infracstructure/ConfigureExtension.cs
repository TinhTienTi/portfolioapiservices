namespace PortfolioServices.Api.Infracstructure
{
    public static class ConfigureExtension
    {
        public static async Task AddConfigureAsync(this WebApplication app)
        {
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();

                app.UseSwaggerUI(c =>
                {
                    c.DefaultModelsExpandDepth(-1);
                });
            }

            app.ConfigureCustomAuditMiddleware();

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            await app.RunAsync();
        }
    }
}
