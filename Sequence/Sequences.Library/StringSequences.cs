using System;
using System.Collections.Generic;
using System.Text;

namespace Sequences.Library
{
    public class StringSequences
    {
        private readonly List<string> _list = new List<string>();

        //delegation -  this class implements Add by delegating the work to another class
        public void Add(string item)
        {
            _list.Add(item);
        }

        public void Remove(string item)
        {
            _list.Remove(item);
        }

        public string Get (int index)
        {
            return _list[index];
        }

        public string this[int index]
        {
            get => _list[index];
            set => _list[index] = value;
        }
    }
}
