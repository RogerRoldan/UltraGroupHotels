﻿using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace UltraGroupHotels.WebAPI.Common.DateConverter;

public class DateOnlySchemaFilter : ISchemaFilter
{
    public void Apply(OpenApiSchema schema, SchemaFilterContext context)
    {
        if (context.Type == typeof(DateOnly))
        {
            schema.Type = "string";
            schema.Format = "date";
            schema.Example = new OpenApiString("2025-12-07");
        }
    }
}