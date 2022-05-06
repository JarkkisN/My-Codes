/* util.c */
#include "util.h"

const double LBS_IN_KG = 0.453592;

double kgToLbs(double kg) {
	return kg/LBS_IN_KG;
}

double lbsToKg(double lbs) {
	return lbs*LBS_IN_KG;
}