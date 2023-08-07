using Kanini_Toursim.Model;
using Microsoft.EntityFrameworkCore;
using Travel.Repository.Interface;
using Travel.Repository.Services;

var builder = WebApplication.CreateBuilder(args);

// Load configuration from appsettings.json
builder.Configuration.AddJsonFile("appsettings.json");

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//builder.Services.AddScoped<ITravelRepository, TravelRepository>();
//builder.Services.AddScoped<IActivitiesRepository, ActivitiesRepository>();
builder.Services.AddScoped<IAdminImageGalleryRepository, AdminImageGalleryRepository>();
builder.Services.AddScoped< IAdminUseService, UsersServices> ();
builder.Services.AddScoped<IBillingDetailsRepository, BillingDetailsRepository>();
builder.Services.AddScoped<IBookingRepository, BookingRepository>();
//builder.Services.AddScoped<IHotelRepository, HotelRepository>();
//builder.Services.AddScoped<ITravelRepository,TravelRepository>();
builder.Services.AddScoped<IPackageRepository, PackageRepository>();
builder.Services.AddScoped<IFeedbackRepository, FeedbackRepository>();

builder.Services.AddCors(op =>
{
    op.AddPolicy("MyCorsPolicy", builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyHeader()
               .AllowAnyMethod();
    });
});// Configure Entity Framework Core with the specified connection string
builder.Services.AddDbContext<KaniniTourismDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectingDB")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("MyCorsPolicy");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
