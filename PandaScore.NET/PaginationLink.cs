using System;
using System.Collections.Generic;
using System.Text;

namespace PandaScoreNET
{
    public enum PaginationLinkType
    {
        First, Previous, Next, Last
    }

    public struct PaginationLink
    {
        public Uri Uri { get; }
        public PaginationLinkType Type { get; }

        public PaginationLink(string header)
        {
            string[] splitHeader = header.Split(';');
            string uriString = splitHeader[0].Trim('<','>', ' ');
            Uri = new Uri(uriString);
            string typeString = splitHeader[1].Remove(splitHeader[1].Length - 1);
            typeString = typeString.Substring(6);
            Enum.TryParse<PaginationLinkType>(typeString, true, out var type);
            Type = type;
        }
    }
}
