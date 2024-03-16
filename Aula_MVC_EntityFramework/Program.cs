using Aula_MVC_EntityFramework.Repositorio.Contexto;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

var app = builder.Build();

var services = new ServiceCollection();

services.AddDbContext<ProdutoContext>();

if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
	app.UseHsts();
}

//Adiciona middleware para redirecionar solicitações HTTP para HTTPS.
app.UseHttpsRedirection();

//Os arquivos são servidos a partir do caminho especificado em
//Microsoft.AspNetCore.Hosting.IWebHostEnvironment.WebRootPath pasta wwwroot
app.UseStaticFiles();

//define um ponto no pipeline de middleware onde as decisões de roteamento
app.UseRouting();

app.UseAuthorization();

// Adiciona middleware para definir as rotas da aplicação
app.MapControllerRoute(
	name: "defualt",
	pattern: "{controller=Produto}/{action=Index}/{id?}");

app.Run();