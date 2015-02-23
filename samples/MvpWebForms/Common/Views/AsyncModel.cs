﻿// Copyright (c) Narvalo.Org. All rights reserved. See LICENSE.txt in the project root for license information.

namespace MvpWebForms.Views
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Threading;

    public sealed class AsyncModel
    {
        private readonly List<string> _messages = new List<string>();

        public IEnumerable<string> Messages { get { return _messages; } }

        public void RecordViewLoad()
        {
            Append_("View Load");
        }

        public void RecordAsyncStarted()
        {
            Append_("Async Started");
        }

        public void RecordAsyncEnded()
        {
            Append_("Async Ended");
        }

        public void RecordPagePreRenderComplete()
        {
            Append_("Page PreRenderComplete");
        }

        private static string Format_(string message)
        {
            return String.Format(
                CultureInfo.InvariantCulture,
                "{2} [Thread={1}] {0}",
                message,
                Thread.CurrentThread.ManagedThreadId,
                DateTime.Now.ToString(@"[HH:mm:ss fff\m\s]", CultureInfo.InvariantCulture));
        }

        private void Append_(string message)
        {
            _messages.Add(Format_(message));
        }
    }
}
