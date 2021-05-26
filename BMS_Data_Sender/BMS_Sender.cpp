/* ***********************************************************************************************************
* File Name   :	BMS_Sender.cpp
* Author      : Karthick vaitheeswaran
* Description : BMS_data sender.cpp is used to send the BMS datas like temperature and State of Charging
* Functions	  :
* *********************************************************************************************************** */
#include<iostream>
#include <stdlib.h>
#include "BMS_Sender.h"

bool BMSParameter::inRange(float current_value, int min_value, int max_value)
{
   return((current_value >= min_value) && (current_value <= max_value));
}

 float BMSParameter::BmsSender_Temperture()
 {
     int Temperture  = randomNumberGenerator(MIN_TEMP,MAX_TEMP);
    
      isInRange(Temperture, MIN_TEMP, MAX_TEMP) ? return Temperture: return Temperture;
   
 }
    
 float BMSParameter::BmsSender_SOC()
 {
        int SOC = randomNumberGenerator(MIN_SOC,MAX_SOC);
       
       isInRange(SOC, MIN_SOC, MAX_SOC) ? return SOC: return Temperture;
   
 }
   
int BMSParameter::randomNumberGenerator(int min_value, int max_value)
{
  return (rand() % (min_value - max_value + 1)) + min_value;         
}

 bool BMSParameter::printOnConsole(std::string parameterType, int GenerateNumbers)
 {
   
 }


