﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VBF.Compilers.Scanners;

namespace VBF.Compilers.Parsers
{
    public class Terminal : ProductionBase<Lexeme>
    {
        //static Dictionary<Token, Terminal> s_tokenDict = new Dictionary<Token,Terminal>();

        public Token Token { get; private set; }

        private Terminal(Token token)
        {
            Token = token;
        }

        public static Terminal GetTerminal(Token token)
        {
            CodeContract.RequiresArgumentNotNull(token, "token");

            /*
            Terminal terminal = null;


            if (s_tokenDict.TryGetValue(token, out terminal))
            {
                return terminal;
            }

            terminal = new Terminal(token);
            s_tokenDict.Add(token, terminal);

            return terminal;
            //*/

            return new Terminal(token);
        }

        public override TResult Accept<TArg, TResult>(IProductionVisitor<TArg, TResult> visitor, TArg argument)
        {
            return visitor.VisitTerminal(this, argument);
        }

        public override bool Equals(object obj)
        {
            var other = obj as Terminal;

            if (other == null)
            {
                return false;
            }

            return Token.Equals(other.Token);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return Token.GetHashCode() + 1;
            }

        }

        public override bool IsTerminal
        {
            get
            {
                return true;
            }
        }

        public override string DebugName
        {
            get
            {
                return Token.Description;
            }
        }

        public override string ToString()
        {
            return Token.Description;
        }
    }
}
