using EApp.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EApp.Domain.Entities.Abstract
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        private DateTime _date=DateTime.Now;
        public DateTime? CreateDate { get { return _date; } set { value = _date; } }
        public DateTime? ModifiedDate { get; set; }
        public DateTime? RemovedDate { get; set; }
        private Status _status= Status.Active;
        public Status Status { get { return _status; } set { value = _status; } }
    }
}
