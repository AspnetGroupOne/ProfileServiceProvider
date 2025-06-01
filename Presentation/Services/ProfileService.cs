using Microsoft.EntityFrameworkCore;
using Presentation.Contexts;
using Presentation.Entities;
using Presentation.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Presentation.Services;

public class ProfileService
{

    private readonly DataContext _dataContext;

    public ProfileService(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<ResponseModel> CreateAsync(CreateProfileReqeustForm request)
    {
        if(request == null)
        {
            throw new ArgumentNullException(nameof(request));
        }

        try
        {
            var Address = new AddressEntity
            {
                StreetName = request.StreetName,
                StreetNumber = request.StreetNumber,
                PostalCode = request.PostalCode,
                CityName = request.CityName,
                CountryName = request.CountryName,
            };

            var Profile = new ProfileEntity
            {
                Id = request.ProfileId,
                Address = Address,

                FirstName = request.FirstName,
                LastName = request.LastName,
                PhoneNumber = request.PhoneNumber,
            };

            var res = await _dataContext.AddAsync(Profile);
            await _dataContext.SaveChangesAsync();

            return new ResponseModel
            {
                Success = true,
                Message = "Profile Created and saved to database",
                ErrorCode = "200",
            };
        }

        catch (Exception ex)
        {
            return new ResponseModel
            {
                Success = false,
                Message = ex.Message,
            };
        }
        
    }

    public async Task<ResponseModel> UpdateAsync(UpdateProfileRequestForm request)
    {
        if (request == null)
        {
            throw new ArgumentNullException(nameof(request));
        }

        try
        {
            var address = new AddressEntity
            {
                StreetName = request.StreetName,
                StreetNumber = request.StreetNumber,
                PostalCode = request.PostalCode,
                CityName = request.CityName,
                CountryName = request.CountryName,
            };

            var profile = new ProfileEntity
            {
                
                Address = address,

                FirstName = request.FirstName,
                LastName = request.LastName,
                PhoneNumber = request.PhoneNumber,
            };

            var originalEntity = await _dataContext.ProfileEntities.FirstOrDefaultAsync(x => x.Id == request.ProfileId);
            if(originalEntity == null)
            {
                return new ResponseModel
                {
                    Success = false,
                    Message = "Entity to update not found",
                    ErrorCode = "404",
                };
            }
            _dataContext.Entry(originalEntity).CurrentValues.SetValues(profile);
            await _dataContext.SaveChangesAsync();
            return new ResponseModel
            {
                Success = true,
            };
        }
        catch (Exception ex)
        {
            return new ResponseModel
            {

                Success = false,
                Message = ex.Message,
            };
        }
    }

    public async Task<ResponseModel<ProfileDetailView>> GetByIdAsync(string id)
    {
        try
        {


            var res = await _dataContext.ProfileEntities.FirstOrDefaultAsync(x => x.Id == id);

            if (res == null)
            {
                return new ResponseModel<ProfileDetailView>
                {
                    Success = false,
                    Message = "No profile matching Id found",
                    ErrorCode = "404",
                };
            }

            var view = new ProfileDetailView
            {
                FirstName = res.FirstName,
                LastName = res.LastName,
                PhoneNumber = res.PhoneNumber,
                StreetName = res.Address.StreetName,
                StreetNumber = res.Address.StreetNumber,
                PostalCode = res.Address.PostalCode,
                CityName = res.Address.CityName,
                CountryName = res.Address.CountryName,
            };

            return new ResponseModel<ProfileDetailView>
            {
                Success = true,
                Object = view,
            };
        }
        catch (Exception ex)
        {
            return new ResponseModel<ProfileDetailView>
            {
                Success = false,
                Message = ex.Message,
            };
        }
        }

    public async Task<ResponseModel> DeleteByIdAsync(string id)
    {
        var removeEntity = _dataContext.ProfileEntities.FirstOrDefaultAsync(x => x.Id == id);
        if (removeEntity.Result == null)
        {
            return new ResponseModel
            {
                Success = false,
                Message = "Profile to remove not found",
                ErrorCode = "404",
            };
        }

        try
        {
            _dataContext.ProfileEntities.Remove(removeEntity.Result);
            await _dataContext.SaveChangesAsync();

            return new ResponseModel
            {
                Success = true,
                Message = "Profile Deleted",
            };
        }

        catch (Exception ex)
        {
            return new ResponseModel
            {
                Success = false,
                Message = ex.Message,
            };
        }
    }
}
