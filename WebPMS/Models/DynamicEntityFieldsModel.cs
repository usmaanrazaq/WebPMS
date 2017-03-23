using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using WebPMS;
using WebPMS.Models;

namespace WebPMS.Models
{

    public class DynamicEntityFields : List<DynamicEntityField>
    {

    }
    public class DynamicEntityField
    {

        public DynamicEntityField() { }
        public DynamicEntityField(int ID, string FieldType, string FieldName, string FieldLabel, string FieldMinValue,
            string FieldMaxValue, int FieldDisplayWidth, int FieldDisplayHeight, int FieldParamCodeListID,
            string FieldDisplayControlType, string FieldEditMask, string FieldMaskType, int FieldMaxLength, string FieldValue)
            {
            this.ID = ID;
            this.FieldType = FieldType;
            this.FieldLabel = FieldLabel;
            this.FieldMinValue = FieldMinValue;
            this.FieldMaxValue = FieldMaxValue;
            this.FieldDisplayWidth = FieldDisplayWidth;
            this.FieldDisplayHeight = FieldDisplayHeight;
            this.FieldParamCodeListID = FieldParamCodeListID;
            this.FieldDisplayControlType = FieldDisplayControlType;
            this.FieldEditMask = FieldEditMask;
            this.FieldMaskType = FieldMaskType;
            this.FieldMaxLength = FieldMaxLength;
            this.FieldValue = FieldValue;


        }

        public string FieldDisplayControlType { get;  set; }
        public int FieldDisplayHeight { get;  set; }
        public int FieldDisplayWidth { get;  set; }
        public string FieldEditMask { get;  set; }
        public string FieldLabel { get;  set; }
        public string FieldMaskType { get;  set; }
        public int FieldMaxLength { get;  set; }
        public string FieldMaxValue { get;  set; }
        public string FieldMinValue { get;  set; }
        public int FieldParamCodeListID { get;  set; }
        public string FieldType { get;  set; }
        public string FieldValue { get;  set; }
        public int ID { get;  set; }
    }

}

public static class BuildDynamicEntityFields
{

    public static DynamicEntityFields ViewDynamicEntityFields(string Type, string SubType, int EntityID, string EntityName, int PropertyID, string OrgID, string PersonID)
    {
        DataTable DT = DB.ReadData(Constants.StoredProcedures.Read.uspGetDynamicEntityFields, DB.StoredProcedures.uspGetDynamicEntityFields(Type, SubType, EntityID, EntityName, PropertyID, OrgID, PersonID));
        DynamicEntityFields prop = new DynamicEntityFields();
        if (DT.Rows.Count > 0)
        {
            foreach (DataRow R in DT.Rows)
            {
                prop.Add(BuildDynamicEntityField(R));
            }

        }
        return prop;
    }

    public static DynamicEntityField BuildDynamicEntityField(DataRow dr)
    {
        return new DynamicEntityField(Functions.ToInt32(dr["ID"]), Functions.ToString(dr["FieldType"]), Functions.ToString(dr["FieldName"]),
            Functions.ToString(dr["FieldLabel"]), Functions.ToString(dr["FieldMinValue"]), Functions.ToString(dr["FieldMaxValue"]), Functions.ToInt32(dr["FieldDisplayWidth"]), Functions.ToInt32(dr["FieldDisplayHeight"]), Functions.ToInt32(dr["FieldParmCodeListID"]), Functions.ToString(dr["FieldDisplayControlType"]), Functions.ToString(dr["FieldEditMask"]), Functions.ToString(dr["FieldMaskType"]), Functions.ToInt32(dr["FieldMaxLength"]), Functions.ToString(dr["FieldValue"]));
    }
}
