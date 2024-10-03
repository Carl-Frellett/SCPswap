// -----------------------------------------------------------------------
// <copyright file="Translation.cs" company="Build">
// Copyright (c) Build. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

using PlayerRoles;

namespace ScpSwap
{
    using System.Collections.Generic;
    using System.ComponentModel;
    using Exiled.API.Features;
    using Exiled.API.Interfaces;
    using ScpSwap.Configs;
    using ScpSwap.Models;

    /// <inheritdoc />
    public class Translation : ITranslation
    {
        /// <summary>
        /// Gets or sets a collection of custom names with their correlating <see cref="RoleTypeId"/>.
        /// </summary>
        [Description("自定义名称及其相关 RoleType 的集合")]
        public Dictionary<string, RoleTypeId> TranslatableSwaps { get; set; } = new Dictionary<string, RoleTypeId>
        {
            { "173", RoleTypeId.Scp173 },
            { "peanut", RoleTypeId.Scp173 },
            { "939", RoleTypeId.Scp939 },
            { "dog", RoleTypeId.Scp939 },
            { "079", RoleTypeId.Scp079 },
            { "79", RoleTypeId.Scp079 },
            { "computer", RoleTypeId.Scp079 },
            { "106", RoleTypeId.Scp106 },
            { "larry", RoleTypeId.Scp106 },
            { "096", RoleTypeId.Scp096 },
            { "96", RoleTypeId.Scp096 },
            { "shyguy", RoleTypeId.Scp096 },
            { "049", RoleTypeId.Scp049 },
            { "49", RoleTypeId.Scp049 },
            { "doctor", RoleTypeId.Scp049 },
            { "0492", RoleTypeId.Scp0492 },
            { "492", RoleTypeId.Scp0492 },
            { "zombie", RoleTypeId.Scp0492 },
        };

        /// <summary>
        /// Gets or sets the message to be displayed to all Scp subjects at the start of the round.
        /// </summary>
        [Description("向所有的SCP发送可以交换SCP的通知")]
        public Broadcast StartMessage { get; set; } = new Broadcast("<color=yellow><b>不想玩这个SCP?按~打开控制台</b></color> 输入 <color=orange>.scpswap (数字编号)</color> 来换成其他SCP吧！\n例: .scpswap 079", 15);

        /// <summary>
        /// Gets or sets the broadcast to display to the receiver of a swap request.
        /// </summary>
        [Description("要向交换请求的接收方显示的广播")]
        public Broadcast RequestBroadcast { get; set; } = new Broadcast("<i>你有一个SCP交换请求!\n打开控制台查看详情", 5);

        /// <summary>
        /// Gets or sets the console message to send to the receiver of a swap request.
        /// </summary>
        [Description("要发送给交换请求接收方的控制台消息")]
        public ConsoleMessage RequestConsoleMessage { get; set; } = new ConsoleMessage("$SenderName想和你交换$RoleName 输入[.scpswap accept]接受交换， 或输入[.scpswap decline]拒绝交换", "yellow");

        /// <summary>
        /// Gets or sets the console message to send to players when the swap succeeds.
        /// </summary>
        [Description("交换成功的控制台消息")]
        public ConsoleMessage SwapSuccessful { get; set; } = new ConsoleMessage("交换成功!", "green");

        /// <summary>
        /// Gets or sets the console message to send to the receiver of a swap request that has timed out.
        /// </summary>
        [Description("要发送给已超时的交换请求接收方的控制台消息")]
        public ConsoleMessage TimeoutReceiver { get; set; } = new ConsoleMessage("你的交换请求已超时", "red");

        /// <summary>
        /// Gets or sets the console message to send to the sender of a swap request that has timed out.
        /// </summary>
        [Description("要发送给已超时的交换请求发送方的控制台消息")]
        public ConsoleMessage TimeoutSender { get; set; } = new ConsoleMessage("对方没有回应您的交换请求", "red");

        /// <summary>
        /// Gets or sets the various command instances to be translated.
        /// </summary>
        [Description("要转换的各种命令实例")]
        public CommandTranslations CommandTranslations { get; set; } = new CommandTranslations();
    }
}