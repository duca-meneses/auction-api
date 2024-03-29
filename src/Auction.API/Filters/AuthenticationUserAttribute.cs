﻿using AppAuction.API.Contracts;
using AppAuction.API.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace AppAuction.API.Filters;

public class AuthenticationUserAttribute : AuthorizeAttribute, IAuthorizationFilter
{
    private IUserRepository _repository;

    public AuthenticationUserAttribute(IUserRepository repository) => _repository = repository;

    public void OnAuthorization(AuthorizationFilterContext context)
    {
        try
        {
            var token = TokenOnRequest(context.HttpContext);

            var email = FromBase64String(token);

            var exist = _repository.ExistWithEmail(email);

            if (exist == false)
            {
                context.Result = new UnauthorizedObjectResult("E-mail not valid");
            }
        }
        catch (Exception ex)
        {
            context.Result = new UnauthorizedObjectResult(ex.Message);
        }
    }

    private string TokenOnRequest(HttpContext context)
    {
        var authetication = context.Request.Headers.Authorization.ToString();

        if (string.IsNullOrEmpty(authetication))
        {
            throw new Exception("Token is missing");
        }

        return authetication["Bearer ".Length..];
    }

    private string FromBase64String(string base64)
    {
        var data = Convert.FromBase64String(base64);

        return System.Text.Encoding.UTF8.GetString(data);
    }
}
