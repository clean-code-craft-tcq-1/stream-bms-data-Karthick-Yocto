#pragma once

//Temperature
#define MIN_TEMP    0.0
#define MAX_TEMP    100.0

//SOC
#define MIN_SOC     0.0
#define MAX_SOC     150.0

#define ERROR     -1

class BMSParameter
{
public:
    bool inRange(int minValueChecker, int maxValueChecker);
    float BmsSender_Temperture();
    float BmsSender_SOC();
    int randomNumberGenerator(int min_value, int max_value);
    bool printOnConsole(std::string parameterType, int GenerateNumbers);

};



