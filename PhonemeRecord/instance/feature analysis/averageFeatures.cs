averageFeatures
	"Compute the average features vector across my sound samples."

	| startI endI featureVectors |
	"skip the first and last bits"
	startI := (samplingRate // 5).
	endI := samples monoSampleCount - (samplingRate // 5).
	endI - startI < FFTSize ifTrue: [^ self extractFeaturesAt: endI].

	featureVectors := (startI to: endI by: FFTSize)
		collect: [:i | (self extractFeaturesAt: i)].
	^ self prunedAverageFeatures: featureVectors
