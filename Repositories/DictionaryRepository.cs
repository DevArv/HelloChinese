using HelloChinese.DatabaseConnection;
using HelloChinese.Models;
using HelloChinese.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace HelloChinese.Repositories;

public class DictionaryRepository
{
    public Task<bool> ValidateAsync(DictionarySimpleViewModel Obj)
    {
        //Required fields validation
        if (string.IsNullOrWhiteSpace(Obj.Handwriting))
            throw new ApplicationException("El campo Caligrafía es requerido.");

        return Task.FromResult(true);
    }
    
    public async Task<Guid> SaveRecordAsync(DictionarySimpleViewModel ViewModel)
    {
        await using var context = new HelloChineseContext();
        await using var transaction = await context.Database.BeginTransactionAsync();
        
        try
        {
            // Generate a new ID when creating the record if none was supplied
            var dictionaryID = ViewModel.ID == Guid.Empty ? Guid.NewGuid() : ViewModel.ID;

            var dictionary = new Dictionary
            {
                ID = dictionaryID,
                Date = ViewModel.Date,
                Handwriting = ViewModel.Handwriting,
                Pronunciation = ViewModel.Pronunciation,
                Meaning = ViewModel.Meaning,
                Category = ViewModel.Category,
            };

            context.Dictionary.Add(dictionary);
            await context.SaveChangesAsync();
            
            return dictionary.ID;
        }
        catch (Exception ex)
        {
            await transaction.RollbackAsync();
            throw new ApplicationException($"Error al guardar", ex);
        }
    }

    public async Task<DictionarySimpleViewModel?> GetRecordAsync(Guid ID)
    {
        await using var context = new HelloChineseContext();

        var query = await context.Dictionary
            .Where(d => d.ID == ID)
            .Select(d => new DictionarySimpleViewModel
            {
                ID = d.ID,
                Date = d.Date,
                Handwriting = d.Handwriting,
                Pronunciation = d.Pronunciation,
                Meaning = d.Meaning,
                Category = d.Category
            })
            .FirstOrDefaultAsync();

        return query;
    }
}