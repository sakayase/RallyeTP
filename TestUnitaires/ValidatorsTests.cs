using Microsoft.VisualStudio.TestTools.UnitTesting;
using Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helpers.Tests
{
    [TestClass()]
    public class ValidatorsTests
    {
        [TestMethod()]
        public void ValidateNumeroTest()
        {
            string failing1 = "";
            string failing2 = "DSDSFEE";
            string failing3 = "123   456";
            string passing1 = "123456";
            string passing2 = "AERTY";
            string passing3 = "dSQs";
            Console.WriteLine(passing1.Length);
            Assert.IsTrue(Validators.ValidateNumero(passing1));
            Assert.IsTrue(Validators.ValidateNumero(passing2));
            Assert.IsTrue(Validators.ValidateNumero(passing3));
            Assert.IsFalse(Validators.ValidateNumero(failing1));
            Assert.IsFalse(Validators.ValidateNumero(failing2));
            Assert.IsFalse(Validators.ValidateNumero(failing3));
        }

        [TestMethod()]
        public void ValidatePoidsTest()
        {
            int failing1 = -10;
            int failing2 = 0;
            int passing1 = 1;
            int passing2 = 1549684;

            Assert.IsTrue(Validators.ValidatePoids(passing1));
            Assert.IsTrue(Validators.ValidatePoids(passing2));
            Assert.IsFalse(Validators.ValidatePoids(failing1));
            Assert.IsFalse(Validators.ValidatePoids(failing2));
        }

        [TestMethod()]
        public void ValidateMarqueTest()
        {
            string failing = "1fsdfds";
            string passing = "fsdsfsd";

            Assert.IsTrue(Validators.ValidateMarque(passing));
            Assert.IsFalse(Validators.ValidateMarque( failing));
        }

        [TestMethod()]
        public void ValidatePuissanceTest()
        {
            int failing1 = -10;
            int failing2 = 0;
            int passing1 = 1;
            int passing2 = 1549684;

            Assert.IsTrue(Validators.ValidatePuissance(passing1));
            Assert.IsTrue(Validators.ValidatePuissance(passing2));
            Assert.IsFalse(Validators.ValidatePuissance(failing1));
            Assert.IsFalse(Validators.ValidatePuissance(failing2));
        }

        [TestMethod()]
        public void ValidateMenuTest()
        {
            List<string> menus = ["menu1", "menu2", "menu3", "menu4"];

            int failing1 = 0;
            int failing2 = 5;
            int passing1 = 1;
            int passing2 = 4;

            Assert.IsTrue(Validators.ValidateMenu(passing1, menus));
            Assert.IsTrue(Validators.ValidateMenu(passing2, menus));
            Assert.IsFalse(Validators.ValidateMenu(failing1, menus));
            Assert.IsFalse(Validators.ValidateMenu(failing2, menus));
        }

        [TestMethod()]
        public void ValidateComparateurTest()
        {
            string passing1 = "=";
            string passing2 = ">=";
            string passing3 = "<=";
            string passing4 = ">";
            string passing5 = "<";
            string failing1 = "";
            string failing2 = "dqsd";
            string failing3 = "=> =";

            Assert.IsTrue(Validators.ValidateComparateur(passing1));
            Assert.IsTrue(Validators.ValidateComparateur(passing2));
            Assert.IsTrue(Validators.ValidateComparateur(passing3));
            Assert.IsTrue(Validators.ValidateComparateur(passing4));
            Assert.IsTrue(Validators.ValidateComparateur(passing5));
            Assert.IsFalse(Validators.ValidateComparateur(failing1));
            Assert.IsFalse(Validators.ValidateComparateur(failing2));
            Assert.IsFalse(Validators.ValidateComparateur(failing3));
        }
    }
}