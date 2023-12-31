﻿#region copyright
//------------------------------------------------------------------------------
//  此代码版权声明为全文件覆盖，如有原作者特别声明，会在下方手动补充
//  此代码版权（除特别声明外的代码）归作者本人AlbertZhao所有
//  源代码使用协议遵循本仓库的开源协议及附加协议
//  Gitee源代码仓库：https://gitee.com/AlbertZhao/AlbertCollection



//------------------------------------------------------------------------------
#endregion

using System.Diagnostics;
using System.Runtime.InteropServices;

internal class User
{
    [DllImport("user32")] internal static extern int ShowWindow(IntPtr hwnd, int nCmdShow);
    [DllImport("user32")] internal static extern int SetForegroundWindow(IntPtr hwnd);
    [DllImport("user32")] internal static extern int FindWindow(string lpClassName, string lpWindowName);
    [DllImport("user32")] internal static extern int GetWindowThreadProcessId(IntPtr hwnd, ref int lpdwProcessId);
}
/// <summary>
/// Win窗口设置
/// </summary>
public class WindowsControl
{
    /// <summary>
    /// 获取当前相同进程名称的列表
    /// </summary>
    /// <returns></returns>
    /// <param name="title">exe标题</param>
    public static List<Process> GetRunningInstance(string title)
    {
        Process currentProcess = Process.GetCurrentProcess();
        Process[] processes = Process.GetProcessesByName(currentProcess.ProcessName);
        if (currentProcess.MainModule == null) return null;

        //遍历与当前进程名称相同的进程列表
        return processes.Where(process => process.Id != currentProcess.Id && process.MainWindowTitle == title).ToList();
    }
    /// <summary>
    /// 窗口显示处理
    /// </summary>
    /// <param name="MainWindowHandle">窗口句柄</param>
    /// <param name="showStyle">显示风格</param>
    private static int HandleRunningInstance(IntPtr MainWindowHandle, int showStyle)
    {
        User.ShowWindow(MainWindowHandle, showStyle); //调用api函数，正常显示窗口
        return User.SetForegroundWindow(MainWindowHandle); //将窗口放置最前端。
    }
    /// <summary>
    /// 按窗体名称找到本程序
    /// </summary>
    /// <param name="title">exe标题</param>
    private static IntPtr FindWindow(string title)
    {
        IntPtr hWnd = (IntPtr)User.FindWindow(null, title);
        return (IntPtr)hWnd;
    }

    /// <summary>
    /// 窗口显示处理
    /// </summary>
    /// <param name="title">exe标题</param>
    /// <param name="showStyle">显示风格</param>
    public static void HandleRunningInstance(string title, int showStyle = 10)
    {
        var t = FindWindow(title);
        HandleRunningInstance((IntPtr)t, showStyle);
    }

}