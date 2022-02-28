using System;
using System.Collections.Generic;
using System.Linq;

namespace SiweSharp.Grammar.SIWE
{
    public class SIWEBuilder : Visitor
    {
        public object Visit(Rule_ALPHA rule)
        {
            throw new System.NotImplementedException();
        }

        public object Visit(Rule_LF rule)
        {
            throw new System.NotImplementedException();
        }

        public object Visit(Rule_DIGIT rule)
        {
            throw new System.NotImplementedException();
        }

        public object Visit(Rule_HEXDIG rule)
        {
            throw new System.NotImplementedException();
        }

        public object Visit(Rule_date_fullyear rule)
        {
            throw new System.NotImplementedException();
        }

        public object Visit(Rule_date_month rule)
        {
            throw new System.NotImplementedException();
        }

        public object Visit(Rule_date_mday rule)
        {
            throw new System.NotImplementedException();
        }

        public object Visit(Rule_time_hour rule)
        {
            throw new System.NotImplementedException();
        }

        public object Visit(Rule_time_minute rule)
        {
            throw new System.NotImplementedException();
        }

        public object Visit(Rule_time_second rule)
        {
            throw new System.NotImplementedException();
        }

        public object Visit(Rule_time_secfrac rule)
        {
            throw new System.NotImplementedException();
        }

        public object Visit(Rule_time_numoffset rule)
        {
            throw new System.NotImplementedException();
        }

        public object Visit(Rule_time_offset rule)
        {
            throw new System.NotImplementedException();
        }

        public object Visit(Rule_partial_time rule)
        {
            throw new System.NotImplementedException();
        }

        public object Visit(Rule_full_date rule)
        {
            throw new System.NotImplementedException();
        }

        public object Visit(Rule_full_time rule)
        {
            throw new System.NotImplementedException();
        }

        public object Visit(Rule_date_time rule)
        {
            throw new System.NotImplementedException();
        }

        public object Visit(Rule_URI rule)
        {
            throw new System.NotImplementedException();
        }

        public object Visit(Rule_hier_part rule)
        {
            throw new System.NotImplementedException();
        }

        public object Visit(Rule_scheme rule)
        {
            throw new System.NotImplementedException();
        }

        public object Visit(Rule_authority rule)
        {
            throw new System.NotImplementedException();
        }

        public object Visit(Rule_userinfo rule)
        {
            throw new System.NotImplementedException();
        }

        public object Visit(Rule_host rule)
        {
            throw new System.NotImplementedException();
        }

        public object Visit(Rule_port rule)
        {
            throw new System.NotImplementedException();
        }

        public object Visit(Rule_IP_literal rule)
        {
            throw new System.NotImplementedException();
        }

        public object Visit(Rule_IPvFuture rule)
        {
            throw new System.NotImplementedException();
        }

        public object Visit(Rule_IPv6address rule)
        {
            throw new System.NotImplementedException();
        }

        public object Visit(Rule_h16 rule)
        {
            throw new System.NotImplementedException();
        }

        public object Visit(Rule_ls32 rule)
        {
            throw new System.NotImplementedException();
        }

        public object Visit(Rule_IPv4address rule)
        {
            throw new System.NotImplementedException();
        }

        public object Visit(Rule_dec_octet rule)
        {
            throw new System.NotImplementedException();
        }

        public object Visit(Rule_reg_name rule)
        {
            throw new System.NotImplementedException();
        }

        public object Visit(Rule_path_abempty rule)
        {
            throw new System.NotImplementedException();
        }

        public object Visit(Rule_path_absolute rule)
        {
            throw new System.NotImplementedException();
        }

        public object Visit(Rule_path_rootless rule)
        {
            throw new System.NotImplementedException();
        }

        public object Visit(Rule_path_empty rule)
        {
            throw new System.NotImplementedException();
        }

        public object Visit(Rule_segment rule)
        {
            throw new System.NotImplementedException();
        }

        public object Visit(Rule_segment_nz rule)
        {
            throw new System.NotImplementedException();
        }

        public object Visit(Rule_pchar rule)
        {
            throw new System.NotImplementedException();
        }

        public object Visit(Rule_query rule)
        {
            throw new System.NotImplementedException();
        }

        public object Visit(Rule_fragment rule)
        {
            throw new System.NotImplementedException();
        }

        public object Visit(Rule_pct_encoded rule)
        {
            throw new System.NotImplementedException();
        }

        public object Visit(Rule_unreserved rule)
        {
            throw new System.NotImplementedException();
        }

        public object Visit(Rule_reserved rule)
        {
            throw new System.NotImplementedException();
        }

        public object Visit(Rule_gen_delims rule)
        {
            throw new System.NotImplementedException();
        }

        public object Visit(Rule_sub_delims rule)
        {
            throw new System.NotImplementedException();
        }

        public object Visit(Rule_domain rule)
        {
            throw new System.NotImplementedException();
        }

        public object Visit(Rule_address rule)
        {
            throw new System.NotImplementedException();
        }

        public object Visit(Rule_statement rule)
        {
            throw new System.NotImplementedException();
        }

        public object Visit(Rule_version rule)
        {
            throw new System.NotImplementedException();
        }

        public object Visit(Rule_nonce rule)
        {
            throw new System.NotImplementedException();
        }

        public object Visit(Rule_issued_at rule)
        {
            throw new System.NotImplementedException();
        }

        public object Visit(Rule_expiration_time rule)
        {
            throw new System.NotImplementedException();
        }

        public object Visit(Rule_not_before rule)
        {
            throw new System.NotImplementedException();
        }

        public object Visit(Rule_request_id rule)
        {
            throw new System.NotImplementedException();
        }

        public object Visit(Rule_chain_id rule)
        {
            throw new System.NotImplementedException();
        }

        public object Visit(Rule_resources rule)
        {
            throw new System.NotImplementedException();
        }

        public object Visit(Rule_resource rule)
        {
            throw new System.NotImplementedException();
        }

        public object Visit(Rule_sign_in_with_ethereum rule)
        {
            string domain = null;
            string address = null;
            string statement = null;
            string uri = null;
            string version = null;
            int chainId = 0;
            string nonce = null; 
            string issuedAt = null;
            string expirationTime = null;
            string notBefore = null;
            string requestId = null;
            List<string> resources = null;
            
            foreach (var r in rule.rules)
            {
                if (r is Rule_domain)
                {
                    domain = r.spelling;
                } 
                else if (r is Rule_address)
                {
                    address = r.spelling;
                }
                else if (r is Rule_statement)
                {
                    statement = r.spelling;
                }
                else if (r is Rule_URI)
                {
                    uri = r.spelling;
                }
                else if (r is Rule_version)
                {
                    version = r.spelling;
                }
                else if (r is Rule_chain_id)
                {
                    chainId = int.Parse(r.spelling);
                }
                else if (r is Rule_nonce)
                {
                    nonce = r.spelling;
                }
                else if (r is Rule_issued_at)
                {
                    issuedAt = r.spelling;
                }
                else if (r is Rule_expiration_time)
                {
                    expirationTime = r.spelling;
                }
                else if (r is Rule_not_before)
                {
                    notBefore = r.spelling;
                }
                else if (r is Rule_request_id)
                {
                    requestId = r.spelling;
                }
                else if (r is Rule_resources)
                {
                    resources = r.spelling.Substring(3).Split("\n- ", StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries).ToList();
                }
            }

            if (domain == null)
            {
                throw new MissingFieldException("No domain provided");
            }

            if (address == null)
            {
                throw new MissingFieldException("No address provided");
            }

            if (uri == null)
            {
                throw new MissingFieldException("No URI provided");
            }

            if (version == null)
            {
                throw new MissingFieldException("No version provided");
            }

            if (chainId == 0)
            {
                throw new MissingFieldException("No chainId provided");
            }

            if (nonce == null)
            {
                throw new MissingFieldException("No nonce provided");
            }

            if (issuedAt == null)
            {
                throw new MissingFieldException("No issuedAt provided");
            }

            return new SiweMessage(
                domain, address, statement, 
                uri, version, chainId, 
                nonce, issuedAt, expirationTime, 
                notBefore, requestId, resources);
        }

        public object Visit(Terminal_StringValue value)
        {
            throw new System.NotImplementedException();
        }

        public object Visit(Terminal_NumericValue value)
        {
            throw new System.NotImplementedException();
        }
        
        
    }
}