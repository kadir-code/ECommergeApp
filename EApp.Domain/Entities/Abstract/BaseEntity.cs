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
        private DateTime _date = DateTime.Now;
        public DateTime? CreateDate
        {
            get => _date;
            set => value = _date;
        }
        public DateTime? ModifiedDate { get; set; }
        public DateTime? RemovedDate { get; set; }
        private Status _status;
        public Status Status
        {
            get => _status;
            set => _status = value;
        }
    }
}
