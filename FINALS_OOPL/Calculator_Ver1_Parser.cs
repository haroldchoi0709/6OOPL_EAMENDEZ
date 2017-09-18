using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FINALS_OOPL
{
    class Parser
    {
        const int NONE = 0;
        const int DELIMITER = 1;
        const int VARIABLE = 2;
        const int NUMBER = 3;
        // These are the types of syntax errors.
        const int SYNTAX = 0;
        const int UNBALPARENS = 1;
        const int NOEXP = 2;
        const int DIVBYZERO = 3;
        // This token indicates end-of-expression.
        const String EOE = "\0";
        private String exp; // refers to expression string
        private int expIdx; // current index into the expression
        private String token; // holds current token
        private int tokType; // holds token's type
                             // Array for variables.
        private double[] vars = new double[26];

        public double evaluate(String expstr)
        {
            try
            {
                double result;
                exp = expstr;
                expIdx = 0;
                getToken();
                if (token.Equals(EOE))
                    handleErr(NOEXP); // no expression present
                                      // Parse and evaluate the expression.
                result = evalExp1();
                if (!token.Equals(EOE)) // last token must be EOE
                    handleErr(SYNTAX);
                return result;
            }
            catch (ParserException pe)
            {
                throw pe;
            }
        }
        private double evalExp1()
        {
            try
            {
                double result;
                int varIdx;
                int ttokType;
                String temptoken;
                if (tokType == VARIABLE)
                {
                    // save old token
                    temptoken = token;
                    ttokType = tokType;
                    // Compute the index of the variable.
                    varIdx = Char.ToUpper(token.First()) - 'A';
                    getToken();
                    if (!token.Equals("="))
                    {
                        putBack(); // return current token
                                   // restore old token -- not an assignment
                        token = temptoken;
                        tokType = ttokType;
                    }
                    else
                    {
                        getToken(); // get next part of exp
                        result = evalExp2();
                        vars[varIdx] = result;
                        return result;
                    }
                }
                return evalExp2();
            }
            catch (ParserException pe)
            {
                throw pe;
            }
        }

        private double evalExp2()
        {
            try
            {
                char op;
                double result;
                double partialResult;
                result = evalExp3();
                while ((op = token.First()) == '+' || op == '-')
                {
                    getToken();
                    partialResult = evalExp3();
                    switch (op)
                    {
                        case '-':
                            result = result - partialResult;
                            break;
                        case '+':
                            result = result + partialResult;
                            break;
                    }
                }
                return result;
            }
            catch (ParserException pe)
            {
                throw pe;
            }
        }

        private double evalExp3()
        {
            try
            {
                char op;
                double result;
                double partialResult;
                result = evalExp4();
                while ((op = token.First()) == '*' || op == '/' || op == '%')
                {
                    getToken();
                    partialResult = evalExp4();
                    switch (op)
                    {
                        case '*':
                            result = result * partialResult;
                            break;
                        case '/':
                            if (partialResult == 0.0)
                                handleErr(DIVBYZERO);
                            result = result / partialResult;
                            break;
                        case '%':
                            if (partialResult == 0.0)
                                handleErr(DIVBYZERO);
                            result = result % partialResult;
                            break;
                    }
                }
                return result;
            }
            catch (ParserException pe)
            {
                throw pe;
            }
        }

        private double evalExp4()
        {
            try
            {
                double result;
                double partialResult;
                double ex;
                int t;
                result = evalExp5();
                if (token.Equals("^"))
                {
                    getToken();
                    partialResult = evalExp4();
                    ex = result;
                    if (partialResult == 0.0)
                    {
                        result = 1.0;
                    }
                    else
                        for (t = (int)partialResult - 1; t > 0; t--)
                            result = result * ex;
                }
                return result;
            }
            catch (ParserException pe)
            {
                throw pe;
            }
        }

        private double evalExp5()
        {
            try
            {
                double result;
                String op;
                op = "";
                if ((tokType == DELIMITER) && token.Equals("+") || token.Equals("-"))
                {
                    op = token;
                    getToken();
                }
                result = evalExp6();
                if (op.Equals("-"))
                    result = -result;
                return result;
            }
            catch (ParserException pe)
            {
                throw pe;
            }
        }

        private double evalExp6()
        {
            try
            {

                double result;
                if (token.Equals("("))
                {
                    getToken();
                    result = evalExp2();
                    if (!token.Equals(")"))
                        handleErr(UNBALPARENS);
                    getToken();
                }
                else
                    result = atom();
                return result;
            }
            catch (ParserException pe)
            {
                throw pe;
            }
        }

        private double atom()
        {
            try
            {
                double result = 0.0;
                switch (tokType)
                {
                    case NUMBER:
                        try
                        {
                            result = Double.Parse(token);
                        }
                        catch (FormatException exc)
                        {
                            handleErr(SYNTAX);
                        }
                        getToken();
                        break;
                    case VARIABLE:
                        result = findVar(token);
                        getToken();
                        break;
                    default:
                        handleErr(SYNTAX);
                        break;
                }
                return result;
            }
            catch (ParserException pe)
            {
                throw pe;
            }
        }

        private double findVar(String vname)
        {
            if (!Char.IsLetter(vname.First()))
            {
                handleErr(SYNTAX);
                return 0.0;
            }
            return vars[Char.ToUpper(vname.First()) - 'A'];
        }
        // Return a token to the input stream.
        private void putBack()
        {
            if (token == EOE)
                return;
            for (int i = 0; i < token.Length; i++)
                expIdx--;
        }
        // Handle an error.
        private void handleErr(int error)
        {
            String[] err = { "Syntax Error", "Unbalanced Parentheses",
                "No Expression Present", "Division by Zero" };
            throw new ParserException(err[error]);
        }

        private void getToken()
        {
            tokType = NONE;
            token = "";
            // Check for end of expression.
            if (expIdx == exp.Length)
            {
                token = EOE;
                return;
            }
            // Skip over white space.
            while (expIdx < exp.Length
                    && Char.IsWhiteSpace(exp.ElementAt(expIdx)))
                ++expIdx;
            // Trailing whitespace ends expression.
            if (expIdx == exp.Length)
            {
                token = EOE;
                return;
            }
            if (isDelim(exp.ElementAt(expIdx)))
            { // is operator
                token += exp.ElementAt(expIdx);
                expIdx++;
                tokType = DELIMITER;
            }
            else
                if (Char.IsLetter(exp.ElementAt(expIdx)))
            { // is variable
                while (!isDelim(exp.ElementAt(expIdx)))
                {
                    token += exp.ElementAt(expIdx);
                    expIdx++;
                    if (expIdx >= exp.Length)
                        break;
                }
                tokType = VARIABLE;
            }
            else
                    if (Char.IsDigit(exp.ElementAt(expIdx)))
            { // is number
                while (!isDelim(exp.ElementAt(expIdx)))
                {
                    token += exp.ElementAt(expIdx);
                    expIdx++;
                    if (expIdx >= exp.Length)
                        break;
                }
                tokType = NUMBER;
            }
            else
            { // unknown character terminates expression
                token = EOE;
                return;
            }
        }

        private bool isDelim(char c)
        {
            if ((" +-/*%^=()".IndexOf(c) != -1))
                return true;
            return false;
        }
    }
    class ParserException : Exception
    {
        String errStr;  // describes the error
        public ParserException(String str)
        {
            errStr = str;
        }
        public String toString()
        {
            return errStr;
        }
    }
}
