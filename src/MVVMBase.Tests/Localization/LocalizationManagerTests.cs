using System.Resources;
using MVVMBase.Localization;

namespace MVVMBase.Tests.Localization
{
    public class LocalizationManagerTests
    {
        [Fact]
        public void Returns_key_with_questions_if_no_manager_specified()
        {
            var manager = new LocalizationManager();
            var key = manager.GetString("key1");
            Assert.Equal("?key1?", key);
;        }

        [Fact]
        public void Returns_key_with_questions_if_no_manager_and_params_specified()
        {
            var manager = new LocalizationManager();
            var key = manager.GetString("key1", "one");
            Assert.Equal("?key1?", key);
        }

        [Fact]
        public void Returns_value_as_expected()
        {
            var rm = new ResourceManager(typeof(Resources.Resources));
            var manager = new LocalizationManager();
            manager.AddResourceManager(rm);
            var key = manager.GetString("TestKey");
            Assert.Equal("TestValue", key);
        }
        [Theory]
        [InlineData("FormattedKey1", new[]{"one"}, "FormattedValue one")]
        [InlineData("FormattedKey2", new[]{"one","two"}, "FormattedValue one two")]
        public void Returns_formatted_value_as_expected(string key, object[] values, string expected)
        {
            var rm = new ResourceManager(typeof(Resources.Resources));
            var manager = new LocalizationManager();
            manager.AddResourceManager(rm);
            var result = manager.GetString(key, values);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        [InlineData("   ")]
        public void Returns_dashes_for_empty_keys(string key)
        {
            var manager = new LocalizationManager();
            var result = manager.GetString(key);
            Assert.Equal("---", result);
        }
        [Fact]
        public void Returns_values_from_two_managers_as_expected()
        {
            var rm = new ResourceManager(typeof(Resources.Resources));
            var rm2 = new ResourceManager(typeof(Resources.Resources2));
            var manager = new LocalizationManager();
            manager.AddResourceManager(rm);
            manager.AddResourceManager(rm2);
            var key = manager.GetString("TestKey");
            var key2 = manager.GetString("TestKey2");
            Assert.Equal("TestValue", key);
            Assert.Equal("TestValue2", key2);
        }
    }
}
