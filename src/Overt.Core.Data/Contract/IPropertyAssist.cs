using System;
using System.Data;
#if !ASP_NET_CORE
using System.Configuration;
#endif

namespace Overt.Core.Data
{
    /// <summary>
    /// 通用的接口
    /// </summary>
    public interface IPropertyAssist
    {
        #region DbStoreKey
        /// <summary>
        /// 数据库key
        /// </summary>
        string DbStoreKey { get; set; }
        #endregion

        #region TableName
        /// <summary>
        /// 表名生成方法
        /// </summary>
        Func<string> TableNameFunc { get; set; }

        /// <summary>
        /// 创建表的sql语句
        /// 参数：表名
        /// </summary>
        Func<string, string> CreateScriptFunc { get; set; }
        #endregion

        #region ConnectionString
        /// <summary>
        /// 连接方法创建
        /// </summary>

#if ASP_NET_CORE
        Func<bool, string> ConnectionFunc { get; set; }
#else
        Func<bool, ConnectionStringSettings> ConnectionFunc { get; set; }
#endif
        #endregion

        #region Connection
        /// <summary>
        /// 打开连接
        /// </summary>
        /// <returns></returns>
        IDbConnection OpenConnection(bool isMaster = false);
        #endregion

        #region ExecuteScript
        /// <summary>
        /// 执行的sql脚本
        /// </summary>
        string ExecuteScript { get; set; }
        #endregion
    }
}
