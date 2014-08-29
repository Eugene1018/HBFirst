using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace FlowSQLServerDAL
{
    public class Flow_DefWorkStepService : FlowIDAL.IFlow_DefWorkStepService
    {
        public bool InsertDefWorkStep(FlowModels.Flow_DefWorkStep model)
        {
            throw new NotImplementedException();
        }

        public bool DeleteDefWorkStep(FlowModels.Flow_DefWorkStep model)
        {
            throw new NotImplementedException();
        }

        public bool UpdateDefWorkStep(FlowModels.Flow_DefWorkStep model)
        {
            throw new NotImplementedException();
        }

        public List<FlowModels.Flow_DefWorkStep> GetAllDefWorkSteps()
        {
            throw new NotImplementedException();
        }

        public List<FlowModels.Flow_DefWorkStep> GetSubDefWorkStepByFlowID(string FlowID)
        {

            throw new NotImplementedException();
        }

        /// <summary>
        /// 获取步骤ID,节点人员
        /// </summary>
        /// <param name="FN_FLOW_ID"></param>
        /// <param name="FN_NODE_ID"></param>
        /// <param name="IsBegin"></param>
        /// <returns></returns>
        public DataSet GetSubDefWorkStepInfo(string FN_FlowID, string FN_StepID, bool IsBegin)
        {

            StringBuilder sql = new StringBuilder();
            DataSet ds = new DataSet();
            if (!IsBegin)
            {
                sql.AppendFormat(@"DECLARE @DefStepID VARCHAR(250)
                                   Select @DefStepID=Fn_DefStepID from dbo.Flow_WorkStep where Fn_StepID='{0}';
                                   SELECT * from  Flow_DefWorkStep where FN_STEPID in (@DefStepID);", FN_StepID);
            }
            else
            {
                sql.AppendFormat(@"DECLARE @NextDefStepID VARCHAR(250);
                                    SELECT  @NextDefStepID=FN_NextDefStepID FROM dbo.Flow_DefWorkAction WHERE FN_DefStepID=(SELECT FN_STEPID FROM Flow_DefWorkStep
                                    WHERE FN_DefFlowID='{0}' AND FN_STEPTYPE='BeginStep');
                                    SELECT * FROM  Flow_DefWorkStep where FN_STEPID in (@NextDefStepID);
                        ", FN_FlowID);
            }           
            DataTable dt_step = DBHelper.Query(sql.ToString()).Tables[0];
            dt_step.TableName = "dt_step";
            dt_step.DataSet.Tables.RemoveAt(0);
            ds.Tables.Add(dt_step);
            if (dt_step.Rows.Count > 0 && dt_step.Rows[0]["FN_StepRole"].ToString() != "")
            {
                string stepRole = dt_step.Rows[0]["FN_StepRole"].ToString();
                if (stepRole.TrimStart().StartsWith("select", true, System.Globalization.CultureInfo.CurrentCulture))
                {
                    try
                    {
                        DataTable dt_role = DBHelper.Query(stepRole).Tables[0];
                        dt_role.TableName = "dt_role";
                        if (dt_role.Rows.Count > 0)
                        {
                            dt_role.DataSet.Tables.RemoveAt(0);
                            ds.Tables.Add(dt_role);
                        }
                    }
                    catch (Exception ex)
                    {

                    }
                }
            }
            return ds;
        }
    }
}
