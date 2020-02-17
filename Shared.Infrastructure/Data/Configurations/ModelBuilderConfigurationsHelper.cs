using Microsoft.EntityFrameworkCore;
using Shared.Infrastructure.Data.Configurations.AttachmentFileconfiguration;
using Shared.Infrastructure.Data.Configurations.SystemLookupsConfiguration;
using Shared.Infrastructure.Data.Configurations.User;

namespace Shared.Infrastructure.Data.Configurations
{
    public class ModelBuilderConfigurationsHelper
    {
        public static ModelBuilder OnModelCreating(ModelBuilder modelBuilder)
        {
            //========== System Table & lookups configuration================
            modelBuilder.ApplyConfiguration(new LookupTypeConfiguration());
            modelBuilder.ApplyConfiguration(new LookupsConfiguration()); 
            
            //========== Users Table Configuration================
            modelBuilder.ApplyConfiguration(new EmpMasterConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());

            //========== File Attachment =======================
            modelBuilder.ApplyConfiguration(new AttachmentFilesConfiguration()); 

            return modelBuilder;
        }
    }
}
