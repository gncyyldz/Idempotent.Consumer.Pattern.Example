using Idempotent.Consumer.Pattern.Example.Shared.Events;
using MassTransit;

string rabbitMQUri = "amqps://befjdvjy:bs5zD-4j8OfHQrZFUOnEAKomCudYmkL1@moose.rmq.cloudamqp.com/befjdvjy";


IBusControl bus = Bus.Factory.CreateUsingRabbitMq(factory =>
{
    factory.Host(rabbitMQUri);
});


var idempotentToken = "9b65fb83-433f-4467-af97-1144a26e402a";
await bus.Publish<OrderCreatedEvent>(new OrderCreatedEvent()
{
    Description = "Example Order Created",
    IdempotentToken = Guid.Parse(idempotentToken),
    OrderId = Guid.NewGuid(),
    Quantity = 10,
});

Console.Read();