using KeywordTag.ApiService.Business.Services.AccountService.GetPincode;
using KeywordTag.ApiService.Business.Services.AccountService.Login;
using KeywordTag.ApiService.Business.Services.KeywordService.Checkin;
using KeywordTag.ApiService.Business.Services.KeywordService.GetKeyword;
using KeywordTag.ApiService.Business.Services.KeywordService.Tag;
using KeywordTag.ApiService.Business.Services.MessageService.GetMessages;
using KeywordTag.Database.SQLServer.Contexts;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

// Add databases
builder.Services.AddDbContext<KeywordTagContext>();

// Add cors
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "api-cors",
            policy =>
            {
                policy
                    //.WithOrigins("http://localhost", "https://localhost")
                    .AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .SetIsOriginAllowedToAllowWildcardSubdomains();
                    //.AllowCredentials();
            });
});

// Add services to the container.
builder.Services.AddScoped<GetPincodeAction>();
builder.Services.AddScoped<LoginAction>();
builder.Services.AddScoped<CheckinAction>();
builder.Services.AddScoped<GetKeywordAction>();
builder.Services.AddScoped<GetMessagesAction>();
builder.Services.AddScoped<GetTopKeywordAction>();
builder.Services.AddScoped<TagAction>();

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

app.MapDefaultEndpoints();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseCors("api-cors");
app.UseAuthorization();

app.MapControllers();

app.Run();
