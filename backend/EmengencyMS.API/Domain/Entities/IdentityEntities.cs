using Microsoft.AspNetCore.Identity;

namespace Domain.Entities;

public class ApplicationUser : IdentityUser<int> { }

public class ApplicationRole : IdentityRole<int> { }
