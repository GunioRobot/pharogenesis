fromAIFFfileNamed: fileName
	"Read a SampledSound from the AIFF file of the given name, merging stereo to mono if necessary."
	"(SampledSound fromAIFFfileNamed: '1.aif') play"
	"| snd |
	 FileDirectory default fileNames do: [:n |
		(n endsWith: '.aif')
			ifTrue: [
				snd _ SampledSound fromAIFFfileNamed: n.
				snd play.
				SoundPlayer waitUntilDonePlaying: snd]]."

	| aiffFileReader |
	aiffFileReader _ AIFFFileReader new.
	aiffFileReader readFromFile: fileName
		mergeIfStereo: true
		skipDataChunk: false.
	^ self
		samples: (aiffFileReader channelData at: 1)
		samplingRate: aiffFileReader samplingRate
