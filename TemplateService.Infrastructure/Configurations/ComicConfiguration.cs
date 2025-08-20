using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemplateService.Infrastructure.Entities;

namespace TemplateService.Infrastructure.Configurations
{
    public class ComicConfiguration : IEntityTypeConfiguration<ComicEntity>
    {
        public void Configure(EntityTypeBuilder<ComicEntity> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(c => c.Title).IsRequired();
            builder.Property(c => c.Description).IsRequired();
            builder.Property(c => c.Publisher).IsRequired();
            builder.Property(c => c.Authors).IsRequired();  
        }
    }
}
