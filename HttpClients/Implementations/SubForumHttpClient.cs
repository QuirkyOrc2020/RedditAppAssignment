﻿using System.Text;
using System.Text.Json;

using Domain.DTOs;
using Domain.Models;
using HttpClients.ClientInterfaces;

namespace HttpClients.Implementations;

public class SubForumHttpClient : ISubForumService
{
    
    private readonly HttpClient client;

    public SubForumHttpClient(HttpClient client)
    {
        this.client = client;
    }
    
    public async Task<ICollection<SubForum>> GetAsync()
    {
        HttpResponseMessage response = await client.GetAsync("/SubForms");
        string content = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(content);
        }

        ICollection<SubForum>? subForums = JsonSerializer.Deserialize<ICollection<SubForum>>(content, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        });

        return subForums;
    }

    public async Task CreateAsync(string name, int id)
    {
        SubForumCreationDto subForumCreationDto = new(name, id);

        string subFormAsJson = JsonSerializer.Serialize(subForumCreationDto);
        StringContent content = new(subFormAsJson, Encoding.UTF8, "application/json");

        HttpResponseMessage response = await client.PostAsync("https://localhost:7141/SubForms", content);
        string responseContent = await response.Content.ReadAsStringAsync();
        
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(responseContent);
        }
    }
}