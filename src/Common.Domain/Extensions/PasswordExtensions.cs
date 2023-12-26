﻿namespace Common.Domain.Extensions;

public static class PasswordExtensions
{
    public static string HashPassword(this string value)
        => BCrypt.Net.BCrypt.HashPassword(value);

    public static bool VerifyHashedPassword(this string hashedPassword, string password)
        => BCrypt.Net.BCrypt.Verify(password, hashedPassword);
}
