﻿using Bazario.AspNetCore.Shared.Abstractions.Messaging;
using Microsoft.Extensions.DependencyInjection;
using Scrutor;
using System.Reflection;

namespace Bazario.AspNetCore.Shared.Application.Messaging.DependencyInjection
{
    public static class MessagingExtensions
    {
        public static IServiceCollection AddMessaging(
            this IServiceCollection services,
            Assembly assembly)
        {
            services.Scan(scan =>
                scan.FromAssemblies(assembly)
                    .AddHandlersOfType(typeof(IQueryHandler<,>))
                    .AddHandlersOfType(typeof(ICommandHandler<>))
                    .AddHandlersOfType(typeof(ICommandHandler<,>)));

            return services;
        }

        private static IImplementationTypeSelector AddHandlersOfType(
            this IImplementationTypeSelector selector,
            Type assignableType)
        {
            return selector.AddClasses(classes => classes.AssignableTo(assignableType), publicOnly: false)
                .AsImplementedInterfaces()
                .WithScopedLifetime();
        }
    }
}
