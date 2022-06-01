using Newtonsoft.Json.Converters;
using System.Text.Json.Serialization;

namespace EducationalSystem.Infrastructure.Enums
{
    public static class CourseTypes
    {
        //[JsonConverter(typeof(StringEnumConverter))]
        public enum CourseType
        {
            Offline,
            Online
        }
    }
}
