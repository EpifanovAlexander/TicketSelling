using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketSelling.Data.DbModels.Tickets
{
    internal class TicketDbModel
    {




        internal class Map : IEntityTypeConfiguration<TicketDbModel>
        {
            public void Configure(EntityTypeBuilder<TicketDbModel> builder)
            {
                builder.ToTable("segments");

                //builder.Property(it => it.Id)
                //    .HasColumnName("id")
                //    .ValueGeneratedOnAdd();

                //builder.Property(it => it.Login)
                //    .HasColumnName("login");

                //builder.Property(it => it.Email)
                //    .HasColumnName("email");

                //builder.HasKey(it => it.Id).HasName("pk_user_id");
            }
        }
    }
}
