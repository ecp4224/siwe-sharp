/* -----------------------------------------------------------------------------
 * ParserAlternative.cs
 * -----------------------------------------------------------------------------
 *
 * Producer : com.parse2.aparse.Parser 2.5
 * Produced : Sun Feb 27 22:17:14 EST 2022
 *
 * -----------------------------------------------------------------------------
 */

using System.Collections.Generic;

namespace SiweSharp.Grammar.SIWE
{
  public class ParserAlternative
  {
    public List<Rule> rules;
    public int start;
    public int end;

    public ParserAlternative(int start)
    {
      this.rules = new List<Rule>();
      this.start = start;
      this.end = start;
    }

    public void Add(Rule rule, int end)
    {
      this.rules.Add(rule);
      this.end = end;
    }

    public void Add(List<Rule> rules, int end)
    {
      this.rules.AddRange(rules);
      this.end = end;
    }

    static public ParserAlternative GetBest(List<ParserAlternative> alternatives)
    {
      ParserAlternative best = null;

      foreach (ParserAlternative alternative in alternatives)
      {
        if (best == null || alternative.end > best.end)
          best = alternative;
      }

      return best;
    }
  }
}

/* -----------------------------------------------------------------------------
 * eof
 * -----------------------------------------------------------------------------
 */
