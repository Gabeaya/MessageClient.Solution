using System.Collections.Generic;

namespace MessageClient.Models
{
  public class Group
  {
    public Group()
    {
      this.JoinEntities = new HashSet<GroupMessage>();
    }

    public int GroupId { get; set; }
    public string Name { get; set; }

    public virtual ICollection<GroupMessage> JoinEntities { get; set; }
  }
}