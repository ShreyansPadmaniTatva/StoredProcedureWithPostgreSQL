using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace NewsDemo.Common
{
    public static class SessionExtensions
    {
        /// <summary>
        /// Gets the boolean.
        /// </summary>
        /// <param name="session">The session.</param>
        /// <param name="key">The key.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public static bool? GetBoolean(this ISession session, string key)
        {
            var data = session.Get(key);
            if (data == null)
            {
                return null;
            }
            return BitConverter.ToBoolean(data, 0);
        }

        /// <summary>
        /// Sets the boolean.
        /// </summary>
        /// <param name="session">The session.</param>
        /// <param name="key">The key.</param>
        /// <param name="value">if set to <c>true</c> [value].</param>
        public static void SetBoolean(this ISession session, string key, bool value)
        {
            session.Set(key, BitConverter.GetBytes(value));
        }

        /// <summary>
        /// Sets the object as json.
        /// </summary>
        /// <param name="session">The session.</param>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        public static void SetObjectAsJson(this ISession session, string key, object value)
        {
            session.SetString(key, JsonConvert.SerializeObject(value));
        }

        /// <summary>
        /// Gets the object from json.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="session">The session.</param>
        /// <param name="key">The key.</param>
        /// <returns>T.</returns>
        public static T? GetObjectFromJson<T>(this ISession session, string key)
        {
            var value = session.GetString(key);

            return value == null ? default : JsonConvert.DeserializeObject<T>(value);
        }
    }
}
