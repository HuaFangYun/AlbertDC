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
    /// 编辑个人信息参数
    /// </summary>
    public class UpdateInfoInput : SysUserAc
    {
        /// <summary>
        /// Id
        /// </summary>
        [MinValue(1, ErrorMessage = "Id不能为空")]
        public override long Id { get; set; }
    }
    /// <summary>
    /// 修改密码
    /// </summary>
    public class PasswordInfoInput : BaseIdInput, IValidatableObject
    {
        /// <summary>
        /// 旧密码
        /// </summary>
        [Description("旧密码")]
        [Required(ErrorMessage = "不能为空")]
        public string OldPassword { get; set; }
        /// <summary>
        /// 新密码
        /// </summary>
        [Description("新密码")]
        [Required(ErrorMessage = "不能为空")]
        public string NewPassword { get; set; }
        /// <summary>
        /// 确认密码
        /// </summary>
        [Description("确认密码")]
        [Required(ErrorMessage = "不能为空")]
        public string ConfirmPassword { get; set; }

        /// <inheritdoc/>
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (NewPassword != ConfirmPassword)
                yield return new ValidationResult("两次密码不一致", new[] { nameof(ConfirmPassword) });
        }
    }
}
