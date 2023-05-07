using Idempotent.Consumer.Pattern.Example.Consumer.Context;
using Idempotent.Consumer.Pattern.Example.Shared.Events;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace Idempotent.Consumer.Pattern.Example.Consumer.Consumers
{
    public class OrderCreatedEventConsumer : IConsumer<OrderCreatedEvent>
    {
        public async Task Consume(ConsumeContext<OrderCreatedEvent> context)
        {
            try
            {
                ApplicationDbContext dbContext = new();
                if (await dbContext.IdempotentEvents.AnyAsync(idempotent => idempotent.IdempotentToken == context.Message.IdempotentToken))
                    return;

                //Handling...
                //Handling...
                //Handling...
                Console.WriteLine($"{JsonSerializer.Serialize(context.Message)}");

                await dbContext.IdempotentEvents.AddAsync(new()
                {
                    IdempotentToken = context.Message.IdempotentToken,
                    OccuredOn = DateTime.UtcNow,
                    ProcessedDate = DateTime.UtcNow,
                    Type = nameof(OrderCreatedEvent)
                });
                await dbContext.SaveChangesAsync();
            }
            catch
            {
                //Rollback Handling
                //or
                //Compensable Transactions
            }
        }
    }
}
