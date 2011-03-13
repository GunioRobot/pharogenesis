gofer
	^ Smalltalk at: #Gofer ifAbsent: [ self installGofer; gofer ]