averageFeatures
	"Compute the average features vector across my sound samples."

	| startI endI featureVectors |
	"skip the first and last bits"
	startI _ (samplingRate // 5).
	endI _ samples monoSampleCount - (samplingRate // 5).
	endI - startI < FFTSize ifTrue: [^ self extractFeaturesAt: endI].

	featureVectors _ (startI to: endI by: FFTSize)
		collect: [:i | (self extractFeaturesAt: i)].
	^ self prunedAverageFeatures: featureVectors
