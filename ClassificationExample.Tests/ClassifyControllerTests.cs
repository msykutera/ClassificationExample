using ClassificationExample;
using FluentAssertions;
using System;
using Xunit;

namespace Syku.ClassificationExample
{
    public class ClassifyControllerTests : IDisposable
    {
        private readonly ClassifyController _controller;

        public ClassifyControllerTests()
        {
            var classificationService = new UsersClassificationService();
            _controller = new ClassifyController(classificationService);
        }

        [Fact]
        public void ShortestDistanceIsCalculatedCorrectly()
        {
            var vm = new UserStatistics(5, 4, 3, 251.0);
            var result = _controller.Classify(vm);
            result.Should().Be(UserType.Good);

            var vm2 = new UserStatistics(5, 4, 3, 251.0);
            var result2 = _controller.Classify(vm2);
            result2.Should().Be(UserType.Good);

            var vm3 = new UserStatistics(2, 2, 1, 51.0);
            var result3 = _controller.Classify(vm3);
            result3.Should().Be(UserType.Average);

            var vm4 = new UserStatistics(1, 2, 1, 151.0);
            var result4 = _controller.Classify(vm4);
            result4.Should().Be(UserType.Average);
        }

        public void Dispose() => _controller.Dispose();
    }
}
