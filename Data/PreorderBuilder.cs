using FluentMigrator.Builders.Create.Table;
using Nop.Core.Domain.Catalog;
using Nop.Core.Domain.Customers;
using Nop.Data.Mapping.Builders;
using System.Data;
using Nop.Data.Extensions;

namespace Nop.Plugin.Preorder.Data
{
    public class PreorderBuilder : NopEntityBuilder<Domain.Preorder>
    {
        /// <summary>
        /// Apply entity configuration
        /// </summary>
        /// <param name="table">Create table expression builder</param>
        public override void MapEntity(CreateTableExpressionBuilder table)
        {
            //map the primary key (not necessary if it is Id field)
            table.WithColumn(nameof(Domain.Preorder.Id)).AsInt32().PrimaryKey()
            //map the additional properties as foreign keys
            .WithColumn(nameof(Domain.Preorder.CustomerId)).AsInt32().ForeignKey<Customer>(onDelete: Rule.Cascade)
            //avoiding truncation/failure
            .WithColumn(nameof(Domain.Preorder.CreatedAt)).AsDateTime()
            //not necessary if we don't specify any rules
            .WithColumn(nameof(Domain.Preorder.CancelledAt)).AsDateTime()
            .WithColumn(nameof(Domain.Preorder.Status)).AsString()
            .WithColumn(nameof(Domain.Preorder.Month)).AsString();


        }

    }
}
