using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace System.Persistence.Core
{
    public interface IConnectionBase
    {
        DbParameterCollection ParamsCollectionResult
        {
            get;
            set;
        }

        DbConnection ConnectionGet(ConnectionBase.enuTypeDataBase typeDataBase = ConnectionBase.enuTypeDataBase.SQLFuxionOffix);

        DbDataReader ExecuteByStoredProcedure(
            string nameStore,
            //ref DbParameterCollection z, 
            IEnumerable<DbParameter> parameters = null,
            ConnectionBase.enuTypeDataBase typeDataBase = ConnectionBase.enuTypeDataBase.SQLFuxionOffix,
            ConnectionBase.enuTypeExecute typeExecute = ConnectionBase.enuTypeExecute.ExecuteReader
            );
        DbDataReader ExecuteByStoredProcedureExigoWeb(
           string nameStore,
           //ref DbParameterCollection z, 
           IEnumerable<DbParameter> parameters = null,
           ConnectionBase.enuTypeDataBase typeDataBase = ConnectionBase.enuTypeDataBase.SQLExigoWeb1,
           ConnectionBase.enuTypeExecute typeExecute = ConnectionBase.enuTypeExecute.ExecuteReader
           );
        DbDataReader ExecuteByStoredProcedureFuxion1(
           string nameStore,
           //ref DbParameterCollection z, 
           IEnumerable<DbParameter> parameters = null,
           ConnectionBase.enuTypeDataBase typeDataBase = ConnectionBase.enuTypeDataBase.SQLExigoWeb1,
           ConnectionBase.enuTypeExecute typeExecute = ConnectionBase.enuTypeExecute.ExecuteReader
           );
        DbDataReader ExecuteByStoredProcedurePenny(
           string nameStore,
           //ref DbParameterCollection z, 
           IEnumerable<DbParameter> parameters = null,
           ConnectionBase.enuTypeDataBase typeDataBase = ConnectionBase.enuTypeDataBase.SQLFuxionPenny,
           ConnectionBase.enuTypeExecute typeExecute = ConnectionBase.enuTypeExecute.ExecuteReader
           );
        DbDataReader ExecuteBySentence(string query,
                            ConnectionBase.enuTypeDataBase typeDataBase = ConnectionBase.enuTypeDataBase.SQLFuxionOffix,
                            ConnectionBase.enuTypeExecute typeExecute = ConnectionBase.enuTypeExecute.ExecuteReader);
    }
}
