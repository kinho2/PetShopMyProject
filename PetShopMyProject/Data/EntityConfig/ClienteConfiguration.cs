using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetShopMyProject.Models;

namespace PetShopMyProject.Data.EntityConfig
{
    public class ClienteConfiguration : IEntityTypeConfiguration <Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("Cliente");
            builder.HasKey(x => x.ClienteId);
        }
    }
}
