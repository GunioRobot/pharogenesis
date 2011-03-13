withEToySound: aByteArray samplingRate: anInteger

	soundClassName _ #SampledSound.
	channels _ {aByteArray}.
	codecName _ #GSMCodec.
	loopEnd _ nil.	"???"
	loopLength _  nil.
	perceivedPitch _ 100.0.
	samplingRate  _ anInteger.
	gain  _ 1.0.	"???"
	firstSample _ 1.
	cachedSound  _ nil.	"???"