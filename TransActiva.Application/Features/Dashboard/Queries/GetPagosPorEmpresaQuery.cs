﻿using MediatR;
using TransActiva.Application.DTOs.Dashboard;

namespace TransActiva.Application.Features.Dashboard.Queries;

public record GetPagosPorEmpresaQuery : IRequest<List<PagoPorEmpresaDto>>;