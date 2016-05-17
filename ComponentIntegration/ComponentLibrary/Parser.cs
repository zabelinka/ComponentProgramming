using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

using System.ComponentModel;


namespace ComponentLibrary
{
    public class Parser : Component
    {
        private float parseNumber(string number)
        {
            var translation = new Dictionary<string, float>(){
                {"-", -1},
                {"", 1}
            };
            float res;
            if (!float.TryParse(number, out res))
            {
                res = translation[number];
            }

            return res;
        }

        public float[] parse(string function)
        {
            var stringWithoutWhitespaces = Regex.Replace(function, @"\s", "");          // delete all whitespaces

            // Match first coef and parentheses contents separately. First group is the coef, the second is the content of parentheses
            Regex regGlobal = new Regex(@"^(-?[0-9\.]*)   x   \*?   ln\((.*)\)$",
                RegexOptions.IgnorePatternWhitespace);
            var match = regGlobal.Match(stringWithoutWhitespaces);
            // expect exactly three coefs: before ln, before x inside parentheses and free member
            float[] coefs = new float[3];
            coefs[0] = this.parseNumber(match.Groups[1].Value);

            Regex regInsideParentheses = new Regex(@"^((-?[0-9.]*)x?)([\+-]?[0-9.]*)$");
            match = regInsideParentheses.Match(match.Groups[2].Value);

            if (match.Groups[1].Value.CompareTo(match.Groups[2].Value) == 0)
            {
                // coef before x
                coefs[1] = 0;
                // one before free member
                coefs[2] = this.parseNumber(match.Groups[1].Value);
            }
            else
            {
                coefs[1] = this.parseNumber(match.Groups[2].Value);
                coefs[2] = match.Groups[3].Value == "" ? 0 : this.parseNumber(match.Groups[3].Value);
            }
            return coefs;
        }
    }
}
