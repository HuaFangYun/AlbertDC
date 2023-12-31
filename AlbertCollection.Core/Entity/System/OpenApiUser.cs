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
    [SugarTable("openapi_user")]
    [Tenant(SqlsugarConst.DB_Default)]
    public class OpenApiUser : BaseEntity
    {
        /// <summary>
        /// 账号
        ///</summary>
        [SugarColumn(ColumnName = "Account", ColumnDescription = "账号", Length = 200, IsNullable = false)]
        public virtual string Account { get; set; }

        /// <summary>
        /// 邮箱
        ///</summary>
        [SugarColumn(ColumnName = "Email", ColumnDescription = "邮箱", Length = 200, IsNullable = true)]
        public string Email { get; set; }

        /// <summary>
        /// 上次登录设备
        ///</summary>
        [SugarColumn(ColumnName = "LastLoginDevice", ColumnDescription = "上次登录设备", IsNullable = true)]
        public string LastLoginDevice { get; set; }

        /// <summary>
        /// 上次登录ip
        ///</summary>
        [SugarColumn(ColumnName = "LastLoginIp", ColumnDescription = "上次登录ip", Length = 200, IsNullable = true)]
        public string LastLoginIp { get; set; }

        /// <summary>
        /// 上次登录时间
        ///</summary>
        [SugarColumn(ColumnName = "LastLoginTime", ColumnDescription = "上次登录时间", IsNullable = true)]
        public DateTime? LastLoginTime { get; set; }

        /// <summary>
        /// 最新登录设备
        ///</summary>
        [SugarColumn(ColumnName = "LatestLoginDevice", ColumnDescription = "最新登录设备", IsNullable = true)]
        public string LatestLoginDevice { get; set; }

        /// <summary>
        /// 最新登录ip
        ///</summary>
        [SugarColumn(ColumnName = "LatestLoginIp", ColumnDescription = "最新登录ip", Length = 200, IsNullable = true)]
        public string LatestLoginIp { get; set; }

        /// <summary>
        /// 最新登录时间
        ///</summary>
        [SugarColumn(ColumnName = "LatestLoginTime", ColumnDescription = "最新登录时间", IsNullable = true)]
        public DateTime? LatestLoginTime { get; set; }

        /// <summary>
        /// 密码
        ///</summary>
        [SugarColumn(ColumnName = "Password", ColumnDescription = "密码", Length = 200, IsNullable = false)]
        public virtual string Password { get; set; }

        /// <summary>
        /// 权限码集合
        /// </summary>
        [SugarColumn(ColumnName = "PermissionCodeList", ColumnDescription = "权限json", IsJson = true, IsNullable = true)]
        public List<string> PermissionCodeList { get; set; }

        /// <summary>
        /// 手机
        ///</summary>
        [SugarColumn(ColumnName = "Phone", ColumnDescription = "手机", Length = 200, IsNullable = true)]
        public string Phone { get; set; }

        /// <summary>
        /// 排序码
        ///</summary>
        [SugarColumn(ColumnName = "SortCode", ColumnDescription = "排序码", IsNullable = true)]
        public int SortCode { get; set; }

        /// <summary>
        /// 用户状态
        ///</summary>
        [SugarColumn(ColumnName = "UserStatus", ColumnDescription = "用户状态", IsNullable = true)]
        public bool UserStatus { get; set; }
    }
}