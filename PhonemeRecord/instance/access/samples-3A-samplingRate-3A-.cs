samples: aSoundBuffer samplingRate: aNumber
	"Set my samples and sampling rate, and clear my cached features vector."

	samples _ aSoundBuffer.
	samplingRate _ aNumber.
	self clearFeatures.
