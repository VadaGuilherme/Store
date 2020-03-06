using Microsoft.VisualStudio.TestTools.UnitTesting;
using Store.Domain.StoreContext.Entities;

namespace Store.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var c = new Customer("Guilherme", "Vada", "123456", "gvadaguariba@gmail.com", "16993004623", "Rua Bento Carlos Botelho do Amaral");
            
            var order = new Order(c);
        }
    }
}
