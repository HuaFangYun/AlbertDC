﻿#region copyright
//------------------------------------------------------------------------------
//  此代码版权声明为全文件覆盖，如有原作者特别声明，会在下方手动补充
//  此代码版权（除特别声明外的代码）归作者本人AlbertZhao所有
//  源代码使用协议遵循本仓库的开源协议及附加协议
//  Gitee源代码仓库：https://gitee.com/AlbertZhao/AlbertCollection



//------------------------------------------------------------------------------
#endregion

using Masa.Blazor;
using Masa.Blazor.Presets;

namespace AlbertCollection.Web.Rcl.Core
{
    public class Startup : AppStartup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMasaBlazor(options =>
            {
                options.Defaults = new Dictionary<string, IDictionary<string, object>>()
                {
                    {
                        PopupComponents.SNACKBAR, new Dictionary<string, object>()
                        {
                            { nameof(PEnqueuedSnackbars.Closeable), true },
                            { nameof(PEnqueuedSnackbars.Position), SnackPosition.TopCenter }
                        }
                    }
                };
                options.ConfigureTheme(theme =>
                {
                    theme.Themes.Dark.Accent = "#FF4081";
                    theme.Themes.Dark.Error = "#FF5252";
                    theme.Themes.Dark.Info = "#2196F3";
                    theme.Themes.Dark.Primary = "#2196F3";
                    theme.Themes.Dark.Secondary = "#424242";
                    theme.Themes.Dark.Success = "#4CAF50";
                    theme.Themes.Dark.Warning = "#FB8C00";
                    theme.Themes.Dark.UserDefined.Add("barColor", "#1e1e1e");

                    theme.Themes.Light.Accent = "#82B1FF";
                    theme.Themes.Light.Error = "#FF5252";
                    theme.Themes.Light.Info = "#2196F3";
                    theme.Themes.Light.Primary = "#1976D2";
                    theme.Themes.Light.Secondary = "#424242";
                    theme.Themes.Light.Success = "#4CAF50";
                    theme.Themes.Light.Warning = "#FB8C00";
                    theme.Themes.Light.UserDefined.Add("barColor", "#fff");


                });
            })

                .AddI18nForServer("wwwroot/i18n");

            services.AddScoped<JsInitVariables>();
            services.AddScoped<AjaxService>();
            services.AddSingleton<BlazorCacheService>();
            services.AddScoped<UserResoures>();

        }
    }
}