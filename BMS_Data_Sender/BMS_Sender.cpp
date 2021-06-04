/* ***********************************************************************************************************
* File Name   :	BMS_Sender.cpp
* Author      : Karthick vaitheeswaran
* Description : BMS_data sender.cpp is used to send the BMS datas like temperature and State of Charging
* Functions	  :
* *********************************************************************************************************** */
#include<iostream>
#include <stdlib.h>
#include <sstream>
#include "BMS_Sender.h"



bool BMSParameter::inRange(float current_value, float min_value, float max_value)
{
      return((current_value >= min_value) && (current_value <= max_value));
}

 float BMSParameter::BmsSender_Temperture()
 {
        return randomNumberGenerator(MIN_TEMP,MAX_TEMP);
 }
    
 float BMSParameter::BmsSender_SOC()
 {
       return randomNumberGenerator(MIN_SOC,MAX_SOC);
       
 }
   
float  BMSParameter::randomNumberGenerator(int min_value, int max_value)
{
      return ((rand() % (min_value - max_value + 1)) + min_value);         
}

char* BMSParameter::OutputJsonData()
{     
   temperature =BmsSender_Temperture();   
   SOC= BmsSender_SOC();
   sprintf(outputJsonData, "{\"Temperature\":%f,\"SOC\":%f}", temperature, SOC);
  
   return outputJsonData;
}

 void BMSParameter::printOnConsole(char *Jsondata)
 {
   std::cout<<Jsondata<<std::endl;
 }


