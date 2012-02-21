#region Copyright

// <copyright file="MvxStopWatch.cs" company="Cirrious">
// (c) Copyright Cirrious. http://www.cirrious.com
// This source is subject to the Microsoft Public License (Ms-PL)
// Please see license.txt on http://opensource.org/licenses/ms-pl.html
// All other rights reserved.
// </copyright>
// 
// Author - Stuart Lodge, Cirrious. http://www.cirrious.com

#endregion

using System;

namespace Cirrious.MvvmCross.Platform.Diagnostics
{
    public class MvxStopWatch 
        : IDisposable
    {
        private readonly string _tag;
        private readonly string _message;
        private readonly int _startTickCount;

        public static MvxStopWatch CreateWithTag(string tag, string text, params object[] args)
        {
            return new MvxStopWatch(tag, text, args);            
        }

        public static MvxStopWatch Create(string text, params object[] args)
        {
            return CreateWithTag("mvxStopWatch", text, args);
        }

        private MvxStopWatch(string tag, string text, params object[] args)
        {
            _tag = tag;
            _startTickCount = Environment.TickCount;
            _message = string.Format(text, args);
        }

        #region Implementation of IDisposable

        public void Dispose()
        {
            MvxTrace.TaggedTrace(_tag, "{0} - {1}", Environment.TickCount - _startTickCount, _message);
        }

        #endregion
    }
}