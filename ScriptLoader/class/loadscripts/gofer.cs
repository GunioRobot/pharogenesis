gofer
	^ Smalltalk at: #Gofer ifAbsent: [ self new installGofer; gofer ]