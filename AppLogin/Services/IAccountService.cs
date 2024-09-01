﻿using AppLogin.DTOs;
using static AppLogin.Responses.CustomResponses;

namespace AppLogin.Services
{
    public interface IAccountService
    {
        Task<RegistrationResponse> RegisterAsync(RegisterDTO model);
        Task<LoginResponse> LoginAsync(LoginDTO model);
        Task<WeatherForecast[]> GetWeatherForecasts();
        Task<LoginResponse> LogoutAsync();
    }
}
