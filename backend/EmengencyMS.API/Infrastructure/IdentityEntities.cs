using Microsoft.AspNetCore.Identity;

namespace Infrastructure;

public class ApplicationUser : IdentityUser<int> { }

public class ApplicationRole : IdentityRole<int> { }
