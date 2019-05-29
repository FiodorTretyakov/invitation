using System;
using Customers.Entity;

namespace Customers
{
    public static class Locator
    {
        public const int EarthRadius = 6371;

        public static double GetRadians(double x) => x * Math.PI / 180;

        public static bool IsCloseTo(Location to, Location from, int distance) => GetDistanceBetween(to, from) <= distance;

        public static double GetDistanceBetween(Location to, Location from) => Math.Acos(Math.Sin(GetRadians(to.Latitude))
            * Math.Sin(GetRadians(from.Latitude)) + Math.Cos(GetRadians(to.Latitude)) * Math.Cos(GetRadians(from.Latitude))
            * (Math.Cos(GetRadians(to.Longitude) - GetRadians(from.Longitude)))) * EarthRadius;
    }
}