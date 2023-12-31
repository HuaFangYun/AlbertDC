﻿#region copyright
//------------------------------------------------------------------------------
//  此代码版权声明为全文件覆盖，如有原作者特别声明，会在下方手动补充
//  此代码版权（除特别声明外的代码）归作者本人AlbertZhao所有
//  源代码使用协议遵循本仓库的开源协议及附加协议
//  Gitee源代码仓库：https://gitee.com/AlbertZhao/AlbertCollection



//------------------------------------------------------------------------------
#endregion

using Microsoft.AspNetCore.SignalR.Client;

using System.Net.Http;

using AlbertCollection.Web.Rcl.Core;

namespace AlbertCollection.Web.Rcl
{
    public partial class SignalR
    {
        public HubConnection _hubConnection;

        [Inject]
        public AjaxService AjaxService { get; set; }

        protected override async Task DisposeAsync(bool disposing)
        {
            if (disposing)
            {
                await _hubConnection.DisposeAsync();
            }
            await base.DisposeAsync(disposing);
        }

        protected override async Task OnInitializedAsync()
        {
            try
            {
                //SignalR
                _hubConnection = new HubConnectionBuilder().WithUrl(NavigationManager.ToAbsoluteUri(HubConst.HubUrl), (opts) =>
            {
                opts.HttpMessageHandlerFactory = (message) =>
                {
                    if (message is HttpClientHandler clientHandler)
                    {
                        // 绕过SSL证书
                        clientHandler.ServerCertificateCustomValidationCallback += (sender, certificate, chain, sslPolicyErrors) =>
                        {
                            return true;
                        };
                    };
                    return message;
                };
                opts.Headers = new Dictionary<string, string>();
                foreach (var item in App.User?.Claims)
                {
                    if (item.Type == ClaimConst.UserId || item.Type == ClaimConst.VerificatId)
                        opts.Headers.Add(item.Type, item.Value);
                }
            }
            ).Build();
                _hubConnection.On<object>("LoginOut", async (message) =>
                {
                    try
                    {

                        await InvokeAsync(async () => await PopupService.EnqueueSnackbarAsync(new(message.ToString(), AlertTypes.Warning)));

                    }
                    catch (Exception ex)
                    {
                    }
                    await Task.Delay(2000);
                    await AjaxService.GotoAsync("/");
                });

                await _hubConnection.StartAsync();
            }
            catch
            {

            }
            await base.OnInitializedAsync();
        }
    }
}