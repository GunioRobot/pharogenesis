featuresAtCenter
	"Answer the features vector computed from a single FFT window taken from the center of my samples."

	^ self extractFeaturesAt: (samples monoSampleCount // 2)
