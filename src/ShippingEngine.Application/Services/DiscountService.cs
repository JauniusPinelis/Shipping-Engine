using ShippingEngine.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingEngine.Application.Services
{
    public class DiscountService : IDiscountService
    {
		private readonly IFileService _fileService;

		public DiscountService(IFileService fileService)
		{
			_fileService = fileService;
		}

		public void ImportData()
		{
			
			
		}
    }
}
