using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace Angular5MultipleFileUpload.Controllers
{

	[Produces("application/json")]
	[Route("api/[controller]")]
	public class UploadController : Controller
    {        
		private IHostingEnvironment _hostingEnvironment;

		public UploadController(IHostingEnvironment hostingEnvironment)
		{
			_hostingEnvironment = hostingEnvironment;
		}

		[HttpPost]
		public IActionResult Index()
		{
			try
			{
				var file = Request.Form.Files[0];
				string folderName = "Upload";
				string webRootPath = _hostingEnvironment.WebRootPath;
				string newPath = Path.Combine(webRootPath, folderName);
				if (!Directory.Exists(newPath))
				{
					Directory.CreateDirectory(newPath);
				}
				if (file.Length > 0)
				{
					string fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
					string fullPath = Path.Combine(newPath, fileName);
					using (var stream = new FileStream(fullPath, FileMode.Create))
					{
						file.CopyTo(stream);
					}
				}
				return Json("Upload Successful.");
			}
			catch (Exception ex)
			{
				return Json("Upload Failed: " + ex.Message);
			}
		}
	}
}