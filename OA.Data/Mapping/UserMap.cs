using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace OA.Data
{
    public  class UserMap
    {
        public UserMap(EntityTypeBuilder<UserModel> entityBuilder)
        {
            entityBuilder.HasKey(t => t.ID);
            entityBuilder.Property(t => t.Name).IsRequired();
            entityBuilder.Property(t => t.Email).IsRequired();
            entityBuilder.Property(t => t.Password).IsRequired();
        }
    }
}
