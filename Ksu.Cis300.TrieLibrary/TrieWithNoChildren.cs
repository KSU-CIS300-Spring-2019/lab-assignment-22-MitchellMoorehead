/* TrieWithNoChildren.cs
 * Author: Mitchell Moorehead
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ksu.Cis300.TrieLibrary
{
    /// <summary>
    /// 
    /// </summary>
    public class TrieWithNoChildren : ITrie
    {
        /// <summary>
        /// sets a private boolean field to start with empty string
        /// </summary>
        private bool _hasEmptyString = false;
        /// <summary>
        /// Adds an ITrie
        /// </summary>
        /// <param name="s"> string added </param>
        /// <returns> either a trie with no children or a new trie with one child </returns>
        public ITrie Add(string s)
        {
            if (s == "")
            {
                _hasEmptyString = true;
                return this;
            }
            else if (s[0] < 'a' || s[0] > 'z')
            {
                throw new ArgumentException();
            }
            return new TrieWithOneChild(s, _hasEmptyString);
            
        }
        /// <summary>
        /// Checking if a Trie contains a given string
        /// </summary>
        /// <param name="s"> the string were looking for </param>
        /// <returns> whether the trie is empty or not </returns>
        public bool Contains(string s)
        {
            if (s == "")
            {
                return _hasEmptyString;
            }
            else
            {
                return false;
            }

        }
    }
}