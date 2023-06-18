using System;

using Frigy.Server.Models.Common.Base;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.ValueGeneration;

namespace Frigy.Server.Data.Configurations.Common;

public class EntityBaseConfiguration<TEntity> : IEntityTypeConfiguration<TEntity>
    where TEntity : EntityBase
{
    public virtual void Configure(EntityTypeBuilder<TEntity> builder)
    {
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Created)
            .HasValueGenerator<DateValueGenerator>()
            .ValueGeneratedOnAdd();
        builder.Property(e => e.Updated)
            .HasValueGenerator<DateValueGenerator>()
            .ValueGeneratedOnAddOrUpdate();
    }
}

public class DateValueGenerator : ValueGenerator<DateTimeOffset>
{
    public override bool GeneratesTemporaryValues { get; }

    public override DateTimeOffset Next(EntityEntry entry)
    {
        return DateTimeOffset.UtcNow;
    }
}