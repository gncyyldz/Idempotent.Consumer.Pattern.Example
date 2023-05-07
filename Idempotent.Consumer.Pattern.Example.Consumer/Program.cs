using Idempotent.Consumer.Pattern.Example.Consumer.Consumers;
using MassTransit;

string rabbitMQUri = "amqps://befjdvjy:bs5zD-4j8OfHQrZFUOnEAKomCudYmkL1@moose.rmq.cloudamqp.com/befjdvjy";

string queueName = "order-created-queue";

IBusControl bus = Bus.Factory.CreateUsingRabbitMq(factory =>
{
    factory.Host(rabbitMQUri);

    factory.ReceiveEndpoint(queueName, endpoint =>
    {
        endpoint.Consumer<OrderCreatedEventConsumer>();
    });
});

await bus.StartAsync();

Console.Read();