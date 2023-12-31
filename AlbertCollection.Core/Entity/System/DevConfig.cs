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
    /// 配置
    ///</summary>
    [SugarTable("dev_config", TableDescription = "配置")]
    [Tenant(SqlsugarConst.DB_CustomId)]
    public class DevConfig : BaseEntity
    {
        /// <summary>
        /// 分类
        ///</summary>
        [SugarColumn(ColumnName = "Category", ColumnDescription = "分类", Length = 200)]
        public virtual string Category { get; set; }

        /// <summary>
        /// 配置键
        ///</summary>
        [SugarColumn(ColumnName = "ConfigKey", ColumnDescription = "配置键", Length = 200)]
        public virtual string ConfigKey { get; set; }

        /// <summary>
        /// 配置值
        ///</summary>
        [SugarColumn(ColumnName = "ConfigValue", ColumnDescription = "配置值", ColumnDataType = StaticConfig.CodeFirst_BigString)]
        public virtual string ConfigValue { get; set; }

        /// <summary>
        /// 备注
        ///</summary>
        [SugarColumn(ColumnName = "Remark", ColumnDescription = "备注", Length = 200, IsNullable = true)]
        public string Remark { get; set; }

        /// <summary>
        /// 排序码
        ///</summary>
        [SugarColumn(ColumnName = "SortCode", ColumnDescription = "排序码", IsNullable = true)]
        public int SortCode { get; set; }
    }
}