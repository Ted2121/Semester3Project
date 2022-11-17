﻿using DataAccessDefinitionLibrary.DAO_Interfaces;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiClient.DTOs;
using WebApiClient.Extensions;

namespace WebApiClient;

public class WebUserFacadeApiClient
{
    private RestClient _restClient;

    public WebUserFacadeApiClient(string uri) => _restClient = new RestClient(uri);

    public async Task<IEnumerable<WebUserDto>> GetWebUsersAsync()
    {
        var response = await _restClient.RequestAsync<IEnumerable<WebUserDto>>(Method.GET, $"WebUser");

        if (!response.IsSuccessful)
        {
            throw new Exception($"Error retrieving all web users. Message was {response.Content}");
        }

        return response.Data;
    }

    public async Task<int> CreateWebUserAsync(WebUserDto webUser)
    {
        var response = await _restClient.RequestAsync<int>(Method.POST, $"WebUser", webUser);

        if (!response.IsSuccessful)
        {
            throw new Exception($"Error creating the web user. Message was {response.Content}");
        }

        return response.Data;

    }

    public async Task<WebUserDto> GetWebUserFromUsernameAsync(string username)
    {
        var response = await _restClient.RequestAsync<WebUserDto>(Method.GET, $"WebUser/{username}");

        if (!response.IsSuccessful)
        {
            throw new Exception($"Error retrieving the web user with the username {username}. Message was {response.Content}");
        }

        return response.Data;

    }

}
