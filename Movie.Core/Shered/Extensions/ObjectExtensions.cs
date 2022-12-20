using System;

namespace Movie.Core.Shered.Extensions
{
    public static class ObjectExtensions
    {
        public static bool IsObjectNull(this object obj)
        {
            return obj == null;
        }

        public static void ThrowIfNull<T>(this T obj, string parameterName)
            where T : class
        {
            if (obj == null) throw new ArgumentNullException($"Parameter {parameterName} is null.");
        }

        public static T CloneObject<T>(this object source)
        {
            T result = Activator.CreateInstance<T>();
            return result;
        }
    }
}
