namespace ConsoleApplication.Domain
{
    using System;
    using System.Collections.Generic;



    public sealed class OrderPart : IEntity
    {
        public int Id { get; set; }

        public Order Order { get; set; }

        public Part Part { get; set; }
        
        
        public override bool Equals(object obj) => new OrderPartComparer().Equals(this, obj as OrderPart);
        
        public override int GetHashCode() => new OrderPartComparer().GetHashCode(this);
    }

    internal sealed class OrderPartComparer : IEqualityComparer<OrderPart>
    {
        public bool Equals(OrderPart x, OrderPart y) =>
            x.Order.Number == y.Order.Number &&
            x.Part.Name.Equals(y.Part.Name, StringComparison.InvariantCultureIgnoreCase);

        public int GetHashCode(OrderPart obj) => (obj.Order.Number, obj.Part.Name.ToLower()).GetHashCode();
    }
}