﻿using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace StringCrushLibrary.Test
{
    [TestClass]
    public class StringCrusherTest
    {
        [TestMethod]
        public void CrushStringTest()
        {
            var crusher = new StringCrusher(3, 3, 3);
            const string str =
                "This tale grew in the telling, until it became a history of the Great War of the Ring and included many glimpses of the yet more ancient history that preceded it. It was begun soon after The Hobbit was written and before its publication in 1937; but I did not go on with this sequel, for I wished first to complete and set in order the mythology and legends of the Elder Days, which had then been taking shape for some years. I desired to do this for my own satisfaction, and I had little hope that other people would be interested in this work, especially since it was primarily linguistic in inspiration and was begun in order to provide the necessary background of 'history' for Elvish tongues.";
            var crushedStr = crusher.CrushString(str);
            Assert.AreNotEqual(str, crushedStr);
        }
    }
}