using System.Security.Claims;

namespace backend.Services
{
	public class AuthenticatedUser
	{
		private readonly IHttpContextAccessor _accessor;

		public AuthenticatedUser(IHttpContextAccessor accessor)
		{
			_accessor = accessor;
		}

		public string Email => _accessor.HttpContext.User.Identity.Name;
		public string Name => GetClaimsIdentity().FirstOrDefault(a => a.Type == ClaimTypes.Name)?.Value;

		public IEnumerable<Claim> GetClaimsIdentity()
		{
			return _accessor.HttpContext.User.Claims;
		}
	}

}
