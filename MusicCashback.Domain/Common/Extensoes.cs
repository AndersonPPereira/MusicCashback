using System;

namespace MusicCashback.Domain.Common
{
    public static class Extensoes
    {
        public static string ToText(this object value)
        {
            return value?.ToString() ?? string.Empty;
        }

        public static int ToInt(this object value)
        {
            try
            {
                return string.IsNullOrEmpty(value.ToText()) ? 0 : int.Parse(value.ToText());
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public static decimal ToDecimal(this object value)
        {
            try
            {
                return value != null ? decimal.Parse(value.ToText()) : 0.0M;
            }
            catch (Exception)
            {
                return 0.0M;
            }
        }

        public static DateTime ToDate(this object value)
        {
            try
            {
                return !string.IsNullOrEmpty(value?.ToText()) ? DateTime.Parse(value.ToText()) : DateTime.MinValue;
            }
            catch (Exception)
            {
                return DateTime.MinValue;
            }
        }

        public static string ToDateOrNull(this object value)
        {
            try
            {
                return !string.IsNullOrEmpty(value?.ToString())
                        ? DateTime.Parse(value.ToText()).ToString("dd/MM/yyyy HH:mm:ss")
                        : string.Empty;
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }

        public static bool ToBool(this object value)
        {
            try
            {
                return value != null && bool.TryParse(value.ToString(), out var valueBool) ? valueBool : value.ToInt() == 1;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
