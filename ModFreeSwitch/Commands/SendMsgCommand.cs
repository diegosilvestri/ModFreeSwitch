using System;

namespace ModFreeSwitch.Commands {
    /// <summary>
    ///     SendMSG command. Help execute an application for a specific FreeSwitch channel
    /// </summary>
    public sealed class SendMsgCommand : BaseCommand {
        public const string CALL_COMMAND = "execute";
        private readonly string _callCommand;
        private readonly bool _eventLock;
        private readonly int _loop;
        private readonly Guid _uuid;

        public SendMsgCommand(Guid uuid,
            string callCommand,
            string applicationName,
            string applicationArgs,
            bool eventLock,
            int loop) {
            _uuid = uuid;
            _callCommand = callCommand;
            ApplicationName = applicationName;
            ApplicationArgs = applicationArgs;
            _eventLock = eventLock;
            _loop = loop;
        }

        public SendMsgCommand(string callCommand,
            string applicationName,
            string applicationArgs,
            bool eventLock,
            int loop) {
            ApplicationName = applicationName;
            ApplicationArgs = applicationArgs;
            _loop = loop;
            _eventLock = eventLock;
            _callCommand = callCommand;
            _uuid = Guid.Empty;
        }

        public SendMsgCommand(Guid uniqueId,
            string callCommand,
            string applicationName,
            string applicationArgs,
            bool eventLock) {
            _uuid = uniqueId;
            ApplicationName = applicationName;
            ApplicationArgs = applicationArgs;
            _eventLock = eventLock;
            _callCommand = callCommand;
            _loop = 1;
        }

        public SendMsgCommand(string callCommand,
            string applicationName,
            string applicationArgs,
            bool eventLock) {
            ApplicationName = applicationName;
            ApplicationArgs = applicationArgs;
            _eventLock = eventLock;
            _callCommand = callCommand;
            _loop = 1;
            _uuid = Guid.Empty;
        }


        public SendMsgCommand(string applicationName,
            string applicationArgs,
            bool eventLock) {
            ApplicationName = applicationName;
            ApplicationArgs = applicationArgs;
            _eventLock = eventLock;
            _callCommand = CALL_COMMAND;
            _loop = 1;
            _uuid = Guid.Empty;
        }

        public override string Command {
            get {
                var cmd =
                    $"sendmsg  {_uuid}\ncall-command: {_callCommand}\nexecute-app-name: {ApplicationName}\nexecute-app-arg: {ApplicationArgs}\nloops: {_loop}";
                if (_eventLock) cmd += $"\nevent-lock: {"true"}";
                else cmd += $"\nevent-lock: {"false"}";
                return cmd;
            }
        }

        public override string Argument => string.Empty;

        public string ApplicationName { get; }

        public string ApplicationArgs { get; }
    }
}