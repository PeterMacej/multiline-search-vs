// Guids.cs
// MUST match guids.h
using System;

namespace Helixoft.MultiLineSearch
{
    static class GuidList
    {
        public const string GUID_MULTI_LINE_SEARCH_PKG_STRING = "29956436-0205-4c9e-9396-abce099383f9";
        public const string GUID_MULTI_LINE_SEARCH_CMD_SET_STRING = "7d58fc84-2160-4645-be98-eb7f27c358f7";
        public const string GUID_TOOL_WINDOW_PERSISTANCE_STRING = "5c82a791-7c9f-441e-952b-8848655dd85e";

        public static readonly Guid GuidMultiLineSearchCmdSet = new Guid(GUID_MULTI_LINE_SEARCH_CMD_SET_STRING);
    };
}