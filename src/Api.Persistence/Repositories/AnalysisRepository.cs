using Api.application.Interface;
using Api.Domain.Entities;
using Api.Persistence.Context;
using Dapper;
using System.Data;

namespace Api.Persistence.Repositories
{
    public class AnalysisRepository : IAnalysisRepository
    {
        private readonly ApplicationDBContext _context;

        public AnalysisRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Analysis>> ListAnalysis()
        {
            using var connection = _context.CreateConnection;

            var query = "uspAnalysisList";
            
            var Analysis = await connection.QueryAsync<Analysis>(query, commandType:CommandType.StoredProcedure);
            
            return Analysis;   
        }
        public async Task<Analysis> AnalysisById(int AnalysisId)
        {
            using var connection = _context.CreateConnection;
            var query = "uspAnalysisById";
            var parameters = new DynamicParameters();
            parameters.Add("AnalysisId",AnalysisId);

            var Analysis = await connection
                .QueryFirstOrDefaultAsync<Analysis>(query,param:parameters, commandType:CommandType.StoredProcedure);
               
           
            return Analysis;
        }

        public async Task<bool> AnalysisRegister(Analysis analysis)
        {
            using var connection = _context.CreateConnection;
            var query = "uspAnalysisRegister";

            var parameters = new DynamicParameters();
            parameters.Add("Name",analysis.Name);
            parameters.Add("State",analysis.State);
            parameters.Add("AuditCreateDat",DateTime.Now);

            var RecordsAffected = await connection
                .ExecuteAsync(query,param:parameters,commandType:CommandType.StoredProcedure);

            return RecordsAffected > 0;
        }

        public async Task<bool> AnalysisEdit(Analysis analysis)
        {
            using var connection = _context.CreateConnection;
            var query = "uspAnalysisEdit";
            var parameters = new DynamicParameters();
            parameters.Add("AnalysisId",analysis.AnalysisId);
            parameters.Add("Name",analysis.Name);

            var RecordsAffected = await connection.ExecuteAsync(query,param:parameters,commandType:CommandType.StoredProcedure);

            return RecordsAffected > 0;
        }

        public async Task<bool> AnalysisRemove(int AnalysisId)
        {
           
            using var connection = _context.CreateConnection;
            var query = "uspAnalysisRemove";
            var parameters = new DynamicParameters();
            parameters.Add("AnalysisId",AnalysisId);
            
            var RecordsAffected = await connection.ExecuteAsync(query, param: parameters, commandType: CommandType.StoredProcedure);
            return RecordsAffected > 0;
        }
    }
}
