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
    /// 添加用户参数
    /// </summary>
    public class UserAddInput : SysUserAc
    {
        /// <summary>
        /// 账号
        /// </summary>
        [Required(ErrorMessage = "账号不能为空"), MinLength(3, ErrorMessage = "账号不能少于4个字符")]
        public override string Account { get; set; }
    }

    /// <summary>
    /// 编辑用户参数
    /// </summary>
    public class UserEditInput : SysUserAc
    {
        /// <summary>
        /// 账号
        /// </summary>
        [Required(ErrorMessage = "账号不能为空"), MinLength(3, ErrorMessage = "账号不能少于4个字符")]
        public override string Account { get; set; }

        /// <summary>
        /// Id
        /// </summary>
        [MinValue(1, ErrorMessage = "Id不能为空")]
        public override long Id { get; set; }
    }

    /// <summary>
    /// 用户分页查询参数
    /// </summary>
    public class UserPageInput : BasePageInput
    {
        /// <summary>
        /// 动态查询条件
        /// </summary>
        public Expressionable<SysUserAc> Expression { get; set; }
    }

    /// <summary>
    /// 用户授权角色参数
    /// </summary>
    public class UserGrantRoleInput
    {
        /// <summary>
        /// Id
        /// </summary>
        [Required(ErrorMessage = "Id不能为空")]
        public long? Id { get; set; }

        /// <summary>
        /// 授权权限信息
        /// </summary>
        [Required(ErrorMessage = "RoleIdList不能为空")]
        public List<long> RoleIdList { get; set; }
    }
}