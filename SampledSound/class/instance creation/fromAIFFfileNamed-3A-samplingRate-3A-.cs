fromAIFFfileNamed: fileName samplingRate: anInteger
	"Read a SampledSound from the AIFF file of the given name. This method skips the header without parsing it; it assumes the file contains 8-bit uncompressed mono data as recorded by the shareware program SoundMachine 2.1. The headers of such AIFF files are 54 bytes."
	"(SampledSound fromAIFFfileNamed: '1.aif' samplingRate: 8000) play"

	| data |
	data _ self rawDataFromAIFFfileNamed: fileName.
	data _ self convert8bitSignedTo16Bit: data.
	^ self samples: data samplingRate: anInteger
