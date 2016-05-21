using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;

namespace BehavioralInformatix.CallER.Client
{

    static class UriExtensions
    {

        /// <summary>
        /// Combines the given path with the URI.
        /// </summary>
        /// <param name="self"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        public static Uri Combine(this Uri self, string path)
        {
            Contract.Requires<ArgumentNullException>(self != null);
            Contract.Requires<ArgumentOutOfRangeException>(self.IsAbsoluteUri);
            Contract.Requires<ArgumentNullException>(path != null);

            if (!self.ToString().EndsWith("/"))
                self = new Uri(self.ToString() + "/");

            return new Uri(self, path);
        }

        /// <summary>
        /// Combines the given paths with the URI.
        /// </summary>
        /// <param name="self"></param>
        /// <param name="paths"></param>
        /// <returns></returns>
        public static Uri Combine(this Uri self, IEnumerable<string> paths)
        {
            Contract.Requires<ArgumentNullException>(self != null);
            Contract.Requires<ArgumentOutOfRangeException>(self.IsAbsoluteUri);
            Contract.Requires<ArgumentNullException>(paths != null);

            foreach (var p in paths)
                self = self.Combine(p);

            return self;
        }

        /// <summary>
        /// Combines the given paths with the URI.
        /// </summary>
        /// <param name="self"></param>
        /// <param name="paths"></param>
        /// <returns></returns>
        public static Uri Combine(this Uri self, IEnumerable<object> paths)
        {
            Contract.Requires<ArgumentNullException>(self != null);
            Contract.Requires<ArgumentOutOfRangeException>(self.IsAbsoluteUri);
            Contract.Requires<ArgumentNullException>(paths != null);

            return Combine(self, paths.Select(i => i.ToString()));
        }

        /// <summary>
        /// Combines the given paths with the URI.
        /// </summary>
        /// <param name="self"></param>
        /// <param name="paths"></param>
        /// <returns></returns>
        public static Uri Combine(this Uri self, params string[] paths)
        {
            Contract.Requires<ArgumentNullException>(self != null);
            Contract.Requires<ArgumentOutOfRangeException>(self.IsAbsoluteUri);
            Contract.Requires<ArgumentNullException>(paths != null);

            return Combine(self, paths.AsEnumerable());
        }

        /// <summary>
        /// Combines the given paths with the URI.
        /// </summary>
        /// <param name="self"></param>
        /// <param name="paths"></param>
        /// <returns></returns>
        public static Uri Combine(this Uri self, params object[] paths)
        {
            Contract.Requires<ArgumentNullException>(self != null);
            Contract.Requires<ArgumentOutOfRangeException>(self.IsAbsoluteUri);
            Contract.Requires<ArgumentNullException>(paths != null);

            return Combine(self, paths.AsEnumerable());
        }

    }

}