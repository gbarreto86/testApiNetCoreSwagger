using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Domain.Entities.MaestroModule;
using System.Domain.Interfaces.MaestroModule;
using System.Infrastructure.Tools.Configuration;
using System.Infrastructure.Tools.Extensions;
using System.Persistence.Core;
using System.Threading.Tasks;
using static System.Persistence.Core.ConnectionBase;
using System.Data;

namespace System.Persistence.Data.MaestroModule.Repositories
{
    public class MaestroRepository : IMaestroRepository
    {
        private readonly IOptions<AppSettings> appSettings;
        private readonly IConnectionBase _connectionBase;

        public MaestroRepository(IOptions<AppSettings> appSettings,
                                 IConnectionBase ConnectionBase)
        {
            this.appSettings = appSettings;
            _connectionBase = ConnectionBase;
        }
    
        public Task<IEnumerable<CustomerEntity>> GetCustomer()
        {
            IEnumerable<CustomerEntity> entityResult = null;
            List<SqlParameter> parameters = new List<SqlParameter>();

            try
            {
                using (SqlDataReader dr = (SqlDataReader)_connectionBase.ExecuteByStoredProcedure("dbo.p_GetCustomer", parameters))
                {
                    entityResult = dr.ReadRows<CustomerEntity>();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Task.FromResult(entityResult);
        }

        public Task<IEnumerable<CustomerIdEntity>> GetCustomerByID(CustomerIdRequestEntity objParametros)
        {
            IEnumerable<CustomerIdEntity> entityResult = null;
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@pID", objParametros.customerID));

            try
            {
                using (SqlDataReader dr = (SqlDataReader)_connectionBase.ExecuteByStoredProcedure("dbo.p_GetCustomerByID", parameters))
                {
                    entityResult = dr.ReadRows<CustomerIdEntity>();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Task.FromResult(entityResult);
        }

        public Task<IEnumerable<MessageEntity>> NewCustomer(NewCustomerRequestEntity objParametros)
        {
            IEnumerable<MessageEntity> entityResult = null;
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@pNombre", objParametros.nombre));
            parameters.Add(new SqlParameter("@pApellido", objParametros.apellidos));
            parameters.Add(new SqlParameter("@pNacimiento", objParametros.fec_nacimiento));

            try
            {
                using (SqlDataReader dr = (SqlDataReader)_connectionBase.ExecuteByStoredProcedure("dbo.p_NewCustomer", parameters))
                {
                    entityResult = dr.ReadRows<MessageEntity>();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Task.FromResult(entityResult);
        }
    }
}
