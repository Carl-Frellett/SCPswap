// -----------------------------------------------------------------------
// <copyright file="ScpSwapParent.cs" company="Build">
// Copyright (c) Build. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

using Exiled.API.Enums;
using PlayerRoles;

namespace ScpSwap.Commands
{
    using System;
    using System.Linq;
    using CommandSystem;
    using Exiled.API.Features;
    using ScpSwap.Configs;
    using ScpSwap.Models;

    /// <summary>
    /// The base command for ScpSwapParent.
    /// </summary>
    [CommandHandler(typeof(ClientCommandHandler))]
    public class ScpSwapParent : ParentCommand
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ScpSwapParent"/> class.
        /// </summary>
        public ScpSwapParent() => LoadGeneratedCommands();

        /// <inheritdoc />
        public override string Command => "scpswap";

        /// <inheritdoc />
        public override string[] Aliases { get; } = { "swap" ,"交换"};

        /// <inheritdoc />
        public override string Description => "Base command for ScpSwap.";

        /// <inheritdoc />
        public sealed override void LoadGeneratedCommands()
        {
            CommandTranslations commandTranslations = Plugin.Instance.Translation.CommandTranslations;

            RegisterCommand(commandTranslations.Accept);
            RegisterCommand(commandTranslations.Cancel);
            RegisterCommand(commandTranslations.Decline);
            RegisterCommand(commandTranslations.List);
        }

        /// <inheritdoc />
        protected override bool ExecuteParent(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            Player playerSender = Player.Get(sender);
            if (playerSender == null)
            {
                response = "此请求必须是为玩家";
                return false;
            }

            if (!Round.IsStarted)
            {
                response = "回合未开始";
                return false;
            }

            if (Round.ElapsedTime.TotalSeconds > Plugin.Instance.Config.SwapTimeout)
            {
                response = "可交换时间已过";
                return false;
            }

            if (arguments.IsEmpty())
            {
                response = $"SCP交换用法: .{Command} SCP编号\n您可以输入[.scplist]来查看可交换的SCP";
                return false;
            }

            if (!playerSender.IsScp && ValidSwaps.GetCustom(playerSender) == null)
            {
                response = "你必须是SCP才可以使用该指令";
                return false;
            }

            if (Swap.FromSender(playerSender) != null)
            {
                response = "你已经申请过了！";
                return false;
            }

            Player receiver = GetReceiver(arguments.At(0), out Action<Player> spawnMethod);
            if (playerSender == receiver)
            {
                response = "你不能和自己交换";
                return false;
            }

            if (receiver != null)
            {
                Swap.Send(playerSender, receiver);
                response = "交换请求已发送!";
                return true;
            }

            if (spawnMethod == null)
            {
                response = "找不到你所需要的角色，请输入[.scplist] 来查询可交换的SCP";
                return false;
            }

            if (Plugin.Instance.Config.AllowNewScps)
            {
                spawnMethod(playerSender);
                response = "交换成功";
                return true;
            }

            response = "找不到你所交换的SCP\n输入[.scplist]可查询可交换那些SCP";
            return false;
        }

        private static Player GetReceiver(string request, out Action<Player> spawnMethod)
        {
            CustomSwap customSwap = ValidSwaps.GetCustom(request);
            if (customSwap != null)
            {
                spawnMethod = customSwap.SpawnMethod;
                return Player.List.FirstOrDefault(player => customSwap.VerificationMethod(player));
            }

            RoleTypeId roleSwap = ValidSwaps.Get(request);
            if (roleSwap != RoleTypeId.None)
            {
                spawnMethod = player => player.Role.Set(roleSwap, SpawnReason.None);
                return Player.List.FirstOrDefault(player => player.Role == roleSwap);
            }

            spawnMethod = null;
            return null;
        }
    }
}