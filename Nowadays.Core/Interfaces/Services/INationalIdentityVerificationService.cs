using Nowadays.Core.Entities;

namespace Nowadays.Core.Interfaces.Services;

public interface INationalIdentityVerificationService
{
    Task<bool> VerifyIdentityAsync(long tcKimlikNo, string ad, string soyad, int dogumYili);
}
