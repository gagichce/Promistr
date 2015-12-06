using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Promistr.Models
{
    public class Promise
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string SourceUrl { get; set; }
        public int Upvotes { get; set; }
        public int Downvotes { get; set; }
        public DateTime TimeCreated { get; set; }
        public DateTime? TimeDeleted { get; set; }

        public virtual ICollection<PromiseStatus> PromiseStatuses { get; set; }
        public virtual ICollection<PromiseComment> PromiseComments { get; set; }
        public virtual ICollection<CategoryPromise> CategoryPromises { get; set; }
    }

    public class PromiseComment
    {
        public int Id { get; set; }
        public string Comment { get; set; }
        public string ApplicationUserId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
        public int PromiseId { get; set; }
        public virtual Promise Promise { get; set; }
        public DateTime TimeAdded { get; set; }
        public DateTime? TimeDeleted { get; set; }
    }

    public class PromiseStatus
    {
        public int Id { get; set; }
        public int PromiseId { get; set; }
        public virtual Promise Promise { get; set; }
        public PromiseStatusEnum PromiseStatusEnum { get; set; }
        public DateTime TimeAdded { get; set; }
        public DateTime? TimeDeleted { get; set; }
    }

    public enum PromiseStatusEnum
    {
        Unknown,
        Promised,
        InProgress,
        Compromised,
        Completed,
        Failed
    }
}