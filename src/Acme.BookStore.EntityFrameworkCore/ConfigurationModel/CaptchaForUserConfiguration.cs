using Acme.BookStore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.BookStore.ConfigurationModel
{
    public class CaptchaForUserConfiguration : IEntityTypeConfiguration<CaptchaForUser>
    {
        public void Configure(EntityTypeBuilder<CaptchaForUser> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Answer).IsRequired();
            builder.Property(x => x.IsUsed).IsRequired();

        }
    }
}
