/* -----------------------------------------------------------------------------
 * Rule_IP_literal.cs
 * -----------------------------------------------------------------------------
 *
 * Producer : com.parse2.aparse.Parser 2.5
 * Produced : Sun Feb 27 22:17:14 EST 2022
 *
 * -----------------------------------------------------------------------------
 */

using System;
using System.Collections.Generic;

namespace SiweSharp.Grammar.SIWE
{
  sealed public class Rule_IP_literal:Rule
  {
    private Rule_IP_literal(String spelling, List<Rule> rules) :
      base(spelling, rules)
    {
    }

    public override Object Accept(Visitor visitor)
    {
      return visitor.Visit(this);
    }

    public static Rule_IP_literal Parse(ParserContext context)
    {
      context.Push("IP-literal");

      Rule rule;
      bool parsed = true;
      ParserAlternative b;
      int s0 = context.index;
      ParserAlternative a0 = new ParserAlternative(s0);

      List<ParserAlternative> as1 = new List<ParserAlternative>();
      parsed = false;
      {
        int s1 = context.index;
        ParserAlternative a1 = new ParserAlternative(s1);
        parsed = true;
        if (parsed)
        {
          bool f1 = true;
          int c1 = 0;
          for (int i1 = 0; i1 < 1 && f1; i1++)
          {
            rule = Terminal_StringValue.Parse(context, "[");
            if ((f1 = rule != null))
            {
              a1.Add(rule, context.index);
              c1++;
            }
          }
          parsed = c1 == 1;
        }
        if (parsed)
        {
          bool f1 = true;
          int c1 = 0;
          for (int i1 = 0; i1 < 1 && f1; i1++)
          {
            int g1 = context.index;
            List<ParserAlternative> as2 = new List<ParserAlternative>();
            parsed = false;
            {
              int s2 = context.index;
              ParserAlternative a2 = new ParserAlternative(s2);
              parsed = true;
              if (parsed)
              {
                bool f2 = true;
                int c2 = 0;
                for (int i2 = 0; i2 < 1 && f2; i2++)
                {
                  rule = Rule_IPv6address.Parse(context);
                  if ((f2 = rule != null))
                  {
                    a2.Add(rule, context.index);
                    c2++;
                  }
                }
                parsed = c2 == 1;
              }
              if (parsed)
              {
                as2.Add(a2);
              }
              context.index = s2;
            }
            {
              int s2 = context.index;
              ParserAlternative a2 = new ParserAlternative(s2);
              parsed = true;
              if (parsed)
              {
                bool f2 = true;
                int c2 = 0;
                for (int i2 = 0; i2 < 1 && f2; i2++)
                {
                  rule = Rule_IPvFuture.Parse(context);
                  if ((f2 = rule != null))
                  {
                    a2.Add(rule, context.index);
                    c2++;
                  }
                }
                parsed = c2 == 1;
              }
              if (parsed)
              {
                as2.Add(a2);
              }
              context.index = s2;
            }

            b = ParserAlternative.GetBest(as2);

            parsed = b != null;

            if (parsed)
            {
              a1.Add(b.rules, b.end);
              context.index = b.end;
            }
            f1 = context.index > g1;
            if (parsed) c1++;
          }
          parsed = c1 == 1;
        }
        if (parsed)
        {
          bool f1 = true;
          int c1 = 0;
          for (int i1 = 0; i1 < 1 && f1; i1++)
          {
            rule = Terminal_StringValue.Parse(context, "]");
            if ((f1 = rule != null))
            {
              a1.Add(rule, context.index);
              c1++;
            }
          }
          parsed = c1 == 1;
        }
        if (parsed)
        {
          as1.Add(a1);
        }
        context.index = s1;
      }

      b = ParserAlternative.GetBest(as1);

      parsed = b != null;

      if (parsed)
      {
        a0.Add(b.rules, b.end);
        context.index = b.end;
      }

      rule = null;
      if (parsed)
      {
        rule = new Rule_IP_literal(context.text.Substring(a0.start, a0.end - a0.start), a0.rules);
      }
      else
      {
        context.index = s0;
      }

      context.Pop("IP-literal", parsed);

      return (Rule_IP_literal)rule;
    }
  }
}

/* -----------------------------------------------------------------------------
 * eof
 * -----------------------------------------------------------------------------
 */
