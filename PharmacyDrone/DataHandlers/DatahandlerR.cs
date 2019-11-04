﻿using PharmacyDrone.Classes;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyDrone.DataHandlers
{
    class DatahandlerR
    {
        static Notify notifier = new Notify();

        static OleDbConnection conn = new OleDbConnection(ConfigurationManager.ConnectionStrings["PharmacyDroneDB"].ConnectionString);


        public List<User> ReadUsers()
        {
            List<User> userList = new List<User>();

            try
            {
                conn.Open();
                if (conn.State == ConnectionState.Open)
                {
                    OleDbCommand cmd = new OleDbCommand("Select * From [User]", conn);
                    OleDbDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        userList.Add( new User(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetInt32(3), reader.GetInt32(4)));
                    }


                }
                else
                {
                    throw new CustomException("Database connection error");
                }
            }

            catch (CustomException ce)
            {

                notifier.error(ce.Message);
            }
            finally
            {
                conn.Close();
            }

            return userList;


        }

        public static bool InsertUser(User u)
        {


            try
            {
                conn.Open();
                if (conn.State == ConnectionState.Open)
                {

                    OleDbCommand cmd = new OleDbCommand("INSERT INTO [User] (UserName, Password, AccountType, AccountState) VALUES ('" + u.Username + "','" + u.Password + "','" + u.AccountType +"','" + u.State + "' )", conn);
                    cmd.ExecuteNonQuery();

                }
            }

            catch (CustomException ce)
            {

                notifier.error(ce.Message);
                return false;
            }
            finally
            {
                conn.Close();
            }

            return true;


        } //Creates a new account



        public List<MedicalSupply> ReadMedicalSupplies()
        {
            List<MedicalSupply> medicalSupplyList = new List<MedicalSupply>();

            try
            {
                conn.Open();
                if (conn.State == ConnectionState.Open)
                {
                    OleDbCommand cmd = new OleDbCommand("Select * From MedicalSupply", conn);
                    OleDbDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        medicalSupplyList.Add(new MedicalSupply(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3),reader.GetInt32(4)));
                    }


                }
                else
                {
                    throw new CustomException("Database connection error");
                }
            }

            catch (CustomException ce)
            {

                notifier.error(ce.Message);
            }
            finally
            {
                conn.Close();
            }

            return medicalSupplyList;


        }



        public static void UpdateState(int i,int id)
        {
            conn.Open();

            OleDbCommand cmd = new OleDbCommand("Update [User] Set AccountState = '"+i+"' Where UserID = '" + id + "'", conn);

            cmd.ExecuteNonQuery();
            conn.Close();


        }
        public static bool UpdateOrderState(int userId)
        {
            conn.Open();

            OleDbCommand cmd = new OleDbCommand("Update [OrderRequests] Set OrderState = '1' Where UserID = '" + userId + "' AND OrderState = '0'", conn);

            int rowsAffected =  cmd.ExecuteNonQuery();
            conn.Close();
            if (rowsAffected == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
            
            


        }


        public static bool InsertOrderRequest(OrderRequest or)
        {


            try
            {
                conn.Open();
                if (conn.State == ConnectionState.Open)
                {

                    OleDbCommand cmd = new OleDbCommand("INSERT INTO OrderRequests (OrderNum, MedicalSupplyID, UserID,DroneID) VALUES ('" + or.OrderNum + "','" + or.MedicalSupplyID + "','" + or.UserID + "','"+or.DroneID+" )", conn);
                    cmd.ExecuteNonQuery();

                }
            }

            catch (CustomException ce) 
            {

                notifier.error(ce.Message);
                return false;
            }
            finally
            {
                conn.Close();
            }

            return true;


        }


        public static List<OrderRequest> ReadOrderRequests()
        {
            List<OrderRequest> orderRequestList = new List<OrderRequest>();

            try
            {
                conn.Open();
                if (conn.State == ConnectionState.Open)
                {
                    OleDbCommand cmd = new OleDbCommand("Select * From OrderRequests", conn);
                    OleDbDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        OrderRequest temp = new OrderRequest(reader.GetInt32(0), reader.GetInt32(1), reader.GetInt32(2), reader.GetInt32(3));
                        temp.SetDrone(reader.GetInt32(4));
                        orderRequestList.Add(temp);
                    }


                }
                else
                {
                    throw new CustomException("Database connection error");
                }
            }

            catch (CustomException ce)
            {

                notifier.error(ce.Message);
            }
            finally
            {
                conn.Close();
            }

            return orderRequestList;


        }

        public MedicalSupply ReadMedicalSuppliesByID(int id)
        {
            MedicalSupply ms = new MedicalSupply();

            try
            {
                conn.Open();
                if (conn.State == ConnectionState.Open)
                {
                    OleDbCommand cmd = new OleDbCommand("Select * From MedicalSupply Where MedicalSupplyID = '" + id + "'", conn);
                    OleDbDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        ms = new MedicalSupply(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetInt32(4));
                    }


                }
                else
                {
                    throw new CustomException("Database connection error");
                }
            }

            catch (CustomException ce)
            {

                notifier.error(ce.Message);
            }
            finally
            {
                conn.Close();
            }

            return ms;


        }

        public static void DeleteOrderByID(int id) 
        {
            conn.Open();

            OleDbCommand cmd = new OleDbCommand("Delete From OrderRequests Where OrderNum = '" + id + "'", conn);

            cmd.ExecuteNonQuery();
            conn.Close();


        }

        public static Drone SelectDrone()
        {
            List<Drone> droneList = new List<Drone>();

            try
            {
                conn.Open();
                if (conn.State == ConnectionState.Open)
                {
                    OleDbCommand cmd = new OleDbCommand("Select * From Drone ", conn);
                    OleDbDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        droneList.Add(new Drone(reader.GetInt32(0), reader.GetString(1)));
                    }


                }
                else
                {
                    throw new CustomException("Database connection error");
                }
            }

            catch (CustomException ce)
            {

                notifier.error(ce.Message);
            }
            finally
            {
                conn.Close();
            }
            Random rnd = new Random();

            return droneList[rnd.Next(0,droneList.Count)];
        }
        public static Drone SelectDroneByID(int ID)
        {
            Drone drone = new Drone();

            try
            {
                conn.Open();
                if (conn.State == ConnectionState.Open)
                {
                    OleDbCommand cmd = new OleDbCommand("Select * From Drone WHERE DroneID = " + ID, conn);
                    OleDbDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        drone = new Drone(reader.GetInt32(0), reader.GetString(1));
                    }


                }
                else
                {
                    throw new CustomException("Database connection error");
                }
            }

            catch (CustomException ce)
            {

                notifier.error(ce.Message);
            }
            finally
            {
                conn.Close();
            }          

            return drone;
        }

    }
}
