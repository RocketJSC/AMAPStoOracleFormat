using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMAPStoOracleFormat
{
    class Program
    {
        static void Main(string[] args)
        {
            String path = @"C:\oracle";
            Process_Normal(path);
            //Process_All_CDF(path);
            Console.WriteLine("Finished.  Press <ENTER> to Exit");
            Console.ReadLine();
        }
        private static void Process_All_CDF(string path)
        {
            Process_CDF(path, "newcdf_09.txt", "cdffile_09.txt");
            Process_CDF(path, "newcdf_10.txt", "cdffile_10.txt");
            Process_CDF(path, "newcdf_11.txt", "cdffile_11.txt");
            Process_CDF(path, "newcdf_12.txt", "cdffile_12.txt");
            Process_CDF(path, "newcdf_13.txt", "cdffile_13.txt");
            Process_CDF(path, "newcdf_14.txt", "cdffile_14.txt");
            Process_CDF(path, "newcdf_15.txt", "cdffile_15.txt");
            Process_CDF(path, "newcdf_16.txt", "cdffile_16.txt");
        }
        private static void Process_Normal(string path)
        {
            Process_BMF(path);
            Process_CCF(path);
            Process_DMF(path);
            Process_IMF(path);
            Process_LDF(path);
            Process_LMF(path);
            Process_LOF(path);
            Process_LTF(path);
            Process_OIF(path);
            Process_RSF(path);
            Process_RVF(path);
            Process_SPF(path);
            Console.WriteLine(' ');
            Process_COS(path);
            Process_ICF(path);
            Process_MRF(path);
            Console.WriteLine(' ');
            Process_CDF(path, "newcdf.txt", "cdffile.txt");
            Process_CTL(path);
            Process_TGF(path);
            Process_TLF(path);
            Process_ADR(path);
            Console.WriteLine(' ');
            Process_MIF(path);
            Console.WriteLine(' ');
            Process_VNF(path);
            Process_PIF(path);
            Process_VIF(path);
            Process_CTF(path);
            Process_LIF(path);
            Process_POF(path);
            Process_PQF(path);
            Process_RCF(path);
        }

        private static void Process_BMF(string path)
        {
            Console.WriteLine("Processing BMF");
            StreamReader sr = new StreamReader(System.IO.Path.Combine(path, "newbmf.txt"));
            StringBuilder outline = new StringBuilder();
            using (FileStream fs = new FileStream(System.IO.Path.Combine(path, "bmffile.txt"), FileMode.Create))
            {
                using (StreamWriter sw = new StreamWriter(fs, Encoding.UTF8))
                {
                    outline.Clear();
                    outline.Append("'Assy_Item_Nbr'|");
                    outline.Append("'Comp_Type'|");
                    outline.Append("'Comp_Usage'|");
                    outline.Append("'Qty'|");
                    outline.Append("'Qty_Type'|");
                    outline.Append("'Qty_Scale_Fctr'|");
                    outline.Append("'Opt_Pct'|");
                    outline.Append("'Scrap_Pct'|");
                    outline.Append("'Dem_Ctl'|");
                    outline.Append("'Issue_Ctl'|");
                    outline.Append("'Comp_LT_Ind'|");
                    outline.Append("'Comp_LT_Offset'|");
                    outline.Append("'Work_Center'|");
                    outline.Append("'Operation'|");
                    outline.Append("'Effect_Date_In'|");
                    outline.Append("'Eng_Ord_Nbr_In'|");
                    outline.Append("'Rev_Level_Out'|");
                    outline.Append("'Effect_Date_Out'|");
                    outline.Append("'Eng_Ord_Nbr_Out'|");
                    outline.Append("'BMS_Date'|");
                    outline.Append("'Text_Id'|");
                    outline.Append("'PRS_Anal_Code'|");
                    outline.Append("'Cum_Yield_Fctr'|");
                    outline.Append("'AMAPS_Space_32'|");
                    outline.Append("'User_Space_16'|");
                    outline.Append("'Find_Nbr'|");
                    outline.Append("'Comp_Item_Nbr'|");
                    outline.Append("'Rev_Level_In'|");
                    sw.WriteLine(outline.ToString());
                    while (sr.Peek() >= 0)
                    {
                        String inline = sr.ReadLine();
                        outline.Clear();
                        outline.Append("'" + inline.Substring(0, 16).Trim() + "'|"); //Assy-Item-Nbr
                        outline.Append("'" + inline.Substring(16, 2).Trim() + "'|"); //Comp-Type
                        outline.Append("'" + inline.Substring(18, 2).Trim() + "'|"); //Comp-Usage
                        outline.Append(inline.Substring(20, 9).Trim() + "|"); //Qty
                        outline.Append("'" + inline.Substring(29, 2).Trim() + "'|"); //Qty-Type
                        outline.Append(inline.Substring(31, 1).Trim() + "|"); //Qty-Scale-Fctr
                        outline.Append(inline.Substring(32, 2).Trim() + "|"); //Opt-Pct
                        outline.Append(inline.Substring(34, 4).Trim() + "|"); //Scrap-Pct
                        outline.Append("'" + inline.Substring(38, 2).Trim() + "'|"); //Dem-Ctl
                        outline.Append("'" + inline.Substring(40, 2).Trim() + "'|"); //Issue-Ctl
                        outline.Append("'" + inline.Substring(42, 2).Trim() + "'|"); //Comp-LT-Ind
                        outline.Append(inline.Substring(44, 3).Trim() + "|"); //Comp-Offset
                        outline.Append("'" + inline.Substring(47, 10).Trim() + "'|"); //Work-Center
                        outline.Append("'" + inline.Substring(57, 6).Trim() + "'|"); //Operation
                        outline.Append("'" + (inline.Substring(63, 8).Trim() != "" ? FormatDate(inline.Substring(63, 8).Trim()) : "") + "'|"); //Effect-Date-In
                        outline.Append("'" + inline.Substring(71, 8).Trim() + "'|"); //Eng-Ord-Nbr-In
                        outline.Append("'" + inline.Substring(79, 2).Trim() + "'|"); //Rev-Lvl-Out
                        outline.Append("'" + (inline.Substring(81, 8).Trim() != "" ? FormatDate(inline.Substring(81, 8).Trim()) : "") + "'|"); //Effect-Date-Out
                        outline.Append("'" + inline.Substring(89, 8).Trim() + "'|"); //Eng-Ord-Nbr-Out
                        outline.Append("'" + (inline.Substring(97, 8).Trim() != "" ? FormatDate(inline.Substring(97, 8).Trim()) : "") + "'|"); //BMS-Out
                        outline.Append("'" + inline.Substring(105,16).Trim() + "'|"); //Text-Id
                        outline.Append("'" + inline.Substring(121, 2).Trim() + "'|"); //PRS-Anal-Code
                        outline.Append(inline.Substring(13, 10).Trim() + "|"); //Cum-Yield-Fctr
                        outline.Append("'" + inline.Substring(133, 32).Trim() + "'|"); //AMAPS-Space-32
                        outline.Append("'" + inline.Substring(165, 16).Trim() + "'|"); //User-Space-16
                        outline.Append("'" + inline.Substring(181, 6).Trim() + "'|"); //Find-Nbr
                        outline.Append("'" + inline.Substring(187, 16).Trim() + "'|"); //Comp-Item-Nbr
                        if (inline.Length > 203)
                        {
                            outline.Append("'" + inline.Substring(203, inline.Length >= 205 ? 2 : 2 - (205 - inline.Length)).Trim() + "'|"); //Rev-Level-In
                        }
                        //Console.WriteLine(inline);
                        sw.WriteLine(outline.ToString());
                        //Console.WriteLine(outline.ToString());
                    }
                }
            }
            sr.Close();
        }
        private static void Process_CCF(string path)
        {
            Console.WriteLine("Processing CCF");
            StreamReader sr = new StreamReader(System.IO.Path.Combine(path, "newccf.txt"));
            StringBuilder outline = new StringBuilder();
            using (FileStream fs = new FileStream(System.IO.Path.Combine(path, "ccffile.txt"), FileMode.Create))
            {
                using (StreamWriter sw = new StreamWriter(fs, Encoding.UTF8))
                {
                    outline.Clear();
                    outline.Append("'Order_Nbr'|");
                    outline.Append("'LTS_Date'|");
                    outline.Append("'Text_Id'|");
                    outline.Append("'User_Space_10'|");
                    outline.Append("'Comp_Lot_Item'|");
                    sw.WriteLine(outline.ToString());
                    while (sr.Peek() >= 0)
                    {
                        String inline = sr.ReadLine();
                        outline.Clear();
                        outline.Append("'" + inline.Substring(0, 16).Trim() + "'|"); //Order-Nbr
                        outline.Append("'" + (inline.Substring(16, 8).Trim() != "" ? FormatDate(inline.Substring(16, 8).Trim()) : "") + "'|"); //LTS-Date
                        outline.Append("'" + inline.Substring(24, 16).Trim() + "'|"); //Text-Id
                        outline.Append("'" + inline.Substring(40, 10).Trim() + "'|"); //User-Space-10
                        if (inline.Length > 50)
                        {
                            outline.Append("'" + inline.Substring(50, inline.Length >= 82 ? 32 : 32 - (82 - inline.Length)).Trim() + "'|"); //Comp-Lot-Item
                        }
                        //Console.WriteLine(inline);
                        sw.WriteLine(outline.ToString());
                        //Console.WriteLine(outline.ToString());
                    }
                }
            }
            sr.Close();
        }
        private static void Process_DMF(string path)
        {
            Console.WriteLine("Processing DMF");
            StreamReader sr = new StreamReader(System.IO.Path.Combine(path, "newdmf.txt"));
            StringBuilder outline = new StringBuilder();
            using (FileStream fs = new FileStream(System.IO.Path.Combine(path, "dmffile.txt"), FileMode.Create))
            {
                using (StreamWriter sw = new StreamWriter(fs, Encoding.UTF8))
                {
                    outline.Clear();
                    outline.Append("'Order_Nbr'|");
                    outline.Append("'Order_Type'|");
                    outline.Append("'Order_Status'|");
                    outline.Append("'SMP_Ind'|");
                    outline.Append("'MCS_Date'|");
                    outline.Append("'Pick_Date'|");
                    outline.Append("'Req_Fraction'|");
                    outline.Append("'Req_Qty'|");
                    outline.Append("'Rel_Qty'|");
                    outline.Append("'Issued_Qty'|");
                    outline.Append("'Scrapped_Qty'|");
                    outline.Append("'Fixed_Qty'|");
                    outline.Append("'Qty_Type'|");
                    outline.Append("'Comp_Type'|");
                    outline.Append("'Issue_Ctl'|");
                    outline.Append("'Comp_LT_Ind'|");
                    outline.Append("'Comp_LT_Offset'|");
                    outline.Append("'Work_Center'|");
                    outline.Append("'Operation'|");
                    outline.Append("'Rev_Level'|");
                    outline.Append("'Effect_Date_In'|");
                    outline.Append("'Effect_Date_Out'|");
                    outline.Append("'Find_Nbr'|");
                    outline.Append("'Assy_Item_Nbr'|");
                    outline.Append("'Par_Find_Nbr'|");
                    outline.Append("'Par_Item_Nbr'|");
                    outline.Append("'Short_Cond_Code'|");
                    outline.Append("'Short_Cond_Date'|");
                    outline.Append("'Auth_Issue_Qty'|");
                    outline.Append("'Cut_Date'|");
                    outline.Append("'Scrap_Pct'|");
                    outline.Append("'Text_Id'|");
                    outline.Append("'AMAPS_Space_32'|");
                    outline.Append("'User_Space_16'|");
                    outline.Append("'Item_Nbr'|");
                    sw.WriteLine(outline.ToString());
                    while (sr.Peek() >= 0)
                    {
                        String inline = sr.ReadLine();
                        outline.Clear();
                        outline.Append("'" + inline.Substring(0, 16).Trim() + "'|"); //Order-Nbr
                        outline.Append("'" + inline.Substring(16, 2).Trim() + "'|"); //Order-Type
                        outline.Append("'" + inline.Substring(18, 2).Trim() + "'|"); //Order-Status
                        outline.Append("'" + inline.Substring(20, 2).Trim() + "'|"); //SMP-Ind
                        outline.Append("'" + (inline.Substring(22, 8).Trim() != "" ? FormatDate(inline.Substring(22, 8).Trim()) : "") + "'|"); //MCS-Date
                        outline.Append("'" + (inline.Substring(30, 8).Trim() != "" ? FormatDate(inline.Substring(30, 8).Trim()) : "") + "'|"); //Pick-Date
                        outline.Append(inline.Substring(38, 8).Trim() + "|"); //Req-Fraction
                        outline.Append(inline.Substring(46, 17).Trim() + "|"); //Req-Qty
                        outline.Append(inline.Substring(63, 17).Trim() + "|"); //Rel-Qty
                        outline.Append(inline.Substring(80, 17).Trim() + "|"); //Issued-Qty
                        outline.Append(inline.Substring(97, 17).Trim() + "|"); //Scrapped-Qty
                        outline.Append(inline.Substring(114, 17).Trim() + "|"); //Fixed-Qty
                        outline.Append("'" + inline.Substring(131, 2).Trim() + "'|"); //Qty-Type
                        outline.Append("'" + inline.Substring(133, 2).Trim() + "'|"); //Comp-Type
                        outline.Append("'" + inline.Substring(135, 2).Trim() + "'|"); //Issue-Ctl
                        outline.Append("'" + inline.Substring(137, 2).Trim() + "'|"); //Comp-LT-Ind
                        outline.Append(inline.Substring(139, 3).Trim() + "|"); //Comp-LT-Offset
                        outline.Append("'" + inline.Substring(142, 10).Trim() + "'|"); //Work-Center
                        outline.Append("'" + inline.Substring(152, 6).Trim() + "'|"); //Operation
                        outline.Append("'" + inline.Substring(158, 2).Trim() + "'|"); //Rev-Level
                        outline.Append("'" + (inline.Substring(160, 8).Trim() != "" ? FormatDate(inline.Substring(160, 8).Trim()) : "") + "'|"); //Effect-Date-Inn
                        outline.Append("'" + (inline.Substring(168, 8).Trim() != "" ? FormatDate(inline.Substring(168, 8).Trim()) : "") + "'|"); //Effect-Date-Out
                        outline.Append("'" + inline.Substring(176, 6).Trim() + "'|"); //Find-Nbr
                        outline.Append("'" + inline.Substring(182, 16).Trim() + "'|"); //Assy-Item-Nbr
                        outline.Append("'" + inline.Substring(198, 6).Trim() + "'|"); //Par-Find-Nbr
                        outline.Append("'" + inline.Substring(204, 16).Trim() + "'|"); //Par-Item-Nbr
                        outline.Append("'" + inline.Substring(220, 2).Trim() + "'|"); //Short-Cond-Code
                        outline.Append("'" + (inline.Substring(222, 8).Trim() != "" ? FormatDate(inline.Substring(222, 8).Trim()) : "") + "'|"); //Short-Cond-Date
                        outline.Append(inline.Substring(230, 17).Trim() + "|"); //Auth-Issue-Qty
                        outline.Append("'" + (inline.Substring(247, 8).Trim() != "" ? FormatDate(inline.Substring(247, 8).Trim()) : "") + "'|"); //Cut-Date
                        outline.Append(inline.Substring(255, 4).Trim() + "|"); //Scrap-Pct
                        outline.Append("'" + inline.Substring(259, 16).Trim() + "'|"); //Text-Id
                        outline.Append("'" + inline.Substring(275, 32).Trim() + "'|"); //AMAPS-Space-32
                        outline.Append("'" + inline.Substring(307, 16).Trim() + "'|"); //User-Space-16
                        if (inline.Length > 323)
                        {
                            outline.Append("'" + inline.Substring(323, inline.Length >= 339 ? 16 : 16 - (339 - inline.Length)).Trim() + "'|"); //Item-Nbr
                        }
                        //Console.WriteLine(inline);
                        sw.WriteLine(outline.ToString());
                        //Console.WriteLine(outline.ToString());
                    }
                }
            }
            sr.Close();
        }
        private static void Process_IMF(string path)
        {
            Console.WriteLine("Processing IMF");
            StreamReader sr = new StreamReader(System.IO.Path.Combine(path, "newimf.txt"));
            StringBuilder outline = new StringBuilder();
            using (FileStream fs = new FileStream(System.IO.Path.Combine(path, "imffile.txt"), FileMode.Create))
            {
                using (StreamWriter sw = new StreamWriter(fs, Encoding.UTF8))
                {
                    outline.Clear();
                    outline.Append("'Item_Nbr'|");
                    outline.Append("'Item_Type'|");
                    outline.Append("'Item_Class'|");
                    outline.Append("'Item_STatus'|");
                    outline.Append("'Unit_Meas'|");
                    outline.Append("'Item_Desc'|");
                    outline.Append("'Item_Desc_2'|");
                    outline.Append("'Unit_Weight'|");
                    outline.Append("'Net_Weight'|");
                    outline.Append("'Gross_Weight'|");
                    outline.Append("'Commodity_Code'|");
                    outline.Append("'Design_Source'|");
                    outline.Append("'Drawing_Nbr'|");
                    outline.Append("'Drawing_Size'|");
                    outline.Append("'Eng_Rev_Level'|");
                    outline.Append("'Eng_Rev_Date'|");
                    outline.Append("'Eng_Order_Nbr'|");
                    outline.Append("'Mfg_Rev_Level'|");
                    outline.Append("'Mfg_Rev_Date'|");
                    outline.Append("'Mfg_Order_Nbr'|");
                    outline.Append("'Low_Level_Code'|");
                    outline.Append("'BMS_Anal_Date'|");
                    outline.Append("'BMS_Date'|");
                    outline.Append("'Proc_Id_Date'|");
                    outline.Append("'Proc_Id_Time'|");
                    outline.Append("'Wk_Qty'|");
                    outline.Append("'Wk_Cost_Chg'|");
                    outline.Append("'Wk_Lvl_Ind'|");
                    outline.Append("'WK_Map'|");
                    outline.Append("'Sum_Rpt_Ctl'|");
                    outline.Append("'Eng_Text_Id'|");
                    outline.Append("'Rout_Recost_Cd'|");
                    outline.Append("'PRS_Anal_Code'|");
                    outline.Append("'PRS_Anal_Ind'|");
                    outline.Append("'Cum_Yield_Fctr'|");
                    outline.Append("'Cost_Ctl_Code'|");
                    outline.Append("'Inv_Cst_Per_Unt'|");
                    outline.Append("'CDS_Date'|");
                    outline.Append("'Inv_Cat_Code'|");
                    outline.Append("'GL_Code'|");
                    outline.Append("'Prod_Ovhd_Type'|");
                    outline.Append("'Acct_Text_Id'|");
                    outline.Append("'Cost_Rollup_Cd'|");
                    outline.Append("'Std_Ord_Qty'|");
                    outline.Append("'Item_Acct_Char1'|");
                    outline.Append("'Item_Acct_Char2'|");
                    outline.Append("'Item_Acct_Char3'|");
                    outline.Append("'Cost_Analyst_Id'|");
                    outline.Append("'Planner'|");
                    outline.Append("'Buyer'|");
                    outline.Append("'Shop_Planner_Id'|");
                    outline.Append("'Make_Buy_Code'|");
                    outline.Append("'Dem_Ctl'|");
                    outline.Append("'Issue_Ctl'|");
                    outline.Append("'MRP_Dem_Pol'|");
                    outline.Append("'Dist_Loc'|");
                    outline.Append("'Rcpt_Qty_Code'|");
                    outline.Append("'Cycle_Count_Int'|");
                    outline.Append("'Cycle_Count_Dte'|");
                    outline.Append("'ABC_Class_Code'|");
                    outline.Append("'Work_Center'|");
                    outline.Append("'MCS_Anal_Date'|");
                    outline.Append("'MRP_Anal_Date'|");
                    outline.Append("'MCS_Date'|");
                    outline.Append("'Use_Up_Eff_Ind'|");
                    outline.Append("'Planner_Text_Id'|");
                    outline.Append("'Alt_Supply_Ct'|");
                    outline.Append("'Loc_Ctl_Pol'|");
                    outline.Append("'Rcpt_Mixing_Pol'|");
                    outline.Append("'Ord_Pol'|");
                    outline.Append("'Ord_Point_Qty'|");
                    outline.Append("'Safe_Stk_Pol'|");
                    outline.Append("'Safe_Stk_Qty'|");
                    outline.Append("'Fixed_Ord_Qty'|");
                    outline.Append("'Min_Ord_Qty'|");
                    outline.Append("'Max_Ord_Qty'|");
                    outline.Append("'Mult_Ord_Qty'|");
                    outline.Append("'Min_Ord_Qty_Mod'|");
                    outline.Append("'Max_Ord_Qty_Mod'|");
                    outline.Append("'Carry_Cost_Amt'|");
                    outline.Append("'Carry_Cost_Pct'|");
                    outline.Append("'Setup_Cost'|");
                    outline.Append("'Shrink_Pct'|");
                    outline.Append("'Avg_Order_Qty'|");
                    outline.Append("'Move_Lead_Time'|");
                    outline.Append("'Queue_Lead_Time'|");
                    outline.Append("'Var_Lead_Time'|");
                    outline.Append("'Fixed_Lead_Time'|");
                    outline.Append("'Lt_Ovr_Ind'|");
                    outline.Append("'Mfg_Planner_Tme'|");
                    outline.Append("'Mfg_Release_Tme'|");
                    outline.Append("'Mfg_Pick_Time'|");
                    outline.Append("'Pur_Planner_Time'|");
                    outline.Append("'Pur_Buyer_Time'|");
                    outline.Append("'Pur_Vendor_Time'|");
                    outline.Append("'Pur_Recv_Time'|");
                    outline.Append("'Pur_Insp_Time'|");
                    outline.Append("'PRS_Date'|");
                    outline.Append("'On_Hand_Qty'|");
                    outline.Append("'In_Inspect_Qty'|");
                    outline.Append("'In_MRB_Qty'|");
                    outline.Append("'In_Transit_Qty'|");
                    outline.Append("'Floor_Stock_Qty'|");
                    outline.Append("'Quarantined_Qty'|");
                    outline.Append("'Rejected_Qty'|");
                    outline.Append("'Avail_Qtys_1'|");
                    outline.Append("'Avail_Qtys_2'|");
                    outline.Append("'Avail_Qtys_3'|");
                    outline.Append("'Avail_Qtys_4'|");
                    outline.Append("'Avail_Qtys_5'|");
                    outline.Append("'Sch_Qty'|");
                    outline.Append("'Ship_Qty'|");
                    outline.Append("'Pur_Qty'|");
                    outline.Append("'Mfg_Qty'|");
                    outline.Append("'Used_Qty'|");
                    outline.Append("'Adj_Qty'|");
                    outline.Append("'Scrap_Qty'|");
                    outline.Append("'Lot_Nbr_Policy'|");
                    outline.Append("'Lot-Mixing_Pol'|");
                    outline.Append("'LTS_Ind'|");
                    outline.Append("'Expire_Def_Days'|");
                    outline.Append("'Retest_Def_Days'|");
                    outline.Append("'Last_Lot_TH_Qty'|");
                    outline.Append("'Last_Loc_TH_Qty'|");
                    outline.Append("'Neg_Bal_Allowed'|");
                    outline.Append("'Ovr_Iss_Tol_Pct'|");
                    outline.Append("'SMP_Ind'|");
                    //outline.Append("'Anl_Proc_Id'|");
                    outline.Append("'Msg_210_Ind'|");
                    outline.Append("'Msg_310_Ind'|");
                    outline.Append("'Msg_320_Ind'|");
                    outline.Append("'Msg_330_Ind'|");
                    outline.Append("'Daily_Rate_Qty'|");
                    outline.Append("'BI_Rpt_Id'|");
                    outline.Append("'BI_Hor_Opt'|");
                    outline.Append("'BI_Hor-Days'|");
                    outline.Append("'BI_Hor_Sch'|");
                    outline.Append("'BI_SS_Pct'|");
                    outline.Append("'BI_Mult_Qty'|");
                    outline.Append("'Item_Qty_Acc'|");
                    outline.Append("'Wip_Qty'|");
                    outline.Append("'FG_Qty'|");
                    outline.Append("'Commod_Frt_Code'|");
                    outline.Append("'FG_Class'|");
                    outline.Append("'Tax_Ind'|");
                    outline.Append("'Product_Line_Cd'|");
                    outline.Append("'Product_Cat_Cd'|");
                    outline.Append("'Product_Mkt_Cd'|");
                    outline.Append("'Commission_Code'|");
                    //outline.Append("'Flags_8'|");
                    outline.Append("'Unit_Cube'|");
                    outline.Append("'Unit_Base_Price'|");
                    //outline.Append("'FG_Dist_Qty'|");
                    //outline.Append("'FG_Dist_Mrb_Qty'|");
                    //outline.Append("'OMS_Date'|");
                    //outline.Append("'Fin_Text_Id'|");
                    outline.Append("'AMAPS_Space_16'|");
                    outline.Append("'User_Space_12'|");
                    sw.WriteLine(outline.ToString());
                    while (sr.Peek() >= 0)
                    {
                        String inline = sr.ReadLine();
                        outline.Clear();
                        outline.Append("'" + inline.Substring(0, 16).Trim() + "'|"); //Item-Nbr
                        outline.Append("'" + inline.Substring(16, 2).Trim() + "'|"); //Item-Type
                        outline.Append("'" + inline.Substring(18, 2).Trim() + "'|"); //Item-Class
                        outline.Append("'" + inline.Substring(20, 2).Trim() + "'|"); //Item-Status
                        outline.Append("'" + inline.Substring(22, 2).Trim() + "'|"); //Unit-Meas
                        outline.Append("'" + inline.Substring(24, 26).Trim() + "'|"); //Item-Desc
                        outline.Append("'" + inline.Substring(50, 26).Trim() + "'|"); //Item-Desc-2
                        outline.Append("'" + inline.Substring(76, 2).Trim() + "'|"); //Unit-Weight
                        outline.Append(inline.Substring(78, 7).Trim() + "|"); //Net-Weight
                        outline.Append(inline.Substring(85, 7).Trim() + "|"); //Gross-Weight
                        outline.Append("'" + inline.Substring(92, 14).Trim() + "'|"); //Commodity-Code
                        outline.Append("'" + inline.Substring(106, 2).Trim() + "'|"); //Design-Source
                        outline.Append("'" + inline.Substring(108, 16).Trim() + "'|"); //Drawing-Nbr
                        outline.Append("'" + inline.Substring(124, 2).Trim() + "'|"); //Drawing-Size
                        outline.Append("'" + inline.Substring(126, 2).Trim() + "'|"); //Eng-Rev-Level
                        outline.Append("'" + (inline.Substring(128, 8).Trim() != "" ? FormatDate(inline.Substring(128, 8).Trim()) : "") + "'|"); //Eng-Rev-Date
                        outline.Append("'" + inline.Substring(136, 8).Trim() + "'|"); //Eng-Order-Nbr
                        outline.Append("'" + inline.Substring(144, 2).Trim() + "'|"); //Mfg-Rev-Level
                        outline.Append("'" + (inline.Substring(146, 8).Trim() != "" ? FormatDate(inline.Substring(146, 8).Trim()) : "") + "'|"); //Mfg-Rev-Date
                        outline.Append("'" + inline.Substring(154, 8).Trim() + "'|"); //Mfg-Order-Nbr
                        outline.Append(inline.Substring(162, 3).Trim() + "|"); //Low-Level-Code
                        outline.Append("'" + (inline.Substring(165, 8).Trim() != "" ? FormatDate(inline.Substring(165, 8).Trim()) : "") + "'|"); //BMS-Anal-Date
                        outline.Append("'" + (inline.Substring(173, 8).Trim() != "" ? FormatDate(inline.Substring(173, 8).Trim()) : "") + "'|"); //BMS-Date
                        outline.Append("'" + (inline.Substring(181, 8).Trim() != "" ? FormatDate(inline.Substring(181, 8).Trim()) : "") + "'|"); //Proc-Id-Date
                        outline.Append(inline.Substring(189, 6).Trim() + "|"); //Proc-Id-Time
                        outline.Append(inline.Substring(195, 19).Trim() + "|"); //Wk-Qty
                        outline.Append(inline.Substring(214, 17).Trim() + "|"); //Wk-Cost-Chg
                        outline.Append("'" + inline.Substring(231, 1).Trim() + "'|"); //Wk-Lvl-Ind
                        outline.Append("'" + inline.Substring(232, 15).Trim() + "'|"); //Wk-Map
                        outline.Append(inline.Substring(247, 3).Trim() + "|"); //Sum-Rpt-Ctl
                        // skip 8 bytes of filler
                        outline.Append("'" + inline.Substring(258, 16).Trim() + "'|"); //Eng-Text-Id
                        outline.Append("'" + inline.Substring(274, 2).Trim() + "'|"); //Rout-Recost-Cd
                        outline.Append("'" + inline.Substring(275, 2).Trim() + "'|"); //PRS-Anal-Code
                        outline.Append("'" + inline.Substring(278, 2).Trim() + "'|"); //PRS-Anal-Ind
                        outline.Append(inline.Substring(280, 10).Trim() + "|"); //Cum-Yield-Fctr
                        outline.Append("'" + inline.Substring(290, 2).Trim() + "'|"); //Cost-Ctl-Code
                        outline.Append(inline.Substring(292, 16).Trim() + "|"); //Inv-Cst-Per-Unt
                        outline.Append("'" + (inline.Substring(308, 8).Trim() != "" ? FormatDate(inline.Substring(308, 8).Trim()) : "") + "'|"); //CDS-Date
                        outline.Append("'" + inline.Substring(316, 2).Trim() + "'|"); //Inv-Cat-Code
                        outline.Append("'" + inline.Substring(318, 24).Trim() + "'|"); //GL-Code
                        outline.Append("'" + inline.Substring(342, 2).Trim() + "'|"); //Prod-Ovhd-Type
                        outline.Append("'" + inline.Substring(344, 16).Trim() + "'|"); //Acct-Text-Id
                        outline.Append("'" + inline.Substring(360, 2).Trim() + "'|"); //Cost-Rollup-Cd
                        outline.Append(inline.Substring(362, 17).Trim() + "|"); //Std-Ord-Qty
                        outline.Append("'" + inline.Substring(379, 4).Trim() + "'|"); //Item-Acct-Char1
                        outline.Append("'" + inline.Substring(383, 4).Trim() + "'|"); //Item-Acct-Char2
                        outline.Append("'" + inline.Substring(387, 4).Trim() + "'|"); //Item-Acct-Char3
                        outline.Append("'" + inline.Substring(391, 2).Trim() + "'|"); //Cost-Analyst-Id
                        outline.Append("'" + inline.Substring(393, 2).Trim() + "'|"); //Planner
                        outline.Append("'" + inline.Substring(395, 2).Trim() + "'|"); //Buyer
                        outline.Append("'" + inline.Substring(397, 2).Trim() + "'|"); //Shop-Planner-Id
                        outline.Append("'" + inline.Substring(399, 2).Trim() + "'|"); //Make-Buy-Code
                        outline.Append("'" + inline.Substring(401, 2).Trim() + "'|"); //Dem-Ctl
                        outline.Append("'" + inline.Substring(403, 2).Trim() + "'|"); //Issue-Ctl
                        outline.Append("'" + inline.Substring(405, 2).Trim() + "'|"); //MRP-Dem-Pol
                        outline.Append("'" + inline.Substring(407, 14).Trim() + "'|"); //Dist-Loc
                        outline.Append("'" + inline.Substring(421, 2).Trim() + "'|"); //Rcpt-Qty-Code
                        outline.Append(inline.Substring(423, 3).Trim() + "|"); //Cycle-Count-Int
                        outline.Append("'" + (inline.Substring(426, 8).Trim() != "" ? FormatDate(inline.Substring(426, 8).Trim()) : "") + "'|"); //Cycle-Count-Dte
                        outline.Append("'" + inline.Substring(434, 2).Trim() + "'|"); //ABC-Class-Code
                        outline.Append("'" + inline.Substring(436, 10).Trim() + "'|"); //Work-Center
                        outline.Append("'" + (inline.Substring(446, 8).Trim() != "" ? FormatDate(inline.Substring(446, 8).Trim()) : "") + "'|"); //MCS-Anal_Date
                        outline.Append("'" + (inline.Substring(454, 8).Trim() != "" ? FormatDate(inline.Substring(454, 8).Trim()) : "") + "'|"); //MRP-Anal-Date
                        outline.Append("'" + (inline.Substring(462, 8).Trim() != "" ? FormatDate(inline.Substring(462, 8).Trim()) : "") + "'|"); //MCS-Date
                        outline.Append("'" + inline.Substring(470, 2).Trim() + "'|"); //Use-Up-Eff-Ind
                        outline.Append("'" + inline.Substring(472, 16).Trim() + "'|"); //Planner-Text-Id
                        outline.Append(inline.Substring(488, 4).Trim() + "|"); //Alt-Supply-Ct
                        outline.Append("'" + inline.Substring(492, 2).Trim() + "'|"); //Loc-Ctl-Pol
                        outline.Append("'" + inline.Substring(494, 2).Trim() + "'|"); //Rcpt-Mixing-Pol
                        outline.Append("'" + inline.Substring(496, 2).Trim() + "'|"); //Ord-Pol
                        outline.Append(inline.Substring(498, 17).Trim() + "|"); //Ord-Point-Qty
                        outline.Append("'" + inline.Substring(515, 2).Trim() + "'|"); //Safe-Stk-Pol
                        outline.Append(inline.Substring(517, 17).Trim() + "|"); //Safe-Stk-Qty
                        outline.Append(inline.Substring(534, 17).Trim() + "|"); //Fixed-Ord-Qty
                        outline.Append(inline.Substring(551, 17).Trim() + "|"); //Min-Ord-Qty
                        outline.Append(inline.Substring(568, 17).Trim() + "|"); //Max-Ord-Qty
                        outline.Append(inline.Substring(585, 17).Trim() + "|"); //Mult-Ord-Qty
                        outline.Append("'" + inline.Substring(602, 2).Trim() + "'|"); //Min-Ord-Qty-Mod
                        outline.Append("'" + inline.Substring(604, 2).Trim() + "'|"); //Max-Ord-Qty-Mod
                        outline.Append(inline.Substring(606, 6).Trim() + "|"); //Carry-Cost-Amt
                        outline.Append(inline.Substring(612, 3).Trim() + "|"); //Carry-Cost-Pct
                        outline.Append(inline.Substring(615, 6).Trim() + "|"); //Setup-Cost
                        outline.Append(inline.Substring(621, 3).Trim() + "|"); //Shrink-Pct
                        outline.Append(inline.Substring(624,17).Trim() + "|"); //Avg-Order-Qty
                        outline.Append(inline.Substring(641, 6).Trim() + "|"); //Move-Lead-Time
                        outline.Append(inline.Substring(647, 6).Trim() + "|"); //Queue-Lead-Time
                        outline.Append(inline.Substring(653, 12).Trim() + "|"); //Var-Lead-Time
                        outline.Append(inline.Substring(665, 12).Trim() + "|"); //Fixed-Lead-Time
                        outline.Append("'" + inline.Substring(677, 2).Trim() + "'|"); //Lt-Ovr-Ind
                        outline.Append(inline.Substring(679, 3).Trim() + "|"); //Mfg-Planner-Tme
                        outline.Append(inline.Substring(682, 3).Trim() + "|"); //Mfg-Release-Tme
                        outline.Append(inline.Substring(685, 3).Trim() + "|"); //Mfg-Pick-Time
                        outline.Append(inline.Substring(688, 3).Trim() + "|"); //Pur-Planner-Tme
                        outline.Append(inline.Substring(691, 3).Trim() + "|"); //Pur-Buyer-Time
                        outline.Append(inline.Substring(694, 3).Trim() + "|"); //Pur-Vendor-Time
                        outline.Append(inline.Substring(697, 3).Trim() + "|"); //Pur-Recv-Time
                        outline.Append(inline.Substring(700, 3).Trim() + "|"); //Pur-Insp-Time
                        outline.Append("'" + (inline.Substring(703, 8).Trim() != "" ? FormatDate(inline.Substring(703, 8).Trim()) : "") + "'|"); //PRS_Date
                        outline.Append(inline.Substring(711, 17).Trim() + "|"); //On-Hand-Qty
                        outline.Append(inline.Substring(728, 17).Trim() + "|"); //In-Inspect-Qty
                        outline.Append(inline.Substring(745, 17).Trim() + "|"); //In-MRB-Qty
                        outline.Append(inline.Substring(762, 17).Trim() + "|"); //In-Transit-Qty
                        outline.Append(inline.Substring(779, 17).Trim() + "|"); //Floor-Stock-Qty
                        outline.Append(inline.Substring(796, 17).Trim() + "|"); //Quarantined-Qty
                        outline.Append(inline.Substring(813, 17).Trim() + "|"); //Rejected-Qty
                        outline.Append(inline.Substring(830, 17).Trim() + "|"); //Avails-Qtys-1
                        outline.Append(inline.Substring(847, 17).Trim() + "|"); //Avails-Qtys-2
                        outline.Append(inline.Substring(864, 17).Trim() + "|"); //Avails-Qtys-3
                        outline.Append(inline.Substring(881, 17).Trim() + "|"); //Avails-Qtys-4
                        outline.Append(inline.Substring(898, 17).Trim() + "|"); //Avails-Qtys-5
                        outline.Append(inline.Substring(915, 19).Trim() + "|"); //Sch-Qty
                        outline.Append(inline.Substring(934, 19).Trim() + "|"); //Ship-Qty
                        outline.Append(inline.Substring(953, 19).Trim() + "|"); //Pur-Qty
                        outline.Append(inline.Substring(972, 19).Trim() + "|"); //Mfg-Qty
                        outline.Append(inline.Substring(991, 19).Trim() + "|"); //Used-Qty
                        outline.Append(inline.Substring(1010, 19).Trim() + "|"); //Adj-Qty
                        outline.Append(inline.Substring(1029, 19).Trim() + "|"); //Scrap-Qty
                        outline.Append("'" + inline.Substring(1048, 2).Trim() + "'|"); //Lot-Nbr-Policy
                        outline.Append("'" + inline.Substring(1050, 2).Trim() + "'|"); //Lot-Mixing-Pol
                        outline.Append("'" + inline.Substring(1052, 2).Trim() + "'|"); //LTS_Ind
                        outline.Append(inline.Substring(1055, 4).Trim() + "|"); //Expire-Def-Days
                        outline.Append(inline.Substring(1058, 4).Trim() + "|"); //Retest-Def-Days
                        outline.Append(inline.Substring(1062, 17).Trim() + "|"); //Last-Lot-TH-Qty
                        outline.Append(inline.Substring(1079, 17).Trim() + "|"); //Last-Loc-TH-Qty
                        outline.Append("'" + inline.Substring(1096, 2).Trim() + "'|"); //Neg-Bal-Allowed
                        outline.Append(inline.Substring(1098, 3).Trim() + "|"); //Ovr-Iss-Tol-Pct
                        outline.Append("'" + inline.Substring(1101, 2).Trim() + "'|"); //SMP-Ind
                        //outline.Append("'" + inline.Substring(1103, 14).Trim() + "'|"); //Anal-Proc-ID
                        outline.Append("'" + inline.Substring(1117, 2).Trim() + "'|"); //Msg-210-Ind
                        outline.Append("'" + inline.Substring(1119, 2).Trim() + "'|"); //Msg-310-Ind
                        outline.Append("'" + inline.Substring(1121, 2).Trim() + "'|"); //Msg-320-Ind
                        outline.Append("'" + inline.Substring(1123, 2).Trim() + "'|"); //Msg-330-Ind
                        outline.Append(inline.Substring(1125, 17).Trim() + "|"); //Daily-Rate-Qty
                        outline.Append("'" + inline.Substring(1142, 2).Trim() + "'|"); //BI-Rpt-Id
                        outline.Append("'" + inline.Substring(1144, 2).Trim() + "'|"); //BI-Hor-Opt
                        outline.Append(inline.Substring(1146, 3).Trim() + "|"); //BI-Hor-Days
                        outline.Append("'" + inline.Substring(1149, 8).Trim() + "'|"); //BI-Hor-Sch
                        outline.Append(inline.Substring(1157, 5).Trim() + "|"); //BI-SS-Pct
                        outline.Append(inline.Substring(1162, 17).Trim() + "|"); //BI-Mult-Qty
                        outline.Append(inline.Substring(1179, 1).Trim() + "|"); //Item-Qty-Acc
                        outline.Append(inline.Substring(1180, 17).Trim() + "|"); //Wip-Qty
                        outline.Append(inline.Substring(1197, 17).Trim() + "|"); //FG-Qty
                        outline.Append("'" + inline.Substring(1214, 4).Trim() + "'|"); //Commod-Frt-Code
                        outline.Append("'" + inline.Substring(1218, 4).Trim() + "'|"); //FG-Class
                        outline.Append("'" + inline.Substring(1222, 2).Trim() + "'|"); //Tax-Ind
                        outline.Append("'" + inline.Substring(1224, 4).Trim() + "'|"); //Product-Line-Cd
                        outline.Append("'" + inline.Substring(1228, 4).Trim() + "'|"); //Product-Cat-Cd
                        outline.Append("'" + inline.Substring(1232, 4).Trim() + "'|"); //Product-Mkt-Cd
                        outline.Append("'" + inline.Substring(1236, 4).Trim() + "'|"); //Commission-Code
                        //outline.Append("'" + inline.Substring(1244, 8).Trim() + "'|"); //Flags-8
                        outline.Append(inline.Substring(1252, 10).Trim() + "|"); //Unit-Cube
                        outline.Append(inline.Substring(1262, 13).Trim() + "|"); //Unit-Base-Price
                        ///outline.Append(inline.Substring(1275, 17).Trim() + "|"); //FG-Dist-Qty
                        //outline.Append(inline.Substring(1292, 17).Trim() + "|"); //FG-Dist-MRB-Qty
                        //outline.Append("'" + inline.Substring(1309, 8).Trim() + "'|"); //OMS-Date
                        //outline.Append("'" + inline.Substring(1317, 16).Trim() + "'|"); //Fin-Text-Id
                        if (inline.Length > 1333)
                        {
                            outline.Append("'" + inline.Substring(1333, inline.Length >= 1349 ? 16 : 16 - (1349 - inline.Length)).Trim() + "'|"); //AMAPS-Space-16
                        }
                        if (inline.Length > 1349)
                        {
                            outline.Append("'" + inline.Substring(1349, inline.Length >= 1361 ? 12 : 12 - (1361 - inline.Length)).Trim() + "'|"); //User-Space-12
                        }
                        //Console.WriteLine(inline);
                        sw.WriteLine(outline.ToString());
                        //Console.WriteLine(outline.ToString());
                    }
                }
            }
            sr.Close();
        }
        private static void Process_LDF(string path)
        {
            Console.WriteLine("Processing LDF");
            StreamReader sr = new StreamReader(System.IO.Path.Combine(path, "newldf.txt"));
            StringBuilder outline = new StringBuilder();
            using (FileStream fs = new FileStream(System.IO.Path.Combine(path, "ldffile.txt"), FileMode.Create))
            {
                using (StreamWriter sw = new StreamWriter(fs, Encoding.UTF8))
                {
                    outline.Clear();
                    outline.Append("'Lot_Item'|");
                    outline.Append("'Loc_Qty'|");
                    outline.Append("'LTS_Date'|");
                    outline.Append("'User_Space_10'|");
                    outline.Append("'Loc_Detail_Key'|");
                    sw.WriteLine(outline.ToString());
                    while (sr.Peek() >= 0)
                    {
                        String inline = sr.ReadLine();
                        outline.Clear();
                        outline.Append("'" + inline.Substring(0, 32).Trim() + "'|"); //Lot-Item
                        outline.Append(inline.Substring(32, 17).Trim() + "|"); //Loc-Qty
                        outline.Append("'" + (inline.Substring(49, 8).Trim() != "" ? FormatDate(inline.Substring(49, 8).Trim()) : "") + "'|"); //LTS-Date
                        outline.Append("'" + inline.Substring(57, 10).Trim() + "'|"); //User-Space-10
                        if (inline.Length > 67)
                        {
                            outline.Append("'" + inline.Substring(67, inline.Length >= 115 ? 48 : 48 - (115 - inline.Length)).Trim() + "'|"); //Loc-Detail-Key
                        }
                        //Console.WriteLine(inline);
                        sw.WriteLine(outline.ToString());
                        //Console.WriteLine(outline.ToString());
                    }
                }
            }
            sr.Close();
        }
        private static void Process_LMF(string path)
        {
            Console.WriteLine("Processing LMF");
            StreamReader sr = new StreamReader(System.IO.Path.Combine(path, "newlmf.txt"));
            StringBuilder outline = new StringBuilder();
            using (FileStream fs = new FileStream(System.IO.Path.Combine(path, "lmffile.txt"), FileMode.Create))
            {
                using (StreamWriter sw = new StreamWriter(fs, Encoding.UTF8))
                {
                    outline.Clear();
                    outline.Append("'Dist_Loc'|");
                    outline.Append("'Loc_Type'|");
                    outline.Append("'LTS_Allowed'|");
                    outline.Append("'Non_LTS_Allowed'|");
                    outline.Append("'BI_Loc_Group'|");
                    outline.Append("'BI_Hor_Opt'|");
                    outline.Append("'BI_Hor_Days'|");
                    outline.Append("'BI_Hor_Sch'|");
                    outline.Append("'MCS_Date'|");
                    outline.Append("'Text_Id'|");
                    outline.Append("'AMAPS_Space_24'|");
                    outline.Append("'User_Space_16'|");
                    sw.WriteLine(outline.ToString());
                    while (sr.Peek() >= 0)
                    {
                        String inline = sr.ReadLine();
                        outline.Clear();
                        outline.Append("'" + inline.Substring(0, 14).Trim() + "'|"); //Dist-Loc
                        outline.Append("'" + inline.Substring(14, 2).Trim() + "'|"); //Loc-Type
                        outline.Append("'" + inline.Substring(16, 2).Trim() + "'|"); //LTS-Allowed
                        outline.Append("'" + inline.Substring(18, 2).Trim() + "'|"); //Non-LTS Allowed
                        outline.Append("'" + inline.Substring(20, 4).Trim() + "'|"); //BI-Loc-Group
                        outline.Append("'" + inline.Substring(24, 2).Trim() + "'|"); //BI-Hor-Opt
                        outline.Append(Convert.ToInt32(inline.Substring(26, 3).Trim()) + "|"); //BI-Hor-Days
                        outline.Append("'" + inline.Substring(29, 8).Trim() + "'|"); //BI-Hor-Sch
                        outline.Append("'" + (inline.Substring(37, 8).Trim() != "" ? FormatDate(inline.Substring(37, 8).Trim()) : "") + "'|"); //MCS-Date
                        if (inline.Length > 45)
                        {
                            //int strlen = inline.Length >= 61 ? 16 : 16 - (61 - inline.Length);
                            outline.Append("'" + inline.Substring(45, inline.Length >= 61 ? 16 : 16 - (61 - inline.Length)).Trim() + "'|"); //Text-Id
                        }
                        if (inline.Length > 61)
                        {
                            outline.Append("'" + inline.Substring(61, inline.Length >= 85 ? 24 : 24 - (85 - inline.Length)).Trim() + "'|"); //AMAPS-Space-24
                        }
                        if (inline.Length > 85)
                        {
                            outline.Append("'" + inline.Substring(85, inline.Length >= 101 ? 16 : 16 - (101 - inline.Length)).Trim() + "'|"); //User-Space-16
                        }
                        //Console.WriteLine(inline);
                        sw.WriteLine(outline.ToString());
                        //Console.WriteLine(outline.ToString());
                    }
                }
            }
            sr.Close();
        }
        private static void Process_LOF(string path)
        {
            Console.WriteLine("Processing LOF");
            StreamReader sr = new StreamReader(System.IO.Path.Combine(path, "newlof.txt"));
            StringBuilder outline = new StringBuilder();
            using (FileStream fs = new FileStream(System.IO.Path.Combine(path, "loffile.txt"), FileMode.Create))
            {
                using (StreamWriter sw = new StreamWriter(fs, Encoding.UTF8))
                {
                    outline.Clear();
                    outline.Append("'Item_Nbr'|");
                    outline.Append("'Lot_Type'|");
                    outline.Append("'Remaining_Qty'|");
                    outline.Append("'Recd_Qty'|");
                    outline.Append("'Issued_Qty'|");
                    outline.Append("'Scrapped_Qty'|");
                    outline.Append("'Transferred_Qty'|");
                    outline.Append("'Adjusted_Qty'|");
                    outline.Append("'Create_Date'|");
                    outline.Append("'Tested_Date'|");
                    outline.Append("'Retest_Date'|");
                    outline.Append("'Expire_Date'|");
                    outline.Append("'Retest_Priority'|");
                    outline.Append("'Expire_Priority'|");
                    outline.Append("'Potency'|");
                    outline.Append("'Text_Id'|");
                    outline.Append("'LTS_Date'|");
                    outline.Append("'Lot-Status'|");
                    outline.Append("'Prev_Lot_Status'|");
                    outline.Append("'CDF_Count'|");
                    outline.Append("'RSF_WU_Count'|");
                    outline.Append("'RSF_Src_Count'|");
                    outline.Append("'Order_Nbr'|");
                    outline.Append("'Order_Rel'|");
                    outline.Append("'Vend_Nbr'|");
                    outline.Append("'Customer_Id'|");
                    outline.Append("'Beg_Serial_Nbr'|");
                    outline.Append("'End_Serial_Nbr'|");
                    outline.Append("'Rcpt_Ind'|");
                    outline.Append("'Rcpt_Text_Id'|");
                    outline.Append("'Last_Rcpt_Date'|");
                    outline.Append("'User_Space_14'|");
                    outline.Append("'Lot_Item'|");
                    sw.WriteLine(outline.ToString());
                    while (sr.Peek() >= 0)
                    {
                        String inline = sr.ReadLine();
                        outline.Clear();
                        outline.Append("'" + inline.Substring(0, 16).Trim() + "'|"); //Item-Nbr
                        outline.Append("'" + inline.Substring(16, 2).Trim() + "'|"); //Lot-Type
                        outline.Append(inline.Substring(18, 17).Trim() + "|"); //Remaining-Qty
                        outline.Append(inline.Substring(35, 17).Trim() + "|"); //Recd-Qty
                        outline.Append(inline.Substring(52, 17).Trim() + "|"); //Issued-Qty
                        outline.Append(inline.Substring(69, 17).Trim() + "|"); //Scrapped-Qty
                        outline.Append(inline.Substring(86, 17).Trim() + "|"); //Transferred-Qty
                        outline.Append(inline.Substring(103, 17).Trim() + "|"); //Adjusted-Qty
                        outline.Append("'" + (inline.Substring(120, 8).Trim() != "" ? FormatDate(inline.Substring(120, 8).Trim()) : "") + "'|"); //Create-Date
                        outline.Append("'" + (inline.Substring(128, 8).Trim() != "" ? FormatDate(inline.Substring(128, 8).Trim()) : "") + "'|"); //Tested-Date
                        outline.Append("'" + (inline.Substring(136, 8).Trim() != "" ? FormatDate(inline.Substring(136, 8).Trim()) : "") + "'|"); //Retest-Date
                        outline.Append("'" + (inline.Substring(144, 8).Trim() != "" ? FormatDate(inline.Substring(144, 8).Trim()) : "") + "'|"); //Expire-Date
                        outline.Append("'" + inline.Substring(152, 2).Trim() + "'|"); //Retest-Priority
                        outline.Append("'" + inline.Substring(154, 2).Trim() + "'|"); //Expire-Priority
                        outline.Append("'" + inline.Substring(156, 16).Trim() + "'|"); //Potency
                        outline.Append("'" + inline.Substring(172, 16).Trim() + "'|"); //Text-Id
                        outline.Append("'" + (inline.Substring(188, 8).Trim() != "" ? FormatDate(inline.Substring(188, 8).Trim()) : "") + "'|"); //LTS-Date
                        outline.Append("'" + inline.Substring(196, 2).Trim() + "'|"); //Lot-Status
                        outline.Append("'" + inline.Substring(198, 2).Trim() + "'|"); //Prev-Lot-Status
                        outline.Append(Convert.ToInt32(inline.Substring(200, 7).Trim()) + "|"); //CDF-Count
                        outline.Append(Convert.ToInt32(inline.Substring(207, 7).Trim()) + "|"); //RSF-WU-Count
                        outline.Append(Convert.ToInt32(inline.Substring(214, 7).Trim()) + "|"); //RSF-Src-Count
                        outline.Append("'" + inline.Substring(221, 16).Trim() + "'|"); //Order-Nbr
                        outline.Append("'" + inline.Substring(237, 2).Trim() + "'|"); //Order-Rel
                        outline.Append("'" + inline.Substring(239, 16).Trim() + "'|"); //Vend-Nbr
                        outline.Append("'" + inline.Substring(255, 8).Trim() + "'|"); //Customer-Id
                        outline.Append("'" + inline.Substring(263, 16).Trim() + "'|"); //Beg-Serial-Nbr
                        outline.Append("'" + inline.Substring(279, 16).Trim() + "'|"); //Beg-Serial-Nbr
                        outline.Append("'" + inline.Substring(295, 2).Trim() + "'|"); //Rcpt-Ind
                        outline.Append("'" + inline.Substring(297, 16).Trim() + "'|"); //Rcpt-Text-Id
                        outline.Append("'" + (inline.Substring(313, 8).Trim() != "" ? FormatDate(inline.Substring(313, 8).Trim()) : "") + "'|"); //Last-Rcpt-Date
                        outline.Append("'" + inline.Substring(321, 14).Trim() + "'|"); //User-Space-14
                        if (inline.Length > 335)
                        {
                            //outline.Append(inline.Substring(291, 32).Trim() + "|"); //Lot-Item
                            outline.Append("'" + inline.Substring(335, inline.Length >= 367 ? 32 : 32 - (367 - inline.Length)).Trim() + "'|"); //Lot-Item
                        }
                        //Console.WriteLine(inline);
                        sw.WriteLine(outline.ToString());
                        //Console.WriteLine(outline.ToString());
                    }
                }
            }
            sr.Close();
        }
        private static void Process_LTF(string path)
        {
            Console.WriteLine("Processing LTF");
            StreamReader sr = new StreamReader(System.IO.Path.Combine(path, "newltf.txt"));
            StringBuilder outline = new StringBuilder();
            using (FileStream fs = new FileStream(System.IO.Path.Combine(path, "ltffile.txt"), FileMode.Create))
            {
                using (StreamWriter sw = new StreamWriter(fs, Encoding.UTF8))
                {
                    outline.Clear();
                    outline.Append("'Dist_Loc'|");
                    outline.Append("'Item_Nbr'|");
                    outline.Append("'Loc_Qty'|");
                    outline.Append("'Last_Rcpt_Date'|");
                    outline.Append("'MCS_Date'|");
                    outline.Append("'Text_Id'|");
                    outline.Append("'User_Space_10'|");
                    outline.Append("'Loc_Item_Key'|");
                    sw.WriteLine(outline.ToString());
                    while (sr.Peek() >= 0)
                    {
                        String inline = sr.ReadLine();
                        outline.Clear();
                        outline.Append("'" + inline.Substring(0, 14).Trim() + "'|"); //Dist-Loc
                        outline.Append("'" + inline.Substring(14, 16).Trim() + "'|"); //Item-Nbr
                        outline.Append(inline.Substring(30, 17).Trim() + "|"); //Loc-Qty
                        outline.Append("'" + (inline.Substring(47, 8).Trim() != "" ? FormatDate(inline.Substring(47, 8).Trim()) : "") + "'|"); //Last-Rcpt-Date
                        outline.Append("'" + (inline.Substring(55, 8).Trim() != "" ? FormatDate(inline.Substring(55, 8).Trim()) : "") + "'|"); //MCS-Date
                        outline.Append("'" + inline.Substring(63, 16).Trim() + "'|"); //Text-Id
                        outline.Append("'" + inline.Substring(79, 10).Trim() + "'|"); //User-Space-10
                        outline.Append("'" + inline.Substring(89, 32).Trim() + "'|"); //Loc-Item-Key
                        //Console.WriteLine(inline);
                        sw.WriteLine(outline.ToString());
                        //Console.WriteLine(outline.ToString());
                    }
                }
            }
            sr.Close();
        }
        private static void Process_OIF(string path)
        {
            Console.WriteLine("Processing OIF");
            StreamReader sr = new StreamReader(System.IO.Path.Combine(path, "newoif.txt"));
            StringBuilder outline = new StringBuilder();
            using (FileStream fs = new FileStream(System.IO.Path.Combine(path, "oiffile.txt"), FileMode.Create))
            {
                using (StreamWriter sw = new StreamWriter(fs, Encoding.UTF8))
                {
                    outline.Clear();
                    outline.Append("'Order_Nbr'|");
                    outline.Append("'Order_Type'|");
                    outline.Append("'Order_Status'|");
                    outline.Append("'Order_Date'|");
                    outline.Append("'Ref'|");
                    outline.Append("'MCS_Sch_Cut_Dte'|");
                    outline.Append("'MCS_Status_Date'|");
                    outline.Append("'MCS_Date'|");
                    outline.Append("'MCS_Sch_Frm_Dte'|");
                    outline.Append("'MCS_Act_Frm_Dte'|");
                    outline.Append("'SFC_Cut_Date'|");
                    outline.Append("'SFC_Anal_Date'|");
                    outline.Append("'Frzn_Sched_Cd'|");
                    outline.Append("'SFC_Anal_Code'|");
                    outline.Append("'MCS_Anal_Code'|");
                    outline.Append("'Cust_Order_Type'|");
                    outline.Append("'Vend_Nbr'|");
                    outline.Append("'Customer_Id'|");
                    outline.Append("'Text_Id'|");
                    outline.Append("'Demand_Ct'|");
                    outline.Append("'Anl_Proc_Id'|");
                    outline.Append("'SMP_Ind'|");
                    outline.Append("'Dist_Site'|");
                    outline.Append("'AMAPS_Space_32'|");
                    outline.Append("'User_Space_16'|");
                    sw.WriteLine(outline.ToString());
                    while (sr.Peek() >= 0)
                    {
                        String inline = sr.ReadLine();
                        outline.Clear();
                        outline.Append("'" + inline.Substring(0, 16).Trim() + "'|"); //Order-Nbr
                        outline.Append("'" + inline.Substring(16, 2).Trim() + "'|"); //Order-Type
                        outline.Append("'" + inline.Substring(18, 2).Trim() + "'|"); //Order-Status
                        outline.Append("'" + (inline.Substring(20, 8).Trim() != "" ? FormatDate(inline.Substring(20, 8).Trim()) : "") + "'|"); //Order-Date
                        outline.Append("'" + inline.Substring(28, 26).Trim() + "'|"); //Ref
                        outline.Append("'" + (inline.Substring(54, 8).Trim() != "" ? FormatDate(inline.Substring(54, 8).Trim()) : "") + "'|"); //MCS-Sch-Cut-Dte
                        outline.Append("'" + (inline.Substring(62, 8).Trim() != "" ? FormatDate(inline.Substring(62, 8).Trim()) : "") + "'|"); //MCS-Status-Date
                        outline.Append("'" + (inline.Substring(70, 8).Trim() != "" ? FormatDate(inline.Substring(70, 8).Trim()) : "") + "'|"); //MCS-Date
                        outline.Append("'" + (inline.Substring(78, 8).Trim() != "" ? FormatDate(inline.Substring(78, 8).Trim()) : "") + "'|"); //MCS-Sch-Frm-Dte
                        outline.Append("'" + (inline.Substring(86, 8).Trim() != "" ? FormatDate(inline.Substring(86, 8).Trim()) : "") + "'|"); //MCS-Act-Frm-Dte
                        outline.Append("'" + (inline.Substring(94, 8).Trim() != "" ? FormatDate(inline.Substring(94, 8).Trim()) : "") + "'|"); //SFC-Cut-Date
                        outline.Append("'" + (inline.Substring(102, 8).Trim() != "" ? FormatDate(inline.Substring(102, 8).Trim()) : "") + "'|"); //SFC-Anal-Date
                        outline.Append("'" + inline.Substring(110, 2).Trim() + "'|"); //Frzn-Sched-Cd
                        outline.Append("'" + inline.Substring(112, 2).Trim() + "'|"); //SFC-Anal-Code
                        outline.Append("'" + (inline.Substring(114, 8).Trim() != "" ? FormatDate(inline.Substring(114, 8).Trim()) : "") + "'|"); //MCS-Anal-Date
                        outline.Append("'" + inline.Substring(122, 2).Trim() + "'|"); //Cust-Order-Type
                        outline.Append("'" + inline.Substring(124, 16).Trim() + "'|"); //Vend-Nbr
                        outline.Append("'" + inline.Substring(140, 8).Trim() + "'|"); //Customer-Id
                        outline.Append("'" + inline.Substring(148, 16).Trim() + "'|"); //Text-Id
                        outline.Append(inline.Substring(164, 4).Trim() + "|"); //Demand-Ct
                        outline.Append("'" + inline.Substring(168, 14).Trim() + "'|"); //Anl-Proc-Id
                        if (inline.Length > 182)
                        {
                            outline.Append("'" + inline.Substring(182, inline.Length >= 184 ? 2 : 2 - (184 - inline.Length)).Trim() + "'|"); //SMP-Ind
                        }
                        if (inline.Length > 184)
                        {
                            outline.Append("'" + inline.Substring(184, inline.Length >= 198 ? 14 : 14 - (198 - inline.Length)).Trim() + "'|"); //Dist-Site
                        }
                        if (inline.Length > 198)
                        {
                            outline.Append("'" + inline.Substring(198, inline.Length >= 230 ? 32 : 32 - (230 - inline.Length)).Trim() + "'|"); //Loc-Detail-Key
                        }
                        if (inline.Length > 230)
                        {
                            outline.Append("'" + inline.Substring(230, inline.Length >= 246 ? 16 : 16 - (246 - inline.Length)).Trim() + "'|"); //Loc-Detail-Key
                        }
                        //Console.WriteLine(inline);
                        sw.WriteLine(outline.ToString());
                        //Console.WriteLine(outline.ToString());
                    }
                }
            }
            sr.Close();
        }
        private static void Process_RSF(string path)
        {
            Console.WriteLine("Processing RSF");
            StreamReader sr = new StreamReader(System.IO.Path.Combine(path, "newrsf.txt"));
            StringBuilder outline = new StringBuilder();
            using (FileStream fs = new FileStream(System.IO.Path.Combine(path, "rsffile.txt"), FileMode.Create))
            {
                using (StreamWriter sw = new StreamWriter(fs, Encoding.UTF8))
                {
                    outline.Clear();
                    outline.Append("'Lot_Item'|");
                    outline.Append("'Create_Date'|");
                    outline.Append("'LTS_Date'|");
                    outline.Append("'Relation_Qty'|");
                    outline.Append("'Scrapped_Qty'|");
                    outline.Append("'Relation_Type'|");
                    outline.Append("'User_Space_10'|");
                    outline.Append("'Comp_Lot_Item'|");
                    sw.WriteLine(outline.ToString());
                    while (sr.Peek() >= 0)
                    {
                        String inline = sr.ReadLine();
                        outline.Clear();
                        outline.Append("'" + inline.Substring(0, 32).Trim() + "'|"); //Lot-Item
                        outline.Append("'" + (inline.Substring(32, 8).Trim() != "" ? FormatDate(inline.Substring(32, 8).Trim()) : "") + "'|"); //Create-Date
                        outline.Append("'" + (inline.Substring(40, 8).Trim() != "" ? FormatDate(inline.Substring(40, 8).Trim()) : "") + "'|"); //LTS-Date
                        outline.Append(inline.Substring(48, 17).Trim() + "|"); //Relation-Qty
                        outline.Append(inline.Substring(65, 17).Trim() + "|"); //Scrapped-Qty
                        outline.Append("'" + inline.Substring(82, 2).Trim() + "'|"); //Relation_Type
                        outline.Append("'" + inline.Substring(84, 10).Trim() + "'|"); //User-Space-10
                        outline.Append("'" + inline.Substring(94, 32).Trim() + "'|"); //Comp-Lot-Item
                        //Console.WriteLine(inline);
                        sw.WriteLine(outline.ToString());
                        //Console.WriteLine(outline.ToString());
                    }
                }
            }
            sr.Close();
        }
        private static void Process_RVF(string path)
        {
            Console.WriteLine("Processing RVF");
            StreamReader sr = new StreamReader(System.IO.Path.Combine(path, "newrvf.txt"));
            StringBuilder outline = new StringBuilder();
            using (FileStream fs = new FileStream(System.IO.Path.Combine(path, "rvffile.txt"), FileMode.Create))
            {
                using (StreamWriter sw = new StreamWriter(fs, Encoding.UTF8))
                {
                    outline.Clear();
                    outline.Append("'Item_Nbr'|");
                    outline.Append("'Eng_Order_Nbr'|");
                    outline.Append("'Reason'|");
                    outline.Append("'Severity_Code'|");
                    outline.Append("'Implement_Date'|");
                    outline.Append("'Approval_Date'|");
                    outline.Append("'Notice_Date'|");
                    outline.Append("'BMS_Date'|");
                    outline.Append("'RV_Ref'|");
                    outline.Append("'Text_Id'|");
                    outline.Append("'AMAPS_Space_10'|");
                    outline.Append("'User_Space_10'|");
                    outline.Append("'Eff_Date_X'|");
                    outline.Append("'Rev_Level'|");
                    sw.WriteLine(outline.ToString());
                    while (sr.Peek() >= 0)
                    {
                        String inline = sr.ReadLine();
                        outline.Clear();
                        outline.Append("'" + inline.Substring(0, 16).Trim() + "'|"); //Item-Nbr
                        outline.Append("'" + inline.Substring(16, 8).Trim() + "'|"); //Eng-Order-Nbr
                        outline.Append("'" + inline.Substring(24, 2).Trim() + "'|"); //Reason
                        outline.Append("'" + inline.Substring(26, 2).Trim() + "'|"); //Severity-Code
                        outline.Append("'" + (inline.Substring(28, 8).Trim() != "" ? FormatDate(inline.Substring(28, 8).Trim()) : "") + "'|"); //Implement-Date
                        outline.Append("'" + (inline.Substring(36, 8).Trim() != "" ? FormatDate(inline.Substring(36, 8).Trim()) : "") + "'|"); //Approval-Date
                        outline.Append("'" + (inline.Substring(44, 8).Trim() != "" ? FormatDate(inline.Substring(44, 8).Trim()) : "") + "'|"); //Notice-Date
                        outline.Append("'" + (inline.Substring(52, 8).Trim() != "" ? FormatDate(inline.Substring(52, 8).Trim()) : "") + "'|"); //BMS-Date
                        outline.Append("'" + inline.Substring(60, 32).Trim() + "'|"); //Rv-Ref
                        outline.Append("'" + inline.Substring(92, 16).Trim() + "'|"); //Text-Id
                        outline.Append("'" + inline.Substring(108, 10).Trim() + "'|"); //AMAPS-Space-10
                        outline.Append("'" + inline.Substring(118, 10).Trim() + "'|"); //User-Space-10
                        outline.Append("'" + (inline.Substring(128, 8).Trim() != "" ? FormatDate(inline.Substring(128, 8).Trim()) : "") + "'|"); //Eff-Date
                        if (inline.Length > 136)
                        {
                            outline.Append("'" + inline.Substring(136, inline.Length >= 138 ? 2 : 2 - (138 - inline.Length)).Trim() + "'|"); //Rev-Level
                        }
                        //Console.WriteLine(inline);
                        sw.WriteLine(outline.ToString());
                        //Console.WriteLine(outline.ToString());
                    }
                }
            }
            sr.Close();
        }
        private static void Process_SPF(string path)
        {
            Console.WriteLine("Processing SPF");
            StreamReader sr = new StreamReader(System.IO.Path.Combine(path, "newspf.txt"));
            StringBuilder outline = new StringBuilder();
            using (FileStream fs = new FileStream(System.IO.Path.Combine(path, "spffile.txt"), FileMode.Create))
            {
                using (StreamWriter sw = new StreamWriter(fs, Encoding.UTF8))
                {
                    outline.Clear();
                    outline.Append("'Order_Nbr'|");
                    outline.Append("'Order_Type'|");
                    outline.Append("'Order_Status'|");
                    outline.Append("'Force_Cut-Ind'|");
                    outline.Append("'Rev_Level'|");
                    outline.Append("'Expl_Date'|");
                    outline.Append("'Expl_Ovr_Ind'|");
                    outline.Append("'Reschedule_Code'|");
                    outline.Append("'MCS_Status_Date'|");
                    outline.Append("'Mfg_Firm_Date'|");
                    outline.Append("'Mfg_Cut_Date'|");
                    outline.Append("'Mfg_Pick_Date'|");
                    outline.Append("'Mfg_Start_Date'|");
                    outline.Append("'Mfg_Due_Date'|");
                    outline.Append("'MCS_Date'|");
                    outline.Append("'SMP_Ind'|");
                    outline.Append("'Req_Qty'|");
                    outline.Append("'Recd_Qty'|");
                    outline.Append("'Accept_Qty'|");
                    outline.Append("'Reject_Qty'|");
                    outline.Append("'Inspect_Qty'|");
                    outline.Append("'MRB_Qty'|");
                    outline.Append("'Work_Center'|");
                    outline.Append("'Shrink_Pct'|");
                    outline.Append("'Demand_Ct'|");
                    outline.Append("'Ord_Oper_Ct'|");
                    outline.Append("'Req_Op_Alt_Nbr'|");
                    outline.Append("'Auto_Issue_Ct'|");
                    outline.Append("'Auto_Receipt_Ct'|");
                    outline.Append("'Sec_Supply_Ct'|");
                    outline.Append("'Alt_Supply_Ct'|");
                    outline.Append("'Tot_Req_Qty'|");
                    outline.Append("'Tot_Recd_Qty'|");
                    outline.Append("'Rec_Fraction'|");
                    outline.Append("'Fixed_Qty'|");
                    outline.Append("'Rmnt_Qty'|");
                    outline.Append("'Rmnt_Fraction'|");
                    outline.Append("'Rmnt_Fixed_Qty'|");
                    outline.Append("'Heel_Qty'|");
                    outline.Append("'Operation'|");
                    outline.Append("'Qty_Type'|");
                    outline.Append("'Rcpt_Ctl'|");
                    outline.Append("'Effect_Date_In'|");
                    outline.Append("'Effect_Date_Out'|");
                    outline.Append("'Find_Nbr'|");
                    outline.Append("'Assy_Item_Nbr'|");
                    outline.Append("'Text_Id'|");
                    outline.Append("'AMAPS_Space_32'|");
                    outline.Append("'User_Space_16'|");
                    outline.Append("'Supply_Type'|");
                    outline.Append("'Item_Nbr'|");
                    sw.WriteLine(outline.ToString());
                    while (sr.Peek() >= 0)
                    {
                        String inline = sr.ReadLine();
                        outline.Clear();
                        outline.Append("'" + inline.Substring(0, 16).Trim() + "'|"); //Order-Nbr
                        outline.Append("'" + inline.Substring(16, 2).Trim() + "'|"); //Order-Type
                        outline.Append("'" + inline.Substring(18, 2).Trim() + "'|"); //Order-Status
                        outline.Append("'" + inline.Substring(20, 2).Trim() + "'|"); //Force-Cut-Ind
                        outline.Append("'" + inline.Substring(22, 2).Trim() + "'|"); //Rev-Level
                        outline.Append("'" + (inline.Substring(24, 8).Trim() != "" ? FormatDate(inline.Substring(24, 8).Trim()) : "") + "'|"); //Expl-Date
                        outline.Append("'" + inline.Substring(32, 2).Trim() + "'|"); //Expl-Ovr-Ind
                        outline.Append("'" + inline.Substring(34, 2).Trim() + "'|"); //Reschedule-Code
                        outline.Append("'" + (inline.Substring(36, 8).Trim() != "" ? FormatDate(inline.Substring(36, 8).Trim()) : "") + "'|"); //MCS-Status-Date
                        outline.Append("'" + (inline.Substring(44, 8).Trim() != "" ? FormatDate(inline.Substring(44, 8).Trim()) : "") + "'|"); //Mfg-Firm-Date
                        outline.Append("'" + (inline.Substring(52, 8).Trim() != "" ? FormatDate(inline.Substring(52, 8).Trim()) : "") + "'|"); //Mfg-Cut-Date
                        outline.Append("'" + (inline.Substring(60, 8).Trim() != "" ? FormatDate(inline.Substring(60, 8).Trim()) : "") + "'|"); //Mfg-Pick-Date
                        outline.Append("'" + (inline.Substring(68, 8).Trim() != "" ? FormatDate(inline.Substring(68, 8).Trim()) : "") + "'|"); //Mfg-Start-Date
                        outline.Append("'" + (inline.Substring(76, 8).Trim() != "" ? FormatDate(inline.Substring(76, 8).Trim()) : "") + "'|"); //Mfg-Due-Date
                        outline.Append("'" + (inline.Substring(84, 8).Trim() != "" ? FormatDate(inline.Substring(84, 8).Trim()) : "") + "'|"); //MCS-Date
                        outline.Append("'" + inline.Substring(92, 2).Trim() + "'|"); //SMP-Ind
                        outline.Append(inline.Substring(94, 17).Trim() + "|"); //Req-Qty
                        outline.Append(inline.Substring(111, 17).Trim() + "|"); //Recd-Qty
                        outline.Append(inline.Substring(128, 17).Trim() + "|"); //Accept-Qty
                        outline.Append(inline.Substring(145, 17).Trim() + "|"); //Reject-Qty
                        outline.Append(inline.Substring(162, 17).Trim() + "|"); //Inspect-Qty
                        outline.Append(inline.Substring(179, 17).Trim() + "|"); //MRB-Qty
                        outline.Append("'" + inline.Substring(196, 10).Trim() + "'|"); //Work-Center
                        outline.Append(inline.Substring(206, 3).Trim() + "|"); //Shrink-Pct
                        outline.Append(inline.Substring(209, 4).Trim() + "|"); //Demand-Ct
                        outline.Append(inline.Substring(213, 4).Trim() + "|"); //Ord-Oper-Ct
                        outline.Append("'" + inline.Substring(217, 2).Trim() + "'|"); //Req-Alt-Op-Nbr
                        outline.Append(inline.Substring(219, 4).Trim() + "|"); //Auto-Issue-Ct
                        outline.Append(inline.Substring(223, 4).Trim() + "|"); //Auto-Receipt-Ct
                        outline.Append(inline.Substring(227, 4).Trim() + "|"); //Sec-Supply-Ct
                        outline.Append(inline.Substring(231, 4).Trim() + "|"); //Alt-Supply-Ct
                        outline.Append(inline.Substring(235, 17).Trim() + "|"); //Tot-Req-Qty
                        outline.Append(inline.Substring(252, 17).Trim() + "|"); //Tot-Recd-Qty
                        outline.Append(inline.Substring(269, 8).Trim() + "|"); //Req-Fraction
                        outline.Append(inline.Substring(277, 17).Trim() + "|"); //Fixed-Qty
                        outline.Append(inline.Substring(294, 17).Trim() + "|"); //Rmnt-Qty
                        outline.Append(inline.Substring(311, 8).Trim() + "|"); //Rmnt-Fraction
                        outline.Append(inline.Substring(319, 17).Trim() + "|"); //Rmnt-Fixed-Qty
                        outline.Append(inline.Substring(336, 17).Trim() + "|"); //Heel-Qty
                        outline.Append("'" + inline.Substring(353, 6).Trim() + "'|"); //Operation
                        outline.Append("'" + inline.Substring(359, 2).Trim() + "'|"); //Qty-Type
                        outline.Append("'" + inline.Substring(361, 2).Trim() + "'|"); //Rcpt-Cntl
                        outline.Append("'" + (inline.Substring(363, 8).Trim() != "" ? FormatDate(inline.Substring(363, 8).Trim()) : "") + "'|"); //Effect-Date-In
                        outline.Append("'" + (inline.Substring(371, 8).Trim() != "" ? FormatDate(inline.Substring(371, 8).Trim()) : "") + "'|"); //Effect-Date-Out
                        outline.Append("'" + inline.Substring(379, 6).Trim() + "'|"); //Find-Nbr
                        outline.Append("'" + inline.Substring(385, 16).Trim() + "'|"); //Assy-Item-Nbr
                        outline.Append("'" + inline.Substring(401, 16).Trim() + "'|"); //Text-Id
                        outline.Append("'" + inline.Substring(417, 32).Trim() + "'|"); //AMAPS-Space-32
                        outline.Append("'" + inline.Substring(449, 16).Trim() + "'|"); //User-Space-16
                        outline.Append("'" + inline.Substring(465, 2).Trim() + "'|"); //Supply-Type
                        if (inline.Length > 467)
                        {
                            outline.Append("'" + inline.Substring(467, inline.Length >= 483 ? 16 : 16 - (483 - inline.Length)).Trim() + "'|"); //Loc-Detail-Key
                        }
                        //Console.WriteLine(inline);
                        sw.WriteLine(outline.ToString());
                        //Console.WriteLine(outline.ToString());
                    }
                }
            }
            sr.Close();
        }
        private static void Process_COS(string path)
        {
            Console.WriteLine("Processing COS");
            StreamReader sr = new StreamReader(System.IO.Path.Combine(path, "newcos.txt"));
            StringBuilder outline = new StringBuilder();
            using (FileStream fs = new FileStream(System.IO.Path.Combine(path, "cosfile.txt"), FileMode.Create))
            {
                using (StreamWriter sw = new StreamWriter(fs, Encoding.UTF8))
                {
                    outline.Clear();
                    outline.Append("'Cost_Type'|");
                    outline.Append("'Lbr_Rt_Tbl'|");
                    outline.Append("'WC_Ovhd_Tbl_Nbr'|");
                    outline.Append("'Curr_Bill_Typ'|");
                    outline.Append("'Bill_Date'|");
                    outline.Append("'Cst_Typ_Usg'|");
                    outline.Append("'Item_Cst_Opt'|");
                    outline.Append("'Cst_Typ_Name'|");
                    outline.Append("'Text_Id'|");
                    outline.Append("'CDS_Date'|");
                    outline.Append("'WCOVHD_Regn_Ind'|");
                    outline.Append("'Lbr_Regn_Ind'|");
                    outline.Append("'Itmcst_Regn_Ind'|");
                    outline.Append("'BM_Regn_Ind'|");
                    outline.Append("'Prev_Bill_Date'|");
                    outline.Append("'Cst_Yld_Loss_In'|");
                    outline.Append("'AMAPS_Space_12'|");
                    outline.Append("'HD_Lbr_Rt_Tbl'|");
                    outline.Append("'HD_Wcov_Tbl_Nbr'|");
                    outline.Append("'HD_Cur_Bill_Typ'|");
                    outline.Append("'HD_BM_Date'|");
                    outline.Append("'HD_Cst_Typ_Usg'|");
                    outline.Append("'HD_Itm_Cst_Opt'|");
                    outline.Append("'PRS_Oper_Ind'|");
                    outline.Append("'Cst_Inpt_Mthd_01'|");
                    outline.Append("'Cst_Inpt_Mthd_02'|");
                    outline.Append("'Cst_Inpt_Mthd_03'|");
                    outline.Append("'Cst_Inpt_Mthd_04'|");
                    outline.Append("'Cst_Inpt_Mthd_05'|");
                    outline.Append("'Cst_Inpt_Mthd_06'|");
                    outline.Append("'Cst_Inpt_Mthd_07'|");
                    outline.Append("'Cst_Inpt_Mthd_08'|");
                    outline.Append("'Cst_Inpt_Mthd_09'|");
                    outline.Append("'Cst_Inpt_Mthd_10'|");
                    outline.Append("'Cst_Inpt_Mthd_11'|");
                    outline.Append("'Cst_Inpt_Mthd_12'|");
                    outline.Append("'Cst_Category_01'|");
                    outline.Append("'Cst_Category_02'|");
                    outline.Append("'Cst_Category_03'|");
                    outline.Append("'Cst_Category_04'|");
                    outline.Append("'Cst_Category_05'|");
                    outline.Append("'Cst_Category_06'|");
                    outline.Append("'Cst_Category_07'|");
                    outline.Append("'Cst_Category_08'|");
                    outline.Append("'Cst_Category_09'|");
                    outline.Append("'Cst_Category_10'|");
                    outline.Append("'Cst_Category_11'|");
                    outline.Append("'Cst_Category_12'|");
                    outline.Append("'Shrink_Opt'|");
                    outline.Append("'Shrink_Cst_Loc'|");
                    outline.Append("'Scrap_Opt'|");
                    outline.Append("'Scrap_Cst_Loc'|");
                    outline.Append("'Run_Cst_Loc'|");
                    outline.Append("'Setup_Cst_Loc'|");
                    outline.Append("'OS_Vnd_Cst_Loc'|");
                    outline.Append("'Effcncy_Pct_Opt'|");
                    outline.Append("'Prod_Ovhd_Opt'|");
                    outline.Append("'Lbr_Grade_Ctl'|");
                    outline.Append("'Inv_Cst_Ind'|");
                    outline.Append("'Lst_Regn_Date'|");
                    outline.Append("'Lst_Netchg_Date'|");
                    outline.Append("'Lst_Roll_Date'|");
                    outline.Append("'Rollover_Src'|");
                    outline.Append("'Last_Cstclr_Date'|");
                    outline.Append("'Cst_Clear_Opt'|");
                    outline.Append("'HD_Cst_Yld_Loss'|");
                    outline.Append("'AMAPS_Space_20'|");
                    outline.Append("'User-Space_12'|");
                    sw.WriteLine(outline.ToString());
                    while (sr.Peek() >= 0)
                    {
                        String inline = sr.ReadLine();
                        outline.Clear();
                        outline.Append("'" + inline.Substring(0, 2).Trim() + "'|"); //Cst-Typ-X
                        outline.Append("'" + inline.Substring(2, 2).Trim() + "'|"); //Lbr-Rt-Tbl
                        outline.Append("'" + inline.Substring(4, 2).Trim() + "'|"); //WC-Ovhd-Tbl-Nbr
                        outline.Append("'" + inline.Substring(6, 2).Trim() + "'|"); //Curr-Bill-Type
                        outline.Append("'" + (inline.Substring(8, 8).Trim() != "" ? FormatDate(inline.Substring(8, 8).Trim()) : "") + "'|"); //Curr-Bill-Date
                        outline.Append("'" + inline.Substring(16, 2).Trim() + "'|"); //Cst-Typ-Usg
                        outline.Append("'" + inline.Substring(18, 2).Trim() + "'|"); //Item-Cst-Opt
                        outline.Append("'" + inline.Substring(20, 26).Trim() + "'|"); //Cst-Typ-Name
                        outline.Append("'" + inline.Substring(46, 16).Trim() + "'|"); //Text-Id
                        outline.Append("'" + (inline.Substring(62, 8).Trim() != "" ? FormatDate(inline.Substring(62, 8).Trim()) : "") + "'|"); //CDS-Date
                        outline.Append("'" + inline.Substring(70, 2).Trim() + "'|"); //Wcovhd-Regn-Ind
                        outline.Append("'" + inline.Substring(72, 2).Trim() + "'|"); //Lbr-Regen-Ind
                        outline.Append("'" + inline.Substring(74, 2).Trim() + "'|"); //Itmcst_Regen_ind
                        outline.Append("'" + inline.Substring(76, 2).Trim() + "'|"); //BM_Regen_Ind
                        outline.Append("'" + (inline.Substring(78, 8).Trim() != "" ? FormatDate(inline.Substring(78, 8).Trim()) : "") + "'|"); //Prev-Bill-Date
                        outline.Append("'" + inline.Substring(86, 2).Trim() + "'|"); //Cst-Yld-Loss-Ind
                        outline.Append("'" + inline.Substring(88, 12).Trim() + "'|"); //AMAPS-Space-12
                        outline.Append("'" + inline.Substring(100, 2).Trim() + "'|"); //HD-Lbr-Rt-Tbl
                        outline.Append("'" + inline.Substring(102, 2).Trim() + "'|"); //HD-Wcov-Tbl-Nbr
                        outline.Append("'" + inline.Substring(104, 2).Trim() + "'|"); //HD-Curr-Bil-Typ
                        outline.Append("'" + (inline.Substring(106, 8).Trim() != "" ? FormatDate(inline.Substring(106, 8).Trim()) : "") + "'|"); //HD-BM-Date
                        outline.Append("'" + inline.Substring(114, 2).Trim() + "'|"); //HD-Cst-Typ-Usg
                        outline.Append("'" + inline.Substring(116, 2).Trim() + "'|"); //Hd-Item-Cst-Opt
                        outline.Append("'" + inline.Substring(118, 2).Trim() + "'|"); //PRS-Oper-Ind
                        outline.Append("'" + inline.Substring(120, 2).Trim() + "'|"); //Cst-Inpt-Mthd-01
                        outline.Append("'" + inline.Substring(122, 2).Trim() + "'|"); //Cst-Inpt-Mthd-02
                        outline.Append("'" + inline.Substring(124, 2).Trim() + "'|"); //Cst-Inpt-Mthd-03
                        outline.Append("'" + inline.Substring(126, 2).Trim() + "'|"); //Cst-Inpt-Mthd-04
                        outline.Append("'" + inline.Substring(128, 2).Trim() + "'|"); //Cst-Inpt-Mthd-05
                        outline.Append("'" + inline.Substring(130, 2).Trim() + "'|"); //Cst-Inpt-Mthd-06
                        outline.Append("'" + inline.Substring(132, 2).Trim() + "'|"); //Cst-Inpt-Mthd-07
                        outline.Append("'" + inline.Substring(134, 2).Trim() + "'|"); //Cst-Inpt-Mthd-08                        
                        outline.Append("'" + inline.Substring(136, 2).Trim() + "'|"); //Cst-Inpt-Mthd-09
                        outline.Append("'" + inline.Substring(138, 2).Trim() + "'|"); //Cst-Inpt-Mthd-10
                        outline.Append("'" + inline.Substring(140, 2).Trim() + "'|"); //Cst-Inpt-Mthd-11
                        outline.Append("'" + inline.Substring(142, 2).Trim() + "'|"); //Cst-Inpt-Mthd-12
                        outline.Append("'" + inline.Substring(144, 2).Trim() + "'|"); //Cst-Category-01
                        outline.Append("'" + inline.Substring(146, 2).Trim() + "'|"); //Cst-Category-02
                        outline.Append("'" + inline.Substring(148, 2).Trim() + "'|"); //Cst-Category-03
                        outline.Append("'" + inline.Substring(150, 2).Trim() + "'|"); //Cst-Category-04
                        outline.Append("'" + inline.Substring(152, 2).Trim() + "'|"); //Cst-Category-05
                        outline.Append("'" + inline.Substring(154, 2).Trim() + "'|"); //Cst-Category-06
                        outline.Append("'" + inline.Substring(156, 2).Trim() + "'|"); //Cst-Category-07
                        outline.Append("'" + inline.Substring(158, 2).Trim() + "'|"); //Cst-Category-08
                        outline.Append("'" + inline.Substring(160, 2).Trim() + "'|"); //Cst-Category-09
                        outline.Append("'" + inline.Substring(162, 2).Trim() + "'|"); //Cst-Category-10
                        outline.Append("'" + inline.Substring(164, 2).Trim() + "'|"); //Cst-Category-11
                        outline.Append("'" + inline.Substring(166, 2).Trim() + "'|"); //Cst-Category-12
                        outline.Append("'" + inline.Substring(168, 2).Trim() + "'|"); //Shrink-Opt
                        outline.Append(inline.Substring(170, 2).Trim() + "|"); //Shrink-Cst-Loc
                        outline.Append("'" + inline.Substring(172, 2).Trim() + "'|"); //ScrapOpt
                        outline.Append(inline.Substring(174, 2).Trim() + "|"); //Scrap-Cst-Loc
                        outline.Append(inline.Substring(176, 2).Trim() + "|"); //Run-Cst-Loc
                        outline.Append(inline.Substring(178, 2).Trim() + "|"); //Setup-Cst-Loc
                        outline.Append(inline.Substring(180, 2).Trim() + "|"); //Os-Vnd-Cst-Loc
                        outline.Append("'" + inline.Substring(182, 2).Trim() + "'|"); //Effcncy-Pct-Opt
                        outline.Append("'" + inline.Substring(184, 2).Trim() + "'|"); //Prod-Ovhd-Opt
                        outline.Append("'" + inline.Substring(186, 2).Trim() + "'|"); //Lbr-Grade-Ctl
                        outline.Append("'" + inline.Substring(188, 2).Trim() + "'|"); //Inv-Cst-Ind
                        outline.Append("'" + (inline.Substring(190, 8).Trim() != "" ? FormatDate(inline.Substring(190, 8).Trim()) : "") + "'|"); //Lst-Regn-Date
                        outline.Append("'" + (inline.Substring(198, 8).Trim() != "" ? FormatDate(inline.Substring(198, 8).Trim()) : "") + "'|"); //Lst-Netchg-Date
                        outline.Append("'" + (inline.Substring(206, 8).Trim() != "" ? FormatDate(inline.Substring(206, 8).Trim()) : "") + "'|"); //Lst-Roll-Date
                        outline.Append(inline.Substring(214, 3).Trim() + "|"); //Roll0ver-Src
                        outline.Append("'" + (inline.Substring(217, 8).Trim() != "" ? FormatDate(inline.Substring(217, 8).Trim()) : "") + "'|"); //Lst-Cstclr-Date
                        outline.Append("'" + inline.Substring(225, 2).Trim() + "'|"); //Cst-Clear-Opt
                        outline.Append("'" + inline.Substring(227, 2).Trim() + "'|"); //HD-Cst-Yld-Loss
                        if (inline.Length > 229)
                        {
                            outline.Append("'" + inline.Substring(229, inline.Length >= 249 ? 20 : 20 - (249 - inline.Length)).Trim() + "'|"); //AMAPS-Space-20
                        }
                        if (inline.Length > 249)
                        {
                            outline.Append("'" + inline.Substring(249, inline.Length >= 261 ? 12 : 12 - (261 - inline.Length)).Trim() + "'|"); //User-SPace-12
                        }
                        //Console.WriteLine(inline);
                        sw.WriteLine(outline.ToString());
                        //Console.WriteLine(outline.ToString());
                    }
                }
            }
            sr.Close();
        }
        private static void Process_ICF(string path)
        {
            Console.WriteLine("Processing ICF");
            StreamReader sr = new StreamReader(System.IO.Path.Combine(path, "newicf.txt"));
            StringBuilder outline = new StringBuilder();
            using (FileStream fs = new FileStream(System.IO.Path.Combine(path, "icffile.txt"), FileMode.Create))
            {
                using (StreamWriter sw = new StreamWriter(fs, Encoding.UTF8))
                {
                    outline.Clear();
                    outline.Append("'Item_Cst_Key'|");
                    outline.Append("'Item_Nbr'|");
                    outline.Append("'Cst_Over_CD'|");
                    outline.Append("'Shrink_Pct_Used'|");
                    outline.Append("'Mtl_Ovhd_Cds_01'|");
                    outline.Append("'Mtl_Ovhd_Cds_02'|");
                    outline.Append("'Mtl_Ovhd_Cds_03'|");
                    outline.Append("'Mtl_Ovhd_Cds_04'|");
                    outline.Append("'Mtl_Ovhd_Cst_01'|");
                    outline.Append("'Mtl_Ovhd_Cst_02'|");
                    outline.Append("'Mtl_Ovhd_Cst_03'|");
                    outline.Append("'Mtl_Ovhd_Cst_04'|");
                    outline.Append("'Mtl_Ovhd_Cst_E_01'|");
                    outline.Append("'Mtl_Ovhd_Cst_E_02'|");
                    outline.Append("'Mtl_Ovhd_Cst_E_03'|");
                    outline.Append("'Mtl_Ovhd_Cst_E_04'|");
                    outline.Append("'Tot_Cst_Elem_01'|");
                    outline.Append("'Tot_Cst_Elem_02'|");
                    outline.Append("'Tot_Cst_Elem_03'|");
                    outline.Append("'Tot_Cst_Elem_04'|");
                    outline.Append("'Tot_Cst_Elem_05'|");
                    outline.Append("'Tot_Cst_Elem_06'|");
                    outline.Append("'Tot_Cst_Elem_07'|");
                    outline.Append("'Tot_Cst_Elem_08'|");
                    outline.Append("'Tot_Cst_Elem_09'|");
                    outline.Append("'Tot_Cst_Elem_10'|");
                    outline.Append("'Tot_Cst_Elem_11'|");
                    outline.Append("'Tot_Cst_Elem_12'|");
                    outline.Append("'Va_Cst_Elem_01'|");
                    outline.Append("'Va_Cst_Elem_02'|");
                    outline.Append("'Va_Cst_Elem_03'|");
                    outline.Append("'Va_Cst_Elem_04'|");
                    outline.Append("'Va_Cst_Elem_05'|");
                    outline.Append("'Va_Cst_Elem_06'|");
                    outline.Append("'Va_Cst_Elem_07'|");
                    outline.Append("'Va_Cst_Elem_08'|");
                    outline.Append("'Va_Cst_Elem_09'|");
                    outline.Append("'Va_Cst_Elem_10'|");
                    outline.Append("'Va_Cst_Elem_11'|");
                    outline.Append("'Va_Cst_Elem_12'|");
                    outline.Append("'Cst_Exc_01'|");
                    outline.Append("'Cst_Exc_02'|");
                    outline.Append("'Cst_Exc_03'|");
                    outline.Append("'Cst_Exc_04'|");
                    outline.Append("'Cst_Exc_05'|");
                    outline.Append("'Cst_Exc_06'|");
                    outline.Append("'Cst_Exc_07'|");
                    outline.Append("'Cst_Exc_08'|");
                    outline.Append("'Cst_Exc_09'|");
                    outline.Append("'Cst_Exc_10'|");
                    outline.Append("'Cst_Exc_11'|");
                    outline.Append("'Cst_Exc_12'|");
                    outline.Append("'Cst_Exc_13'|");
                    outline.Append("'Cst_Exc_14'|");
                    outline.Append("'Cst_Exc_15'|");
                    outline.Append("'Cst_Exc_16'|");
                    outline.Append("'Cst_Exc_17'|");
                    outline.Append("'Cst_Exc_18'|");
                    outline.Append("'Cst_Exc_19'|");
                    outline.Append("'Cst_Exc_20'|");
                    outline.Append("'Cst_Exc_21'|");
                    outline.Append("'Cst_Exc_22'|");
                    outline.Append("'Cst_Exc_23'|");
                    outline.Append("'Cst_Exc_24'|");
                    outline.Append("'Cst_Exc_25'|");
                    outline.Append("'Cst_Exc_26'|");
                    outline.Append("'Text_Id'|");
                    outline.Append("'Recost_Date'|");
                    outline.Append("'CDS_Date'|");
                    outline.Append("'Shrink_Cst'|");
                    outline.Append("'Rev_Level'|");
                    outline.Append("'SOQ_Used'|");
                    outline.Append("'AMAPS_Space_12'|");
                    outline.Append("'User_Space_12'|");
                    outline.Append("'Cst_Typ_X'|");
                    sw.WriteLine(outline.ToString());
                    while (sr.Peek() >= 0)
                    {
                        String inline = sr.ReadLine();
                        outline.Clear();
                        outline.Append("'" + inline.Substring(0, 18).Trim() + "'|"); //Item-Cst-Key
                        outline.Append("'" + inline.Substring(18, 16).Trim() + "'|"); //Item-Nbr
                        outline.Append("'" + inline.Substring(34, 2).Trim() + "'|"); //Cst-Over-Cd
                        outline.Append(inline.Substring(36, 3).Trim() + "|"); //Shrink-Pct-Used
                        outline.Append("'" + inline.Substring(39, 4).Trim() + "'|"); //Mtl-Ovhd-Cds-01
                        outline.Append("'" + inline.Substring(43, 4).Trim() + "'|"); //Mtl-Ovhd-Cds-02
                        outline.Append("'" + inline.Substring(47, 4).Trim() + "'|"); //Mtl-Ovhd-Cds-03
                        outline.Append("'" + inline.Substring(51, 4).Trim() + "'|"); //Mtl-Ovhd-Cds-04
                        outline.Append(inline.Substring(55, 16).Trim() + "|"); //Mtl-Ovhd-Cst-01
                        outline.Append(inline.Substring(71, 16).Trim() + "|"); //Mtl-Ovhd-Cst-02
                        outline.Append(inline.Substring(87, 16).Trim() + "|"); //Mtl-Ovhd-Cst-03
                        outline.Append(inline.Substring(103, 16).Trim() + "|"); //Mtl-Ovhd-Cst-04
                        outline.Append("'" + inline.Substring(119, 2).Trim() + "'|"); //Mtl-Ovhd-Cst-El-01
                        outline.Append("'" + inline.Substring(121, 2).Trim() + "'|"); //Mtl-Ovhd-Cst-El-02
                        outline.Append("'" + inline.Substring(123, 2).Trim() + "'|"); //Mtl-Ovhd-Cst-El-03
                        outline.Append("'" + inline.Substring(125, 2).Trim() + "'|"); //Mtl-Ovhd-Cst-El-04
                        outline.Append(inline.Substring(127, 16).Trim() + "|"); //Tot-Cst-Elem-01
                        outline.Append(inline.Substring(143, 16).Trim() + "|"); //Tot-Cst-Elem-02
                        outline.Append(inline.Substring(159, 16).Trim() + "|"); //Tot-Cst-Elem-03
                        outline.Append(inline.Substring(175, 16).Trim() + "|"); //Tot-Cst-Elem-04
                        outline.Append(inline.Substring(191, 16).Trim() + "|"); //Tot-Cst-Elem-05
                        outline.Append(inline.Substring(207, 16).Trim() + "|"); //Tot-Cst-Elem-06
                        outline.Append(inline.Substring(223, 16).Trim() + "|"); //Tot-Cst-Elem-07
                        outline.Append(inline.Substring(239, 16).Trim() + "|"); //Tot-Cst-Elem-08
                        outline.Append(inline.Substring(255, 16).Trim() + "|"); //Tot-Cst-Elem-09
                        outline.Append(inline.Substring(271, 16).Trim() + "|"); //Tot-Cst-Elem-10
                        outline.Append(inline.Substring(287, 16).Trim() + "|"); //Tot-Cst-Elem-11
                        outline.Append(inline.Substring(303, 16).Trim() + "|"); //Tot-Cst-Elem-12
                        outline.Append(inline.Substring(319, 16).Trim() + "|"); //Va-Cst-Elem-01
                        outline.Append(inline.Substring(335, 16).Trim() + "|"); //Va-Cst-Elem-02
                        outline.Append(inline.Substring(351, 16).Trim() + "|"); //Va-Cst-Elem-03
                        outline.Append(inline.Substring(367, 16).Trim() + "|"); //Va-Cst-Elem-04
                        outline.Append(inline.Substring(383, 16).Trim() + "|"); //Va-Cst-Elem-05
                        outline.Append(inline.Substring(399, 16).Trim() + "|"); //Va-Cst-Elem-06
                        outline.Append(inline.Substring(415, 16).Trim() + "|"); //Va-Cst-Elem-07
                        outline.Append(inline.Substring(431, 16).Trim() + "|"); //Va-Cst-Elem-08
                        outline.Append(inline.Substring(447, 16).Trim() + "|"); //Va-Cst-Elem-09
                        outline.Append(inline.Substring(463, 16).Trim() + "|"); //Va-Cst-Elem-10
                        outline.Append(inline.Substring(479, 16).Trim() + "|"); //Va-Cst-Elem-11
                        outline.Append(inline.Substring(495, 16).Trim() + "|"); //Va-Cst-Elem-12
                        outline.Append(inline.Substring(511, 2).Trim() + "|"); //Cst-Exc-01
                        outline.Append(inline.Substring(513, 2).Trim() + "|"); //Cst-Exc-02
                        outline.Append(inline.Substring(515, 2).Trim() + "|"); //Cst-Exc-03
                        outline.Append(inline.Substring(517, 2).Trim() + "|"); //Cst-Exc-04
                        outline.Append(inline.Substring(519, 2).Trim() + "|"); //Cst-Exc-05
                        outline.Append(inline.Substring(521, 2).Trim() + "|"); //Cst-Exc-06
                        outline.Append(inline.Substring(523, 2).Trim() + "|"); //Cst-Exc-07
                        outline.Append(inline.Substring(525, 2).Trim() + "|"); //Cst-Exc-08
                        outline.Append(inline.Substring(527, 2).Trim() + "|"); //Cst-Exc-09
                        outline.Append(inline.Substring(529, 2).Trim() + "|"); //Cst-Exc-10
                        outline.Append(inline.Substring(531, 2).Trim() + "|"); //Cst-Exc-11
                        outline.Append(inline.Substring(533, 2).Trim() + "|"); //Cst-Exc-12
                        outline.Append(inline.Substring(535, 2).Trim() + "|"); //Cst-Exc-13
                        outline.Append(inline.Substring(537, 2).Trim() + "|"); //Cst-Exc-14
                        outline.Append(inline.Substring(539, 2).Trim() + "|"); //Cst-Exc-15
                        outline.Append(inline.Substring(541, 2).Trim() + "|"); //Cst-Exc-16
                        outline.Append(inline.Substring(543, 2).Trim() + "|"); //Cst-Exc-17
                        outline.Append(inline.Substring(545, 2).Trim() + "|"); //Cst-Exc-18
                        outline.Append(inline.Substring(547, 2).Trim() + "|"); //Cst-Exc-19
                        outline.Append(inline.Substring(549, 2).Trim() + "|"); //Cst-Exc-20
                        outline.Append(inline.Substring(551, 2).Trim() + "|"); //Cst-Exc-21
                        outline.Append(inline.Substring(553, 2).Trim() + "|"); //Cst-Exc-22
                        outline.Append(inline.Substring(555, 2).Trim() + "|"); //Cst-Exc-23
                        outline.Append(inline.Substring(557, 2).Trim() + "|"); //Cst-Exc-24
                        outline.Append(inline.Substring(559, 2).Trim() + "|"); //Cst-Exc-25
                        outline.Append(inline.Substring(561, 2).Trim() + "|"); //Cst-Exc-26
                        outline.Append("'" + inline.Substring(563, 16).Trim() + "'|"); //Text-Id
                        outline.Append("'" + (inline.Substring(579, 8).Trim() != "" ? FormatDate(inline.Substring(579, 8).Trim()) : "") + "'|"); //Recost-Date
                        outline.Append("'" + (inline.Substring(587, 8).Trim() != "" ? FormatDate(inline.Substring(587, 8).Trim()) : "") + "'|"); //CDS-Date
                        outline.Append(inline.Substring(595, 16).Trim() + "|"); //Shrink-Cst
                        outline.Append("'" + inline.Substring(611, 2).Trim() + "'|"); //Rev-Level
                        outline.Append(inline.Substring(613, 17).Trim() + "|"); //SOQ-USed
                        outline.Append("'" + inline.Substring(630, 12).Trim() + "'|"); //AMAPS-Space-12
                        outline.Append("'" + inline.Substring(642, 12).Trim() + "'|"); //User-SPace-12
                        if (inline.Length > 654)
                        {
                            outline.Append("'" + inline.Substring(654, inline.Length >= 656 ? 2 : 2 - (656 - inline.Length)).Trim() + "'|"); //Cst-Typ-X
                        }
                        //Console.WriteLine(inline);
                        sw.WriteLine(outline.ToString());
                        //Console.WriteLine(outline.ToString());
                    }
                }
            }
            sr.Close();
        }
        private static void Process_MRF(string path)
        {
            Console.WriteLine("Processing MRF");
            StreamReader sr = new StreamReader(System.IO.Path.Combine(path, "newmrf.txt"));
            StringBuilder outline = new StringBuilder();
            using (FileStream fs = new FileStream(System.IO.Path.Combine(path, "mrffile.txt"), FileMode.Create))
            {
                using (StreamWriter sw = new StreamWriter(fs, Encoding.UTF8))
                {
                    outline.Clear();
                    outline.Append("'Mtl_Ovhd_cd'|");
                    outline.Append("'Mtl_Ovhd_Typ'|");
                    outline.Append("'Mtl_Ovhd_Rate'|");
                    outline.Append("'Apl_Cst_Lvl'|");
                    outline.Append("'Apl_Cst_Elem_01'|");
                    outline.Append("'Apl_Cst_Elem_02'|");
                    outline.Append("'Apl_Cst_Elem_03'|");
                    outline.Append("'Accum_Cst_Elem'|");
                    outline.Append("'First_Use_Cd'|");
                    outline.Append("'Text_Id'|");
                    outline.Append("'GL_Code'|");
                    outline.Append("'CDS_Date'|");
                    outline.Append("'Apln_Method'|");
                    outline.Append("'AMAPS_Space_20'|");
                    outline.Append("'User_Space_12'|");
                    sw.WriteLine(outline.ToString());
                    while (sr.Peek() >= 0)
                    {
                        String inline = sr.ReadLine();
                        outline.Clear();
                        outline.Append("'" + inline.Substring(0, 4).Trim() + "'|"); //Mtl-Ovhd_Cd
                        outline.Append("'" + inline.Substring(4, 2).Trim() + "'|"); //Mtl-Ovhd-Typ
                        outline.Append(inline.Substring(6, 10).Trim() + "|"); //Mtl-Ovhd-Rate
                        outline.Append("'" + inline.Substring(16, 2).Trim() + "'|"); //Apl-Cst-Lvl
                        outline.Append("'" + inline.Substring(18, 2).Trim() + "'|"); //Apl-Cst-Elem-01
                        outline.Append("'" + inline.Substring(20, 2).Trim() + "'|"); //Apl-Cst-Elem-02
                        outline.Append("'" + inline.Substring(22, 2).Trim() + "'|"); //Apl-Cst-Elem-03
                        outline.Append("'" + inline.Substring(24, 2).Trim() + "'|"); //Accum-Cst-Elem
                        outline.Append("'" + inline.Substring(26, 2).Trim() + "'|"); //First-Use-Cd
                        if (inline.Length > 28)
                        {
                            outline.Append("'" + inline.Substring(28, inline.Length >= 16 ? 24 : 16 - (44 - inline.Length)).Trim() + "'|"); //Text-Id
                        }
                        if (inline.Length > 44)
                        {
                            outline.Append("'" + inline.Substring(44, inline.Length >= 68 ? 24 : 24 - (68 - inline.Length)).Trim() + "'|"); //GL-Code
                        }
                        if (inline.Length > 68)
                        {
                            outline.Append("'" + inline.Substring(68, inline.Length >= 76 ? 8 : 8 - (76 - inline.Length)).Trim() != "" ? FormatDate(inline.Substring(68, 8).Trim()) : "" + "'|"); //User-Space-12
                        }
                        //outline.Append("'" + (inline.Substring(68, 8).Trim() != "" ? FormatDate(inline.Substring(68, 8).Trim()) : "") + "'|"); //CDS-Date
                        if (inline.Length > 76)
                        {
                            outline.Append("'" + inline.Substring(76, inline.Length >= 78 ? 2 : 2 - (78 - inline.Length)).Trim() + "'|"); //Apl-Method
                        }
                        if (inline.Length > 78)
                        {
                            outline.Append("'" + inline.Substring(78, inline.Length >= 90 ? 12 : 12 - (90 - inline.Length)).Trim() + "'|"); //AMAPS-Space-12
                        }
                        if (inline.Length > 90)
                        {
                            outline.Append("'" + inline.Substring(90, inline.Length >= 102 ? 12 : 12 - (102 - inline.Length)).Trim() + "'|"); //User-Space-12
                        }
                        //Console.WriteLine(inline);
                        sw.WriteLine(outline.ToString());
                        //Console.WriteLine(outline.ToString());
                    }
                }
            }
            sr.Close();
        }
        private static void Process_CDF(string path, string filenamein, string filenameout)
        {
            Console.WriteLine("Processing CDF ({0})", filenamein);
            StreamReader sr = new StreamReader(System.IO.Path.Combine(path, filenamein));
            StringBuilder outline = new StringBuilder();
            using (FileStream fs = new FileStream(System.IO.Path.Combine(path, filenameout), FileMode.Create))
            {
                using (StreamWriter sw = new StreamWriter(fs, Encoding.UTF8))
                {
                    outline.Clear();
                    outline.Append("'Item_Nbr'|");
                    outline.Append("'Txn_Scr'|");
                    outline.Append("'Txn_Fcn'|");
                    outline.Append("'Txn_User'|");
                    outline.Append("'Txn_Mode'|");
                    outline.Append("'Source_Code'|");
                    outline.Append("'Puf_Thf_Ind'|");
                    outline.Append("'Puf_LTS_Ind'|");
                    outline.Append("'Processed_Date'|");
                    outline.Append("'Order_Nbr'|");
                    outline.Append("'Order_Type'|");
                    outline.Append("'Supply_Type'|");
                    outline.Append("'SMP_Ind'|");
                    outline.Append("'Schedule'|");
                    outline.Append("'Send_Dist_Loc'|");
                    outline.Append("'Send_Qty_Code'|");
                    outline.Append("'Send_Lot_Nbr'|");
                    outline.Append("'Recd_Dist_Loc'|");
                    outline.Append("'Recd_Qty_Code'|");
                    outline.Append("'Recd_Lot_Nbr'|");
                    outline.Append("'Txn_Cst_Per_Unit'|");
                    outline.Append("'Txn_Qty'|");
                    outline.Append("'Txn_Reason'|");
                    outline.Append("'Txn_Acty_Code'|");
                    outline.Append("'Txn_Int_Code'|");
                    outline.Append("'Document'|");
                    outline.Append("'Shipper_Ref'|");
                    outline.Append("'Txn_Text_Id'|");
                    outline.Append("'QC_Text_Id'|");
                    outline.Append("'Retest_Date'|");
                    outline.Append("'Expire_Date'|");
                    outline.Append("'GL_FillerNbr'|");
                    outline.Append("'GL_Code'|");
                    outline.Append("'GL_Journal_Nbr'|");
                    outline.Append("'Contra_Acct'|");
                    outline.Append("'Reference_Id'|");
                    outline.Append("'Hst_Posted_Date'|");
                    outline.Append("'CMS_Posted_Date'|");
                    outline.Append("'FCI_Posted_Date'|");
                    outline.Append("'AMAPS_Space_24'|");
                    outline.Append("'User_Space_32'|");
                    outline.Append("'Trans_Date_X'|");
                    outline.Append("'Trans_Time_X'|");
                    sw.WriteLine(outline.ToString());
                    while (sr.Peek() >= 0)
                    {
                        String inline = sr.ReadLine();
                        outline.Clear();
                        outline.Append("'" + inline.Substring(0, 16).Trim() + "'|"); //Item-Nbr
                        outline.Append("'" + inline.Substring(16, 4).Trim() + "'|"); //Txn-Scr
                        outline.Append("'" + inline.Substring(20, 4).Trim() + "'|"); //Txn-Fcn
                        outline.Append("'" + inline.Substring(24, 4).Trim() + "'|"); //Txn-User
                        outline.Append("'" + inline.Substring(28, 2).Trim() + "'|"); //Txn-Mode
                        outline.Append("'" + inline.Substring(30, 2).Trim() + "'|"); //Source-Code
                        outline.Append("'" + inline.Substring(32, 1).Trim() + "'|"); //Puf-Thf-Inf
                        outline.Append("'" + inline.Substring(33, 1).Trim() + "'|"); //Puf-LTS-Ind
                        outline.Append("'" + (inline.Substring(34, 8).Trim() != "" ? FormatDate(inline.Substring(34, 8).Trim()) : "") + "'|"); //Processed-Date
                        outline.Append("'" + inline.Substring(42, 16).Trim() + "'|"); //Order-Nbr
                        outline.Append("'" + inline.Substring(58, 2).Trim() + "'|"); //Order-Type
                        outline.Append("'" + inline.Substring(60, 2).Trim() + "'|"); //Supply-Type
                        outline.Append("'" + inline.Substring(62, 2).Trim() + "'|"); //SMP-Ind
                        outline.Append("'" + inline.Substring(64, 8).Trim() + "'|"); //Schedule
                        // skip distribution part of location
                        outline.Append("'" + inline.Substring(76, 10).Trim() + "'|"); //Send-Dist-Loc
                        outline.Append("'" + inline.Substring(86, 2).Trim() + "'|"); //Send-Qty-Code
                        outline.Append("'" + inline.Substring(88, 16).Trim() + "'|"); //Send-Lot-Nbr
                        // skip distribution part of location
                        outline.Append("'" + inline.Substring(108, 10).Trim() + "'|"); //Recd-Dist-Loc
                        outline.Append("'" + inline.Substring(118, 2).Trim() + "'|"); //Recd-Qty-Code
                        outline.Append("'" + inline.Substring(120, 16).Trim() + "'|"); //Recd-Lot-Nbr
                        outline.Append(inline.Substring(136, 16).Trim() + "|"); //Txn-Cst-Per-Unt
                        outline.Append(inline.Substring(152, 17).Trim() + "|"); //Txn-Qty
                        outline.Append("'" + inline.Substring(169, 2).Trim() + "'|"); //Txn-Reason
                        outline.Append("'" + inline.Substring(171, 2).Trim() + "'|"); //Txn-Acty-Code
                        outline.Append("'" + inline.Substring(173, 2).Trim() + "'|"); //Txn-Int-Code
                        outline.Append("'" + inline.Substring(175, 16).Trim() + "'|"); //Document
                        outline.Append("'" + inline.Substring(191, 16).Trim() + "'|"); //Shipper-Ref
                        outline.Append("'" + inline.Substring(207, 16).Trim() + "'|"); //Txn-Text-Id
                        outline.Append("'" + inline.Substring(223, 16).Trim() + "'|"); //QC-Text-Id
                        outline.Append("'" + (inline.Substring(239, 8).Trim() != "" ? FormatDate(inline.Substring(239, 8).Trim()) : "") + "'|"); //Retest-Date
                        outline.Append("'" + (inline.Substring(247, 8).Trim() != "" ? FormatDate(inline.Substring(247, 8).Trim()) : "") + "'|"); //Expire-Date
                        outline.Append("'" + inline.Substring(255, 30).Trim() + "'|"); //GL-Filler
                        outline.Append("'" + inline.Substring(285, 24).Trim() + "'|"); //GL-Code
                        outline.Append("'" + inline.Substring(309, 6).Trim() + "'|"); //GL-Journal-Nbr
                        outline.Append("'" + inline.Substring(315, 24).Trim() + "'|"); //Contra-Acct
                        outline.Append("'" + inline.Substring(339, 20).Trim() + "'|"); //Reference-Id
                        outline.Append("'" + (inline.Substring(359, 8).Trim() != "" ? FormatDate(inline.Substring(359, 8).Trim()) : "") + "'|"); //Hst-Posted-Date
                        outline.Append("'" + (inline.Substring(367, 8).Trim() != "" ? FormatDate(inline.Substring(367, 8).Trim()) : "") + "'|"); //CMS-Posted-Date
                        outline.Append("'" + (inline.Substring(375, 8).Trim() != "" ? FormatDate(inline.Substring(375, 8).Trim()) : "") + "'|"); //FCI-Posted-Date
                        outline.Append("'" + inline.Substring(383, 24).Trim() + "'|"); //AMAPS-Space-24
                        outline.Append("'" + inline.Substring(407, 32).Trim() + "'|"); //User-Space-32
                        outline.Append("'" + (inline.Substring(439, 8).Trim() != "" ? FormatDate(inline.Substring(439, 8).Trim()) : "") + "'|"); //Trans-Date-X
                        outline.Append("'" + inline.Substring(447, 6).Trim() + "'|"); //Trans-Time-X
                        //Console.WriteLine(inline);
                        sw.WriteLine(outline.ToString());
                        //Console.WriteLine(outline.ToString());
                    }
                }
            }
            sr.Close();
        }
        private static void Process_CTL(string path)
        {
            Console.WriteLine("Processing CTL");
            StreamReader sr = new StreamReader(System.IO.Path.Combine(path, "newctl.txt"));
            StringBuilder outline = new StringBuilder();
            using (FileStream fs = new FileStream(System.IO.Path.Combine(path, "ctlfile.txt"), FileMode.Create))
            {
                using (StreamWriter sw = new StreamWriter(fs, Encoding.UTF8))
                {
                    outline.Clear();
                    outline.Append("'Rec_Data'|");
                    outline.Append("'Rec_Seq'|");
                    outline.Append("'Lst_Maint_Date_C'|");
                    outline.Append("'Rec_Id'|");
                    outline.Append("'Rec_Key'|");
                    sw.WriteLine(outline.ToString());
                    while (sr.Peek() >= 0)
                    {
                        String inline = sr.ReadLine();
                        outline.Clear();
                        outline.Append("'" + inline.Substring(0, 60).Trim() + "'|"); //Rec-Data
                        outline.Append("'" + inline.Substring(60, 4).Trim() + "'|"); //Rec_Seq
                        outline.Append("'" + (inline.Substring(64, 8).Trim() != "" ? FormatDate(inline.Substring(64, 8).Trim()) : "") + "'|"); //Lst_Maint_Date_C
                        outline.Append("'" + inline.Substring(72, 4).Trim() + "'|"); //Rec-Id
                        if (inline.Length > 76)
                        {
                            outline.Append("'" + inline.Substring(76, inline.Length >= 20 ? 20 : 96 - (96 - inline.Length)).Trim() + "'|"); //Rec-Key
                        }
                        //Console.WriteLine(inline);
                        sw.WriteLine(outline.ToString());
                        //Console.WriteLine(outline.ToString());
                    }
                }
            }
            sr.Close();
        }
        private static void Process_TGF(string path)
        {
            Console.WriteLine("Processing TGF");
            StreamReader sr = new StreamReader(System.IO.Path.Combine(path, "newtgf.txt"));
            StringBuilder outline = new StringBuilder();
            using (FileStream fs = new FileStream(System.IO.Path.Combine(path, "tgffile.txt"), FileMode.Create))
            {
                using (StreamWriter sw = new StreamWriter(fs, Encoding.UTF8))
                {
                    outline.Clear();
                    outline.Append("'Text_id'|");
                    outline.Append("'Text_Owner'|");
                    outline.Append("'Text_Exp-Date'|");
                    outline.Append("'Text_Usage_Cntr'|");
                    outline.Append("'Text_Line_Cntr'|");
                    outline.Append("'Last_Maint_Date'|");
                    outline.Append("'AMAPS_Space_06'|");
                    outline.Append("'User_Space_06'|");
                    sw.WriteLine(outline.ToString());
                    while (sr.Peek() >= 0)
                    {
                        String inline = sr.ReadLine();
                        outline.Clear();
                        outline.Append("'" + inline.Substring(0, 16).Trim() + "'|"); //Text_Id
                        outline.Append("'" + inline.Substring(16, 4).Trim() + "'|"); //Text_Owner
                        outline.Append("'" + (inline.Substring(20, 8).Trim() != "" ? FormatDate(inline.Substring(20, 8).Trim()) : "") + "'|"); //Text-Exp-Date
                        outline.Append(inline.Substring(28, 4).Trim() + "|"); //Text-Usage-Cntr
                        outline.Append(inline.Substring(32, 3).Trim() + "|"); //Line-Usage-Cntr
                        outline.Append("'" + (inline.Substring(35, 8).Trim() != "" ? FormatDate(inline.Substring(35, 8).Trim()) : "") + "'|"); //Last-Maint-Date
                        if (inline.Length > 43)
                        {
                            outline.Append("'" + inline.Substring(43, inline.Length >= 6 ? 6 : 51 - (51 - inline.Length)).Trim() + "'|"); //AMAPS-Space-06
                        }
                        if (inline.Length > 49)
                        {
                            outline.Append("'" + inline.Substring(49, inline.Length >= 6 ? 6 : 55 - (55 - inline.Length)).Trim() + "'|"); //User-Space-06
                        }
                        //Console.WriteLine(inline);
                        sw.WriteLine(outline.ToString());
                        //Console.WriteLine(outline.ToString());
                    }
                }
            }
            sr.Close();
        }
        private static void Process_TLF(string path)
        {
            Console.WriteLine("Processing TLF");
            StreamReader sr = new StreamReader(System.IO.Path.Combine(path, "newtlf.txt"));
            StringBuilder outline = new StringBuilder();
            using (FileStream fs = new FileStream(System.IO.Path.Combine(path, "tlffile.txt"), FileMode.Create))
            {
                using (StreamWriter sw = new StreamWriter(fs, Encoding.UTF8))
                {
                    outline.Clear();
                    outline.Append("'Text_Id'|");
                    outline.Append("'Text_Line'|");
                    outline.Append("'Last_Maint_Date'|");
                    outline.Append("'AMAPS_Space_10'|");
                    outline.Append("'User_Space_10'|");
                    outline.Append("'Text_Seq'|");
                    sw.WriteLine(outline.ToString());
                    while (sr.Peek() >= 0)
                    {
                        String inline = sr.ReadLine();
                        outline.Clear();
                        outline.Append("'" + inline.Substring(0, 16).Trim() + "'|"); //Text_Id
                        outline.Append("'" + inline.Substring(16, 54).Trim() + "'|"); //Text_Line
                        //SKIP PROC-ID
                        outline.Append("'" + (inline.Substring(78, 8).Trim() != "" ? FormatDate(inline.Substring(78, 8).Trim()) : "") + "'|"); //Last-Maint-Date
                        outline.Append("'" + inline.Substring(86, 10).Trim() + "'|"); //AMAPS-Space-10
                        outline.Append("'" + inline.Substring(96, 10).Trim() + "'|"); //User-Space-10
                        outline.Append("'" + inline.Substring(106, 4).Trim() + "'|"); //Text-Seq
                        //Console.WriteLine(inline);
                        sw.WriteLine(outline.ToString());
                        //Console.WriteLine(outline.ToString());
                    }
                }
            }
            sr.Close();
        }
        private static void Process_ADR(string path)
        {
            Console.WriteLine("Processing ADR");
            StreamReader sr = new StreamReader(System.IO.Path.Combine(path, "newadr.txt"));
            StringBuilder outline = new StringBuilder();
            using (FileStream fs = new FileStream(System.IO.Path.Combine(path, "adrfile.txt"), FileMode.Create))
            {
                using (StreamWriter sw = new StreamWriter(fs, Encoding.UTF8))
                {
                    outline.Clear();
                    outline.Append("'Address_Key'|");
                    outline.Append("'Name'|");
                    outline.Append("'Address_1'|");
                    outline.Append("'Address_2'|");
                    outline.Append("'Address_3'|");
                    outline.Append("'Address_4'|");
                    outline.Append("'Address_5'|");
                    outline.Append("'City'|");
                    outline.Append("'State'|");
                    outline.Append("'Zip'|");
                    outline.Append("'Country'|");
                    outline.Append("'Telephone'|");
                    outline.Append("'Geo_Region'|");
                    outline.Append("'Contact'|");
                    outline.Append("'Sales_Region'|");
                    outline.Append("'Credit_Code'|");
                    outline.Append("'Credit_Limit'|");
                    outline.Append("'Usage_Counter'|");
                    outline.Append("'Effective_Date'|");
                    outline.Append("'Date_Maint'|");
                    outline.Append("'Flags_8'|");
                    outline.Append("'Text_Id'|");
                    outline.Append("'AMAPS_Space_20'|");
                    outline.Append("'User_Space_20'|");
                    sw.WriteLine(outline.ToString());
                    while (sr.Peek() >= 0)
                    {
                        String inline = sr.ReadLine();
                        outline.Clear();
                        outline.Append("'" + inline.Substring(0, 22).Trim() + "'|"); //Address-Key
                        outline.Append("'" + inline.Substring(22, 30).Trim() + "'|"); //Name
                        outline.Append("'" + inline.Substring(52, 30).Trim() + "'|"); //Address-1
                        outline.Append("'" + inline.Substring(82, 30).Trim() + "'|"); //Address-2
                        outline.Append("'" + inline.Substring(112, 30).Trim() + "'|"); //Address-3
                        outline.Append("'" + inline.Substring(142, 30).Trim() + "'|"); //Address-4
                        outline.Append("'" + inline.Substring(172, 30).Trim() + "'|"); //Address-5
                        outline.Append("'" + inline.Substring(202, 20).Trim() + "'|"); //City
                        outline.Append("'" + inline.Substring(222, 2).Trim() + "'|"); //State
                        outline.Append("'" + inline.Substring(224, 10).Trim() + "'|"); //Zip
                        outline.Append("'" + inline.Substring(234, 30).Trim() + "'|"); //Country
                        outline.Append("'" + inline.Substring(264, 20).Trim() + "'|"); //Telephone
                        outline.Append("'" + inline.Substring(284, 4).Trim() + "'|"); //Geo-Region
                        outline.Append("'" + inline.Substring(288, 30).Trim() + "'|"); //Contact
                        outline.Append("'" + inline.Substring(318, 4).Trim() + "'|"); //Sales-Region
                        outline.Append("'" + inline.Substring(322, 4).Trim() + "'|"); //Credit-Code
                        outline.Append(inline.Substring(326, 10).Trim() + "|"); //Credit-Limit
                        outline.Append(inline.Substring(336, 4).Trim() + "|"); //Usage-Counter
                        outline.Append("'" + (inline.Substring(340, 8).Trim() != "" ? FormatDate(inline.Substring(340, 8).Trim()) : "") + "'|"); //Effective-Date
                        outline.Append("'" + (inline.Substring(348, 8).Trim() != "" ? FormatDate(inline.Substring(348, 8).Trim()) : "") + "'|"); //Date-Maint
                        outline.Append("'" + inline.Substring(356, 8).Trim() + "'|"); //Flags-8
                        //outline.Append("'" + inline.Substring(364, 16).Trim() + "'|"); //Text-Id
                        if (inline.Length > 364)
                        {
                            outline.Append("'" + inline.Substring(364, inline.Length >= 16 ? 16 : 380 - (380 - inline.Length)).Trim() + "'|"); //Text-Id
                        }
                        if (inline.Length > 380)
                        {
                            outline.Append("'" + inline.Substring(380, inline.Length >= 20 ? 20 : 400 - (400 - inline.Length)).Trim() + "'|"); //AMAPS-Space-20
                        }
                        if (inline.Length > 400)
                        {
                            outline.Append("'" + inline.Substring(400, inline.Length >= 20 ? 20 : 420 - (420 - inline.Length)).Trim() + "'|"); //User-Space-20
                        }
                        //Console.WriteLine(inline);
                        sw.WriteLine(outline.ToString());
                        //Console.WriteLine(outline.ToString());
                    }
                }
            }
            sr.Close();
        }
        private static void Process_MIF(string path)
        {
            Console.WriteLine("Processing MIF");
            StreamReader sr = new StreamReader(System.IO.Path.Combine(path, "newmif.txt"));
            StringBuilder outline = new StringBuilder();
            using (FileStream fs = new FileStream(System.IO.Path.Combine(path, "miffile.txt"), FileMode.Create))
            {
                using (StreamWriter sw = new StreamWriter(fs, Encoding.UTF8))
                {
                    outline.Clear();
                    outline.Append("'Item_Nbr'|");
                    outline.Append("'Item_Desc'|");
                    outline.Append("'Mstr_Schdr'|");
                    outline.Append("'Mstr_Schd_Type'|");
                    outline.Append("'Mstr_Schd_Class'|");
                    outline.Append("'Cust_DM_Alloc'|");
                    outline.Append("'Prj_Avl_Bal_Cd'|");
                    outline.Append("'Horizon_Periods'|");
                    outline.Append("'Product_Group'|");
                    outline.Append("'Product_Subgrp'|");
                    outline.Append("'Cum_Lead_Time'|");
                    outline.Append("'MPS_Order_Qty'|");
                    outline.Append("'Special_Instr'|");
                    outline.Append("'Comp_CO_Count'|");
                    outline.Append("'MPS_Date'|");
                    outline.Append("'Frcst_Maint_Cd'|");
                    outline.Append("'Proj_Qty'|");
                    outline.Append("'Proj_Internal'|");
                    outline.Append("'Frcst_Ret_Pers'|");
                    outline.Append("'MPS_Ret_Pers'|");
                    outline.Append("'Frcst_Maint_Dte'|");
                    outline.Append("'Frcst_Replan_Cd'|");
                    outline.Append("'Inquiry_Code'|");
                    outline.Append("'Supp_Maint_Cd'|");
                    outline.Append("'Supp_Maint_Fnce'|");
                    outline.Append("'Supp_Maint_Off'|");
                    outline.Append("'Supp_Maint_PABC'|");
                    outline.Append("'AMAPS_Space_02'|");
                    outline.Append("'User_Space_10'|");
                    sw.WriteLine(outline.ToString());
                    while (sr.Peek() >= 0)
                    {
                        String inline = sr.ReadLine();
                        outline.Clear();
                        outline.Append("'" + inline.Substring(0, 16).Trim() + "'|"); //Item-Nbr
                        outline.Append("'" + inline.Substring(16, 26).Trim() + "'|"); //Item-Desc
                        outline.Append("'" + inline.Substring(42, 2).Trim() + "'|"); //Mstr-Schdr
                        outline.Append("'" + inline.Substring(44, 2).Trim() + "'|"); //Mstr-Schd-Type
                        outline.Append("'" + inline.Substring(46, 2).Trim() + "'|"); //Mstr-Schd-Class
                        outline.Append("'" + inline.Substring(48, 2).Trim() + "'|"); //Cust-DM-Alloc
                        outline.Append("'" + inline.Substring(50, 2).Trim() + "'|"); //Prj-Avl-Bal-Cd
                        outline.Append(inline.Substring(52, 2).Trim() + "|"); //Horizon-Periods
                        outline.Append("'" + inline.Substring(54, 6).Trim() + "'|"); //Product-Group
                        outline.Append("'" + inline.Substring(60, 4).Trim() + "'|"); //Product-Subgrp
                        outline.Append(inline.Substring(64, 3).Trim() + "|"); //Cum-Lead-Time
                        outline.Append(inline.Substring(67, 7).Trim() + "|"); //MPS-Order-Qty
                        outline.Append("'" + inline.Substring(74,26).Trim() + "'|"); //Special-Instr
                        outline.Append(inline.Substring(100, 4).Trim() + "|"); //Comp-CO-Count
                        outline.Append("'" + (inline.Substring(104, 8).Trim() != "" ? FormatDate(inline.Substring(104, 8).Trim()) : "") + "'|"); //MPS-Date
                        outline.Append("'" + inline.Substring(112, 2).Trim() + "'|"); //Frcst-Maint-Cd
                        outline.Append(inline.Substring(114, 7).Trim() + "|"); //Proj-Qty
                        outline.Append(inline.Substring(121, 2).Trim() + "|"); //Proj-Internal
                        outline.Append(inline.Substring(123, 2).Trim() + "|"); //Frcst-Ret-Pers
                        outline.Append(inline.Substring(125, 2).Trim() + "|"); //MPS-Ret-Pers
                        outline.Append("'" + (inline.Substring(127, 8).Trim() != "" ? FormatDate(inline.Substring(127, 8).Trim()) : "") + "'|"); //Frcst-Maint-Dte
                        //SKIP PROC-ID - 8 bytes
                        outline.Append("'" + inline.Substring(143, 2).Trim() + "'|"); //Frcst-Replan-Cd
                        outline.Append("'" + inline.Substring(145, 2).Trim() + "'|"); //Inquiry-Code
                        outline.Append("'" + inline.Substring(147, 2).Trim() + "'|"); //Supp-Maint-Cd
                        outline.Append(inline.Substring(149, 2).Trim() + "|"); //Supp-Maint-Fnce
                        outline.Append(inline.Substring(151, 2).Trim() + "|"); //Supp-Maint-Off
                        if (inline.Length > 153)
                        {
                            outline.Append("'" + inline.Substring(153, inline.Length >= 2 ? 2 : 155 - (155 - inline.Length)).Trim() + "'|"); //Supp-Maint-PABC
                        }
                        if (inline.Length > 155)
                        {
                            outline.Append("'" + inline.Substring(155, inline.Length >= 2 ? 2 : 157 - (157 - inline.Length)).Trim() + "'|"); //AMAPS-Space-02
                        }
                        if (inline.Length > 157)
                        {
                            outline.Append("'" + inline.Substring(157, inline.Length >= 10 ? 10 : 167 - (167 - inline.Length)).Trim() + "'|"); //User-Space-10
                        }
                        //Console.WriteLine(inline);
                        sw.WriteLine(outline.ToString());
                        //Console.WriteLine(outline.ToString());
                    }
                }
            }
            sr.Close();
        }
        private static void Process_VNF(string path)
        {
            Console.WriteLine("Processing VNF");
            StreamReader sr = new StreamReader(System.IO.Path.Combine(path, "newvnf.txt"));
            StringBuilder outline = new StringBuilder();
            using (FileStream fs = new FileStream(System.IO.Path.Combine(path, "vnffile.txt"), FileMode.Create))
            {
                using (StreamWriter sw = new StreamWriter(fs, Encoding.UTF8))
                {
                    outline.Clear();
                    outline.Append("'Vend_Nbr'|");
                    outline.Append("'Vend_Name'|");
                    outline.Append("'Vend_Abbre'|");
                    outline.Append("'Vend_Addr_Grp_1'|");
                    outline.Append("'Vend_Addr_Grp_2'|");
                    outline.Append("'Vend_Addr_Grp_3'|");
                    outline.Append("'Vend_Addr_Grp_4'|");
                    outline.Append("'Vend_Addr_Grp_5'|");
                    outline.Append("'Payment_Code'|");
                    outline.Append("'Frt_Terms_Code'|");
                    outline.Append("'Carrier_Code'|");
                    outline.Append("'Value_Limit'|");
                    outline.Append("'Text_Id'|");
                    outline.Append("'Vend_Class_Code_01'|");
                    outline.Append("'Vend_Class_Code_02'|");
                    outline.Append("'Vend_Class_Code_03'|");
                    outline.Append("'Vend_Class_Code_04'|");
                    outline.Append("'Vend_Class_Code_05'|");
                    outline.Append("'Vend_Class_Code_06'|");
                    outline.Append("'Vend_Class_Code_07'|");
                    outline.Append("'Vend_Class_Code_08'|");
                    outline.Append("'Vend_Class_Code_09'|");
                    outline.Append("'Vend_Class_Code_10'|");
                    outline.Append("'Vend_Class_Code_11'|");
                    outline.Append("'Vend_Class_Code_12'|");
                    outline.Append("'Vend_Class_Code_13'|");
                    outline.Append("'Vend_Class_Code_14'|");
                    outline.Append("'Vend_Class_Code_15'|");
                    outline.Append("'Vend_Class_Code_16'|");
                    outline.Append("'Vend_Class_Code_17'|");
                    outline.Append("'Vend_Class_Code_18'|");
                    outline.Append("'Vend_Class_Code_19'|");
                    outline.Append("'Vend_Class_Code_20'|");
                    outline.Append("'Vend_Class_Code_21'|");
                    outline.Append("'Vend_Class_Code_22'|");
                    outline.Append("'Vend_Class_Code_23'|");
                    outline.Append("'Vend_Class_Code_24'|");
                    outline.Append("'Vend_Class_Code_25'|");
                    outline.Append("'Vend_Class_Code_26'|");
                    outline.Append("'Vend_Class_Code_27'|");
                    outline.Append("'Vend_Class_Code_28'|");
                    outline.Append("'Qual_Vend_Code'|");
                    outline.Append("'Overship_Ctrl'|");
                    outline.Append("'Ext_Order_Bal'|");
                    outline.Append("'Exchange_Code'|");
                    outline.Append("'Dun_Brad'|");
                    outline.Append("'SIC_Code'|");
                    outline.Append("'Vendor_Status'|");
                    outline.Append("'Temp_Vendor_Ind'|");
                    outline.Append("'Indicator_1099'|");
                    outline.Append("'Federal_Tax_Id'|");
                    outline.Append("'Vend_Type'|");
                    outline.Append("'Bank_Id'|");
                    outline.Append("'GL_Code'|");
                    outline.Append("'Credit_Code'|");
                    outline.Append("'Date_Effective'|");
                    outline.Append("'Date_Invoice'|");
                    outline.Append("'Date_Pmnt'|");
                    outline.Append("'MTD_Purchases'|");
                    outline.Append("'MTD_Payments'|");
                    outline.Append("'MTD_Disc_Earned'|");
                    outline.Append("'MTD_Disc_Lost'|");
                    outline.Append("'YTD_Purchases'|");
                    outline.Append("'YTD_Payments'|");
                    outline.Append("'YTD_Disc_Earned'|");
                    outline.Append("'YTD_Disc_Lost'|");
                    outline.Append("'YTD_1099_Amount'|");
                    outline.Append("'Nbr_Invoices'|");
                    outline.Append("'Nbr_Pmnts'|");
                    outline.Append("'Flags_8'|");
                    outline.Append("'PCS_Date'|");
                    outline.Append("'AMAPS_Space_26'|");
                    outline.Append("'User_Space_30'|");
                    sw.WriteLine(outline.ToString());
                    while (sr.Peek() >= 0)
                    {
                        String inline = sr.ReadLine();
                        outline.Clear();
                        outline.Append("'" + inline.Substring(0, 16).Trim() + "'|"); //Vend-Nbr
                        outline.Append("'" + inline.Substring(16, 30).Trim() + "'|"); //Vend-Name
                        outline.Append("'" + inline.Substring(46, 8).Trim() + "'|"); //Vend-Abbre
                        outline.Append("'" + inline.Substring(54, 18).Trim() + "'|"); //Vnd-Addr-Grp-1
                        outline.Append("'" + inline.Substring(72, 18).Trim() + "'|"); //Vnd-Addr-Grp-2
                        outline.Append("'" + inline.Substring(90, 18).Trim() + "'|"); //Vnd-Addr-Grp-3
                        outline.Append("'" + inline.Substring(108, 18).Trim() + "'|"); //Vnd-Addr-Grp-4
                        outline.Append("'" + inline.Substring(126, 18).Trim() + "'|"); //Vnd-Addr-Grp-5
                        outline.Append("'" + inline.Substring(144, 4).Trim() + "'|"); //Payment-Code
                        outline.Append("'" + inline.Substring(148, 4).Trim() + "'|"); //Frt-Terms-Code
                        outline.Append("'" + inline.Substring(152, 4).Trim() + "'|"); //Carrier-Code
                        outline.Append(inline.Substring(156, 11).Trim() + "|"); //Value-Limit
                        outline.Append("'" + inline.Substring(167, 16).Trim() + "'|"); //Text-Id
                        outline.Append("'" + inline.Substring(183, 2).Trim() + "'|"); //Vend-Class-Code-01
                        outline.Append("'" + inline.Substring(185, 2).Trim() + "'|"); //Vend-Class-Code-02
                        outline.Append("'" + inline.Substring(187, 2).Trim() + "'|"); //Vend-Class-Code-03
                        outline.Append("'" + inline.Substring(189, 2).Trim() + "'|"); //Vend-Class-Code-04
                        outline.Append("'" + inline.Substring(191, 2).Trim() + "'|"); //Vend-Class-Code-05
                        outline.Append("'" + inline.Substring(193, 2).Trim() + "'|"); //Vend-Class-Code-06
                        outline.Append("'" + inline.Substring(195, 2).Trim() + "'|"); //Vend-Class-Code-07
                        outline.Append("'" + inline.Substring(197, 2).Trim() + "'|"); //Vend-Class-Code-08
                        outline.Append("'" + inline.Substring(199, 2).Trim() + "'|"); //Vend-Class-Code-09
                        outline.Append("'" + inline.Substring(201, 2).Trim() + "'|"); //Vend-Class-Code-10
                        outline.Append("'" + inline.Substring(203, 2).Trim() + "'|"); //Vend-Class-Code-11
                        outline.Append("'" + inline.Substring(205, 2).Trim() + "'|"); //Vend-Class-Code-12
                        outline.Append("'" + inline.Substring(207, 2).Trim() + "'|"); //Vend-Class-Code-13
                        outline.Append("'" + inline.Substring(209, 2).Trim() + "'|"); //Vend-Class-Code-14
                        outline.Append("'" + inline.Substring(211, 2).Trim() + "'|"); //Vend-Class-Code-15
                        outline.Append("'" + inline.Substring(213, 2).Trim() + "'|"); //Vend-Class-Code-16
                        outline.Append("'" + inline.Substring(215, 2).Trim() + "'|"); //Vend-Class-Code-17
                        outline.Append("'" + inline.Substring(217, 2).Trim() + "'|"); //Vend-Class-Code-18
                        outline.Append("'" + inline.Substring(219, 2).Trim() + "'|"); //Vend-Class-Code-19
                        outline.Append("'" + inline.Substring(221, 2).Trim() + "'|"); //Vend-Class-Code-20
                        outline.Append("'" + inline.Substring(223, 2).Trim() + "'|"); //Vend-Class-Code-21
                        outline.Append("'" + inline.Substring(225, 2).Trim() + "'|"); //Vend-Class-Code-22
                        outline.Append("'" + inline.Substring(227, 2).Trim() + "'|"); //Vend-Class-Code-23
                        outline.Append("'" + inline.Substring(229, 2).Trim() + "'|"); //Vend-Class-Code-24
                        outline.Append("'" + inline.Substring(231, 2).Trim() + "'|"); //Vend-Class-Code-25
                        outline.Append("'" + inline.Substring(233, 2).Trim() + "'|"); //Vend-Class-Code-26
                        outline.Append("'" + inline.Substring(235, 2).Trim() + "'|"); //Vend-Class-Code-27
                        outline.Append("'" + inline.Substring(237, 2).Trim() + "'|"); //Vend-Class-Code-28
                        outline.Append("'" + inline.Substring(239, 2).Trim() + "'|"); //Qual-Vend-Code
                        outline.Append("'" + inline.Substring(241, 2).Trim() + "'|"); //Overship-Ctrl
                        outline.Append(inline.Substring(243, 14).Trim() + "|"); //Ext-Order-Bal
                        outline.Append("'" + inline.Substring(257, 4).Trim() + "'|"); //Exchange-Code
                        outline.Append("'" + inline.Substring(261, 10).Trim() + "'|"); //Dun-Brad
                        outline.Append("'" + inline.Substring(271, 6).Trim() + "'|"); //SIC-Code
                        outline.Append("'" + inline.Substring(277, 2).Trim() + "'|"); //Vendor-Status
                        outline.Append("'" + inline.Substring(279, 2).Trim() + "'|"); //Temp-Vendor-Ind
                        outline.Append("'" + inline.Substring(281, 2).Trim() + "'|"); //Indicator-1099
                        outline.Append("'" + inline.Substring(283, 10).Trim() + "'|"); //Federal-Tax-Id
                        outline.Append("'" + inline.Substring(293, 4).Trim() + "'|"); //Vend-Type
                        outline.Append("'" + inline.Substring(297, 4).Trim() + "'|"); //Bank-Id
                        outline.Append("'" + inline.Substring(301, 24).Trim() + "'|"); //GL-Code
                        outline.Append("'" + inline.Substring(325, 4).Trim() + "'|"); //Credit-Code
                        outline.Append("'" + (inline.Substring(329, 8).Trim() != "" ? FormatDate(inline.Substring(329, 8).Trim()) : "") + "'|"); //Date-Effective
                        outline.Append("'" + (inline.Substring(337, 8).Trim() != "" ? FormatDate(inline.Substring(337, 8).Trim()) : "") + "'|"); //Date-Invoice
                        outline.Append("'" + (inline.Substring(345, 8).Trim() != "" ? FormatDate(inline.Substring(345, 8).Trim()) : "") + "'|"); //Date-Pmnt
                        outline.Append(inline.Substring(353, 17).Trim() + "|"); //MTD-Purchases
                        outline.Append(inline.Substring(370, 17).Trim() + "|"); //MTD-Payments
                        outline.Append(inline.Substring(387, 10).Trim() + "|"); //MTD-Disc-Earned
                        outline.Append(inline.Substring(397, 10).Trim() + "|"); //MTD-Disc-Lost
                        outline.Append(inline.Substring(407, 17).Trim() + "|"); //YTD-Purchases
                        outline.Append(inline.Substring(424, 17).Trim() + "|"); //YTD-Payments
                        outline.Append(inline.Substring(441, 10).Trim() + "|"); //YTD-Disc-Earned
                        outline.Append(inline.Substring(451, 10).Trim() + "|"); //YTD-Disc-Lost
                        outline.Append(inline.Substring(461, 10).Trim() + "|"); //YTD-1099-Amount
                        outline.Append(inline.Substring(471, 4).Trim() + "|"); //Nbr-Invoices
                        outline.Append(inline.Substring(475, 4).Trim() + "|"); //Nbr-Payments
                        outline.Append("'" + inline.Substring(479, 8).Trim() + "'|"); //Flags-8
                        outline.Append("'" + (inline.Substring(487, 8).Trim() != "" ? FormatDate(inline.Substring(487, 8).Trim()) : "") + "'|"); //PCS-Date
                        //SKIP PROC-ID - 8 bytes
                        if (inline.Length > 503)
                        {
                            outline.Append("'" + inline.Substring(503, inline.Length >= 26 ? 26 : 529 - (529 - inline.Length)).Trim() + "'|"); //AMAPS-Space-26
                        }
                        if (inline.Length > 529)
                        {
                            outline.Append("'" + inline.Substring(529, inline.Length >= 30 ? 30 : 559 - (559 - inline.Length)).Trim() + "'|"); //User-Space-30
                        }
                        //Console.WriteLine(inline);
                        sw.WriteLine(outline.ToString());
                        //Console.WriteLine(outline.ToString());
                    }
                }
            }
            sr.Close();
        }
        private static void Process_PIF(string path)
        {
            Console.WriteLine("Processing PIF");
            StreamReader sr = new StreamReader(System.IO.Path.Combine(path, "newpif.txt"));
            StringBuilder outline = new StringBuilder();
            using (FileStream fs = new FileStream(System.IO.Path.Combine(path, "piffile.txt"), FileMode.Create))
            {
                using (StreamWriter sw = new StreamWriter(fs, Encoding.UTF8))
                {
                    outline.Clear();
                    outline.Append("'Item_Nbr'|");
                    outline.Append("'Pur_Item_Type'|");
                    outline.Append("'Item_Desc'|");
                    outline.Append("'Item_Desc_2'|");
                    outline.Append("'Buying_Grp_Opt'|");
                    outline.Append("'Vend_Sel_Pol'|");
                    outline.Append("'Reqd_Quotes'|");
                    outline.Append("'Reqd_Contr'|");
                    outline.Append("'Text_Id'|");
                    outline.Append("'Pur_Unit_Meas'|");
                    outline.Append("'UM_Conv_Fctr'|");
                    outline.Append("'Desc_Text_Id'|");
                    outline.Append("'Pur_Pric_Sc_Fct'|");
                    outline.Append("'Target_Price'|");
                    outline.Append("'Last_Buy_Cost'|");
                    outline.Append("'Preferred_Vend'|");
                    outline.Append("'Ven_Item_Ctrl'|");
                    outline.Append("'Rcpt_Hndlg_Code'|");
                    outline.Append("'Buyer'|");
                    outline.Append("'Buying_Grp'|");
                    outline.Append("'GL_Code'|");
                    outline.Append("'Buy_Entity'|");
                    outline.Append("'Pay_Entity'|");
                    outline.Append("'Match_Policy'|");
                    outline.Append("'Rcpt_Disp'|");
                    outline.Append("'Preferred_Mfg'|");
                    outline.Append("'Prev_Buy_Hor'|");
                    outline.Append("'Quote_Lt'|");
                    outline.Append("'Contr_Negot_Lt'|");
                    outline.Append("'Early_Tol'|");
                    outline.Append("'Late_Tol'|");
                    outline.Append("'Over_Tol'|");
                    outline.Append("'Short_Tol'|");
                    outline.Append("'Tol_Class'|");
                    outline.Append("'Pur_Itm_Class'|");
                    outline.Append("'Itm_Qty_Acc'|");
                    outline.Append("'Drawings_Req'|");
                    outline.Append("'PCS_Date'|");
                    outline.Append("'AMAPS_Space_28'|");
                    outline.Append("'User_Space_30'|");
                    sw.WriteLine(outline.ToString());
                    while (sr.Peek() >= 0)
                    {
                        String inline = sr.ReadLine();
                        outline.Clear();
                        outline.Append("'" + inline.Substring(0, 16).Trim() + "'|"); //Item-Nbr
                        outline.Append("'" + inline.Substring(16, 2).Trim() + "'|"); //Pur-Item-Type
                        outline.Append("'" + inline.Substring(18, 26).Trim() + "'|"); //Item-Desc
                        outline.Append("'" + inline.Substring(44, 26).Trim() + "'|"); //Item-Desc-2
                        outline.Append("'" + inline.Substring(70, 2).Trim() + "'|"); //Buying-Grp-Opt
                        outline.Append("'" + inline.Substring(72, 2).Trim() + "'|"); //Vend-Sel-Pol
                        outline.Append(inline.Substring(74, 2).Trim() + "|"); //Reqd-Quotes
                        outline.Append(inline.Substring(76, 2).Trim() + "|"); //Reqd-Contr
                        outline.Append("'" + inline.Substring(78, 16).Trim() + "'|"); //Text-Id
                        outline.Append("'" + inline.Substring(94, 2).Trim() + "'|"); //Pur-Unit-Meas
                        outline.Append(inline.Substring(96, 14).Trim() + "|"); //UM-Conv-Fctr
                        outline.Append("'" + inline.Substring(110, 16).Trim() + "'|"); //Desc-Text-Id
                        outline.Append(inline.Substring(126, 1).Trim() + "|"); //Pur-Pric-Sc-Fctr
                        outline.Append(inline.Substring(127, 9).Trim() + "|"); //Target-Price
                        outline.Append(inline.Substring(136, 9).Trim() + "|"); //Last-Buy-Cost
                        outline.Append("'" + inline.Substring(145, 16).Trim() + "'|"); //Preferred-Vend
                        outline.Append("'" + inline.Substring(161, 2).Trim() + "'|"); //Ven-Item-Ctrl
                        outline.Append("'" + inline.Substring(163, 2).Trim() + "'|"); //Rcpt-Hndlg-Code
                        outline.Append("'" + inline.Substring(165, 2).Trim() + "'|"); //Buyer
                        outline.Append("'" + inline.Substring(167, 10).Trim() + "'|"); //Buying-Grp
                        outline.Append("'" + inline.Substring(177, 24).Trim() + "'|"); //GL-Code
                        outline.Append("'" + inline.Substring(201, 8).Trim() + "'|"); //Buy-Entity
                        outline.Append("'" + inline.Substring(209, 8).Trim() + "'|"); //Pay-Entity
                        outline.Append("'" + inline.Substring(217, 4).Trim() + "'|"); //Match-Policy
                        outline.Append("'" + inline.Substring(221, 20).Trim() + "'|"); //Rcpt-Disp
                        outline.Append("'" + inline.Substring(241, 26).Trim() + "'|"); //Preferred-Mfg
                        outline.Append(inline.Substring(267, 2).Trim() + "|"); //Prev-Buy-Hor
                        outline.Append(inline.Substring(269, 3).Trim() + "|"); //Quote-LT
                        outline.Append(inline.Substring(272, 3).Trim() + "|"); //Contr-Negot-LT
                        outline.Append(inline.Substring(275, 3).Trim() + "|"); //Early-Tol
                        outline.Append(inline.Substring(278, 3).Trim() + "|"); //Late-Tol
                        outline.Append(inline.Substring(281, 3).Trim() + "|"); //Over-Tol
                        outline.Append(inline.Substring(284, 3).Trim() + "|"); //Short-Tol
                        outline.Append("'" + inline.Substring(287, 2).Trim() + "'|"); //Tol-Class
                        outline.Append("'" + inline.Substring(289, 8).Trim() + "'|"); //Pur-Item-Class
                        outline.Append("'" + inline.Substring(297, 1).Trim() + "'|"); //Item-Qty-Acc
                        outline.Append("'" + inline.Substring(298, 2).Trim() + "'|"); //Drawings-Req
                        outline.Append("'" + (inline.Substring(300, 8).Trim() != "" ? FormatDate(inline.Substring(300, 8).Trim()) : "") + "'|"); //PCS-Date
                        if (inline.Length > 308)
                        {
                            outline.Append("'" + inline.Substring(308, inline.Length >= 28 ? 28 : 336 - (336 - inline.Length)).Trim() + "'|"); //User-Space-28
                        }
                        if (inline.Length > 336)
                        {
                            outline.Append("'" + inline.Substring(336, inline.Length >= 30 ? 30 : 366 - (366 - inline.Length)).Trim() + "'|"); //User-Space-30
                        }
                        //Console.WriteLine(inline);
                        sw.WriteLine(outline.ToString());
                        //Console.WriteLine(outline.ToString());
                    }
                }
            }
            sr.Close();
        }
        private static void Process_VIF(string path)
        {
            Console.WriteLine("Processing VIF");
            StreamReader sr = new StreamReader(System.IO.Path.Combine(path, "newvif.txt"));
            StringBuilder outline = new StringBuilder();
            using (FileStream fs = new FileStream(System.IO.Path.Combine(path, "viffile.txt"), FileMode.Create))
            {
                using (StreamWriter sw = new StreamWriter(fs, Encoding.UTF8))
                {
                    outline.Clear();
                    outline.Append("'Vend_Item_Refer'|");
                    outline.Append("'Desc_Text_Id'|");
                    outline.Append("'Quote_Nbr'|");
                    outline.Append("'Quote_Exp_Date'|");
                    outline.Append("'Source-Mfg'|");
                    outline.Append("'Max_RC_Hst_Days'|");
                    outline.Append("'Max_RC_Hst_Recs'|");
                    outline.Append("'Old_RC_Hst_Date'|");
                    outline.Append("'Purge_Act_Ind'|");
                    outline.Append("'Vend_Item_LT'|");
                    outline.Append("'Ven_Itm_Shr_Fct'|");
                    outline.Append("'Text_Id'|");
                    outline.Append("'Vend_Catalg_Nbr'|");
                    outline.Append("'Qual_Vend_Code'|");
                    outline.Append("'Alloc_Fctr'|");
                    outline.Append("'Tol_Class'|");
                    outline.Append("'Price_Brk_Range_1'|");
                    outline.Append("'Price_Brk_Range_2'|");
                    outline.Append("'Price_Brk_Range_3'|");
                    outline.Append("'Price_Brk_Range_4'|");
                    outline.Append("'Price_Brk_Range_5'|");
                    outline.Append("'Price_Brk_Amount_1'|");
                    outline.Append("'Price_Brk_Amount_2'|");
                    outline.Append("'Price_Brk_Amount_3'|");
                    outline.Append("'Price_Brk_Amount_4'|");
                    outline.Append("'Price_Brk_Amount_5'|");
                    outline.Append("'Price_Brk_SC_Fct_1'|");
                    outline.Append("'Price_Brk_SC_Fct_2'|");
                    outline.Append("'Price_Brk_SC_Fct_3'|");
                    outline.Append("'Price_Brk_SC_Fct_4'|");
                    outline.Append("'Price_Brk_SC_Fct_5'|");
                    outline.Append("'PCS_Date'|");
                    outline.Append("'AMAPS_Space_20'|");
                    outline.Append("'User-Space-18'|");
                    outline.Append("'Vend_Nbr'|");
                    outline.Append("'Item_Nbr'|");
                    sw.WriteLine(outline.ToString());
                    while (sr.Peek() >= 0)
                    {
                        String inline = sr.ReadLine();
                        outline.Clear();
                        outline.Append("'" + inline.Substring(0, 2).Trim() + "'|"); //Vend-Item-Refer
                        outline.Append("'" + inline.Substring(2, 16).Trim() + "'|"); //Desc-Text-Id
                        outline.Append("'" + inline.Substring(18, 16).Trim() + "'|"); //Quote-Nbr
                        outline.Append("'" + (inline.Substring(34, 8).Trim() != "" ? FormatDate(inline.Substring(34, 8).Trim()) : "") + "'|"); //Quote-Exp-Date
                        outline.Append("'" + inline.Substring(42, 26).Trim() + "'|"); //Source-Mfr
                        outline.Append(inline.Substring(68, 3).Trim() + "|"); //Max-RC-Hst-Days
                        outline.Append(inline.Substring(71, 4).Trim() + "|"); //Max-RC-Hst-Recs
                        outline.Append("'" + (inline.Substring(75, 8).Trim() != "" ? FormatDate(inline.Substring(75, 8).Trim()) : "") + "'|"); //Old-RC-Hst-Date
                        outline.Append("'" + inline.Substring(83, 2).Trim() + "'|"); //Purge-Act-Ind
                        outline.Append(inline.Substring(85, 3).Trim() + "|"); //Vend-Item-LT
                        outline.Append(inline.Substring(88, 3).Trim() + "|"); //Ven-Itm-Shr-Fct
                        outline.Append("'" + inline.Substring(91, 16).Trim() + "'|"); //Text-Id
                        outline.Append("'" + inline.Substring(107, 30).Trim() + "'|"); //Vend-Catalg-Nbr
                        outline.Append("'" + inline.Substring(137, 2).Trim() + "'|"); //Vend-Qual-Code
                        outline.Append(inline.Substring(139, 3).Trim() + "|"); //Alloc-Fctr
                        outline.Append("'" + inline.Substring(142, 2).Trim() + "'|"); //Tol-Class
                        outline.Append(inline.Substring(144, 9).Trim() + "|"); //Price-Brk-Range-1
                        outline.Append(inline.Substring(153, 9).Trim() + "|"); //Price-Brk-Range-2
                        outline.Append(inline.Substring(162, 9).Trim() + "|"); //Price-Brk-Range-3
                        outline.Append(inline.Substring(171, 9).Trim() + "|"); //Price-Brk-Range-4
                        outline.Append(inline.Substring(180, 9).Trim() + "|"); //Price-Brk-Range-5
                        outline.Append(inline.Substring(189, 9).Trim() + "|"); //Price-Brk-Amount-1
                        outline.Append(inline.Substring(198, 9).Trim() + "|"); //Price-Brk-Amount-2
                        outline.Append(inline.Substring(207, 9).Trim() + "|"); //Price-Brk-Amount-3
                        outline.Append(inline.Substring(216, 9).Trim() + "|"); //Price-Brk-Amount-4
                        outline.Append(inline.Substring(225, 9).Trim() + "|"); //Price-Brk-Amount-5
                        outline.Append(inline.Substring(234, 1).Trim() + "|"); //Price-Brk-SC-Fct-1
                        outline.Append(inline.Substring(235, 1).Trim() + "|"); //Price-Brk-SC-Fct-2
                        outline.Append(inline.Substring(236, 1).Trim() + "|"); //Price-Brk-SC-Fct-3
                        outline.Append(inline.Substring(237, 1).Trim() + "|"); //Price-Brk-SC-Fct-4
                        outline.Append(inline.Substring(238, 1).Trim() + "|"); //Price-Brk-SC-Fct-5
                        outline.Append("'" + (inline.Substring(239, 8).Trim() != "" ? FormatDate(inline.Substring(239, 8).Trim()) : "") + "'|"); //PCS-Date
                        outline.Append("'" + inline.Substring(247, 20).Trim() + "'|"); //AMAPS-Space-20
                        outline.Append("'" + inline.Substring(267, 18).Trim() + "'|"); //User-Space-18
                        outline.Append("'" + inline.Substring(285, 16).Trim() + "'|"); //Vend-Nbr
                        if (inline.Length > 301)
                        {
                            outline.Append("'" + inline.Substring(301, inline.Length >= 16 ? 16 : 317 - (317 - inline.Length)).Trim() + "'|"); //Item-Nbr
                        }
                        //Console.WriteLine(inline);
                        sw.WriteLine(outline.ToString());
                        //Console.WriteLine(outline.ToString());
                    }
                }
            }
            sr.Close();
        }
        private static void Process_CTF(string path)
        {
            Console.WriteLine("Processing CTF");
            StreamReader sr = new StreamReader(System.IO.Path.Combine(path, "newctf.txt"));
            StringBuilder outline = new StringBuilder();
            using (FileStream fs = new FileStream(System.IO.Path.Combine(path, "ctffile.txt"), FileMode.Create))
            {
                using (StreamWriter sw = new StreamWriter(fs, Encoding.UTF8))
                {
                    outline.Clear();
                    outline.Append("'Vend_Nbr'|");
                    outline.Append("'Contr_Type'|");
                    outline.Append("'Contr_Admin'|");
                    outline.Append("'Exchange_Code'|");
                    outline.Append("'Exchange_Ind'|");
                    outline.Append("'Exchange_Rate'|");
                    outline.Append("'Payment_Code'|");
                    outline.Append("'Frt_Terms_Code'|");
                    outline.Append("'Carrier_Code'|");
                    outline.Append("'Change_Text_Id'|");
                    outline.Append("'Ship_Text_Id'|");
                    outline.Append("'Overship_Ctrl'|");
                    outline.Append("'Value_Hor'|");
                    outline.Append("'Value_On_Order'|");
                    outline.Append("'Value_Limit'|");
                    outline.Append("'Value_Accepted'|");
                    outline.Append("'Value_Cancelled'|");
                    outline.Append("'Value_Rejected'|");
                    outline.Append("'Value_RTV'|");
                    outline.Append("'Expiration_Date'|");
                    outline.Append("'Place_Date'|");
                    outline.Append("'Contr_Clause_01'|");
                    outline.Append("'Contr_Clause_02'|");
                    outline.Append("'Contr_Clause_03'|");
                    outline.Append("'Contr_Clause_04'|");
                    outline.Append("'Contr_Clause_05'|");
                    outline.Append("'Contr_Clause_06'|");
                    outline.Append("'Contr_Clause_07'|");
                    outline.Append("'Contr_Clause_08'|");
                    outline.Append("'Contr_Clause_09'|");
                    outline.Append("'Contr_Clause_10'|");
                    outline.Append("'Contr_Status'|");
                    outline.Append("'Contr_Chg_Lvl'|");
                    outline.Append("'Contr_Print_Lvl'|");
                    outline.Append("'Contr_High_Line_Nbr'|");
                    outline.Append("'Contr_Chg_Flag'|");
                    outline.Append("'Vend_Addr_Type'|");
                    outline.Append("'Text_Id'|");
                    outline.Append("'Pur_Itm_Override'|");
                    outline.Append("'Contr_Due_Date'|");
                    outline.Append("'Contr_Eff_Date'|");
                    outline.Append("'PCS_Date'|");
                    outline.Append("'AMAPS_Space_22'|");
                    outline.Append("'User_Space_22'|");
                    outline.Append("'Contr_Nbr'|");
                    sw.WriteLine(outline.ToString());
                    while (sr.Peek() >= 0)
                    {
                        String inline = sr.ReadLine();
                        outline.Clear();
                        outline.Append("'" + inline.Substring(0, 16).Trim() + "'|"); //Vend-Nbr
                        outline.Append("'" + inline.Substring(16, 2).Trim() + "'|"); //Contr-Type
                        outline.Append("'" + inline.Substring(18, 2).Trim() + "'|"); //Contr-Admin
                        outline.Append("'" + inline.Substring(20, 4).Trim() + "'|"); //Exchange-Code
                        outline.Append("'" + inline.Substring(24, 2).Trim() + "'|"); //Exchange-Ind
                        outline.Append(inline.Substring(26, 14).Trim() + "|"); //Exchange-Rate
                        outline.Append("'" + inline.Substring(40, 4).Trim() + "'|"); //Payment-Code
                        outline.Append("'" + inline.Substring(44, 4).Trim() + "'|"); //Frt-Terms-Code
                        outline.Append("'" + inline.Substring(48, 4).Trim() + "'|"); //Carrier-Code
                        outline.Append("'" + inline.Substring(52, 16).Trim() + "'|"); //Change-Text-Id
                        outline.Append("'" + inline.Substring(68, 16).Trim() + "'|"); //Ship-Text-Id
                        outline.Append("'" + inline.Substring(84, 2).Trim() + "'|"); //Overship-Ctrl
                        outline.Append(inline.Substring(86, 11).Trim() + "|"); //Value-Hor
                        outline.Append(inline.Substring(97, 14).Trim() + "|"); //Value-On-Order
                        outline.Append(inline.Substring(111, 11).Trim() + "|"); //Value-Limit
                        outline.Append(inline.Substring(122, 14).Trim() + "|"); //Value-Accepted
                        outline.Append(inline.Substring(136, 14).Trim() + "|"); //Value-Cancelled
                        outline.Append(inline.Substring(150, 14).Trim() + "|"); //Value-Rejected
                        outline.Append(inline.Substring(164, 14).Trim() + "|"); //Value-RTV
                        outline.Append("'" + (inline.Substring(178, 8).Trim() != "" ? FormatDate(inline.Substring(178, 8).Trim()) : "") + "'|"); //Expiration-Date
                        outline.Append("'" + (inline.Substring(186, 8).Trim() != "" ? FormatDate(inline.Substring(186, 8).Trim()) : "") + "'|"); //Place-Date
                        outline.Append("'" + inline.Substring(194, 18).Trim() + "'|"); //Contr-Clause-01
                        outline.Append("'" + inline.Substring(212, 18).Trim() + "'|"); //Contr-Clause-02
                        outline.Append("'" + inline.Substring(230, 18).Trim() + "'|"); //Contr-Clause-03
                        outline.Append("'" + inline.Substring(248, 18).Trim() + "'|"); //Contr-Clause-04
                        outline.Append("'" + inline.Substring(266, 18).Trim() + "'|"); //Contr-Clause-05
                        outline.Append("'" + inline.Substring(284, 18).Trim() + "'|"); //Contr-Clause-06
                        outline.Append("'" + inline.Substring(302, 18).Trim() + "'|"); //Contr-Clause-07
                        outline.Append("'" + inline.Substring(320, 18).Trim() + "'|"); //Contr-Clause-08
                        outline.Append("'" + inline.Substring(338, 18).Trim() + "'|"); //Contr-Clause-09
                        outline.Append("'" + inline.Substring(356, 18).Trim() + "'|"); //Contr-Clause-10
                        outline.Append("'" + inline.Substring(374, 2).Trim() + "'|"); //Contr-Status
                        outline.Append(inline.Substring(376, 3).Trim() + "|"); //Contr-Chg-Lvl
                        outline.Append(inline.Substring(379, 3).Trim() + "|"); //Contr-Print-Lvl
                        outline.Append(inline.Substring(382, 2).Trim() + "|"); //High-Line-Nbr
                        outline.Append("'" + inline.Substring(384, 2).Trim() + "'|"); //Contr-Chg-Flag
                        outline.Append("'" + inline.Substring(386, 2).Trim() + "'|"); //Vend-Addr-Type
                        outline.Append("'" + inline.Substring(388, 16).Trim() + "'|"); //Text-Id
                        outline.Append("'" + inline.Substring(404, 2).Trim() + "'|"); //Pur-Itm-Override
                        outline.Append("'" + (inline.Substring(406, 8).Trim() != "" ? FormatDate(inline.Substring(406, 8).Trim()) : "") + "'|"); //Contr-Due-Date
                        outline.Append("'" + (inline.Substring(414, 8).Trim() != "" ? FormatDate(inline.Substring(414, 8).Trim()) : "") + "'|"); //Contr-Eff-Date
                        outline.Append("'" + (inline.Substring(422, 8).Trim() != "" ? FormatDate(inline.Substring(422, 8).Trim()) : "") + "'|"); //PCS-Date
                        //SKIP PROC-ID
                        outline.Append("'" + inline.Substring(430, 22).Trim() + "'|"); //AMAPS-Space-22
                        outline.Append("'" + inline.Substring(452, 22).Trim() + "'|"); //User-Space-22
                        if (inline.Length > 474)
                        {
                            outline.Append("'" + inline.Substring(474, inline.Length >= 16 ? 16 : 490 - (490 - inline.Length)).Trim() + "'|"); //Contr-Nbr
                        }
                        //Console.WriteLine(inline);
                        sw.WriteLine(outline.ToString());
                        //Console.WriteLine(outline.ToString());
                    }
                }
            }
            sr.Close();
        }
        private static void Process_LIF(string path)
        {
            Console.WriteLine("Processing LIF");
            StreamReader sr = new StreamReader(System.IO.Path.Combine(path, "newlif.txt"));
            StringBuilder outline = new StringBuilder();
            using (FileStream fs = new FileStream(System.IO.Path.Combine(path, "liffile.txt"), FileMode.Create))
            {
                using (StreamWriter sw = new StreamWriter(fs, Encoding.UTF8))
                {
                    outline.Clear();
                    outline.Append("'Contr_Line_key'|");
                    outline.Append("'Contr_Nbr'|");
                    outline.Append("'Item_Nbr'|");
                    outline.Append("'Vend_Nbr'|");
                    outline.Append("'Vend_Item_Refer'|");
                    outline.Append("'Lin_Itm_Prt_Lvl'|");
                    outline.Append("'Lin_Itm_Chg_Lvl'|");
                    outline.Append("'Lin_Itm_Status'|");
                    outline.Append("'Lin_Itm_Rev_Lvl'|");
                    outline.Append("'Lin_Itm_Dsc_Src'|");
                    outline.Append("'Quote_Nbr'|");
                    outline.Append("'Change_Text_Id'|");
                    outline.Append("'Text_Id'|");
                    outline.Append("'Pur_Unit_Meas'|");
                    outline.Append("'UM_Conv_Fctr'|");
                    outline.Append("'Max_Lin_Itm_Qty'|");
                    outline.Append("'Qty_OutStdg'|");
                    outline.Append("'Qty_On_Order'|");
                    outline.Append("'Qty_Accepted'|");
                    outline.Append("'Qty_Cancelled'|");
                    outline.Append("'Qty_Rejected'|");
                    outline.Append("'Qty_RTV'|");
                    outline.Append("'Pur_Price'|");
                    outline.Append("'Purt_Pric_Sc_Fct'|");
                    outline.Append("'Value_On_Order'|");
                    outline.Append("'Value_Accepted'|");
                    outline.Append("'Value_Cancelled'|");
                    outline.Append("'Value_Rejected'|");
                    outline.Append("'Value_RTV'|");
                    outline.Append("'Tax_Code'|");
                    outline.Append("'Carrier_Code'|");
                    outline.Append("'Frt_Terms_Code'|");
                    outline.Append("'Payment_Code'|");
                    outline.Append("'Overship_Ctrl'|");
                    outline.Append("'Ship_Text_Id'|");
                    outline.Append("'Match_Policy'|");
                    outline.Append("'Lin_Itm_Lst_Rel'|");
                    outline.Append("'Lin_Itm_Chg_Flg'|");
                    outline.Append("'PCS_Date'|");
                    outline.Append("'AMAPS_Space_16'|");
                    outline.Append("'User_Space_16'|");
                    outline.Append("'Line_Nbr_X'|");
                    sw.WriteLine(outline.ToString());
                    while (sr.Peek() >= 0)
                    {
                        String inline = sr.ReadLine();
                        outline.Clear();
                        outline.Append("'" + inline.Substring(0, 12).Trim() + "'|"); //Contr-Line-Key
                        outline.Append("'" + inline.Substring(12, 10).Trim() + "'|"); //Contr-Nbr
                        outline.Append("'" + inline.Substring(22, 16).Trim() + "'|"); //Item-Nbr
                        outline.Append("'" + inline.Substring(38, 16).Trim() + "'|"); //Vend-Nbr
                        outline.Append("'" + inline.Substring(54, 2).Trim() + "'|"); //Vend-Item-Refer
                        outline.Append(inline.Substring(56, 3).Trim() + "|"); //Lin-Itm-Prt-Lvl
                        outline.Append(inline.Substring(59, 3).Trim() + "|"); //Lin-Itm-Chg-Lvl
                        outline.Append("'" + inline.Substring(62, 2).Trim() + "'|"); //Lin-Itm-Status
                        outline.Append("'" + inline.Substring(64, 2).Trim() + "'|"); //Lin-Itm-Rev-Lvl
                        outline.Append("'" + inline.Substring(66, 2).Trim() + "'|"); //Lin-Itm-Dsc-Src
                        outline.Append("'" + inline.Substring(68, 16).Trim() + "'|"); //Quote-Nbr
                        outline.Append("'" + inline.Substring(84, 16).Trim() + "'|"); //Change-Text-Id
                        outline.Append("'" + inline.Substring(90, 16).Trim() + "'|"); //Text-Id
                        outline.Append("'" + inline.Substring(116, 2).Trim() + "'|"); //Pur-Unit-Meas
                        outline.Append(inline.Substring(118, 14).Trim() + "|"); //Um-Conv-Fctr
                        outline.Append(inline.Substring(132, 17).Trim() + "|"); //Max-Lin-Itm-Qty
                        outline.Append(inline.Substring(149, 17).Trim() + "|"); //Qty-Outstdg
                        outline.Append(inline.Substring(166, 17).Trim() + "|"); //Qty-On-Order
                        outline.Append(inline.Substring(183, 17).Trim() + "|"); //Qty-Accepted
                        outline.Append(inline.Substring(200, 17).Trim() + "|"); //Qty-Cancelled
                        outline.Append(inline.Substring(217, 17).Trim() + "|"); //Qty-Rejected
                        outline.Append(inline.Substring(234, 17).Trim() + "|"); //Qty-RTV
                        outline.Append(inline.Substring(251, 9).Trim() + "|"); //Pur-Price
                        outline.Append(inline.Substring(260, 1).Trim() + "|"); //Pur-Pric-Sc-Fct
                        outline.Append(inline.Substring(261, 14).Trim() + "|"); //Value-On-Order
                        outline.Append(inline.Substring(275, 14).Trim() + "|"); //Value-Accepted
                        outline.Append(inline.Substring(289, 14).Trim() + "|"); //Value-Cancelled
                        outline.Append(inline.Substring(303, 14).Trim() + "|"); //Value-Rejected
                        outline.Append(inline.Substring(317, 14).Trim() + "|"); //Value-RTV
                        outline.Append("'" + inline.Substring(331, 4).Trim() + "'|"); //Tax-Code
                        outline.Append("'" + inline.Substring(335, 4).Trim() + "'|"); //Carrier-Code
                        outline.Append("'" + inline.Substring(339, 4).Trim() + "'|"); //Frt-Terms-Code
                        outline.Append("'" + inline.Substring(343, 4).Trim() + "'|"); //Payment-Terms
                        outline.Append("'" + inline.Substring(347, 2).Trim() + "'|"); //Overship-Ctrl
                        outline.Append("'" + inline.Substring(349, 16).Trim() + "'|"); //Ship-Text-Id
                        outline.Append("'" + inline.Substring(365, 4).Trim() + "'|"); //Match-Policy
                        outline.Append(inline.Substring(369, 3).Trim() + "|"); //Lin-Itm-Lst-Rel
                        outline.Append(inline.Substring(372, 2).Trim() + "|"); //Lin-Itm-Chg-Flag
                        outline.Append("'" + (inline.Substring(374, 8).Trim() != "" ? FormatDate(inline.Substring(374, 8).Trim()) : "") + "'|"); //PCS-Date
                        //SKIP PROC-ID
                        outline.Append("'" + inline.Substring(382, 16).Trim() + "'|"); //AMAPS-Space-16
                        outline.Append("'" + inline.Substring(398, 16).Trim() + "'|"); //User-Space-16
                        if (inline.Length > 414)
                        {
                            outline.Append("'" + inline.Substring(414, inline.Length >= 2 ? 2 : 416 - (416 - inline.Length)).Trim() + "'|"); //Line-Nbr-X
                        }
                        //Console.WriteLine(inline);
                        sw.WriteLine(outline.ToString());
                        //Console.WriteLine(outline.ToString());
                    }
                }
            }
            sr.Close();
        }
        private static void Process_POF(string path)
        {
            Console.WriteLine("Processing POF");
            StreamReader sr = new StreamReader(System.IO.Path.Combine(path, "newpof.txt"));
            StringBuilder outline = new StringBuilder();
            using (FileStream fs = new FileStream(System.IO.Path.Combine(path, "poffile.txt"), FileMode.Create))
            {
                using (StreamWriter sw = new StreamWriter(fs, Encoding.UTF8))
                {
                    outline.Clear();
                    outline.Append("'Contr_Line_key'|");
                    outline.Append("'Item_Nbr'|");
                    outline.Append("'Vend_Nbr'|");
                    outline.Append("'Dtl_Chg_Lvl'|");
                    outline.Append("'Contr_Print_Nbr'|");
                    outline.Append("'Place_Date'|");
                    outline.Append("'Last_Rcpt_Date'|");
                    outline.Append("'Dock_Date'|");
                    outline.Append("'Dock_Time'|");
                    outline.Append("'Dtl_Status'|");
                    outline.Append("'Qty_OutStdg'|");
                    outline.Append("'Place_Qty'|");
                    outline.Append("'Pur_Price'|");
                    outline.Append("'Purt_Pric_Sc_Fct'|");
                    outline.Append("'Orig_Prom_Date'|");
                    outline.Append("'Chgs_To_Promise'|");
                    outline.Append("'Purch_Due_Date'|");
                    outline.Append("'Confirm_Date'|");
                    outline.Append("'Confirm_By'|");
                    outline.Append("'Quote_Nbr'|");
                    outline.Append("'Rcpt_Disp'|");
                    outline.Append("'Tax_Code'|");
                    outline.Append("'GL_Code'|");
                    outline.Append("'Change_Text_Id'|");
                    outline.Append("'Ship_Text_Id'|");
                    outline.Append("'Ship_To_Code'|");
                    outline.Append("'Relieve_Ord_Nbr'|");
                    outline.Append("'Inspect_Code'|");
                    outline.Append("'Rev_Level'|");
                    outline.Append("'Exchange_Code'|");
                    outline.Append("'Exchange_Ind'|");
                    outline.Append("'Exchange_Rate'|");
                    outline.Append("'Plant_Code'|");
                    outline.Append("'II_IM_Qty'|");
                    outline.Append("'Pur_Unit_Meas'|");
                    outline.Append("'Dtl_Chg_Flag'|");
                    outline.Append("'Text_Id'|");
                    outline.Append("'PCS_Date'|");
                    outline.Append("'AMAPS_Space_16'|");
                    outline.Append("'User_Space_16'|");
                    outline.Append("'Rel_Nbr'|");
                    sw.WriteLine(outline.ToString());
                    while (sr.Peek() >= 0)
                    {
                        String inline = sr.ReadLine();
                        outline.Clear();
                        outline.Append("'" + inline.Substring(0, 12).Trim() + "'|"); //Contr-Line-Key
                        outline.Append("'" + inline.Substring(12, 16).Trim() + "'|"); //Item-Nbr
                        outline.Append("'" + inline.Substring(28, 16).Trim() + "'|"); //Vend-Nbr
                        outline.Append(inline.Substring(44, 3).Trim() + "|"); //Dtl-Chg-Lvl
                        outline.Append(inline.Substring(47, 3).Trim() + "|"); //Contr-Print-Nbr
                        outline.Append("'" + (inline.Substring(50, 8).Trim() != "" ? FormatDate(inline.Substring(50, 8).Trim()) : "") + "'|"); //Place-Date
                        outline.Append("'" + (inline.Substring(58, 8).Trim() != "" ? FormatDate(inline.Substring(58, 8).Trim()) : "") + "'|"); //Last-Rcpt-Date
                        outline.Append("'" + (inline.Substring(66, 8).Trim() != "" ? FormatDate(inline.Substring(66, 8).Trim()) : "") + "'|"); //Dock-Date
                        outline.Append(inline.Substring(74, 4).Trim() + "|"); //Dock-Time
                        outline.Append(inline.Substring(78, 2).Trim() + "|"); //Dtl-Status
                        outline.Append(inline.Substring(80, 17).Trim() + "|"); //Qty-Outstdg
                        outline.Append(inline.Substring(97, 17).Trim() + "|"); //Place-Qty
                        outline.Append(inline.Substring(114, 9).Trim() + "|"); //Pur-Price
                        outline.Append(inline.Substring(123, 1).Trim() + "|"); //Pur-Pric-Sc-Fct
                        outline.Append("'" + (inline.Substring(124, 8).Trim() != "" ? FormatDate(inline.Substring(124, 8).Trim()) : "") + "'|"); //Orig-Prom-Date
                        outline.Append(inline.Substring(132, 2).Trim() + "|"); //Chgs-To-Promise
                        outline.Append("'" + (inline.Substring(134, 8).Trim() != "" ? FormatDate(inline.Substring(134, 8).Trim()) : "") + "'|"); //Purch-Due-Date
                        outline.Append("'" + (inline.Substring(142, 8).Trim() != "" ? FormatDate(inline.Substring(142, 8).Trim()) : "") + "'|"); //Confirm-Date
                        outline.Append("'" + inline.Substring(150, 20).Trim() + "'|"); //Confirm-By
                        outline.Append("'" + inline.Substring(170, 16).Trim() + "'|"); //Quote-Nbr
                        outline.Append("'" + inline.Substring(186, 20).Trim() + "'|"); //Rcpt-Disp
                        outline.Append("'" + inline.Substring(206, 4).Trim() + "'|"); //Tax-Code
                        outline.Append("'" + inline.Substring(210, 24).Trim() + "'|"); //GL-Code
                        outline.Append("'" + inline.Substring(234, 16).Trim() + "'|"); //Change-Text-Id
                        outline.Append("'" + inline.Substring(250, 16).Trim() + "'|"); //Ship-Text-Id
                        outline.Append("'" + inline.Substring(266, 4).Trim() + "'|"); //Ship-To-Code
                        outline.Append("'" + inline.Substring(270, 16).Trim() + "'|"); //Relieve-Ord-Nbr
                        outline.Append("'" + inline.Substring(286, 4).Trim() + "'|"); //Inspect-Code
                        outline.Append("'" + inline.Substring(290, 2).Trim() + "'|"); //Rev-Level
                        outline.Append("'" + inline.Substring(292, 4).Trim() + "'|"); //Exchange-Code
                        outline.Append("'" + inline.Substring(296, 2).Trim() + "'|"); //Exchange-Ind
                        outline.Append(inline.Substring(298, 14).Trim() + "|"); //Exchange-Rate
                        outline.Append("'" + inline.Substring(312, 4).Trim() + "'|"); //Plant-Code
                        outline.Append(inline.Substring(316, 17).Trim() + "|"); //II-IM-Qty
                        outline.Append("'" + inline.Substring(333, 2).Trim() + "'|"); //Pur-Unit-Meas
                        outline.Append("'" + inline.Substring(335, 2).Trim() + "'|"); //Dtl-Chg-Flag
                        outline.Append("'" + inline.Substring(337, 16).Trim() + "'|"); //Text-Id
                        outline.Append("'" + (inline.Substring(353, 8).Trim() != "" ? FormatDate(inline.Substring(353, 8).Trim()) : "") + "'|"); //PCS-Date
                        //SKIP PROC-ID
                        outline.Append("'" + inline.Substring(361, 16).Trim() + "'|"); //AMAPS-Space-16
                        outline.Append("'" + inline.Substring(377, 16).Trim() + "'|"); //User-Space-16
                        if (inline.Length > 393)
                        {
                            outline.Append("'" + inline.Substring(393, inline.Length >= 4 ? 4 : 397 - (397 - inline.Length)).Trim() + "'|"); //Line-Nbr-X
                        }
                        //Console.WriteLine(inline);
                        sw.WriteLine(outline.ToString());
                        //Console.WriteLine(outline.ToString());
                    }
                }
            }
            sr.Close();
        }
        private static void Process_PQF(string path)
        {
            Console.WriteLine("Processing PQF");
            StreamReader sr = new StreamReader(System.IO.Path.Combine(path, "newpqf.txt"));
            StringBuilder outline = new StringBuilder();
            using (FileStream fs = new FileStream(System.IO.Path.Combine(path, "pqffile.txt"), FileMode.Create))
            {
                using (StreamWriter sw = new StreamWriter(fs, Encoding.UTF8))
                {
                    outline.Clear();
                    outline.Append("'Item_Nbr'|");
                    outline.Append("'RQMT_TP_Nbr_Key'|");
                    outline.Append("'Contr_Line_Key'|");
                    outline.Append("'Req_Date'|");
                    outline.Append("'Vend_Nbr'|");
                    outline.Append("'Auth_Id'|");
                    outline.Append("'Auth_Date'|");
                    outline.Append("'GL_Code'|");
                    outline.Append("'Buy_Entity'|");
                    outline.Append("'Pay_Entity'|");
                    outline.Append("'Tax_Code'|");
                    outline.Append("'Rcpt_Disp'|");
                    outline.Append("'RQMT_Text_Id'|");
                    outline.Append("'RQMT_SP_Text_Id'|");
                    outline.Append("'Req_Qty'|");
                    outline.Append("'Place-Qty'|");
                    outline.Append("'Unit_Meas'|");
                    outline.Append("'Pur_Unit_Meas'|");
                    outline.Append("'UM_Conv_Fctr'|");
                    outline.Append("'Purch_Due_Date'|");
                    outline.Append("'Req_Dock_Date'|");
                    outline.Append("'Dock_Date'|");
                    outline.Append("'Req_Place_Date'|");
                    outline.Append("'Act_Place_Date'|");
                    outline.Append("'Req_Cut_Date'|");
                    outline.Append("'Buyer'|");
                    outline.Append("'Pur_Price'|");
                    outline.Append("'Pur_Pric_Sc_Fct'|");
                    outline.Append("'Target_Price'|");
                    outline.Append("'Pur_Itm_Sc_Fct'|");
                    outline.Append("'AMAPS_Space_30'|");
                    outline.Append("'User_Space_30'|");
                    outline.Append("'Rel_Nbr'|");
                    sw.WriteLine(outline.ToString());
                    while (sr.Peek() >= 0)
                    {
                        String inline = sr.ReadLine();
                        outline.Clear();
                        outline.Append("'" + inline.Substring(0, 16).Trim() + "'|"); //Item-Nbr
                        outline.Append("'" + inline.Substring(16, 18).Trim() + "'|"); //Rqmt_TP_Nbr_Key
                        outline.Append("'" + inline.Substring(34, 12).Trim() + "'|"); //Contr-Line-Key
                        outline.Append("'" + (inline.Substring(46, 8).Trim() != "" ? FormatDate(inline.Substring(46, 8).Trim()) : "") + "'|"); //Req-Date
                        outline.Append("'" + inline.Substring(54, 16).Trim() + "'|"); //Vend-Nbr
                        outline.Append("'" + inline.Substring(70, 2).Trim() + "'|"); //Auth-Id
                        outline.Append("'" + (inline.Substring(72, 8).Trim() != "" ? FormatDate(inline.Substring(72, 8).Trim()) : "") + "'|"); //Auth-Date
                        outline.Append("'" + inline.Substring(80, 24).Trim() + "'|"); //GL-Code
                        outline.Append("'" + inline.Substring(104, 8).Trim() + "'|"); //Buy-Entity
                        outline.Append("'" + inline.Substring(112, 8).Trim() + "'|"); //Pay-Entity
                        outline.Append("'" + inline.Substring(120, 4).Trim() + "'|"); //Tax-Code
                        outline.Append("'" + inline.Substring(124, 20).Trim() + "'|"); //Rcpt-Disp
                        outline.Append("'" + inline.Substring(144, 16).Trim() + "'|"); //Rqmt-Text-Id
                        outline.Append("'" + inline.Substring(160, 16).Trim() + "'|"); //Rqmt-SP-Text-Id
                        outline.Append(inline.Substring(176, 17).Trim() + "|"); //Req-Qty
                        outline.Append(inline.Substring(193, 17).Trim() + "|"); //Place-Qty
                        outline.Append("'" + inline.Substring(210, 2).Trim() + "'|"); //Unit-Meas
                        outline.Append("'" + inline.Substring(212, 2).Trim() + "'|"); //Pur-Unit-Meas
                        outline.Append(inline.Substring(214, 14).Trim() + "|"); //UM-Conv-Fctr
                        outline.Append("'" + (inline.Substring(228, 8).Trim() != "" ? FormatDate(inline.Substring(226, 8).Trim()) : "") + "'|"); //Purch-Due-Date
                        outline.Append("'" + (inline.Substring(236, 8).Trim() != "" ? FormatDate(inline.Substring(236, 8).Trim()) : "") + "'|"); //Req-Dock-Date
                        outline.Append("'" + (inline.Substring(244, 8).Trim() != "" ? FormatDate(inline.Substring(244, 8).Trim()) : "") + "'|"); //Dock-Date
                        outline.Append("'" + (inline.Substring(252, 8).Trim() != "" ? FormatDate(inline.Substring(252, 8).Trim()) : "") + "'|"); //Req-Place-Date
                        outline.Append("'" + (inline.Substring(260, 8).Trim() != "" ? FormatDate(inline.Substring(260, 8).Trim()) : "") + "'|"); //Act-Place-Date
                        outline.Append("'" + (inline.Substring(268, 8).Trim() != "" ? FormatDate(inline.Substring(268, 8).Trim()) : "") + "'|"); //Req-Cut-Date
                        outline.Append("'" + inline.Substring(276, 2).Trim() + "'|"); //Buyer
                        outline.Append(inline.Substring(278, 9).Trim() + "|"); //Pur-Price
                        outline.Append(inline.Substring(287, 1).Trim() + "|"); //Pur-Pric-Sc-Fct
                        outline.Append(inline.Substring(288, 9).Trim() + "|"); //Target-Price
                        outline.Append(inline.Substring(297, 1).Trim() + "|"); //Pur-Itm-Sc-Fct
                        outline.Append("'" + inline.Substring(298, 30).Trim() + "'|"); //AMAPS-Space-30
                        outline.Append("'" + inline.Substring(328, 30).Trim() + "'|"); //User-Space-30
                        if (inline.Length > 358)
                        {
                            outline.Append("'" + inline.Substring(358, inline.Length >= 4 ? 4 : 362 - (362 - inline.Length)).Trim() + "'|"); //Line-Nbr-X
                        }
                        //Console.WriteLine(inline);
                        sw.WriteLine(outline.ToString());
                        //Console.WriteLine(outline.ToString());
                    }
                }
            }
            sr.Close();
        }
        private static void Process_RCF(string path)
        {
            Console.WriteLine("Processing RCF");
            StreamReader sr = new StreamReader(System.IO.Path.Combine(path, "newrcf.txt"));
            StringBuilder outline = new StringBuilder();
            using (FileStream fs = new FileStream(System.IO.Path.Combine(path, "rcffile.txt"), FileMode.Create))
            {
                using (StreamWriter sw = new StreamWriter(fs, Encoding.UTF8))
                {
                    outline.Clear();
                    outline.Append("'Ven_Itm_Ref_Key'|");
                    outline.Append("'Order_Nbr'|");
                    outline.Append("'Document'|");
                    outline.Append("'Shipper_Ref'|");
                    outline.Append("'Pur_Txn_Qty'|");
                    outline.Append("'Inv_Txn_Qty'|");
                    outline.Append("'Pur_Unit_Meas'|");
                    outline.Append("'Unit_Meas'|");
                    outline.Append("'Defect_Code'|");
                    outline.Append("'Inspect_Code'|");
                    outline.Append("'Plan_Carrier'|");
                    outline.Append("'Act_Carrier'|");
                    outline.Append("'Qty_Code'|");
                    outline.Append("'Dist_Loc'|");
                    outline.Append("'Txn_Scr'|");
                    outline.Append("'Act_Dock_Date'|");
                    outline.Append("'Act_Dock_Time'|");
                    outline.Append("'Plan_Dock_Date'|");
                    outline.Append("'Plan_Dock_Time'|");
                    outline.Append("'Orig_Prom_Date'|");
                    outline.Append("'Chgs_To_Promise'|");
                    outline.Append("'Place-Date'|");
                    outline.Append("'Qty_Outstdg'|");
                    outline.Append("'Rcpt_Disp'|");
                    outline.Append("'Buyer'|");
                    outline.Append("'AMAPS_Space_30'|");
                    outline.Append("'User_Space_30'|");
                    outline.Append("'Rcpt_Date_X'|");
                    sw.WriteLine(outline.ToString());
                    while (sr.Peek() >= 0)
                    {
                        String inline = sr.ReadLine();
                        outline.Clear();
                        outline.Append("'" + inline.Substring(0, 34).Trim() + "'|"); //Ven-Itm-Ref-Key
                        outline.Append("'" + inline.Substring(34, 16).Trim() + "'|"); //Order-Nbr
                        outline.Append("'" + inline.Substring(50, 16).Trim() + "'|"); //Document
                        outline.Append("'" + inline.Substring(66, 16).Trim() + "'|"); //Shipper-Ref
                        outline.Append(inline.Substring(82, 17).Trim() + "|"); //Pur-Txn-Qty
                        outline.Append(inline.Substring(99, 17).Trim() + "|"); //Inv-Txn-Qty
                        outline.Append("'" + inline.Substring(116, 2).Trim() + "'|"); //Pur-Unit-Meas
                        outline.Append("'" + inline.Substring(118, 2).Trim() + "'|"); //Unit-Meas
                        outline.Append("'" + inline.Substring(120, 4).Trim() + "'|"); //Defect-Code
                        outline.Append("'" + inline.Substring(124, 4).Trim() + "'|"); //Inspect-Code
                        outline.Append("'" + inline.Substring(128, 4).Trim() + "'|"); //Plan-Carrier
                        outline.Append("'" + inline.Substring(132, 4).Trim() + "'|"); //Act-Carrier
                        outline.Append("'" + inline.Substring(136, 2).Trim() + "'|"); //Qty-Code
                        outline.Append("'" + inline.Substring(138, 14).Trim() + "'|"); //Dist-Loc
                        outline.Append("'" + inline.Substring(152, 4).Trim() + "'|"); //Txn-Scr
                        outline.Append("'" + (inline.Substring(156, 8).Trim() != "" ? FormatDate(inline.Substring(156, 8).Trim()) : "") + "'|"); //Act-Dock-Date
                        outline.Append(inline.Substring(164, 4).Trim() + "|"); //Act-Dock-Time
                        outline.Append("'" + (inline.Substring(168, 8).Trim() != "" ? FormatDate(inline.Substring(168, 8).Trim()) : "") + "'|"); //Plan-Dock-Date
                        outline.Append(inline.Substring(176, 4).Trim() + "|"); //Plan-Dock-Time
                        outline.Append("'" + (inline.Substring(180, 8).Trim() != "" ? FormatDate(inline.Substring(180, 8).Trim()) : "") + "'|"); //Orig-Prom-Date
                        outline.Append(inline.Substring(188, 2).Trim() + "|"); //Chgs-To-Promise
                        outline.Append("'" + (inline.Substring(190, 8).Trim() != "" ? FormatDate(inline.Substring(190, 8).Trim()) : "") + "'|"); //Place-Date
                        outline.Append(inline.Substring(198, 17).Trim() + "|"); //Qty-Outstdg
                        outline.Append("'" + inline.Substring(215, 20).Trim() + "'|"); //Rcpt-Disp
                        outline.Append("'" + inline.Substring(235, 2).Trim() + "'|"); //Buyer
                        outline.Append("'" + inline.Substring(237, 30).Trim() + "'|"); //AMAPS-Space-30
                        outline.Append("'" + inline.Substring(267, 30).Trim() + "'|"); //User-Space-30
                        if (inline.Length > 297)
                        {
                            //outline.Append("'" + inline.Substring(358, inline.Length >= 4 ? 4 : 362 - (362 - inline.Length)).Trim() + "'|"); //Line-Nbr-X
                            outline.Append("'" + inline.Substring(297, inline.Length >= 305 ? 8 : 8 - (305 - inline.Length)).Trim() != "" ? FormatDate(inline.Substring(297, 8).Trim()) : "" + "'|"); //Rcpt-Date-X
                        }
                        //Console.WriteLine(inline);
                        sw.WriteLine(outline.ToString());
                        //Console.WriteLine(outline.ToString());
                    }
                }
            }
            sr.Close();
        }
        private static string FormatDate(string indate)
        {
            StringBuilder outdate = new StringBuilder();
            string intmonth = indate.Substring(4, 2);
            string strmonth;
            switch (intmonth)
            {
                case "01":
                    strmonth = "Jan";
                    break;
                case "02":
                    strmonth = "Feb";
                    break;
                case "03":
                    strmonth = "Mar";
                    break;
                case "04":
                    strmonth = "Apr";
                    break;
                case "05":
                    strmonth = "May";
                    break;
                case "06":
                    strmonth = "Jun";
                    break;
                case "07":
                    strmonth = "Jul";
                    break;
                case "08":
                    strmonth = "Aug";
                    break;
                case "09":
                    strmonth = "Sep";
                    break;
                case "10":
                    strmonth = "Oct";
                    break;
                case "11":
                    strmonth = "Nov";
                    break;
                case "12":
                    strmonth = "Dec";
                    break;
                default: strmonth = "Undef";
                    break;
            }
            outdate.Append(strmonth);
            outdate.Append("-");
            outdate.Append(indate.Substring(6, 2));
            outdate.Append("-");
            outdate.Append(indate.Substring(0, 4));
            return outdate.ToString();
        }
    }
}
