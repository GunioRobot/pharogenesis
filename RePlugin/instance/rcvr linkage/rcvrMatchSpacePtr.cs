rcvrMatchSpacePtr

	self inline: true.
	self returnTypeC: 'int *'.
	^self
		cCoerce: (interpreterProxy fetchArray: 7 ofObject: rcvr)
		to: 'int *'.