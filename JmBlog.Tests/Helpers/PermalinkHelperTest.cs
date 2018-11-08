using JmBlog.Helpers;
using Xunit;

namespace JmBlog.Tests.Helpers
{
    public class PermalinkHelperTest
    {
        public PermalinkHelperTest()
        {

        }

        [Fact]
        public void GeneratePermalink()
        {
            var slug = PermalinkHelper.GenerateSlug("Título que vai virar permalink com acentuação");
            Assert.Equal("titulo-que-vai-virar-permalink-com-acentuacao", slug);
        }

        [Fact]
        public void RemoveDiatricts()
        {
            var newPhrase = PermalinkHelper.RemoveDiacritics("Título que vai virar permalink com acentuação");
            Assert.Equal("Titulo que vai virar permalink com acentuacao", newPhrase);
        }
    }
}