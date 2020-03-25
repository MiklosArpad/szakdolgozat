using IngatlanCentrum.Exceptions;
using IngatlanCentrum.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;

namespace IngatlanCentrum.Validation.Tests
{
    [TestClass()]
    public class UgynokValidatorTests
    {
        /// <summary>
        /// Ügynök teszt modell.
        /// </summary>
        private Ugynok ugynok;

        public UgynokValidatorTests()
        {
            ugynok = new Ugynok();
            ugynok.Id = "ABC123";
            ugynok.Jelszo = "";
            ugynok.Vezeteknev = "Miklós";
            ugynok.Keresztnev = "Árpád";
            ugynok.Telefonszam = "06702936781";
            ugynok.Jogosultsag = "admin";
        }

        [TestMethod()]
        public void ValidateTest_UgynokAzonositoTartalmazKisbetut()
        {
            try
            {
                ugynok.Id = "ABc123";
                UgynokValidator.Validate(ugynok);
            }
            catch (UgynokException e)
            {
                Debug.WriteLine(e.Message);
                return;
            }

            Assert.Fail("Nem dob kivételt kisbetűt tartalmazó ügynökazonosítóra!");
        }

        [TestMethod()]
        public void ValidateTest_UgynokAzonositoNemTartalmazSzamot()
        {
            try
            {
                ugynok.Id = "ABCDEF";
                UgynokValidator.Validate(ugynok);
            }
            catch (UgynokException e)
            {
                Debug.WriteLine(e.Message);
                return;
            }

            Assert.Fail("Nem dob kivételt számot nem tartalmazó ügynökazonosítóra!");
        }

        [TestMethod()]
        public void ValidateTest_UgynokAzonositoNemHatKarakterbolAll()
        {
            try
            {
                ugynok.Id = "ABCDEFGH12345";
                UgynokValidator.Validate(ugynok);
            }
            catch (UgynokException e)
            {
                Debug.WriteLine(e.Message);
                return;
            }

            Assert.Fail("Nem dob kivételt nem 6 karaktert tartalmazó ügynökazonosítóra!");
        }

        [TestMethod()]
        public void ValidateTest_UgynokJelszoNemTizKarakterbolAll()
        {
            try
            {
                ugynok.Jelszo = "A1B2c3d4";
                UgynokValidator.Validate(ugynok);
            }
            catch (UgynokException e)
            {
                Debug.WriteLine(e.Message);
                return;
            }

            Assert.Fail("Nem dob kivételt számot nem 10 karakterből álló ügynök jelszóra!");
        }

        [TestMethod()]
        public void ValidateTest_UgynokJelszoNemTartalmazSzamot()
        {
            try
            {
                ugynok.Jelszo = "MiKloSaRpI";
                UgynokValidator.Validate(ugynok);
            }
            catch (UgynokException e)
            {
                Debug.WriteLine(e.Message);
                return;
            }

            Assert.Fail("Nem dob kivételt számot nem tartalmazó ügynök jelszóra!");
        }
    }
}
