changeImageNameTo: aString

	^ self deprecated: 'Use SmalltalkImage current changeImageNameTo: ', aString
		block: [SmalltalkImage current changeImageNameTo: aString]
