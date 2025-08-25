using Microsoft.EntityFrameworkCore;
using WebAppStudent_Repositary_Pattern.Data;
using WebAppStudent_Repositary_Pattern.Repositories;
using WebAppStudent_Repositary_Pattern.Repositories.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddMvc();

//DB Context
builder.Services.AddDbContext<StudentDbContext>(options => 
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Repository Pattern
builder.Services.AddScoped<IStudentRepository, StudentRepo>();
builder.Services.AddScoped<ICourseRepository, CourseRepo>();
builder.Services.AddScoped<IEnrollmentRepo, EnrollmentRepo>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
