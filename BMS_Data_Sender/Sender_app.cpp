/* ***********************************************************************************************************
* File Name   :	Sender_app.cpp
* Author      : Karthick Vaitheeswaran
* Description : sender_app.cpp is implementation of main.
* Functions   :
* *********************************************************************************************************** */

#include<iostream>
#include <stdlib.h>
#include <sstream>
#include <unistd.h>
#include "BMS_Sender.h"

int main()
{
	BMSParameter * sender_obj = new BMSParameter;
	while(1)
	{
		std::stringstream outputData=sender_obj->OutputJsonData();
		sender_obj->printOnConsole();
		sleep(500);
	}
	return 0;
}
