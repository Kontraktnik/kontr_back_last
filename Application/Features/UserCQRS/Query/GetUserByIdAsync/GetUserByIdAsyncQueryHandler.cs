using Application.Contracts.Persistence;
using Application.DTO.Common;
using Application.DTO.User;
using Application.Resource;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Localization;

namespace Application.Features.UserCQRS.Query.GetUserByIdAsync;

public class GetUserByIdAsyncQueryHandler : IRequestHandler<GetUserByIdAsync,ResponseDTO<UserDTO>>
{
    private readonly IUserRepository _repository;
    private readonly IMapper _mapper;
    private IStringLocalizer<Localize> localizer;
    public GetUserByIdAsyncQueryHandler(IUserRepository repository,IMapper mapper,IStringLocalizer<Localize> localizer)
    {
        _repository = repository;
        _mapper = mapper;
        this.localizer = localizer;
    }


    public async Task<ResponseDTO<UserDTO>> Handle(GetUserByIdAsync request, CancellationToken cancellationToken)
    {
        var model = await _repository.GetEntityWithSpecAsync(request.specification);
        if (model != null)
        {
            return new ResponseDTO<UserDTO>()
            {
                Success = true,
                StatusCode = 200,
                Data = _mapper.Map<UserDTO>(model)
            };
        }
        else
        {
            return new ResponseDTO<UserDTO>()
            {
                Success = false,
                StatusCode = 404,
                Message = this.localizer["NotFound"]
            };
        }
    }
}