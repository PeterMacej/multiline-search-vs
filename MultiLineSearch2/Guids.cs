// Guids.cs
// MUST match guids.h
using System;

namespace Company.MultiLineSearch2
{
    static class GuidList
    {
        public const string guidMultiLineSearch2PkgString = "b996608b-c716-452d-a711-7cfad5c874c5";
        public const string guidMultiLineSearch2CmdSetString = "f9d2a289-d7f7-44df-a331-f39b8e29d869";
        public const string guidToolWindowPersistanceString = "0c0f322c-3ac7-4632-8af2-e707597f9fb1";

        public static readonly Guid guidMultiLineSearch2CmdSet = new Guid(guidMultiLineSearch2CmdSetString);
    };
}