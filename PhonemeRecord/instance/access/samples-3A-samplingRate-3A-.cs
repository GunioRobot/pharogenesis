samples: aSoundBuffer samplingRate: aNumber
	"Set my samples and sampling rate, and clear my cached features vector."

	samples := aSoundBuffer.
	samplingRate := aNumber.
	self clearFeatures.
