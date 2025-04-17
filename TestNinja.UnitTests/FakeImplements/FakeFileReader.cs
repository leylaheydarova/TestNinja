using TestNinja.Mocking;

namespace TestNinja.UnitTests.FakeImplements
{
    public class FakeFileReader : IFileReader
    {
        public string ReadFile(string path)
        {
            return "";
        }
    }
}
