/* -----------------------------------------------------------------------------
 * Rule_time_offset.cs
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
  sealed public class Rule_time_offset:Rule
  {
    private Rule_time_offset(String spelling, List<Rule> rules) :
      base(spelling, rules)
    {
    }

    public override Object Accept(Visitor visitor)
    {
      return visitor.Visit(this);
    }

    public static Rule_time_offset Parse(ParserContext context)
    {
      context.Push("time-offset");

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
            rule = Terminal_StringValue.Parse(context, "Z");
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
            rule = Rule_time_numoffset.Parse(context);
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
        rule = new Rule_time_offset(context.text.Substring(a0.start, a0.end - a0.start), a0.rules);
      }
      else
      {
        context.index = s0;
      }

      context.Pop("time-offset", parsed);

      return (Rule_time_offset)rule;
    }
  }
}

/* -----------------------------------------------------------------------------
 * eof
 * -----------------------------------------------------------------------------
 */
