#pragma once
#include <vector>
#include <string>

using namespace std;

class SymbolClassifier {
private:
	unsigned int numInputs;
	unsigned int numHidden;
	unsigned int numOutputs;

	vector<float> weightsIH;
	vector<float> weightsHO;
	vector<float> biasH;
	vector<float> biasO;

public:
	void loadModel(string path);
	void saveModel(string path);
	int predict(int* matrixpixels, int size);
};