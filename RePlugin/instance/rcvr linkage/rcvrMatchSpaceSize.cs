rcvrMatchSpaceSize

	self inline: true.
	^(interpreterProxy byteSizeOf: (interpreterProxy fetchPointer: 7 ofObject: rcvr))//4.