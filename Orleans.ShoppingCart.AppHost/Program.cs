// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT License.

var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.Orleans_ShoppingCart_Silo>("orleans-shoppingcart-silo");

builder.Build().Run();
