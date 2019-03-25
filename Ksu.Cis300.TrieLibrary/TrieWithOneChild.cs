/* TrieWithOneChild.cs
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
    /// Class for a trie containing one child
    /// </summary>
    public class TrieWithOneChild : ITrie
    {
        /// <summary>
        /// 
        /// </summary>
        private bool _empty;
        /// <summary>
        /// field for 
        /// </summary>
        private ITrie _onlyChild;
        /// <summary>
        /// the label of the child
        /// </summary>
        private char _label;
        /// <summary>
        /// Constructor for a trie with one child
        /// </summary>
        /// <param name="s"> the string in the trie </param>
        /// <param name="hasEmpty"> the result of looking if s is an empty string </param>
        public TrieWithOneChild(string s, bool hasEmpty)
        {
            if (s == "" || s[0] < 'a' || s[0] > 'z')
            {

                throw new ArgumentException();
            }
            //_hasEmptyString = hasEmpty;
            //_children[childLabel - 'a'] = child;
            //Add(s);
            _empty = hasEmpty;
            _label = s[0];
            _onlyChild = new TrieWithNoChildren().Add(s.Substring(1));
            
        }
        /// <summary>
        /// Adds a string to a trie
        /// </summary>
        /// <param name="s"> string to be added </param>
        /// <returns> either an added trie, or a new trie with many children </returns>
        public ITrie Add(string s)
        {
            if (s == "")
            {
                _empty = true;
            }
            else if (s[0] < 'a' || s[0] > 'z')
            {
                throw new ArgumentException();
            }
            else
            {

                if (_label == s[0])
                {
                    _onlyChild = _onlyChild.Add(s.Substring(1));
                    return this;
                }
                else
                {
                    return new TrieWithManyChildren(s, _empty, _label, _onlyChild);
                }
            }
            return this;
        }
        /// <summary>
        /// Gets whether the trie rooted at this node contains the given string.
        /// </summary>
        /// <param name="s"> the trie to look up</param>
        /// <returns> the result of the lookup </returns>
        public bool Contains(string s)
        {

            if (s == "")
            {
                return _empty;
            }
            else
            {
                if (_label != s[0])
                {
                    return false;
                }
                else
                {
                    return _onlyChild.Contains(s.Substring(1));
                }
            }
        }
    }
}
