using MediatR;
using TransActiva.Application.DTOs.Dashboard;
using TransActiva.Application.Features.Dashboard.Queries;
using TransActiva.Application.Interfaces;

namespace TransActiva.Application.Features.Dashboard.Handlers;

public class GetUserTypeDistributionQueryHandler 
    : IRequestHandler<GetUserTypeDistributionQuery, List<UserTypeDistributionDto>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetUserTypeDistributionQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<List<UserTypeDistributionDto>> Handle(GetUserTypeDistributionQuery request, CancellationToken cancellationToken)
    {
        var users = await _unitOfWork.Users.GetAllAsync();
        var userTypes = await _unitOfWork.UserTypes.GetAllAsync();

        var grouped = users
            .GroupBy(u => u.UserTypeId)
            .Select(g =>
            {
                var userTypeName = userTypes
                    .FirstOrDefault(t => t.Id == g.Key)?.Name ?? "Desconocido";

                return new UserTypeDistributionDto
                {
                    TipoUsuario = userTypeName,
                    Cantidad = g.Count()
                };
            })
            .ToList();

        return grouped;
    }
}