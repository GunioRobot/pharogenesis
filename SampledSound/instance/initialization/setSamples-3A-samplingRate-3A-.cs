setSamples: anArray samplingRate: rate
	"Set my samples array to the given array with the given nominal sampling rate. Altering the rate parameter allows the sampled sound to be played back at different pitches."
	"Assume: anArray is either a SoundBuffer or a collection of signed 16-bit sample values."
	"(SampledSound
		samples: SampledSound coffeeCupClink
		samplingRate: 5000) play"

	"copy the array into a SoundBuffer if necessary"
	anArray class isWords
		ifTrue: [samples _ anArray]
		ifFalse: [samples _ SoundBuffer fromArray: anArray].

	samplesSize _ samples size.
	originalSamplingRate _ rate.
	initialCount _ (samplesSize * self samplingRate) // originalSamplingRate.
	self setLoudness: 0.25.
	self reset.
