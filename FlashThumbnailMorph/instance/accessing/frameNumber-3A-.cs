frameNumber: aNumber
	frameNumber = aNumber ifFalse:[
		frameNumber := aNumber.
		image := nil.
	].