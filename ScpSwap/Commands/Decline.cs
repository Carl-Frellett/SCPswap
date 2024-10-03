// -----------------------------------------------------------------------
// <copyright file="Decline.cs" company="Build">
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
    /// Rejects an active swap request.
    /// </summary>
    public class Decline : ICommand
    {
        /// <inheritdoc />
        public string Command { get; set; } = "�ܾ�";

        /// <inheritdoc />
        public string[] Aliases { get; set; } = { "no", "d" };

        /// <inheritdoc />
        public string Description { get; set; } = "�ܾ�����SCP����";

        /// <inheritdoc />
        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            Player playerSender = Player.Get(sender);
            if (playerSender == null)
            {
                response = "�����������Ϊ���";
                return false;
            }

            Swap swap = Swap.FromReceiver(playerSender);
            if (swap == null)
            {
                response = "��û��SCP�������ھܾ�";
                return false;
            }

            swap.Decline();
            response = "�����Ѿܾ�!";
            return true;
        }
    }
}