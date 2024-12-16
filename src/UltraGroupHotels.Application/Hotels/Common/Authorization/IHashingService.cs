﻿namespace UltraGroupHotels.Application.Hotels.Common.Authorization;

public interface IHashingService
{
    string HashPassword(string password);
    bool VerifyHash(string password, string hashedPassword);
}