using Xunit;
using JM = JenkinsMVC.Controllers;

namespace JenkinsMVC.Tests
{
    public class HomeController
    {
      [Fact]
      public void HelloTest()
      {
        var hc = new JM.HomeController();
        Assert.NotNull(hc);
      }
    }
}