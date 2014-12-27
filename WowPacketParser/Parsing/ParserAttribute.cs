using System;
using WowPacketParser.Enums;
using WowPacketParser.Enums.Version;
using WowPacketParser.Misc;

namespace WowPacketParser.Parsing
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = false)]
    public sealed class ParserAttribute : Attribute
    {
        public ParserAttribute(Opcode opcode)
        {
            Opcode = opcode;
        }

        /// <summary>
        /// [addedInVersion, +inf[
        /// </summary>
        /// <param name="opcode"></param>
        /// <param name="addedInVersion"></param>
        public ParserAttribute(Opcode opcode, ClientVersionBuild addedInVersion)
        {
            if (ClientVersion.AddedInVersion(addedInVersion))
                Opcode = opcode;
        }

        /// <summary>
        /// [addedInVersion, removedInVersion[
        /// </summary>
        /// <param name="opcode"></param>
        /// <param name="addedInVersion"></param>
        /// <param name="removedInVersion"></param>
        public ParserAttribute(Opcode opcode, ClientVersionBuild addedInVersion, ClientVersionBuild removedInVersion)
        {
            if (ClientVersion.AddedInVersion(addedInVersion) && ClientVersion.RemovedInVersion(removedInVersion))
                Opcode = opcode;
        }

        /*[Obsolete]
        public ParserAttribute(int opcode)
        {
            Opcode = Opcodes.GetOpcode(opcode);
        }*/

        /// <summary>
        /// [addedInVersion, +inf[
        /// </summary>
        /// <param name="opcode"></param>
        /// <param name="addedInVersion"></param>
        /// <param name="direction"></param>
        /*[Obsolete]
        public ParserAttribute(int opcode, ClientVersionBuild addedInVersion)
        {
            if (ClientVersion.AddedInVersion(addedInVersion))
                Opcodes.GetOpcode(opcode);
        }*/

        /// <summary>
        /// [addedInVersion, removedInVersion[
        /// </summary>
        /// <param name="opcode"></param>
        /// <param name="addedInVersion"></param>
        /// <param name="removedInVersion"></param> 
        /*[Obsolete]
        public ParserAttribute(int opcode, ClientVersionBuild addedInVersion, ClientVersionBuild removedInVersion)
        {
            if (ClientVersion.AddedInVersion(addedInVersion) && ClientVersion.RemovedInVersion(removedInVersion))
                Opcode = Opcodes.GetOpcode(opcode);
        }*/

        public Opcode Opcode { get; private set; }
    }
}
