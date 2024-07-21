using Application.Commands.VehicleTaxCalculator.DTOs;
using MediatR;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Http.HttpResults;

namespace FintralearnCongestionTaxCalculator.Controllers
{
    public static class EndPoints
    {
        public static void MapVehicleTaxCalculatorEndpoints(this IEndpointRouteBuilder endpoints, string tag)
        {

            endpoints.MapPost(tag + "/PayVehicleTax", async (VehicleTaxCalculatorRequest item,IMediator mediator) =>
            {
               
                VehicleTaxCalculatorResponse result = await mediator.Send(item);
                return Results.Ok(result);
            }).WithTags(tag);

        }
    }
}
