extractFeaturesAt: startIndex
	"Extract a features vector from the given point in my samples."

	| spectrum cutoffIndex binSize s i avg unscaledFeatures total |
	spectrum _ (FFT new: FFTSize)
		transformDataFrom: samples
		startingAt: (startIndex min: (samples monoSampleCount - FFTSize + 1)).

	cutoffIndex _ ((CutoffFreq * spectrum size) / (samplingRate / 2)) rounded.
	binSize _ ((FilterBandwidth * spectrum size) / (samplingRate / 2)) rounded.

	s _ WriteStream on: (Array new: 50).
	i _ 2. "skip first bin of FFT data, which just contains the D.C. component"
	[i < cutoffIndex] whileTrue: [
		avg _ (spectrum copyFrom: i to: i + binSize - 1) sum / binSize.
		s nextPut: avg.
		i _ i + binSize].

	"final entry of feature vector sums all energy above the cutoff frequency"
	s nextPut: HighFreqWeight *
		((spectrum copyFrom: i to: spectrum size) sum / (spectrum size + 1 - i)).

	unscaledFeatures _ s contents.
	total _ unscaledFeatures sum.
	^ unscaledFeatures collect: [:n | (1000.0 * n) // total].
