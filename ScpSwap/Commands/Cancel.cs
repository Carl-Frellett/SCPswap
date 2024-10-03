// -----------------------------------------------------------------------
// <copyright file="Cancel.cs" company="Build">
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
    /// Cancels an active swap request.
    /// </summary>
    public class Cancel : ICommand
    {
        /// <inheritdoc />
        public string Command { get; set; } = "取消";

        /// <inheritdoc />
        public string[] Aliases { get; set; } = { "c" };

        /// <inheritdoc />
        public string Description { get; set; } = "取消您的SCP交换请求";

        /// <inheritdoc />
        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            Player playerSender = Player.Get(sender);
            if (playerSender == null)
            {
                response = "此请求必须是为玩家";
                return false;
            }

            Swap swap = Swap.FromSender(playerSender);
            if (swap == null)
            {
                response = "你没有SCP请求用于取消";
                return false;
            }

            swap.Cancel();
            response = "交换已取消!";
            return true;
        }
    }
}