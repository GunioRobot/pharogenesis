fromAIFFfileNamed: fileName
	"Read a SampledSound from the AIFF file of the given name assuming a default sampling rate."
	"(SampledSound fromAIFFfileNamed: '1.aif') play"
	"| snd |
	 FileDirectory default fileNames do: [:n |
		(n endsWith: '.aif')
			ifTrue: [
				snd _ SampledSound fromAIFFfileNamed: n.
				snd play.
				SoundPlayer waitUntilDonePlaying: snd]]."

	| data |
	data _ self rawDataFromAIFFfileNamed: fileName.
	data _ self convert8bitSignedTo16Bit: data.
	^ self samples: data samplingRate: 11025
