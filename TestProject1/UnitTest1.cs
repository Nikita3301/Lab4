using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Lab41.Student st = new Lab41.Student() ;
            st.Name = "Остап";
            st.LastName = "Мельник";
            st.Group = "IТ-10";
            st.Year = 2022;
            st.Adress = "Müller-Breslau-Straße 14A, 10623 Berlin";
            st.Passport = "000000000";
            st.Age = 19;
            st.Telephon = "(000) 000 0000";
            st.Rating = 81;
            string r = "Mожна вчитися краще";
            string result = st.StudentRating(st.Rating);
            Assert.AreEqual(r,result);
        }
    }
}