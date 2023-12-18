namespace Common.Domain.Extensions;

public static class DateExtensions
{
    public static string FormatPasswordReset(this DateTime value)
        => string.Format("{0:yyyy-MM-dd HH:mm:ss.fffff}", value);
}
