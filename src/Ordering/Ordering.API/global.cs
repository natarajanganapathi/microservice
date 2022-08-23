global using System;
global using System.Net;
global using System.Threading.Tasks;
global using System.Collections.Generic;
global using System.Data.Common;
global using System.Data.SqlClient;
global using MediatR;
global using Dapper;
global using Microsoft.AspNetCore.Mvc;
global using Microsoft.AspNetCore.Authorization;
global using FluentValidation;
global using Microsoft.Extensions.Logging;
global using System.Runtime.Serialization;
global using Serilog.Context;
global using Microsoft.EntityFrameworkCore;

global using Ordering.API.Application.Behaviors;
global using Ordering.API.Application.DomainEventHandlers;
global using Ordering.API.Application.DomainEventHandlers.BuyerAndPaymentMethodVerified;
global using Ordering.API.Application.DomainEventHandlers.OrderCancelled;
global using Ordering.API.Application.DomainEventHandlers.OrderGracePeriodConfirmed;
global using Ordering.API.Application.DomainEventHandlers.OrderPaid;
global using Ordering.API.Application.DomainEventHandlers.OrderShipped;
global using Ordering.API.Application.DomainEventHandlers.OrderStartedEvent;
global using Ordering.API.Application.DomainEventHandlers.OrderStockConfirmed;

global using Ordering.API.Application.IntegrationEvents;
global using Ordering.API.Application.IntegrationEvents.EventHandling;
global using Ordering.API.Application.IntegrationEvents.Events;

global using Ordering.API.Application.Models;
global using Ordering.API.Application.Validations;
global using Ordering.API.Application.Queries;
global using Ordering.API.Application.Commands;
global using static Ordering.API.Application.Commands.CreateOrderCommand;
global using Ordering.API.Extensions;

global using Ordering.Domain;
global using Ordering.Domain.AggregatesModel;
global using Ordering.Domain.Events;
global using Ordering.Domain.Exceptions;

global using Ordering.Infrastructure;
global using Ordering.Infrastructure.Idempotency;
global using Ordering.Infrastructure.EntityConfiguration;
global using Ordering.Infrastructure.Repositories;

global using EventBus;
global using EventBus.Abstractions;
global using EventBus.Events;
global using EventBus.Extensions;

global using EventBusRabbitMQ;

global using IntegrationEventLogEF;
global using IntegrationEventLogEF.Services;
global using IntegrationEventLogEF.Utilities;
