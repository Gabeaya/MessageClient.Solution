using System.Collections.Generic;
using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Microsoft.EntityFrameworkCore;

namespace MessageClient.Models
{
  public class MessageClientContext : DbContext
  {
    public DbSet<Group> Groups { get; set; }
    public DbSet<Message> Messages { get; set; }

    public DbSet<GroupMessage> GroupMessage { get; set; }

    public MessageClientContext(DbContextOptions options) : base(options) {}

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseLazyLoadingProxies();
    }
  }
}