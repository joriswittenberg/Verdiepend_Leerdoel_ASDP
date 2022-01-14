
using VerdiependLeerdoel.tables;

namespace VerdiependLeerdoel.helpers
{
    public class testdata
    {
        public List<Entity> getEntities()
        {
            var entities = new List<Entity>();

            var entity1 = new Entity
            {
                entityId = "entity1",
                entityLocation = "FACTORY",
            };

            var entity2 = new Entity
            {
                entityId = "entity2",
                entityLocation = "WHOLESALE"
            };

            var entity3 = new Entity
            {
                entityId = "entity3",
                entityLocation = "WAREHOUSE"
            };
            var entity4 = new Entity
            {
                entityId = "entity4",
                entityLocation = "RETAIL"
            };

            entity1.suppliers = new List<string> { entity2.entityId };
            entity2.suppliers = new List<string> { entity1.entityId };
            entity3.suppliers = new List<string> { entity1.entityId };
            entity4.suppliers = new List<string> { entity2.entityId };
            entities.Add(entity1);
            entities.Add(entity2);
            entities.Add(entity3);
            entities.Add(entity4);

            return entities;

        }

        public List<Round> GetRounds()
        {
            var rounds = new List<Round>();
            var round1 = new Round
            {
                roundNumber = 1,
                messages = GetMessages(),
                entityStatistics = GetEntityStatistics()
            };
            rounds.Add(round1);

            return rounds;
            {


            };
        }
        private List<Message> GetMessages()
        {
            var messages = new List<Message>();

            var message1 = new Message
            {
                time = 10,
                senderName = "testuser1",
                chatText = "testMessage",
                recipientUuid = "uuidTestuser2",
                senderUuid = "uuidTestuser1"
            };

            messages.Add(message1);
            return messages;
        }
        private List<EntityStatistics> GetEntityStatistics()
        {
            var entityStatistics = new List<EntityStatistics>();

            var entityStatisticsUser1Round1 = new EntityStatistics()
            {
                entityId = "uuidTestuser1",
                entityType = "PLAYER",
                stock = 10,
                costs = 5,
                delivery = GetDelivery(),
                backlog = GetBacklog(),
                order = GetOrder()

            };
            entityStatistics.Add(entityStatisticsUser1Round1);
            return entityStatistics;

        }

        private Delivery GetDelivery()
        {
            return new Delivery()
            {
                amount = 10,
                receiverId = "uuidTestuser2",
                amountAsked = 15
            };
        }

        private Backlog GetBacklog()
        {
            return new Backlog()
            {
                receiverId = "uuidTestuser2",
                amount = 10,
            };
        }

        private Order GetOrder()
        {
            return new Order()
            {
                supplierId = "uuidTestuser2",
                amount = 10
            };
        }
    }
}