#pragma once

class BMSParameter
{
public:
    bool inRange(int minValueChecker, int maxValueChecker);
    float BmsSender_ReadTemperture();
    float BmsSender_ReadSOC();
    bool printOnConsole(std::string parameterType, int GenerateNumbers);

};



