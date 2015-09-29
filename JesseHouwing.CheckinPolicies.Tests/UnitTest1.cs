using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JesseHouwing.CheckinPolicies.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void IsSubDirectory_MatchesOnChildPath()
        {
            string path = "$/Branch1/1.1";
            string root = "$/Branch1";

            bool result = WarnMultipleBranchPolicy.IsSubDirectoryOf(root, path);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsSubDirectory_DoesntMatchOnSimilarRootPath()
        {
            string path = "$/Branch1.1";
            string root = "$/Branch1";

            bool result = WarnMultipleBranchPolicy.IsSubDirectoryOf(root, path);

            Assert.IsFalse(result);
        }
    }
}
