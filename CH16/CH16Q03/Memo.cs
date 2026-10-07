using System;
using System.Collections.Generic;
using System.Text;

namespace CH16Q03
{
    internal class Memo
    {
        public string Text;

        public int Revision;


        public void Edit(string text)
        {
            Text = text;
            Revision++;
            return;
        }

    }
}
