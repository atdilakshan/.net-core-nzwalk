﻿using NZWalks.API.Models.Domain;

namespace NZWalks.API.Repositories
{
    public interface ITokenHandler
    {
        Task<string> CreeateTokenAsync(User user);
    }
}
