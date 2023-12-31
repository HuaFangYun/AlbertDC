﻿#region copyright
//------------------------------------------------------------------------------
//  此代码版权声明为全文件覆盖，如有原作者特别声明，会在下方手动补充
//  此代码版权（除特别声明外的代码）归作者本人AlbertZhao所有
//  源代码使用协议遵循本仓库的开源协议及附加协议
//  Gitee源代码仓库：https://gitee.com/AlbertZhao/AlbertCollection



//------------------------------------------------------------------------------
#endregion

using Furion.Schedule;

namespace AlbertCollection.Web.Core;

/// <summary>
/// 清理日志作业任务
/// </summary>
[JobDetail("job_log", Description = "清理访问/操作日志", GroupName = "default", Concurrent = false)]
[Daily(TriggerId = "trigger_log", Description = "清理访问/操作日志", RunOnStart = true)]
public class LogJob : IJob
{
    private readonly IServiceProvider _serviceProvider;
    /// <summary>
    /// <inheritdoc cref="LogJob"/>
    /// </summary>
    /// <param name="serviceProvider"></param>
    public LogJob(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }
    /// <inheritdoc/>
    public async Task ExecuteAsync(JobExecutingContext context, CancellationToken stoppingToken)
    {
        var db = DbContext.Db.CopyNew();
        var daysAgo = 30; // 删除30天以前
        await db.Deleteable<DevLogVisit>().Where(u => (DateTime)u.CreateTime < DateTime.UtcNow.AddDays(-daysAgo)).ExecuteCommandAsync(); // 删除访问日志
        await db.Deleteable<DevLogOperate>().Where(u => (DateTime)u.CreateTime < DateTime.UtcNow.AddDays(-daysAgo)).ExecuteCommandAsync(); // 删除操作日志
    }
}