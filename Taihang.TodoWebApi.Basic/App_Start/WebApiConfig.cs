using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Taihang.TodoWebApi.Basic
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API 配置和服务

            // Web API 路由
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
           
            // 设置返回的日期格式
            SetDataFormatInJsonSerializers();
        }

        private static void SetDataFormatInJsonSerializers()
        {
            var settings = GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings;
            settings.DateTimeZoneHandling = Newtonsoft.Json.DateTimeZoneHandling.Local;
            settings.DateFormatString = "yyyy-MM-dd HH:mm:ss";
        }
    }
}
