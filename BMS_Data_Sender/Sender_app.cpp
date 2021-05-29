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
		sender_obj->printOnConsole(sender_obj->OutputJsonData());
		sleep(500);
	}
	return 0;
}
