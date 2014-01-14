﻿using LumenWorks.Framework.IO.Csv;

namespace Narvalo.LumenWorks
{
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.IO;
    using System.Text;
    using Narvalo;

    /// <summary>
    /// Classe permettant de lire d'un coup toutes les lignes d'un fichier CSV.
    /// </summary>
    public class CvsSlurp
    {
        public const char DefaultDelimiter = ';';
        public static readonly Encoding DefaultEncoding = Encoding.GetEncoding(1252);

        readonly string _fileName;

        Encoding _encoding = DefaultEncoding;
        char _delimiter = DefaultDelimiter;
        bool _hasHeaders = true;
        IList<string> _headers = new string[] { };
        IList<Dictionary<string, string>> _records = new List<Dictionary<string, string>>();

        public CvsSlurp(string fileName)
        {
            Requires.NotNullOrEmpty(fileName, "fileName");

            _fileName = fileName;
        }

        /// <summary>
        /// Le caractère utilisé pour séparer les champs dans une même ligne.
        /// </summary>
        public char Delimiter
        {
            get { return _delimiter; }
            set { _delimiter = value; }
        }

        /// <summary>
        /// Type d'encodage texte utilisé.
        /// </summary>
        public Encoding Encoding
        {
            get { return _encoding; }
            set { _encoding = Check.NotNull(value); }
        }

        /// <summary>
        /// Vrai si la première ligne du CSV sert pour décrire les champs.
        /// </summary>
        public bool HasHeaders
        {
            get { return _hasHeaders; }
            set { _hasHeaders = value; }
        }

        /// <summary>
        /// Liste des en-têtes, si il y en a.
        /// </summary>
        public IEnumerable<string> Headers { get { return _headers; } }

        /// <summary>
        /// Liste des éléments trouvés.
        /// </summary>
        [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures")]
        public IEnumerable<Dictionary<string, string>> Records { get { return _records; } }

        public void Parse()
        {
            using (var streamReader = new StreamReader(_fileName, Encoding)) {
                using (var reader = new CsvReader(streamReader, HasHeaders, Delimiter)) {
                    reader.DefaultParseErrorAction = ParseErrorAction.ThrowException;

                    int fieldCount = reader.FieldCount;
                    _headers = reader.GetFieldHeaders();

                    while (reader.ReadNextRecord()) {
                        var record = new Dictionary<string, string>();

                        for (int i = 0; i < fieldCount; i++) {
                            record.Add(_headers[i], reader[i]);
                        }

                        _records.Add(record);
                    }
                }
            }
        }

        [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures")]
        public IEnumerable<Dictionary<string, string>> Read()
        {
            Parse();

            return _records;
        }
    }
}
