using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using WebPMS;
using WebPMS.Models;

namespace WebPMS.Models
{

    public class PropertyRoomList: List<PropertyRoomItem> { }
    public class PropertyRoomItem
    {

        public PropertyRoomItem(int ID, int Sequence, string Title)
        {
            this.ID = ID;
            this.Sequence = Sequence;
            this.Title = Title;
        }

        public int ID { get; private set; }
        public int Sequence { get; private set; }
        public string Title { get; private set; }
    }
}

public static class BuildPropertyRoomList
{

    public static PropertyRoomList ViewPropertyRoomList(int PropertyID)
    {
        DataTable DT = DB.ReadData(Constants.StoredProcedures.Read.uspGetPropertyRoomList, DB.StoredProcedures.uspGetPropertyRoomList(PropertyID));
        PropertyRoomList prop = new PropertyRoomList();
        if (DT.Rows.Count > 0)
        {
            foreach (DataRow R in DT.Rows)
            {
                prop.Add(BuildPRIByRow(R));
            }

        }
        return prop;
    }


    private static PropertyRoomItem BuildPRIByRow(DataRow dr)
    {
        return new PropertyRoomItem(Functions.ToInt32(dr["ID"]), Functions.ToInt32(dr["Sequence"]), Functions.ToString(dr["Title"]));

    }
}



