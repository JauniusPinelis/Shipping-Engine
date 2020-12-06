using FluentAssertions;
using ShippingEngine.Application.Services;
using ShippingEngine.Domain.Interfaces;
using Xunit;

namespace ShippingEngine.ApplicationTests.Services
{
    public class FileServiceTests
	{
		private readonly IFileService _fileService;

		public FileServiceTests()
		{
			_fileService = new FileService();
		}

		[Fact]
		public void ReadOrdersFile_GivenOrdersFile_ServiceCanRead()
		{
			var ordersData = _fileService.ReadShipmentsFile();

			ordersData.Should().NotBeEmpty();
		}

		[Fact]
		public void ReadPricingsFile_GivenPricingsFile_ServiceCanRead()
		{
			var pricingsData = _fileService.ReadShipmentsFile();

			pricingsData.Should().NotBeEmpty();
		}
	}
}
