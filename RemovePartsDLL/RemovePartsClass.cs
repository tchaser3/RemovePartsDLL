/* Title:           Remove Parts Class
 * Date:            2-8-17
 * Author:          Terry Holmes
 * 
 * Description:     This is the class for removing parts */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewEventLogDLL;

namespace RemovePartsDLL
{
    public class RemovePartsClass
    {
        //setting up the classes
        EventLogClass TheEventLogClass = new EventLogClass();

        //setting up the data
        RemovedPartsIDDataSet aRemovedPartsIDDataSet;
        RemovedPartsIDDataSetTableAdapters.removedpartsidTableAdapter aRemovedPartsIDTableAdapter;

        RemovedPartsDataSet aRemovedPartsDataSet;
        RemovedPartsDataSetTableAdapters.removedpartsTableAdapter aRemovedPartsTableAdapter;

        public RemovedPartsDataSet GetRemovedPartsInfo()
        {
            try
            {
                aRemovedPartsDataSet = new RemovedPartsDataSet();
                aRemovedPartsTableAdapter = new RemovedPartsDataSetTableAdapters.removedpartsTableAdapter();
                aRemovedPartsTableAdapter.Fill(aRemovedPartsDataSet.removedparts);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Remove Parts Class Get Removed Parts Info " + Ex.Message);
            }

            return aRemovedPartsDataSet;
        }
        public void UpdateRemovedPartsDB(RemovedPartsDataSet aRemovedPartsDataSet)
        {
            try
            {
                aRemovedPartsTableAdapter = new RemovedPartsDataSetTableAdapters.removedpartsTableAdapter();
                aRemovedPartsTableAdapter.Update(aRemovedPartsDataSet.removedparts);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Remove Parts Class Update Removed Parts DB " + Ex.Message);
            }
        }
        public int CreateRemovePartsID()
        {
            int intTransactionID = 0;

            try
            {
                aRemovedPartsIDDataSet = new RemovedPartsIDDataSet();
                aRemovedPartsIDTableAdapter = new RemovedPartsIDDataSetTableAdapters.removedpartsidTableAdapter();
                aRemovedPartsIDTableAdapter.Fill(aRemovedPartsIDDataSet.removedpartsid);

                intTransactionID = aRemovedPartsIDDataSet.removedpartsid[0].CreatedTransactionID;
                intTransactionID++;

                aRemovedPartsIDDataSet.removedpartsid[0].TransactionID = intTransactionID;
                aRemovedPartsIDTableAdapter.Update(aRemovedPartsIDDataSet.removedpartsid);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Remove Parts Class Create Remove Parts ID " + Ex.Message);
            }

            //returning the value
            return intTransactionID;
        }
    }
}
