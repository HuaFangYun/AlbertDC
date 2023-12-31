﻿#region copyright
//------------------------------------------------------------------------------
//  此代码版权声明为全文件覆盖，如有原作者特别声明，会在下方手动补充
//  此代码版权（除特别声明外的代码）归作者本人AlbertZhao所有
//  源代码使用协议遵循本仓库的开源协议及附加协议
//  Gitee源代码仓库：https://gitee.com/AlbertZhao/AlbertCollection



//------------------------------------------------------------------------------
#endregion

namespace AlbertCollection.Core
{
    /// <summary>
    /// AppStartup启动类
    /// </summary>
    [AppStartup(99)]
    public class Startup : AppStartup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddComponent<LoggingConsoleComponent>();//启动控制台日志格式化组件
            services.AddComponent<LoggingFileComponent>();//启动日志写入文件组件

            // 配置雪花Id算法机器码
            YitIdHelper.SetIdGenerator(new IdGeneratorOptions
            {
                WorkerId = 4// 取值范围0~63
            });

            // 缓存注册
            services.AddCache();
        }
    }
}