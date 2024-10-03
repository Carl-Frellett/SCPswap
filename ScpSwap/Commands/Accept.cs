// -----------------------------------------------------------------------
// <copyright file="Accept.cs" company="Build">
// Copyright (c) Build. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace ScpSwap.Commands
{
    using System;
    using CommandSystem;
    using Exiled.API.Features;
    using ScpSwap.Models;

    /// <summary>
    /// Accepts an active swap request.
    /// </summary>
    public class Accept : ICommand
    {
        /// <inheritdoc />
        public string Command { get; set; } = "接受";

        /// <inheritdoc />
        public string[] Aliases { get; set; } = { "yes", "y" };

        /// <inheritdoc />
        public string Description { get; set; } = "同意SCP交换请求";

        /// <inheritdoc />
        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            Player playerSender = Player.Get(sender);
            if (playerSender == null)
            {
                response = "此请求必须是为玩家";
                return false;
            }

            Swap swap = Swap.FromReceiver(playerSender);
            if (swap == null)
            {
                response = "您没有待处理的交换请求";
                return false;
            }

            swap.Run();
            response = "交换成功";
            return true;
        }
    }
}