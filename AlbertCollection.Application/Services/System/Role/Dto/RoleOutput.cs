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
    /// 角色拥有的资源输出
    /// </summary>
    public class RoleOwnResourceOutput
    {
        /// <summary>
        /// 已授权资源信息
        /// </summary>
        public virtual List<RelationRoleResuorce> GrantInfoList { get; set; }

        /// <summary>
        /// Id
        /// </summary>
        public virtual long Id { get; set; }
    }
}