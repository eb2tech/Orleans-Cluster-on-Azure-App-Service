// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT License.

var builder = DistributedApplication.CreateBuilder(args);

var redis = builder.AddRedis("shoppingcart-redis");

var orleans = builder.AddOrleans("shoppingcart-cluster")
                     .WithClustering(redis)
                     .WithGrainStorage("shopping-cart", redis);

builder.AddProject<Projects.Orleans_ShoppingCart_Silo>("shoppingcart-silo")
       .WithReference(orleans)
       .WaitFor(redis)
       .WithReplicas(3)
       .WithExternalHttpEndpoints();

builder.Build().Run();
