using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoRepository.Dapper
{
    public interface IDapperModel
    {
        long Id { get; set; }

        DateTime UpdateTime { get; set; }

        DateTime InsertTime { get; set; }
    }

    public class DapperModel : IDapperModel
    {
        [Key]
        public long Id { get; set; }

        public DateTime UpdateTime { get; set; }

        public DateTime InsertTime { get; set; }
    }

    public static class IDapperModelExtension
    {
        public static void InitTime(this IDapperModel model)
        {
            model.UpdateTime = DateTime.Now;
            model.InsertTime = DateTime.Now;
        }

        public static void UpdateTime(this IDapperModel model)
        {
            model.UpdateTime = DateTime.Now;
        }
    }
}
