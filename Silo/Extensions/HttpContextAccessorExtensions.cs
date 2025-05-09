﻿// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT License.

using System.Security.Claims;

namespace Orleans.ShoppingCart.Silo.Extensions;

internal static class HttpContextAccessorExtensions
{
    internal static string? TryGetUserId(
        this IHttpContextAccessor? httpContextAccessor) =>
        httpContextAccessor
            ?.HttpContext
            ?.User
            .FindFirstValue(ClaimTypes.NameIdentifier)
        ?? "demo-shared-user";
}
