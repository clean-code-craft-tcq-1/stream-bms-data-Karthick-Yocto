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
private:
    float temperature;
	float SOC;
public:
    bool inRange(float current_value, float min_value, float max_value);
    float BmsSender_Temperture();
    float BmsSender_SOC();
    float  randomNumberGenerator(int min_value, int max_value);
    void OutputData();
    bool printOnConsole(std::stringstream parameterType);

};



