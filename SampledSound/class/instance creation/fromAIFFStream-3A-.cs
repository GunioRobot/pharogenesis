fromAIFFStream: fileStream

	| aiffFileReader |
	aiffFileReader _ AIFFFileReader new.
	aiffFileReader readFrom: fileStream
		mergeIfStereo: true
		skipDataChunk: false.
	^ self
		samples: (aiffFileReader channelData at: 1)
		samplingRate: aiffFileReader samplingRate
