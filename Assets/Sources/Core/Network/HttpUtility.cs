using System.Text;

namespace Assets.Sources.Core.Network
{
    public class HttpUtility
    {
        public static string BuildParameters<T>(T instance, StringBuilder sb) where T : class, new()
        {
            foreach (var property in instance.GetType().GetProperties())
            {
                var propertyName = property.Name;
                var value = property.GetValue(instance, null);
                sb.Append(propertyName + "=" + value + "&");
            }
            return sb.ToString().TrimEnd('&');
        }
    }
}
