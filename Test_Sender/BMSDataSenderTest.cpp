#define CATCH_CONFIG_MAIN  // This tells Catch to provide a main() - only do this in one cpp file
#include<iostream>
#include <stdlib.h>
#include "../BMS_Data_Sender/BMS_Sender.h"
#include "catch.hpp"

TEST_CASE("BMS Data Sender Test") 
{
    BMSParameter * sender_obj = new BMSParameter;
  
    for (int iter = 0; iter < 50; iter++) 
    {
	    float temperature =sender_obj->BmsSender_Temperture();   
      	    float SOC= sender_obj->BmsSender_SOC();
      	    std::cout<<"Temperature="<<temperature<<std::endl;
	    std::cout<<"SOC="<<SOC<<std::endl;
      
	    REQUIRE(sender_obj->inRange(SOC, MIN_SOC, MAX_SOC));
	    REQUIRE(sender_obj->inRange(temperature, MIN_TEMP, MAX_TEMP));
    }
}
