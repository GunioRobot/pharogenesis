buildAbsolutePath: pathParts
	^String streamContents: [:stream |
		stream nextPut: $/.
		pathParts
			do: [:pathPart | stream nextPutAll: pathPart]
			separatedBy: [stream nextPut: $/]]