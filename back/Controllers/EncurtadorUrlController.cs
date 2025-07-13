using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using encurtador_url.back.Data;
using encurtador_url.back.Models;

namespace encurtador_url.back.Controllers
{
	[ApiController]
	[Route("encurtador_url")]
	public class EncurtadorUrlController : ControllerBase
	{
		private readonly AppDbContext _context;

		public EncurtadorUrlController(AppDbContext context)
		{
			_context = context;
		}

		[HttpPost("shorten")]
		public async Task<IActionResult> Shorten([FromBody] UrlShortenRequest request)
		{
			if (!Uri.IsWellFormedUriString(request.OriginalUrl, UriKind.Absolute))
				return BadRequest("URL inválida.");

			// Verifica se URL já está cadastrada
			var existing = await _context.UrlMappings
				.FirstOrDefaultAsync(u => u.OriginalUrl == request.OriginalUrl);

			if (existing != null)
			{
				return Ok(new
				{
					shortUrl = $"{Request.Scheme}://{Request.Host}/encurtador_url/{existing.ShortCode}"
				});
			}

			// Gera código único
			var code = GenerateUniqueCode();

			var mapping = new UrlMapping
			{
				OriginalUrl = request.OriginalUrl,
				ShortCode = code
			};

			_context.UrlMappings.Add(mapping);
			await _context.SaveChangesAsync();

			return Ok(new
			{
				shortUrl = $"{Request.Scheme}://{Request.Host}/encurtador_url/{code}"
			});
		}

		[HttpGet("{code}")]
		public async Task<IActionResult> RedirectToOriginal(string code)
		{
			var mapping = await _context.UrlMappings
				.FirstOrDefaultAsync(u => u.ShortCode == code);

			if (mapping == null)
				return NotFound("Código não encontrado.");

			return Redirect(mapping.OriginalUrl);
		}

		private string GenerateUniqueCode()
		{
			const string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
			var random = new Random();

			string code;
			do
			{
				code = new string(Enumerable.Range(0, 6)
					.Select(_ => chars[random.Next(chars.Length)])
					.ToArray());
			}
			while (_context.UrlMappings.Any(u => u.ShortCode == code));

			return code;
		}
	}

	public class UrlShortenRequest
	{
		public string OriginalUrl { get; set; } = string.Empty;
	}
}
