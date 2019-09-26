using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Persistence;

namespace OpenApp.Activities
{
    public class List
    {
        public class Query : IRequest<List<Activity>> { }

        //List<Activity> is the type of return value; <TReqeust, TResponse>
        public class Handler : IRequestHandler<Query, List<Activity>>
        {
            private readonly DataContext _context;
            private readonly ILogger<List> _logger;
            public Handler(DataContext context, ILogger<List> logger)
            {
                _logger = logger;
                _context = context;
            }
            public async Task<List<Activity>> Handle(Query request, CancellationToken cancellationToken)
            {/*
                try
                {
                    for (int i = 0; i < 10; ++i)
                    {
                        cancellationToken.ThrowIfCancellationRequested();
                        await Task.Delay(1000, cancellationToken);
                        _logger.LogInformation($"Task {i} is completed.");
                    }
                }
                catch (TaskCanceledException)
                {
                    _logger.LogInformation("Task was cancelled.");
                } */

                var activities = await _context.Activities.ToListAsync();
                return activities;
            }
        }
    }
}