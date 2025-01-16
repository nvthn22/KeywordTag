var builder = DistributedApplication.CreateBuilder(args);

//var cache = builder.AddRedis("cache");

var apiService = builder.AddProject<Projects.api_service>("api-service");
var apiBusiness = builder.AddProject<Projects.api_business>("api-business");

builder.AddProject<Projects.web_blazor>("web-blazor")
    .WithExternalHttpEndpoints()
    //.WithReference(cache)
    //.WaitFor(cache)
    .WithReference(apiService)
    .WaitFor(apiService)
    .WithReference(apiBusiness)
    .WaitFor(apiBusiness);

builder.AddNpmApp("web-react", "../keywordtag.web.react")
    .WithReference(apiService)
    .WaitFor(apiService)
    .WithReference(apiBusiness)
    .WaitFor(apiBusiness)
    .WithEnvironment("BROWSER", "none")
    .WithHttpEndpoint(env: "PORT")
    .WithExternalHttpEndpoints();
//.PublishAsDockerFile();

builder.AddNpmApp("web-vue", "../keywordtag.web.vue")
    .WithReference(apiService)
    .WaitFor(apiService)
    .WithReference(apiBusiness)
    .WaitFor(apiBusiness)
    .WithHttpEndpoint(env: "PORT")
    .WithExternalHttpEndpoints();
//.PublishAsDockerFile();

builder.Build().Run();
