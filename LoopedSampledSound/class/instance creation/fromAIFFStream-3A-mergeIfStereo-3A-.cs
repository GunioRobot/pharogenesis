fromAIFFStream: fileStream mergeIfStereo: mergeFlag
	"Initialize this sound from the data in the given AIFF file. If mergeFlag is true and the file is stereo, its left and right channels are mixed together to produce a mono sampled sound."

	| aiffFileReader |
	aiffFileReader _ AIFFFileReader new.
	aiffFileReader readFrom: fileStream
		mergeIfStereo: mergeFlag
		skipDataChunk: false.
	^self new fromAIFFFileReader: aiffFileReader mergeIfStereo: mergeFlag