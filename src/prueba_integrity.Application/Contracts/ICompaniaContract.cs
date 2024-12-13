using System;
using modelo_canonico.Types;

namespace prueba_integrity.Application.Contracts;

public interface ICompaniaContract
{
    public Task<CompaniaType> GetCompaniaID(int id);
    public Task<List<CompaniaType>> GetAllCompanias();
    public Task<bool> CreateCompania(CompaniaType compania);
    public Task<bool> UpdateCompania(CompaniaType compania);
    public Task<bool> DeleteCompania(int id);
}
