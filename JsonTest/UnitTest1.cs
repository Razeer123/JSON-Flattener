using System.IO;
using NUnit.Framework;
using JSON_Flattener;

namespace JsonTest
{
    public class Tests
    {

        [Test]
        public void Test1()
        {
            var directory = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            var file = File.ReadAllText(Path.Combine(directory, "test1.json"));
            var handler = new JsonHandler(Path.Combine(file));
            var reference = handler.DeserializeJson();
            var check = File.ReadAllText(Path.Combine(directory, "check1.json"));
            Assert.AreEqual(reference.Replace(" ", ""), check.Replace(" ", ""));
        }
        
        [Test]
        public void Test2()
        {
            var directory = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            var file = File.ReadAllText(Path.Combine(directory, "test2.json"));
            var handler = new JsonHandler(Path.Combine(file));
            var reference = handler.DeserializeJson();
            var check = File.ReadAllText(Path.Combine(directory, "check2.json"));
            Assert.AreEqual(reference.Replace(" ", "").Replace("\t", ""), check.Replace(" ", "").Replace("\t", ""));
        }
        
        [Test]
        public void Test3()
        {
            var directory = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            var file = File.ReadAllText(Path.Combine(directory, "test3.json"));
            var handler = new JsonHandler(Path.Combine(file));
            var reference = handler.DeserializeJson();
            var check = File.ReadAllText(Path.Combine(directory, "check3.json"));
            Assert.AreEqual(reference.Replace(" ", "").Replace("\t", ""), check.Replace(" ", "").Replace("\t", ""));
        }
        
        [Test]
        public void Test4()
        {
            var directory = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            var file = File.ReadAllText(Path.Combine(directory, "test4.json"));
            var handler = new JsonHandler(Path.Combine(file));
            var reference = handler.DeserializeJson();
            var check = File.ReadAllText(Path.Combine(directory, "check4.json"));
            Assert.AreEqual(reference.Replace(" ", "").Replace("\t", ""), check.Replace(" ", "").Replace("\t", ""));
        }
    }
}