/*
--[[
MZ-IPL-Loader, controls the Loading of Map-IPL´s in FiveM
Copyright (C) 27.08.2019  MasterZyper 🐦
Contact: masterzyper@reloaded-server.de

You like to get a FiveM-Server? 
Visit ZapHosting: https://zap-hosting.com/a/17444fc14f5749d607b4ca949eaf305ed50c0837

Support us on Patreon: https://www.patreon.com/gtafivemorg

For help with this Script visit: https://gta-fivem.org/

This program is free software; you can redistribute it and/or modify it under the terms of the 
GNU General Public License as published by the Free Software Foundation; either version 3 of 
the License, or (at your option) any later version.

This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY;
without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. 
See the GNU General Public License for more details.

You should have received a copy of the GNU General Public License along with this program; 
if not, see <http://www.gnu.org/licenses/>.
]]
*/
using CitizenFX.Core;
using CitizenFX.Core.Native;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mz_ipl_loader
{
    public class MZ_IPL_LOADER : BaseScript
    {
        //Public Variables
        private bool Exception = false;
        //Variables from CFG
        bool Load_Carrier = false;
        bool Load_HeistYacht = false;
        bool Load_GunrunningYacht = false;
        bool Load_Simeon = false;
        bool Load_TrevorTrailer = false;
        bool Load_MaxRenda = false;
        bool Load_CluckinBell = false;
        bool Load_Des_Farm = false;
        bool Load_FIB_Lobby = false;
        bool Load_Billboard_iFruit = false;
        bool Load_LesterFactory = false;
        bool Load_LifeInvaderLobby = false;
        bool Load_Tunnel = false;
        bool Load_StadiumFameOrShame = false;
        bool Load_HouseInBanhamCanyon = false;
        bool Load_LostsTrailerPark = false;
        bool Load_RatonCanyonRiver = false;
        bool Load_PillboxHospital = false;
        bool Load_LostSafehouse = false;
        bool Load_RedCarpet = false;
        bool Load_DesHospital = false;
        bool Load_SunkenCargoShip = false;
        bool Load_JewelryStore = false;
        bool Load_TrainCrash = false;
        bool Load_BrokenStiltHouse = false;
        bool Load_PlaneCrash = false;
        bool Load_NorthYankton = false;
        bool Load_OnlineBunkers = false;
        bool Load_ArcadiusBusinessCentre = false;
        bool Load_Morgue = false;
        private bool ReadInputAsBool(string resource_name, string data_field)
        {
            return Convert.ToBoolean(Convert.ToInt32(API.GetResourceMetadata(resource_name, data_field, 0)));
        }
        public MZ_IPL_LOADER()
        {
            string resource_name = API.GetCurrentResourceName();
            string resource_author = "MasterZyper";
            Debug.Write($"{resource_name} by {resource_author} started loading");
            //Prepare
            try
            {
                Load_Carrier = ReadInputAsBool(resource_name, "load_carrier");
                Load_HeistYacht = ReadInputAsBool(resource_name, "load_heist_yacht");
                Load_GunrunningYacht = ReadInputAsBool(resource_name, "load_gunrunning_yacht");
                Load_Simeon = ReadInputAsBool(resource_name, "load_simeon");
                Load_TrevorTrailer = ReadInputAsBool(resource_name, "load_trevor_trailer");
                Load_MaxRenda = ReadInputAsBool(resource_name, "load_maxrenda");
                Load_CluckinBell = ReadInputAsBool(resource_name, "load_cluckingbell");
                Load_Des_Farm = ReadInputAsBool(resource_name, "load_des_farm");
                Load_FIB_Lobby = ReadInputAsBool(resource_name, "load_fib_lobby");
                Load_Billboard_iFruit = ReadInputAsBool(resource_name, "load_billboard_ifruit");
                Load_LesterFactory = ReadInputAsBool(resource_name, "load_lesterfactory");
                Load_LifeInvaderLobby = ReadInputAsBool(resource_name, "load_lifeinvaderlobby");
                Load_Tunnel = ReadInputAsBool(resource_name, "load_tunnel");
                Load_StadiumFameOrShame = ReadInputAsBool(resource_name, "load_stadiumfameorshame");
                Load_HouseInBanhamCanyon = ReadInputAsBool(resource_name, "load_houseinbanhamcanyon");
                Load_LostsTrailerPark = ReadInputAsBool(resource_name, "load_loststrailerpark");
                Load_RatonCanyonRiver = ReadInputAsBool(resource_name, "load_ratoncanyonriver");
                Load_PillboxHospital = ReadInputAsBool(resource_name, "load_pillboxhospital");
                Load_LostSafehouse = ReadInputAsBool(resource_name, "load_lostsafehouse");
                Load_RedCarpet = ReadInputAsBool(resource_name, "load_redcarpet");
                Load_DesHospital = ReadInputAsBool(resource_name, "load_deshospital");
                Load_SunkenCargoShip = ReadInputAsBool(resource_name, "load_sunkencargoship");
                Load_JewelryStore = ReadInputAsBool(resource_name, "load_jewelrystore");
                Load_TrainCrash = ReadInputAsBool(resource_name, "load_traincrash");
                Load_BrokenStiltHouse = ReadInputAsBool(resource_name, "load_brokenstilthouse");
                Load_PlaneCrash = ReadInputAsBool(resource_name, "load_planecrash");
                Load_NorthYankton = ReadInputAsBool(resource_name, "load_northyankton");
                Load_OnlineBunkers = ReadInputAsBool(resource_name, "load_onlinebunkers");
                Load_ArcadiusBusinessCentre = ReadInputAsBool(resource_name, "load_arcadiusbusinesscentre");
                Load_Morgue = ReadInputAsBool(resource_name, "load_morgue");
            }
            catch (FormatException e)
            {
                Debug.Write($"Fatal ERROR while loading config of {resource_name}");
                Debug.Write($"Exception-Message: {e.Message}");
                Exception = true;
            }
            catch (OverflowException e)
            {
                Debug.Write($"Fatal ERROR while loading config of {resource_name}");
                Debug.Write($"Exception-Message: {e.Message}");
                Exception = true;
            }
            if (!Exception)
            {
                Debug.Write($"{resource_name} successful started!");
                API.LoadMpDlcMaps();
                API.EnableMpDlcMaps(true);
                if (Load_Carrier)
                {
                    API.RequestIpl("hei_carrier");
                    API.RequestIpl("hei_carrier_distantlights");
                    API.RequestIpl("hei_Carrier_int1");
                    API.RequestIpl("hei_Carrier_int2");
                    API.RequestIpl("hei_Carrier_int3");
                    API.RequestIpl("hei_Carrier_int4");
                    API.RequestIpl("hei_Carrier_int5");
                    API.RequestIpl("hei_Carrier_int6");
                    API.RequestIpl("hei_carrier_lodlights");
                    API.RequestIpl("hei_carrier_slod");
                }
                else
                {
                    API.RemoveIpl("hei_carrier");
                    API.RemoveIpl("hei_carrier_distantlights");
                    API.RemoveIpl("hei_Carrier_int1");
                    API.RemoveIpl("hei_Carrier_int2");
                    API.RemoveIpl("hei_Carrier_int3");
                    API.RemoveIpl("hei_Carrier_int4");
                    API.RemoveIpl("hei_Carrier_int5");
                    API.RemoveIpl("hei_Carrier_int6");
                    API.RemoveIpl("hei_carrier_lodlights");
                    API.RemoveIpl("hei_carrier_slod");
                }
                if (Load_HeistYacht)
                {
                    API.RequestIpl("hei_yacht_heist");
                    API.RequestIpl("hei_yacht_heist_Bar");
                    API.RequestIpl("hei_yacht_heist_Bedrm");
                    API.RequestIpl("hei_yacht_heist_Bridge");
                    API.RequestIpl("hei_yacht_heist_DistantLights");
                    API.RequestIpl("hei_yacht_heist_enginrm");
                    API.RequestIpl("hei_yacht_heist_LODLights");
                    API.RequestIpl("hei_yacht_heist_Lounge");
                }
                else
                {
                    API.RemoveIpl("hei_yacht_heist");
                    API.RemoveIpl("hei_yacht_heist_Bar");
                    API.RemoveIpl("hei_yacht_heist_Bedrm");
                    API.RemoveIpl("hei_yacht_heist_Bridge");
                    API.RemoveIpl("hei_yacht_heist_DistantLights");
                    API.RemoveIpl("hei_yacht_heist_enginrm");
                    API.RemoveIpl("hei_yacht_heist_LODLights");
                    API.RemoveIpl("hei_yacht_heist_Lounge");
                }
                if (Load_GunrunningYacht)
                {
                    API.RequestIpl("gr_heist_yacht2");
                    API.RequestIpl("gr_heist_yacht2_bar");
                    API.RequestIpl("gr_heist_yacht2_bedrm");
                    API.RequestIpl("gr_heist_yacht2_bridge");
                    API.RequestIpl("gr_heist_yacht2_enginrm");
                    API.RequestIpl("gr_heist_yacht2_lounge");
                }
                else
                {
                    API.RemoveIpl("gr_heist_yacht2");
                    API.RemoveIpl("gr_heist_yacht2_bar");
                    API.RemoveIpl("gr_heist_yacht2_bedrm");
                    API.RemoveIpl("gr_heist_yacht2_bridge");
                    API.RemoveIpl("gr_heist_yacht2_enginrm");
                    API.RemoveIpl("gr_heist_yacht2_lounge");
                }
                if (Load_Simeon)
                    API.RequestIpl("shr_int");
                else
                    API.RemoveIpl("shr_int");
                if (Load_TrevorTrailer)
                    API.RequestIpl("TrevorsTrailerTrash");
                else
                    API.RemoveIpl("TrevorsTrailerTrash");
                if (Load_MaxRenda)
                    API.RequestIpl("refit_unload");
                else
                    API.RemoveIpl("refit_unload");
                if (Load_CluckinBell)
                {
                    API.RequestIpl("CS1_02_cf_onmission1");
                    API.RequestIpl("CS1_02_cf_onmission2");
                    API.RequestIpl("CS1_02_cf_onmission3");
                    API.RequestIpl("CS1_02_cf_onmission4");
                }
                else
                {
                    API.RemoveIpl("CS1_02_cf_onmission1");
                    API.RemoveIpl("CS1_02_cf_onmission2");
                    API.RemoveIpl("CS1_02_cf_onmission3");
                    API.RemoveIpl("CS1_02_cf_onmission4");
                }
                if (Load_Des_Farm)
                {
                    API.RequestIpl("farm");
                    API.RequestIpl("farmint");
                    API.RequestIpl("farm_lod");
                    API.RequestIpl("farm_props");
                    API.RequestIpl("des_farmhouse");
                }
                else
                {
                    API.RemoveIpl("farmint");
                    API.RemoveIpl("farm_lod");
                    API.RemoveIpl("farm_props");
                    API.RemoveIpl("des_farmhouse");
                }
                if (Load_FIB_Lobby)
                {
                    API.RequestIpl("FIBlobby");
                    API.RemoveIpl("facelobbyfake");
                }
                else
                {
                    API.RequestIpl("facelobbyfake");
                    API.RemoveIpl("FIBlobby");
                }
                if (Load_Billboard_iFruit)
                {
                    API.RemoveIpl("FruitBB");
                    API.RemoveIpl("sc1_01_newbill");
                    API.RemoveIpl("hw1_02_newbill");
                    API.RemoveIpl("hw1_emissive_newbill");
                    API.RemoveIpl("sc1_14_newbill");
                    API.RemoveIpl("dt1_17_newbill");
                }
                else
                {
                    API.RequestIpl("FruitBB");
                    API.RequestIpl("sc1_01_newbill");
                    API.RequestIpl("hw1_02_newbill");
                    API.RequestIpl("hw1_emissive_newbill");
                    API.RequestIpl("sc1_14_newbill");
                    API.RequestIpl("dt1_17_newbill");
                }
                if (Load_LesterFactory)
                {
                    API.RequestIpl("id2_14_during_door");
                    API.RequestIpl("id2_14_during1");
                }
                else
                {
                    API.RemoveIpl("id2_14_during_door");
                    API.RemoveIpl("id2_14_during1");
                }
                if (Load_LifeInvaderLobby)
                    API.RequestIpl("facelobby");
                else
                    API.RemoveIpl("facelobby");
                if (Load_Tunnel)
                    API.RequestIpl("v_tunnel_hole");
                else
                    API.RemoveIpl("v_tunnel_hole");
                if (Load_StadiumFameOrShame)
                {
                    API.RequestIpl("sp1_10_real_interior");
                    API.RequestIpl("sp1_10_real_interior_lod");
                }
                else
                {
                    API.RemoveIpl("sp1_10_real_interior");
                    API.RemoveIpl("sp1_10_real_interior_lod");
                }
                if (Load_HouseInBanhamCanyon)
                    API.RequestIpl("ch1_02_open");
                else
                    API.RemoveIpl("ch1_02_open");
                if (Load_LostsTrailerPark)
                    API.RequestIpl("methtrailer_grp1");
                else
                    API.RemoveIpl("methtrailer_grp1");
                if (Load_RatonCanyonRiver)
                    API.RequestIpl("CanyonRvrShallow");
                else
                    API.RemoveIpl("CanyonRvrShallow");
                if (Load_PillboxHospital)
                    API.RequestIpl("rc12b_default");
                else
                    API.RemoveIpl("rc12b_default");
                if (Load_LostSafehouse)
                    API.RequestIpl("bkr_bi_hw1_13_int");
                else
                    API.RemoveIpl("bkr_bi_hw1_13_int");
                if (Load_RedCarpet)
                    API.RequestIpl("redCarpet");
                else
                    API.RemoveIpl("redCarpet");
                if (Load_DesHospital)
                {
                    API.RequestIpl("RC12B_Destroyed");
                    API.RequestIpl("RC12B_HospitalInterior");
                }
                else
                {
                    API.RemoveIpl("RC12B_Destroyed");
                    API.RemoveIpl("RC12B_HospitalInterior");
                }
                if (Load_SunkenCargoShip)
                {
                    API.RemoveIpl("cargoship");
                    API.RequestIpl("post_hiest_unload");
                    API.RequestIpl("sunkcargoship");
                }
                else
                {
                    API.RequestIpl("cargoship");
                    API.RemoveIpl("post_hiest_unload");
                    API.RemoveIpl("sunkcargoship");
                }
                if (Load_JewelryStore)
                {
                    API.RequestIpl("post_hiest_unload");
                    API.RemoveIpl("bh1_16_refurb");
                    API.RemoveIpl("jewel2fake");
                }
                else
                {
                    API.RemoveIpl("post_hiest_unload");
                    API.RequestIpl("bh1_16_refurb");
                    API.RequestIpl("jewel2fake");
                }
                if (Load_TrainCrash)
                {
                    API.RequestIpl("canyonriver01_traincrash");
                    API.RequestIpl("railing_end");
                    API.RemoveIpl("railing_start");
                    API.RemoveIpl("canyonriver01");
                }
                else
                {
                    API.RemoveIpl("canyonriver01_traincrash");
                    API.RemoveIpl("railing_end");
                    API.RequestIpl("railing_start");
                    API.RequestIpl("canyonriver01");
                }
                if (Load_BrokenStiltHouse)
                {
                    API.RequestIpl("DES_StiltHouse_imapend");
                    API.RemoveIpl("DES_StiltHouse_imapstart");
                    API.RemoveIpl("des_stilthouse_rebuild");
                }
                else
                {
                    API.RemoveIpl("DES_StiltHouse_imapend");
                    API.RemoveIpl("DES_StiltHouse_imapstart");
                    API.RequestIpl("des_stilthouse_rebuild");
                }
                if (Load_PlaneCrash)
                {
                    API.RequestIpl("Plane_crash_trench");
                    API.RequestIpl("prop_shamal_crash");
                }
                else
                {
                    API.RemoveIpl("Plane_crash_trench");
                    API.RemoveIpl("prop_shamal_crash");
                }
                if (Load_NorthYankton)
                {
                    API.RequestIpl("prologue01");
                    API.RequestIpl("prologue01c");
                    API.RequestIpl("prologue01d");
                    API.RequestIpl("prologue01e");
                    API.RequestIpl("prologue01f");
                    API.RequestIpl("prologue01g");
                    API.RequestIpl("prologue01h");
                    API.RequestIpl("prologue01i");
                    API.RequestIpl("prologue01j");
                    API.RequestIpl("prologue01k");
                    API.RequestIpl("prologue01z");
                    API.RequestIpl("prologue02");
                    API.RequestIpl("prologue03");
                    API.RequestIpl("prologue03b");
                    API.RequestIpl("prologue04");
                    API.RequestIpl("prologue04b");
                    API.RequestIpl("prologue05");
                    API.RequestIpl("prologue05b");
                    API.RequestIpl("prologue06");
                    API.RequestIpl("prologue06b");
                    API.RequestIpl("prologue06_int");
                    API.RequestIpl("prologuerd");
                    API.RequestIpl("prologuerdb ");
                    API.RequestIpl("prologue_DistantLights");
                    API.RequestIpl("prologue_LODLights");
                    API.RequestIpl("prologue_m2_door");
                }
                else
                {
                    API.RemoveIpl("prologue01");
                    API.RemoveIpl("prologue01c");
                    API.RemoveIpl("prologue01d");
                    API.RemoveIpl("prologue01e");
                    API.RemoveIpl("prologue01f");
                    API.RemoveIpl("prologue01g");
                    API.RemoveIpl("prologue01h");
                    API.RemoveIpl("prologue01i");
                    API.RemoveIpl("prologue01j");
                    API.RemoveIpl("prologue01k");
                    API.RemoveIpl("prologue01z");
                    API.RemoveIpl("prologue02");
                    API.RemoveIpl("prologue03");
                    API.RemoveIpl("prologue03b");
                    API.RemoveIpl("prologue04");
                    API.RemoveIpl("prologue04b");
                    API.RemoveIpl("prologue05");
                    API.RemoveIpl("prologue05b");
                    API.RemoveIpl("prologue06");
                    API.RemoveIpl("prologue06b");
                    API.RemoveIpl("prologue06_int");
                    API.RemoveIpl("prologuerd");
                    API.RemoveIpl("prologuerdb ");
                    API.RemoveIpl("prologue_DistantLights");
                    API.RemoveIpl("prologue_LODLights");
                    API.RemoveIpl("prologue_m2_door");
                }
                if (Load_OnlineBunkers)
                {
                    API.RequestIpl("gr_case0_bunkerclosed");
                    API.RequestIpl("gr_case1_bunkerclosed");
                    API.RequestIpl("gr_case2_bunkerclosed");
                    API.RequestIpl("gr_case3_bunkerclosed");
                    API.RequestIpl("gr_case4_bunkerclosed");
                    API.RequestIpl("gr_case5_bunkerclosed");
                    API.RequestIpl("gr_case6_bunkerclosed");
                    API.RequestIpl("gr_case7_bunkerclosed");
                    API.RequestIpl("gr_case8_bunkerclosed");
                    API.RequestIpl("gr_case9_bunkerclosed");
                    API.RequestIpl("gr_case10_bunkerclosed");
                    API.RequestIpl("gr_case11_bunkerclosed");
                }
                else
                {
                    API.RemoveIpl("gr_case0_bunkerclosed");
                    API.RemoveIpl("gr_case1_bunkerclosed");
                    API.RemoveIpl("gr_case2_bunkerclosed");
                    API.RemoveIpl("gr_case3_bunkerclosed");
                    API.RemoveIpl("gr_case4_bunkerclosed");
                    API.RemoveIpl("gr_case5_bunkerclosed");
                    API.RemoveIpl("gr_case6_bunkerclosed");
                    API.RemoveIpl("gr_case7_bunkerclosed");
                    API.RemoveIpl("gr_case8_bunkerclosed");
                    API.RemoveIpl("gr_case9_bunkerclosed");
                    API.RemoveIpl("gr_case10_bunkerclosed");
                    API.RemoveIpl("gr_case11_bunkerclosed");
                }
                if (Load_ArcadiusBusinessCentre)
                {
                    API.RequestIpl("ex_dt1_02_office_02b");
                    API.RequestIpl("ex_dt1_02_office_02c");
                    API.RequestIpl("ex_dt1_02_office_02a");
                    API.RequestIpl("ex_dt1_02_office_01a");
                    API.RequestIpl("ex_dt1_02_office_01b");
                    API.RequestIpl("ex_dt1_02_office_01c");
                    API.RequestIpl("ex_dt1_02_office_03a");
                    API.RequestIpl("ex_dt1_02_office_03b");
                    API.RequestIpl("ex_dt1_02_office_03c");
                }
                else
                {
                    API.RemoveIpl("ex_dt1_02_office_02b");
                    API.RemoveIpl("ex_dt1_02_office_02c");
                    API.RemoveIpl("ex_dt1_02_office_02a");
                    API.RemoveIpl("ex_dt1_02_office_01a");
                    API.RemoveIpl("ex_dt1_02_office_01b");
                    API.RemoveIpl("ex_dt1_02_office_01c");
                    API.RemoveIpl("ex_dt1_02_office_03a");
                    API.RemoveIpl("ex_dt1_02_office_03b");
                    API.RemoveIpl("ex_dt1_02_office_03c");
                }
                if (Load_Morgue)
                {
                    API.RequestIpl("coronertrash");
                    API.RequestIpl("Coroner_Int_On");
                }
                else
                {
                    API.RemoveIpl("coronertrash");
                    API.RemoveIpl("Coroner_Int_On");
                }
            }
        }
    }
}
