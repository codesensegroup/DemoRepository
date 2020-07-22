using Dapper;
using Dapper.Contrib.Extensions;
using DapperRepository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DemoRepository.Dapper
{
    public interface IMemberRepository
    {
        /// <summary>
        /// 新增成員
        /// </summary>
        void Add(Member member);

        /// <summary>
        /// 取得成員，藉由年齡限制
        /// </summary>
       IEnumerable<Member> Read(int age);
    }

    /// <summary>
    /// 介面型(DDD版本)
    /// </summary>
    public class MemberRepository : DapperRepositoryTemplate, IMemberRepository
    {
        public MemberRepository(Func<IDbTransaction> transaction, int? commandTimeout = null) : base(transaction, commandTimeout)
        {
        }

        public void Add(Member member) => Connection.Insert(member, Transaction, CommandTimeout);

        public  IEnumerable<Member> Read(int age)
        {
            return Connection.Query<Member>("SELECT * FROM Member WHERE Age = ?Age?", new { Age = age});
        }
    }
}
