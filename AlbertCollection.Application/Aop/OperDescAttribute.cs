﻿#region copyright
//------------------------------------------------------------------------------
//  此代码版权声明为全文件覆盖，如有原作者特别声明，会在下方手动补充
//  此代码版权（除特别声明外的代码）归作者本人AlbertZhao所有
//  源代码使用协议遵循本仓库的开源协议及附加协议
//  Gitee源代码仓库：https://gitee.com/AlbertZhao
//------------------------------------------------------------------------------
#endregion


namespace System.ComponentModel
{
    /// <summary>
    /// 操作事件说明
    /// </summary>
    [AttributeUsage(AttributeTargets.Method)]
    public class OperDescAttribute : Attribute
    {
        /// <summary>
        /// 操作记录标识
        /// </summary>
        /// <param name="description"></param>
        /// <param name="catcategory"></param>
        public OperDescAttribute(string description, string catcategory = CateGoryConst.Log_OPERATE)
        {
            Description = description;
            Catcategory = catcategory;
        }
        /// <summary>
        /// 分类
        /// </summary>
        public string Catcategory { get; }
        /// <summary>
        /// 说明
        /// </summary>
        public string Description { get; }
        /// <summary>
        /// 记录参数
        /// </summary>
        public bool IsRecordPar { get; set; } = true;
    }
}