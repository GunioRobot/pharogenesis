rcvrPatternStrPtr

	self inline: true.
	self returnTypeC: 'char *'.
	^self 
		cCoerce: (interpreterProxy fetchArray: 0 ofObject: rcvr) 
		to: 'char *'.