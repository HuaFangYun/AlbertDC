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
    /// 访问日志分页输入
    /// </summary>
    public class VisitLogPageInput : BasePageInput
    {
        /// <summary>
        /// 账号
        /// </summary>
        [Description("账号")]
        public string Account { get; set; }

        /// <summary>
        /// 分类
        /// </summary>
        [Description("分类")]
        public string Category { get; set; }

        /// <summary>
        /// 执行状态
        ///</summary>
        [Description("执行状态")]
        public string ExeStatus { get; set; }
    }
}