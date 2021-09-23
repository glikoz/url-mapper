using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using CsvHelper;
using UrlMapper.Test.App.Entity;
using Xunit.Sdk;

namespace UrlMapper.Test.App.Extensions
{
    [AttributeUsage(AttributeTargets.Method, Inherited = false)]
    internal class CsvDataAttribute : DataAttribute
    {
        private readonly string fileName;

        public CsvDataAttribute(string fileName)
        {
            this.fileName = fileName;
        }

        private static object[] ConvertParameters(IReadOnlyList<object> values, IReadOnlyList<Type> parameterTypes)
        {
            var result = new object[parameterTypes.Count];
            for (var idx = 0; idx < parameterTypes.Count; idx++)
                result[idx] = ConvertParameter(values[idx], parameterTypes[idx]);

            return result;
        }

        private static object ConvertParameter(object parameter, Type parameterType)
        {
            return parameterType == typeof(int) ? Convert.ToInt32(parameter) : parameter;
        }

        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            if (testMethod == null) throw new ArgumentNullException(nameof(testMethod));

            var path = Path.IsPathRooted(fileName)
                ? fileName
                : Path.GetRelativePath(Directory.GetCurrentDirectory(), fileName);

            if (!File.Exists(path)) throw new ArgumentException($"Could not find file at path: {path}");


            IEnumerable<MapTestData> maps;

            using (var reader = new StreamReader(path))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                csv.Context.RegisterClassMap<MapTestDataMapper>();
                maps = csv.GetRecords<MapTestData>().ToArray();
            }


            var pars = testMethod.GetParameters();
            var parameterTypes = pars.Select(par => par.ParameterType).ToArray();

            var arr = maps.Select(p => ConvertParameters(new object[] {p}, parameterTypes)).ToArray();
            return arr;
        }
    }
}