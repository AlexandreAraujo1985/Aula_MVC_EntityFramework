using Aula_MVC_EntityFramework.Repositorio.Contexto;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

var services = new ServiceCollection();

services.AddControllers();
services.AddSwaggerGen();

services.AddDbContext<ProdutoContext>();

app.UseSwagger();

//app.UseSwaggerUI(c =>
//{
//	c.SwaggerEndpoint("/swagger/v1/swagger.json", "API V1");
//});

app.UseHttpsRedirection();
app.UseRouting();

//app.UseCors("CorsPolicy");
app.UseStaticFiles();

app.Run();
