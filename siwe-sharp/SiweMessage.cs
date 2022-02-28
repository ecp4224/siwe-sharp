using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using SiweSharp.Grammar.SIWE;

namespace SiweSharp
{
    public class SiweMessage
    {
        private string _issuedAt;
        private string _expirationTime;
        private string _notBefore;
        
        [NotNull]
        public string Domain { get; private set; }
        
        [NotNull]
        public string Address { get; private set; }
        
        [MaybeNull]
        public string Statement { get; private set; }
        
        [NotNull]
        public string URI { get; private set; }
        
        [NotNull]
        public string Version { get; private set; }
        
        public int ChainID { get; private set; }
        
        [NotNull]
        public string Nonce { get; private set; }

        [NotNull]
        public DateTime IssuedAt
        {
            get
            {
                return DateTime.Parse(_issuedAt);
            }
        }

        [MaybeNull]
        public DateTime? ExpirationTime 
        {
            get
            {
                if (_expirationTime == null)
                    return null;

                return DateTime.Parse(_expirationTime);
            } 
        }

        [MaybeNull]
        public DateTime? NotBefore
        {
            get
            {
                if (_notBefore == null)
                    return null;

                return DateTime.Parse(_notBefore);
            }
        }

        [MaybeNull]
        public string RequestId { get; private set; }
        
        [NotNull]
        public List<string> Resources { get; private set; }

        public bool IsExpired
        {
            get
            {
                if (ExpirationTime != null)
                {
                    return DateTime.Now >= ExpirationTime;
                }

                return false;
            }
        }

        public bool IsValidTime => (NotBefore == null || !(DateTime.Now < NotBefore)) && !IsExpired;

        public SiweMessage([NotNull] string abnfMessage)
        {
            //Get rid of any carriage returns
            abnfMessage = abnfMessage.Replace("\r\n", "\n");
            
            Rule signInWithEthereum = Parser.Parse("sign-in-with-ethereum", abnfMessage);

            SIWEBuilder builder = new SIWEBuilder();
            var options = (SiweMessage)signInWithEthereum.Accept(builder);
            
            Domain = options.Domain;
            Address = options.Address;
            Statement = options.Statement;
            URI = options.URI;
            Version = options.Version;
            ChainID = options.ChainID;
            Nonce = options.Nonce;
            _issuedAt = options._issuedAt;
            _expirationTime = options._expirationTime;
            _notBefore = options._notBefore;
            RequestId = options.RequestId;
            Resources = options.Resources;

            if (Resources == null)
            {
                Resources = new List<string>();
            }

            if (_issuedAt == null)
            {
                _issuedAt = DateTime.UtcNow.ToString("O");
            }
            
            if (Nonce == null)
            {
                Nonce = RandomNonce();
            }
        }

        public SiweMessage(
            [NotNull]
            string domain, 
            [NotNull]
            string address, 
            [MaybeNull]
            string statement, 
            [NotNull]
            string uri, 
            [NotNull]
            string version, 
            int chainId, 
            [MaybeNull]
            string nonce = null, 
            [MaybeNull]
            string issuedAt = null, 
            [MaybeNull]
            string expirationTime = null, 
            [MaybeNull]
            string notBefore = null, 
            [MaybeNull]
            string requestId = null,
            [MaybeNull]
            List<string> resources = null)
        {
            Domain = domain;
            Address = address;
            Statement = statement;
            URI = uri;
            Version = version;
            ChainID = chainId;
            Nonce = nonce;
            _issuedAt = issuedAt;
            _expirationTime = expirationTime;
            _notBefore = notBefore;
            RequestId = requestId;
            Resources = resources;

            if (Resources == null)
            {
                Resources = new List<string>();
            }
            
            if (Nonce == null)
            {
                Nonce = RandomNonce();
            }

            if (_issuedAt == null)
            {
                _issuedAt = DateTime.UtcNow.ToString("O");
            }
        }

        public string ToMessage()
        {
            var header = $"{Domain} wants you to sign in with your Ethereum account:";
            var uriField = $"URI: {URI}";
            var prefix = string.Join('\n', header, Address);
            var versionField = $"Version: {Version}";
            var chainField = $"Chain ID: {ChainID}";
            var nonceField = $"Nonce: {Nonce}";

            var suffixArray = new List<string>(new string[]
            {
                uriField, versionField, chainField, nonceField
            });
            
            suffixArray.Add($"Issued At: ${_issuedAt}");

            if (_expirationTime != null)
            {
                suffixArray.Add($"Expiration Time: {_expirationTime}");
            }

            if (_notBefore != null)
            {
                suffixArray.Add($"Not Before: {_notBefore}");
            }

            if (RequestId != null)
            {
                suffixArray.Add($"Request ID: ${RequestId}");
            }

            if (Resources.Count > 0)
            {
                suffixArray.Add(string.Join('\n', new[] {"Resources:"}.Concat(Resources.Select(x => $"- {x}"))));
            }

            var suffix = string.Join('\n', suffixArray);

            prefix = string.Join("\n\n", prefix, Statement);
            if (!string.IsNullOrWhiteSpace(Statement))
            {
                prefix += "\n";
            }

            return string.Join('\n', prefix, suffix);
        }

        public string PrepareMessage()
        {
            string message;
            switch (Version)
            {
                case "1":
                default:
                    message = ToMessage();
                    break;
            }

            return message;
        }

        public override string ToString()
        {
            return ToMessage();
        }

        private static string RandomNonce()
        {
            return RandomString(96);
        }
        
        private static string RandomString(int length)
        {
            const string valid = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            StringBuilder res = new StringBuilder();
            using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
            {
                byte[] uintBuffer = new byte[sizeof(uint)];

                while (length-- > 0)
                {
                    rng.GetBytes(uintBuffer);
                    uint num = BitConverter.ToUInt32(uintBuffer, 0);
                    res.Append(valid[(int)(num % (uint)valid.Length)]);
                }
            }

            return res.ToString();
        }
    }
}