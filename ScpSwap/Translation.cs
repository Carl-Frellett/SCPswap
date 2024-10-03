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
        [Description("�Զ������Ƽ������ RoleType �ļ���")]
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
        [Description("�����е�SCP���Ϳ��Խ���SCP��֪ͨ")]
        public Broadcast StartMessage { get; set; } = new Broadcast("<color=yellow><b>���������SCP?��~�򿪿���̨</b></color> ���� <color=orange>.scpswap (���ֱ��)</color> ����������SCP�ɣ�\n��: .scpswap 079", 15);

        /// <summary>
        /// Gets or sets the broadcast to display to the receiver of a swap request.
        /// </summary>
        [Description("Ҫ�򽻻�����Ľ��շ���ʾ�Ĺ㲥")]
        public Broadcast RequestBroadcast { get; set; } = new Broadcast("<i>����һ��SCP��������!\n�򿪿���̨�鿴����", 5);

        /// <summary>
        /// Gets or sets the console message to send to the receiver of a swap request.
        /// </summary>
        [Description("Ҫ���͸�����������շ��Ŀ���̨��Ϣ")]
        public ConsoleMessage RequestConsoleMessage { get; set; } = new ConsoleMessage("$SenderName����㽻��$RoleName ����[.scpswap accept]���ܽ����� ������[.scpswap decline]�ܾ�����", "yellow");

        /// <summary>
        /// Gets or sets the console message to send to players when the swap succeeds.
        /// </summary>
        [Description("�����ɹ��Ŀ���̨��Ϣ")]
        public ConsoleMessage SwapSuccessful { get; set; } = new ConsoleMessage("�����ɹ�!", "green");

        /// <summary>
        /// Gets or sets the console message to send to the receiver of a swap request that has timed out.
        /// </summary>
        [Description("Ҫ���͸��ѳ�ʱ�Ľ���������շ��Ŀ���̨��Ϣ")]
        public ConsoleMessage TimeoutReceiver { get; set; } = new ConsoleMessage("��Ľ��������ѳ�ʱ", "red");

        /// <summary>
        /// Gets or sets the console message to send to the sender of a swap request that has timed out.
        /// </summary>
        [Description("Ҫ���͸��ѳ�ʱ�Ľ��������ͷ��Ŀ���̨��Ϣ")]
        public ConsoleMessage TimeoutSender { get; set; } = new ConsoleMessage("�Է�û�л�Ӧ���Ľ�������", "red");

        /// <summary>
        /// Gets or sets the various command instances to be translated.
        /// </summary>
        [Description("Ҫת���ĸ�������ʵ��")]
        public CommandTranslations CommandTranslations { get; set; } = new CommandTranslations();
    }
}