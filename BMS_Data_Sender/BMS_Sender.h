#pragma once
#define MIN_TEMP    -25.0
#define MAX_TEMP    100.0

#define ERROR_TEMP  150.0

#define MIN_SOC     0.0
#define MAX_SOC     100.0

#define ERROR_SOC   255.0

class BMSParameter
{
public:
    bool inRange(int minValueChecker, int maxValueChecker);
    float BmsSender_ReadTemperture();
    float BmsSender_ReadSOC();
    bool printOnConsole(std::string parameterType, int GenerateNumbers);

};



