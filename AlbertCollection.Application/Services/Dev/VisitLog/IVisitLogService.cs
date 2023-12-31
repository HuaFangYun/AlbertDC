﻿#region copyright
//------------------------------------------------------------------------------
//  此代码版权声明为全文件覆盖，如有原作者特别声明，会在下方手动补充
//  此代码版权（除特别声明外的代码）归作者本人AlbertZhao所有
//  源代码使用协议遵循本仓库的开源协议及附加协议
//  Gitee源代码仓库：https://gitee.com/AlbertZhao/AlbertCollection



//------------------------------------------------------------------------------
#endregion

namespace AlbertCollection.Application
{
    /// <summary>
    /// 访问日志服务
    /// </summary>

    public interface IVisitLogService : ITransient
    {
        /// <summary>
        /// 根据分类删除
        /// </summary>
        /// <param name="category">分类名称</param>
        /// <returns></returns>
        Task Delete(params string[] category);

        /// <summary>
        /// 访问日志分页查询
        /// </summary>
        /// <param name="input">查询参数</param>
        /// <returns>日志列表</returns>
        Task<SqlSugarPagedList<DevLogVisit>> Page(VisitLogPageInput input);
    }
}