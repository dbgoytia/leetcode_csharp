using Microsoft.VisualStudio.TestTools.UnitTesting;
using Leetcode;

// Given an input string s, and a pattern p, implement regular
// expression matching with support for '.' and '*', where:
// * '.' matches any single character.
// * '*' matches zero or more of the preceding element.


namespace LeetCode.Test.Unit
{
    [TestClass]
    public class RegularExpressionMatchingTest
    {
        private readonly RegularExpressionMatching _regularExpressionMatching = new RegularExpressionMatching();

        [TestMethod]
        public void RegularExpressionDoesNotMatchTheEntireStrings()
        {
            string input = "aa";
            string pattern = "a";
            bool expected = false;
            Assert.AreEqual(_regularExpressionMatching.isMatch(input, pattern), expected);
        }

        [TestMethod]
        public void RegularExpressionMatchesZeroOrMorePrecedingElement()
        {
            string input = "aa";
            string pattern = "a*";
            bool expected = true;
            Assert.AreEqual(_regularExpressionMatching.isMatch(input, pattern), expected);
        }

        [TestMethod]
        public void RegularExpressionMatchesZeroOrMoreOfAnyCharacter()
        {
            string input = "ab";
            string pattern = ".*";
            bool expected = true;
            Assert.AreEqual(_regularExpressionMatching.isMatch(input, pattern), expected);
        }
    }
}


/***
 * 
 * 
 * Example 1
 * input "a"
 * pattern "."
 * expected = nomatch
 * 
 * 
 * Explanation:
 * 
 * 
 * 
 * 
 * 
 * _____________________
 * 
 * Example 2
 * input "ab"
 * pattern "."
 * expected = match
 * 
 * 
 * Explanation: the pattern "." matches any zero or more chars from current char
 * so

 *      
 * Example 3
 * input "abcdefg"
 * pattern = "abcdef."
 * expected = match
 * 
 * We need to match every letter until special character, and then appply regex.
 * 
 * 
 * input = [ a, b, c, d, e, f, g ]      i = 6
 *                             i        j = 6
 *                                      input[i] == pattern[j] and pattern[j] != '.' False;
 *                                      i = 2
 *           
 *  
 * pattern = [ a, b, c, d, e, f, . ]
 *                               j 
 *  
 *  
 * While input[i] == pattern[j] && pattern[j] != '.':
 *    i ++;
 *    j ++;
 *  
 *  
 * if pattern[j] == '.':
 *    if input[i+1] != None:
 *       return True; ## it will match anything.
 * elif pattern[j] == '*':
 *    
 * 
 * 
 * 
 * 
 ***/
