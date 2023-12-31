﻿#region copyright
//------------------------------------------------------------------------------
//  此代码版权声明为全文件覆盖，如有原作者特别声明，会在下方手动补充
//  此代码版权（除特别声明外的代码）归作者本人AlbertZhao所有
//  源代码使用协议遵循本仓库的开源协议及附加协议
//  Gitee源代码仓库：https://gitee.com/AlbertZhao/AlbertCollection



//------------------------------------------------------------------------------
#endregion


using Masa.Blazor;

namespace AlbertCollection.Web.Rcl.Core
{
    /// <summary>
    /// 扩展方法,部分代码来源为开源代码收集等
    /// </summary>
    public static class PopupServiceExtensions
    {

        public static async Task<bool> OpenConfirmDialogAsync(this IPopupService PopupService, string title, string content)
        {
            return await PopupService.ConfirmAsync(title, content, AlertTypes.Error);
        }

        public static async Task<bool> OpenConfirmDialogAsync(this IPopupService PopupService, string title, string content, AlertTypes type)
        {
            return await PopupService.ConfirmAsync(title, content, type);
        }

        public static async Task OpenInformationMessageAsync(this IPopupService PopupService, string message)
        {
            await PopupService.EnqueueSnackbarAsync(message, AlertTypes.Info);
        }


    }
}