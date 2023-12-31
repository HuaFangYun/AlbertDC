﻿#region copyright
//------------------------------------------------------------------------------
//  此代码版权声明为全文件覆盖，如有原作者特别声明，会在下方手动补充
//  此代码版权（除特别声明外的代码）归作者本人AlbertZhao所有
//  源代码使用协议遵循本仓库的开源协议及附加协议
//  Gitee源代码仓库：https://gitee.com/AlbertZhao/AlbertCollection



//------------------------------------------------------------------------------
#endregion

// Copyright (c) Argo Zhang (argo@163.com). All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.
// Website: https://www.blazor.zone or https://argozhang.github.io/

global using Microsoft.JSInterop;

namespace AlbertCollection.Web.Rcl.Core
{
    /// <summary>
    /// JSModule extensions class
    /// </summary>
    public static class JSModuleExtensions
    {
        /// <summary>
        /// IJSRuntime 扩展方法 动态加载脚本
        /// </summary>
        /// <param name="jsRuntime"></param>
        /// <param name="fileName"></param>
        /// <param name="relative">是否为相对路径 默认 true</param>
        /// <returns></returns>
        public static async Task<IJSObjectReference> LoadModuleAsync(this IJSRuntime jsRuntime, string fileName, bool relative = true)
        {
            var filePath = relative ? BlazorConst.ResourceUrl + $"js/{fileName}.js" : fileName;
            try
            {
                return await jsRuntime.InvokeAsync<IJSObjectReference>(identifier: "import", filePath);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}