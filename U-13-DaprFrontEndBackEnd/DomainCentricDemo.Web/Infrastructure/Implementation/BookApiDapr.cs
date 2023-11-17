using Dapr.Client;
using DomainCentricDemo.Web.Infrastructure.Dto;

namespace DomainCentricDemo.Web.Infrastructure.Implementation;

public class BookApiDapr : IBookApiProxy
{
    private readonly DaprClient _daprClient;
    private readonly string _methodName = "api/Book";
    private readonly string _appId = "bookdemoapi";

    public BookApiDapr(DaprClient daprClient)
    {
        _daprClient = daprClient;
    }

    async Task IBookApiProxy.CreateAsync(BookDto book)
    {
        await _daprClient.InvokeMethodAsync(
            HttpMethod.Post,
            _appId,
            _methodName, book);
    }

    async Task IBookApiProxy.DeleteAsync(int id)
    {
        await _daprClient.InvokeMethodAsync(
            HttpMethod.Delete,
            _appId,
            $"{_methodName}/{id}");
    }

    async Task<IEnumerable<BookDto>?> IBookApiProxy.GetAllAsync()
    {
        return  await _daprClient.InvokeMethodAsync<List<BookDto>>(
            HttpMethod.Get,
            _appId,
            _methodName);
    }

    async Task<BookDto?> IBookApiProxy.GetAsync(int id)
    {
        return await _daprClient.InvokeMethodAsync<BookDto>(HttpMethod.Get, _appId,
                $"{_methodName}/{id}");
    }

    async Task IBookApiProxy.UpdateAsync(BookDto book)
    {
        await _daprClient.InvokeMethodAsync(
            HttpMethod.Put,
            _appId,
            _methodName, book);
    }
}

public class WetherApiDapr : IWetherApiProxy
{
    private readonly DaprClient _daprClient;
    private readonly string _appId = "weatherdemoapi";
    private readonly string _methodName = "WeatherForecast";

    public WetherApiDapr(DaprClient daprClient)
    {
        _daprClient = daprClient;
    }

    async Task<IEnumerable<WetherDto>?> IWetherApiProxy.GetAllAsync()
    {
        return  await _daprClient.InvokeMethodAsync<List<WetherDto>>(
            HttpMethod.Get,
            _appId,
            _methodName);
    }
}