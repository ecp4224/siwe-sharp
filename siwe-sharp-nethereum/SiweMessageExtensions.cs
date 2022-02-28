using System;
using System.Collections.Generic;
using System.IO;
using Nethereum.ABI.FunctionEncoding.Attributes;
using Nethereum.Contracts;
using Nethereum.Signer;
using Nethereum.Web3;

namespace SiweSharp.NEthereum
{
    [Function("isValidSignature", "bool")]
    public class ContractWalletVerifySignature : FunctionMessage
    {
        [Parameter("bytes32", "_message")]
        public string Message { get; set; }

        [Parameter("bytes", "_signature")]
        public string Signature { get; set; }
    }
    
    public static class SiweMessageExtensions
    {
        public static SiweMessage Validate(this SiweMessage msg, string signature, Web3 provider = null)
        {
            var message = msg.PrepareMessage();

            List<string> missing = new List<string>();
            if (string.IsNullOrWhiteSpace(message))
            {
                missing.Add("message");
            }

            if (string.IsNullOrWhiteSpace(signature))
            {
                missing.Add("signature");
            }

            if (string.IsNullOrWhiteSpace(msg.Address))
            {
                missing.Add("address");
            }

            if (missing.Count > 0)
            {
                throw new ArgumentException(ErrorType.MalformedSession + $" missing: {string.Join(',', missing)}");
            }

            var signer = new MessageSigner();
            var address = signer.HashAndEcRecover(message, signature);

            if (address != msg.Address)
            {
                if (provider != null)
                {
                    var validSignatureHandler =
                        provider.Eth.GetContractQueryHandler<ContractWalletVerifySignature>();

                    var validSignatureParms = new ContractWalletVerifySignature()
                    {
                        Message = message,
                        Signature = signature
                    };

                    var queryTask = validSignatureHandler.QueryAsync<bool>(msg.Address, validSignatureParms);

                    queryTask.Wait();

                    var result = queryTask.Result;

                    if (!result)
                    {
                        throw new IOException(ErrorType.InvalidSignature + $": {address} != {msg.Address}");
                    }
                }
            }

            var parsedMessage = new SiweMessage(message);

            if (!parsedMessage.IsValidTime)
            {
                throw new Exception(ErrorType.ExpiredMessage);
            }

            return parsedMessage;
        }
    }
}