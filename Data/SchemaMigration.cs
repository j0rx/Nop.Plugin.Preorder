using FluentMigrator;
using Nop.Data.Migrations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nop.Plugin.Preorder.Data
{
    [SkipMigrationOnUpdate]
    [NopMigration("2021/02/20 21:13", "Preorder base schema")]
    public class SchemaMigration : AutoReversingMigration
    {
        protected IMigrationManager _migrationManager;

        public SchemaMigration(IMigrationManager migrationManager)
        {
            _migrationManager = migrationManager;
        }

        public override void Up()
        {
            _migrationManager.BuildTable<Domain.Preorder>(Create);
            _migrationManager.BuildTable<Domain.PreorderItem>(Create);

        }
    }
}