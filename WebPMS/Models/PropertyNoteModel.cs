using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using WebPMS;
using WebPMS.Models;

namespace WebPMS.Models
{
    public class PropertyNotes
    {

        public PropertyNotes(string Notes)
        {
            this.Notes = Notes;
        }

        public string Notes { get; set; }
        public string[] NotesSeperated
        {
            get
            {
                var items = this.Notes.Split(new[] { "\r\n" }, StringSplitOptions.None);
                return items;
            }
        }
    }

}

public static class BuildPropertyNotes
{
    public static PropertyNotes ViewPropertyNotes(int ID)
    {
        DataTable DT = DB.ReadData(Constants.StoredProcedures.Read.uspGetPropertyNotes, DB.StoredProcedures.uspGetPropertyNotes(ID));

        if (DT.Rows.Count > 0)
        {
            return BuildPNByRow(DT.Rows[0]);
        }
        return null;
    }


    private static PropertyNotes BuildPNByRow(DataRow dr)
    {
        return new PropertyNotes(Functions.ToString(dr["Notes"]));
    }
}