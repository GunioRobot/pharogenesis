addLibrarySoundNamed: aString fromAIFFfileNamed: fileName sampleRate: samplesPerSecond
	"Add a sound from the given AIFF file to the library. The file is assumed to be 8-bits, mono, uncompressed."
	"SampledSound addLibrarySoundNamed: 'shutterClick'
		fromAIFFfileNamed: '7.aif'
		sampleRate: 11025"

	self addLibrarySoundNamed: aString
		samples: (self rawDataFromAIFFfileNamed: fileName)
		sampleRate: samplesPerSecond.
