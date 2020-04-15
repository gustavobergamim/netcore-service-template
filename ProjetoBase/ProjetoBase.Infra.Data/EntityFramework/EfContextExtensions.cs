using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace ProjetoBase.Infra.Data.EntityFramework
{
    public static class EfContextExtensions
    {
        public static void StringPropertiesTrimmer(this ChangeTracker changeTracker)
        {
            changeTracker.DetectChanges();
            foreach (var entry in changeTracker.Entries())
            {
                if (entry.State == EntityState.Detached
                    || entry.State == EntityState.Unchanged
                    || entry.State == EntityState.Deleted)
                {
                    continue;
                }

                foreach (var property in entry.Properties)
                {
                    if (property.IsTemporary || property.Metadata.IsPrimaryKey()) continue;
                    if (property.Metadata.ClrType != typeof(string)) continue;
                    property.CurrentValue = property.CurrentValue?.ToString().Trim();
                }
            }
        }
    }
}
