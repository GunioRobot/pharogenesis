rcvrCompileFlags

	self inline:true.
	^interpreterProxy fetchInteger: 1 ofObject: rcvr.
