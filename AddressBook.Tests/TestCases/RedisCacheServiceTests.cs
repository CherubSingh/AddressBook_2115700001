using NUnit.Framework;
using Moq;
using StackExchange.Redis;
using AddressBook.Cache;
using Newtonsoft.Json;
using System;
using Newtonsoft.Json.Linq;

namespace AddressBooktest.TestCases
{
    [TestFixture]
    public class RedisCacheServiceTests
    {
        private Mock<IConnectionMultiplexer> _mockRedis;
        private Mock<IDatabase> _mockDatabase;
        private ICacheService _cacheService;

        [SetUp]
        public void Setup()
        {
            _mockRedis = new Mock<IConnectionMultiplexer>();
            _mockDatabase = new Mock<IDatabase>();

            _mockRedis.Setup(r => r.GetDatabase(It.IsAny<int>(), It.IsAny<object>())).Returns(_mockDatabase.Object);
            _cacheService = new CacheService(_mockRedis.Object);
        }

        [Test]
        public void SetData_ValidKeyAndValue_ReturnsTrue()
        {
            _mockDatabase.Setup(db => db.StringSet(It.IsAny<RedisKey>(), It.IsAny<RedisValue>(), It.IsAny<TimeSpan?>(),
                It.IsAny<When>(), It.IsAny<CommandFlags>())).Returns(true);

            var result = _cacheService.SetData("testKey", "testValue", DateTimeOffset.Now.AddMinutes(10));
            Assert.That(result, Is.True);
        }

        [Test]
        public void GetData_ExistingKey_ReturnsValue()
        {
            _mockDatabase.Setup(db => db.StringGet("testKey", It.IsAny<CommandFlags>())).Returns(JsonConvert.SerializeObject("testValue"));

            var result = _cacheService.GetData<string>("testKey");
            Assert.That(result, Is.EqualTo("testValue"));
        }
    }
}
