from16BitAIFFfileNamed: fileName samplingRate: anInteger
	"Read a SampledSound from the 16-bit AIFF file of the given name. This method skips the header without parsing it; it assumes the file contains 16-bit uncompressed mono data. The headers of such AIFF files are 54 bytes."
	"(SampledSound from16BitAIFFfileNamed: 'b2Pageturn.aif' samplingRate: 22050) play"

	| data |
	data _ self rawDataFromAIFFfileNamed: fileName.
	data _ self convertBytesTo16BitSamples: data mostSignificantByteFirst: true.
	^ self samples: data samplingRate: anInteger
