frameNumber: aNumber
	frameNumber = aNumber ifFalse:[
		frameNumber _ aNumber.
		image _ nil.
	].