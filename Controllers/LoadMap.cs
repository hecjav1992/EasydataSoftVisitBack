﻿using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Text.Json;

namespace SistemaDeVisitaCampeon.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DistanceController : ControllerBase
{
    private readonly IHttpClientFactory _clientFactory;
    private readonly IConfiguration _config;




    public DistanceController(IHttpClientFactory clientFactory, IConfiguration config)
    {
        _clientFactory = clientFactory;
        _config = config;
    }
    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] string origins, [FromQuery] string destinations)
    {
        if (string.IsNullOrWhiteSpace(origins) || string.IsNullOrWhiteSpace(destinations))
            return BadRequest("origins y destinations son obligatorios");

        string apiKey = _config["GoogleMaps:ApiKey"];
        string url =
            $"https://maps.googleapis.com/maps/api/distancematrix/json?" +
            $"origins={Uri.EscapeDataString(origins)}&" +
            $"destinations={Uri.EscapeDataString(destinations)}&" +
            $"&departure_time=now&mode=driving"+
            $"units=metric&language=es&key={apiKey}";

        var client = _clientFactory.CreateClient("GoogleMaps");
        var response = await client.GetAsync(url);

        if (!response.IsSuccessStatusCode)
            return StatusCode((int)response.StatusCode, await response.Content.ReadAsStringAsync());

        var json = await response.Content.ReadAsStringAsync();

        using var doc = JsonDocument.Parse(json);
        var element = doc.RootElement;

        var distancia = element
            .GetProperty("rows")[0]
            .GetProperty("elements")[0]
            .GetProperty("distance")
            .GetProperty("text")
            .GetString();

        var duracion = element
            .GetProperty("rows")[0]
            .GetProperty("elements")[0]
            .GetProperty("duration")
            .GetProperty("text")
            .GetString();

        var duraciontrfic = element
           .GetProperty("rows")[0]
           .GetProperty("elements")[0]
           .GetProperty("duration_in_traffic")
           .GetProperty("text")
           .GetString();
        return Ok(new {distancia, duracion,duraciontrfic });

    }
}

