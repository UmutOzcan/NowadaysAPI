using MernisServisReference;
using Nowadays.Core.Entities;
using Nowadays.Core.Interfaces.Services;
using System;

namespace Nowadays.API.Services;

public class NationalIdentityVerificationService : INationalIdentityVerificationService
{
    private readonly KPSPublicSoapClient _client;

    public NationalIdentityVerificationService(KPSPublicSoapClient client)
    {
        _client = client;
    }

    public async Task<bool> VerifyIdentityAsync(long tcKimlikNo, string ad, string soyad, int dogumYili)
    {
        try
        {
            var result = await _client.TCKimlikNoDogrulaAsync(tcKimlikNo, ad, soyad, dogumYili);
            return result.Body.TCKimlikNoDogrulaResult;
        }
        catch (Exception ex)
        {
            throw new Exception("TC kimlik no doğrulama sırasında bir hata oluştu.", ex);
        }
    }
}
