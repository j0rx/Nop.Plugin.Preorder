using FluentMigrator.Builders.Create.Table;
using Nop.Core.Domain.Catalog;
using Nop.Core.Domain.Customers;
using Nop.Data.Mapping.Builders;
using System.Data;
using Nop.Data.Extensions;

namespace Nop.Plugin.Preorder.Data
{
    public class PreorderItemBuilder : NopEntityBuilder<Domain.PreorderItem>
    {
        /// <summary>
        /// Apply entity configuration
        /// </summary>
        /// <param name="table">Create table expression builder</param>
        public override void MapEntity(CreateTableExpressionBuilder table)
        {
            //map the primary key (not necessary if it is Id field)
            table.WithColumn(nameof(Domain.PreorderItem.Id)).AsInt32().PrimaryKey()
            //map the additional properties as foreign keys
            .WithColumn(nameof(Domain.PreorderItem.ProductId)).AsInt32().ForeignKey<Product>(onDelete: Rule.Cascade)
            .WithColumn(nameof(Domain.PreorderItem.PreorderId)).AsInt32().ForeignKey<Domain.Preorder>(onDelete: Rule.Cascade)
            //avoiding truncation/failure
            .WithColumn(nameof(Domain.PreorderItem.ProductName)).AsString()
            //not necessary if we don't specify any rules
            .WithColumn(nameof(Domain.PreorderItem.Qty)).AsInt32()
            .WithColumn(nameof(Domain.PreorderItem.ProductPrice)).AsDecimal()
            .WithColumn(nameof(Domain.PreorderItem.DateAdded)).AsDateTime();


        }

    }
}
