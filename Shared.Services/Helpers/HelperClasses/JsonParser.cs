using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Linq;
using Microsoft.AspNetCore.Hosting;
using Shared.Services.ViewModels.ServicesViewModel;

namespace Shared.Services.Helpers.HelperClasses
{
    public class JsonParser
    {
        private readonly IHostingEnvironment _env;

        private string _locale;

        public JsonParser(IHostingEnvironment env, UserService userService)
        {
            _env = env;
             _locale = userService != null ? userService.Locale ?? "ar" : "ar";
        }

        public List<T> ParseFileFromPath<T>(string fileName) where T : class
        {
            var filePath = Path.Combine(_env.WebRootPath, "Initializers", fileName);

            if (!File.Exists(filePath))
                return new List<T>();

            var contents = File.ReadAllText(filePath);

            if (string.IsNullOrEmpty(contents))
                return new List<T>();

            var result = JsonConvert.DeserializeObject<List<T>>(contents);

            return result;
        }

        public static List<JsonObject> GetJsonValues(string json)
        {
            var response = JsonConvert.DeserializeObject<List<JsonObject>>(json);
            return response;
        }

        public string ConvertJsonToTextByLocale(string json, string locale = null)
        {
            if (locale != null)
                _locale = locale;
            if (string.IsNullOrEmpty(json)) return json;
            if (!IsValidJson(json)) return json;
            var response = JsonConvert.DeserializeObject<List<JsonObject>>(json);
            if (!response.Any()) return json;
            json = response.ToList().FirstOrDefault(x => x.Locale == _locale)?.Text;
            if (string.IsNullOrEmpty(json))
                json = response.ToList().FirstOrDefault()?.Text;
            return json;
        }

        public string ConvertTextToJsonByLocale(string text, string newValue)
        {
            var obj = new JsonObject
            {
                Locale = _locale,
                Text = newValue
            };

            var response = new List<JsonObject>();

            if (!string.IsNullOrEmpty(text))
            {
                if (IsValidJson(text))
                {
                    response = JsonConvert.DeserializeObject<List<JsonObject>>(text);

                    if (response.Any())
                    {
                        var oldObj = response.ToList().FirstOrDefault(x => x.Locale == _locale);
                        if (oldObj != null)
                            response.Remove(oldObj);
                    }
                }
                else
                {
                    obj.Locale = Regex.IsMatch(text, "^[a-zA-Z0-9 ]*$") ? "en" : "ar";
                    obj.Text = text;
                    response.Add(obj);
                }
            }
            if (newValue != text)
            {
                obj = new JsonObject
                {
                    Locale = _locale,
                    Text = newValue
                };
                response.Add(obj);
            }
            text = response.Count > 0 ? JsonConvert.SerializeObject(response) : "";
            return text;
        }

        public static bool IsValidJson(string strInput)
        {
            strInput = strInput.Trim();
            if ((!strInput.StartsWith("{") || !strInput.EndsWith("}")) &&
                (!strInput.StartsWith("[") || !strInput.EndsWith("]"))) return false;
            try
            {
                JToken.Parse(strInput);
                return true;
            }
            catch (JsonReaderException)
            {
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
