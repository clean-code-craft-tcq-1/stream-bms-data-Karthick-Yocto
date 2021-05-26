#pragma once

//Temperature
#define MIN_TEMP    -25.0
#define MAX_TEMP    100.0

//SOC
#define MIN_SOC     0.0
#define MAX_SOC     100.0



class BMSParameter
{
public:
    bool inRange(int minValueChecker, int maxValueChecker);
    float BmsSender_Temperture();
    float BmsSender_SOC();
    bool printOnConsole(std::string parameterType, int GenerateNumbers);

};



