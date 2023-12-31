﻿#region copyright
//------------------------------------------------------------------------------
//  此代码版权声明为全文件覆盖，如有原作者特别声明，会在下方手动补充
//  此代码版权（除特别声明外的代码）归作者本人AlbertZhao所有
//  源代码使用协议遵循本仓库的开源协议及附加协议
//  Gitee源代码仓库：https://gitee.com/AlbertZhao/AlbertCollection



//------------------------------------------------------------------------------
#endregion

using Furion.SpecificationDocument;
using IGeekFan.AspNetCore.Knife4jUI;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.WebEncoders;
using Newtonsoft.Json;
using System.Text.Encodings.Web;
using System.Text.Json.Serialization;
using System.Text.Unicode;
using ThingsGateway.Web.Core;

namespace AlbertCollection.Web.Core
{
    /// <inheritdoc/>
    public class Startup : AppStartup
    {
        /// <inheritdoc/>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            // 启用HTTPS
            //app.UseHttpsRedirection();

            app.UseStaticFiles();
            // 任务调度看板
            app.UseScheduleUI();

            // 限流服务，自行开启
            //app.UseIpRateLimiting();


            // 配置Swagger-Knife4UI（路由前缀一致代表独立，不同则代表共存）
            app.UseKnife4UI(options =>
            {
                options.RoutePrefix = "api";
                foreach (var groupInfo in SpecificationDocumentBuilder.GetOpenApiGroups())
                {
                    options.SwaggerEndpoint("/" + groupInfo.RouteTemplate, groupInfo.Title);
                }
            });

            app.UseInject("swagger");


            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();

                endpoints.MapHubs();

                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }

        /// <inheritdoc/>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddLogoDisplay();

            // 允许跨域
            services.AddCorsAccessor();

            services.Configure<WebEncoderOptions>(options => options.TextEncoderSettings = new TextEncoderSettings(UnicodeRanges.All));

            // 限流服务，自行开启
            //services.Configure<IpRateLimitOptions>(App.Configuration.GetSection("IpRateLimiting"));
            //services.AddInMemoryRateLimiting();
            //services.AddSingleton<IRateLimitConfiguration, RateLimitConfiguration>();

            // 任务调度
            services.AddSchedule(options =>
            {
                options.AddPersistence<JobPersistence>();
            });

            //启动LoggingMonitor操作日志写入数据库组件
            services.AddComponent<LoggingMonitorComponent>();

            //认证组件
            services.AddComponent<AuthComponent>();

            //启动Web设置SignalRComponent组件
            services.AddComponent<SignalRComponent>();

            services.AddRazorPages();
            services.AddControllers()//循环引用
                .AddJsonOptions(options => options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles)
                .AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore)
             .AddFriendlyException()
             .AddInjectWithUnifyResult<UnifyResultProvider>();//规范化

            services.AddServerSideBlazor().AddHubOptions(options => options.MaximumReceiveMessageSize = 64 * 1024); ;
            services.AddHealthChecks();

        }
    }
}