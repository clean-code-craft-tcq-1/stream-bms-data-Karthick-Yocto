/* ***********************************************************************************************************
* File Name   :	BMS_Sender.cpp
* Author      : Karthick vaitheeswaran
* Description : BMS_data sender.cpp is used to send the BMS datas like temperature and State of Charging
* Functions	  :
* *********************************************************************************************************** */
#include<iostream>
#include <stdlib.h>
#include <boost/property_tree/ptree.hpp>
#include <boost/property_tree/json_parser.hpp>
#include "BMS_Sender.h"

bool BMSParameter::inRange(float current_value, int min_value, int max_value)
{
      return((current_value >= min_value) && (current_value <= max_value));
}

 float BMSParameter::BmsSender_Temperture()
 {
        int Temperture  = randomNumberGenerator(MIN_TEMP,MAX_TEMP);

        isInRange(Temperture, MIN_TEMP, MAX_TEMP) ? return Temperture: return ERROR;
 }
    
 float BMSParameter::BmsSender_SOC()
 {
       int SOC = randomNumberGenerator(MIN_SOC,MAX_SOC);
       
       isInRange(SOC, MIN_SOC, MAX_SOC) ? return SOC: return ERROR; 
 }
   
int BMSParameter::randomNumberGenerator(int min_value, int max_value)
{
      return (rand() % (min_value - max_value + 1)) + min_value;         
}

void BMSParameter::OutputData()
{
   boost::property_tree::ptree Jsondata;
   int Temperature =BmsSender_Temperture();
   int SOC= BmsSender_SOC();
   
   Jsondata.put("Temperature", Temperature);
   Jsondata.put("SOC", SOC);
   
   std::stringstream output;
   boost::property_tree::json_parser::write_json(output, Jsondata);
  
   printOnConsole(output);
}

 void BMSParameter::printOnConsole(std::string parameterType)
 {
   cout<<parameterType<<endl;
 }

main()
{
   OutputData();
}
