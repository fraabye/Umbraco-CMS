﻿using System;
using System.Runtime.CompilerServices;

namespace Umbraco.Web.PublishedCache.NuCache
{
    static class CacheKeys
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static string DraftOrPub(bool previewing)
        {
            return previewing ? "D:" : "P:";
        }

        public static string PublishedContentChildren(Guid contentUid, bool previewing)
        {
            return "NuCache.Content.Children[" + DraftOrPub(previewing) + ":" + contentUid + "]";
        }

        public static string PublishedContentAsPreviewing(Guid contentUid)
        {
            return "NuCache.Content.AsPreviewing[" + contentUid + "]";
        }

        public static string ProfileName(int userId)
        {
            return "NuCache.Profile.Name[" + userId + "]";
        }

        public static string PropertyRecurse(Guid contentUid, string typeAlias, bool previewing)
        {
            return "NuCache.Property.Recurse[" + DraftOrPub(previewing) + contentUid + ":" + typeAlias + "]";
        }

        public static string PropertyValueSet(Guid contentUid, string typeAlias, bool previewing)
        {
            return "NuCache.Property.ValueSet[" + DraftOrPub(previewing) + contentUid + ":" + typeAlias + "]";
        }

        // routes still use int id and not Guid uid, because routable nodes must have
        // a valid ID in the database at that point, whereas content and properties
        // may be virtual (and not in umbracoNode).

        public static string ContentCacheRouteByContent(int id, bool previewing)
        {
            return "NuCache.ContentCache.RouteByContent[" + DraftOrPub(previewing) + id + "]";
        }

        public static string ContentCacheContentByRoute(string route, bool previewing)
        {
            return "NuCache.ContentCache.ContentByRoute[" + DraftOrPub(previewing) + route + "]";
        }
    }
}
