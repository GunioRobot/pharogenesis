initialize
	"Initialize the parameter used to extract phoneme features. After changing these parameters, execute 'PhonemeRecord initialize'. The features vectors of any existing phoneme records will be cleared and recomputed as needed."
	"PhonemeRecord initialize"

	FFTSize _ 512.			"size of FFT for analysis; this must be a power of two"
	CutoffFreq _ 4000.		"boundary between fine and coarse ranges"
	FilterBandwidth _ 160.	"bandwidth of each frequency band in the fine range"
	HighFreqWeight _ 5.		"weighting of energy above the cutoff frequency"
	AverageFeatures _ false.
		"If AverageFeatures is true, then average features over the phoneme recording. Otherwise, extract features from the center of the recording."

	"clear all cached feature vectors"
	PhonemeRecord allInstancesDo: [:p | p clearFeatures].
