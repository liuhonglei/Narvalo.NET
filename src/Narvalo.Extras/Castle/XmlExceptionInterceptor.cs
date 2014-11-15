﻿// Copyright (c) 2014, Narvalo.Org. All rights reserved. See LICENSE.txt in the project root for license information.

using Castle.DynamicProxy;

namespace Narvalo.Castle
{
    using System;
    using System.Xml;

    public sealed class XmlExceptionInterceptor : IInterceptor
    {
        readonly Action<XmlException> _onException;

        public XmlExceptionInterceptor(Action<XmlException> onException)
        {
            Require.NotNull(onException, "onException");

            _onException = onException;
        }

        public void Intercept(IInvocation invocation)
        {
            Require.NotNull(invocation, "invocation");

            try {
                invocation.Proceed();
            }
            catch (XmlException ex) {
                _onException(ex);
                throw;
            }
        }
    }
}
