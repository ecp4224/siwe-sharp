/* -----------------------------------------------------------------------------
 * Rule_segment.cs
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
  sealed public class Rule_segment:Rule
  {
    private Rule_segment(String spelling, List<Rule> rules) :
      base(spelling, rules)
    {
    }

    public override Object Accept(Visitor visitor)
    {
      return visitor.Visit(this);
    }

    public static Rule_segment Parse(ParserContext context)
    {
      context.Push("segment");

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
          while (f1)
          {
            rule = Rule_pchar.Parse(context);
            if ((f1 = rule != null))
            {
              a1.Add(rule, context.index);
              c1++;
            }
          }
          parsed = true;
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
        rule = new Rule_segment(context.text.Substring(a0.start, a0.end - a0.start), a0.rules);
      }
      else
      {
        context.index = s0;
      }

      context.Pop("segment", parsed);

      return (Rule_segment)rule;
    }
  }
}

/* -----------------------------------------------------------------------------
 * eof
 * -----------------------------------------------------------------------------
 */
