fromAIFFStream: fileStream
	"Initialize this sound from the data in the given AIFF file. If mergeFlag is true and the file is stereo, its left and right channels are mixed together to produce a mono sampled sound."

	^self fromAIFFStream: fileStream mergeIfStereo: true