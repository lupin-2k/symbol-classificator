#include "pch.h"
#include "SymbolClassifier.h"
#include <fstream>
#include <iostream>
#include <cmath>
#include <algorithm>

const float predictionThreshold = 0.40;
const int inputsize = 784;

float relu(float x) { return max(0, x); }

void SymbolClassifier::loadModel(string path) {
	fstream flp;
	flp.open(path, ios::in);
	if (!flp) { cout << "ERROR: Could not open file at: " << path << endl; return; }

	flp >> numInputs;

	flp >> numHidden;

	flp >> numOutputs;

	weightsIH.resize(numInputs * numHidden);
	weightsHO.resize(numHidden * numOutputs);
	biasH.resize(numHidden);
	biasO.resize(numOutputs);

	for (unsigned int i = 0; i < weightsIH.size(); i++) {
		flp >> weightsIH[i];
	}

	for (unsigned int i = 0; i < weightsHO.size(); i++) {
		flp >> weightsHO[i];
	}

	for (unsigned int i = 0; i < biasH.size(); i++) {
		flp >> biasH[i];
	}

	for (unsigned int i = 0; i < biasO.size(); i++) {
		flp >> biasO[i];
	}
}

void SymbolClassifier::saveModel(string path) {
	fstream flp;
	flp.open(path, ios::out | ios::trunc);
	if (!flp) { cout << "ERROR: Could not open file at: " << path << endl; return; }

	flp << numInputs << " ";

	flp << numHidden << " ";

	flp << numOutputs << " ";

	weightsIH.resize(numInputs * numHidden);
	weightsHO.resize(numHidden * numOutputs);
	biasH.resize(numHidden);
	biasO.resize(numOutputs);

	for (unsigned int i = 0; i < weightsIH.size(); i++) {
		flp << weightsIH[i] << " ";
	}

	for (unsigned int i = 0; i < weightsHO.size(); i++) {
		flp << weightsHO[i] << " ";
	}

	for (unsigned int i = 0; i < biasH.size(); i++) {
		flp << biasH[i] << " ";
	}

	for (unsigned int i = 0; i < biasO.size(); i++) {
		flp << biasO[i] << " ";
	}
}

int SymbolClassifier::predict(int* matrixpixels,int size) {
	vector<int> inputVector(matrixpixels, matrixpixels + size);
	vector<float> hiddenOutput(numHidden, 0);
	for (unsigned int i = 0; i < numHidden; i++) {
		float sumHidden = 0;
		for (unsigned int j = 0; j < numInputs; j++) {
			sumHidden += inputVector[j] * weightsIH[i * numInputs + j];
		}
		sumHidden += biasH[i];
		hiddenOutput[i] = relu(sumHidden);
	}

	vector<float> finalPrediction(numOutputs, 0);
	float maxLogit = -1e9;
	for (unsigned int i = 0; i < numOutputs; i++) {
		float sumOutput = 0;
		for (unsigned int j = 0; j < numHidden; j++) {
			sumOutput += hiddenOutput[j] * weightsHO[i * numHidden + j];
		}
		sumOutput += biasO[i];
		finalPrediction[i] = sumOutput;
		if (sumOutput > maxLogit) maxLogit = sumOutput;
	}
	float sumExp = 0.0f;
	for (unsigned int i = 0; i < numOutputs; i++) {
		finalPrediction[i] = std::exp(finalPrediction[i] - maxLogit);
		sumExp += finalPrediction[i];
	}
	for (unsigned int i = 0; i < numOutputs; i++) {
		finalPrediction[i] /= sumExp;
	}
	int mostProbClass = 0;
	float highestLikelihood = finalPrediction[0];
	for (unsigned int i = 1; i < numOutputs; i++) {
		if (finalPrediction[i] > highestLikelihood) {
			highestLikelihood = finalPrediction[i];
			mostProbClass = i;
		}
	}
	if (highestLikelihood < predictionThreshold) return -1;
	return mostProbClass;
	/*for (unsigned int i = 0; i < numOutputs; i++) {
		float sumOutput = 0;
		for (unsigned int j = 0; j < numHidden; j++) {
			sumOutput += hiddenOutput[j] * weightsHO[i * numHidden + j];
		}
		sumOutput += biasO[i];
		finalPrediction[i] = relu(sumOutput);
	}

	int mostProbClass = 0;
	float highestLikelihood = finalPrediction[0];
	for (unsigned int i = 0; i < finalPrediction.size(); i++) {
		if (finalPrediction[i] > highestLikelihood) { highestLikelihood = finalPrediction[i]; mostProbClass = i; }
	}
	return mostProbClass;*/

}

SymbolClassifier classifier;

extern "C" __declspec(dllexport) int Predict(int* matrixpixels) {
	return classifier.predict(matrixpixels,inputsize);
}

extern "C" __declspec(dllexport) void LoadModel(const char* filePath) {
	string path(filePath);
	classifier.loadModel(path);
}