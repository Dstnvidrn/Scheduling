using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Scheduling.Helpers
{
    public static class TimeHelper
    {
        // Ensure DateTime has the correct Kind
        public static DateTime EnsureDateTimeKind(DateTime dateTime, DateTimeKind kind)
        {
            return dateTime.Kind == DateTimeKind.Unspecified
                ? DateTime.SpecifyKind(dateTime, kind)
                : dateTime;
        }

        // Convert local time to UTC
        public static DateTime ConvertToUtc(DateTime localDateTime)
        {
            if (localDateTime.Kind == DateTimeKind.Unspecified)
                localDateTime = DateTime.SpecifyKind(localDateTime, DateTimeKind.Local);

            return localDateTime.ToUniversalTime();
        }

        // Convert UTC time to local time for a given time zone
        public static DateTime ConvertFromUtc(DateTime utcDateTime, TimeZoneInfo timeZone)
        {
            if (utcDateTime.Kind == DateTimeKind.Local)
            {
                throw new ArgumentException("DateTime must not be Local when converting from UTC.");
            }

            if (utcDateTime.Kind == DateTimeKind.Unspecified)
            {
                utcDateTime = DateTime.SpecifyKind(utcDateTime, DateTimeKind.Utc);
            }

            return TimeZoneInfo.ConvertTimeFromUtc(utcDateTime, timeZone);
        }

        // Get user's time zone
        public static TimeZoneInfo GetUserTimeZone()
        {
            try
            {
                if (GlobalUserInfo.CurrentUserInfo != null && !string.IsNullOrEmpty(GlobalUserInfo.CurrentUserInfo.Timezone))
                {
                    // Map IANA to Windows if necessary
                    string timeZoneId = MapTimeZoneToWindows(GlobalUserInfo.CurrentUserInfo.Timezone)
                                        ?? GlobalUserInfo.CurrentUserInfo.Timezone;

                    return TimeZoneInfo.FindSystemTimeZoneById(timeZoneId);
                }
                else
                {
                    MessageBox.Show("User time zone is not set. Defaulting to UTC.");
                    return TimeZoneInfo.Utc; // Fallback to UTC
                }
            }
            catch (TimeZoneNotFoundException)
            {
                MessageBox.Show($"Invalid time zone: {GlobalUserInfo.CurrentUserInfo.Timezone}. Defaulting to UTC.");
                return TimeZoneInfo.Utc; // Fallback to UTC
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while retrieving the user's time zone: {ex.Message}");
                return TimeZoneInfo.Utc; // Fallback to UTC
            }
        }

        // Map IANA to Windows time zones
        private static string MapTimeZoneToWindows(string ianaTimeZone)
        {
            var timeZoneMap = new Dictionary<string, string>
            {
                { "America/Chicago", "Central Standard Time" },
                { "America/New_York", "Eastern Standard Time" },
                { "America/Los_Angeles", "Pacific Standard Time" },
                { "UTC", "UTC" }
            };

            return timeZoneMap.TryGetValue(ianaTimeZone, out var windowsTimeZone)
                ? windowsTimeZone
                : null; // Return null if not found
        }
    }
}
