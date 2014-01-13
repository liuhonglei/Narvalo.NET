﻿namespace Narvalo.Mail {
    using System;
    using System.Collections.ObjectModel;
    using System.Collections.Specialized;
    using System.Net.Mail;
    using System.Text;
    using Narvalo.Diagnostics;

    public class MailObject : IDisposable {
        #region Fields

        private static readonly Encoding 
    		DefaultHeadersEncoding = Encoding.UTF8,
    		DefaultHtmlBodyEncoding = Encoding.UTF8,
    		DefaultSubjectEncoding = Encoding.UTF8,
    		DefaultTextBodyEncoding = Encoding.UTF8;

        private AttachmentCollection _attachments = new AttachmentCollection();
        private MailAddressCollection _blackCarbonCopyList = new MailAddressCollection();
        private MailAddressCollection _carbonCopyList = new MailAddressCollection();
        private bool _disposed = false;
        private NameValueCollection _headers = new NameValueCollection();
        private Encoding _headersEncoding = DefaultHeadersEncoding;
        private string _htmlBody;
        private Encoding _htmlBodyEncoding = DefaultHtmlBodyEncoding;
        private bool _isBodyHtml = false;
        private MailPriority _priority = MailPriority.Normal;
        private MailAddressCollection _recipients = new MailAddressCollection();
        private MailAddressCollection _replyToList = new MailAddressCollection();
        private MailAddress _returnPath;
        private MailAddress _sender;
        private string _subject;
        private Encoding _subjectEncoding = DefaultSubjectEncoding;
        private string _textBody;
        private Encoding _textBodyEncoding = DefaultTextBodyEncoding;

        #endregion

        #region Ctor

        public MailObject(string sender, string recipient, string subject, string textBody)
            : this(new MailAddress(sender), new MailAddress(recipient), subject, textBody) {
        }

        public MailObject(MailAddress sender, MailAddress recipient, string subject, string textBody) {
            Requires.NotNull(sender, "sender");
            Requires.NotNull(recipient, "recipient");
            Requires.NotNullOrEmpty(subject, "subject");
            Requires.NotNullOrEmpty(textBody, "textBody");

            _recipients.Add(recipient);
            _sender = sender;
            _subject = subject;
            _textBody = textBody;
        }

        #endregion

        #region Properties

        public ReadOnlyCollection<Attachment> Attachments {
            get { return new ReadOnlyCollection<Attachment>(_attachments); }
        }

        public MailAddressCollection BlackCarbonCopyList { get { return _blackCarbonCopyList; } }

        public MailAddressCollection CarbonCopyList { get { return _carbonCopyList; } }

        public NameValueCollection Headers { get { return _headers; } }

        public Encoding HeadersEncoding { get { return _headersEncoding; } }

        public string HtmlBody {
            get { return _htmlBody; }
            set {
                _isBodyHtml = !String.IsNullOrEmpty(value);
                _htmlBody = value;
            }
        }

        public Encoding HtmlBodyEncoding { get { return _htmlBodyEncoding; } set { _htmlBodyEncoding = value; } }

        public bool IsBodyHtml { get { return _isBodyHtml; } }

        public MailPriority Priority { get { return _priority; } set { _priority = value; } }

        public ReadOnlyCollection<MailAddress> Recipients {
            get { return new ReadOnlyCollection<MailAddress>(_recipients); }
        }

        public MailAddressCollection ReplyToList { get { return _replyToList; } }

        public MailAddress ReturnPath { get { return _returnPath; } set { _returnPath = value; } }

        public MailAddress Sender { get { return _sender; } }

        public string Subject { get { return _subject; } }

        public Encoding SubjectEncoding { get { return _subjectEncoding; } set { _subjectEncoding = value; } }

        public string TextBody { get { return _textBody; } }

        public Encoding TextBodyEncoding { get { return _textBodyEncoding; } set { _textBodyEncoding = value; } }

        #endregion

        #region IDisposable

        public void Dispose() {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion

        #region Public methods

        public void Attach(Attachment item) {
            Requires.NotNull(item, "item");

            _attachments.Add(item);
        }

        public void AddRecipient(MailAddress address) {
            Requires.NotNull(address, "address");

            _recipients.Add(address);
        }

        public void ClearAttachments() {
            _attachments.Clear();
        }

        public void Detach(Attachment item) {
            Requires.NotNull(item, "item");

            _attachments.Remove(item);
        }

        #endregion

        #region Protected methods

        protected virtual void Dispose(bool disposing) {
            if (!_disposed) {
                if (disposing) {
                    if (_attachments != null) {
                        _attachments.Dispose();
                    }
                }

                _attachments = null;
                _disposed = true;
            }
        }

        #endregion
    }
}
