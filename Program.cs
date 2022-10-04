using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//Lo deja como esta en la clase, tal cual es la property "SummaryPlusCamelCase" --> "SummaryPlusCamelCase"
//builder.Services.AddControllers()
//    .AddJsonOptions(option => option.JsonSerializerOptions.PropertyNamingPolicy = null);


//Aca lo pasa a camelCase "SummaryPlusCamelCase" --> "summaryPlusCamelCase"
//builder.Services.AddControllers()
//    .AddJsonOptions(option => option.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase);


////Aca lo pasa a PascalCase con un custom policy que cree abajo "SummaryPlusCamelCase" --> "SUMMARYPLUSCAMELCASE"
builder.Services.AddControllers()
    .AddJsonOptions(option => option.JsonSerializerOptions.PropertyNamingPolicy = new UpperCaseNamingPolicy());



//por defecto se usa la serializacion de System.Text.Json pero si bajas el paquete --> Microsoft.AspNetCore.Mvc.NewtonsoftJson
// aca vemos un ejemplo con camelCase
//builder.Services.AddControllers()

//    .AddNewtonsoftJson(jsonOptions =>
//        jsonOptions.UseCamelCasing(false)
//    );

//Aca se usa newtonsoft y se le dice que mantenga el nombre de la propiedad "SummaryPlusCamelCase" --> "SummaryPlusCamelCase"
//builder.Services.AddControllers()

//    .AddNewtonsoftJson(jsonOptions =>
//        jsonOptions.UseMemberCasing()
//    );



// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();


public class UpperCaseNamingPolicy : JsonNamingPolicy
{
    public override string ConvertName(string name) =>
        name.ToUpper();
}
