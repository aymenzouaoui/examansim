using EX.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EX.Data.Configuration
{
    public class FluentApiConfiguration : IEntityTypeConfiguration<Presation>
    {
        public void Configure(EntityTypeBuilder<Presation> builder)
        {

            builder.HasKey(r => new { r.clientFK, r.prestataireFK,r.heureDeut });

            // Foreign Key with fluent API
            builder.HasOne(r => r.prestataire)
              .WithMany(p => p.presations)
              .HasForeignKey(r => r.prestataireFK);

            builder.HasOne(r => r.client)
                .WithMany(f => f.presationsC)
                .HasForeignKey(r => r.clientFK)
                .OnDelete(DeleteBehavior.Cascade);

           
            builder.Property(p => p.heureDeut).HasColumnName("HeureRDV").IsRequired();
                

            
           
        }
    }
}

