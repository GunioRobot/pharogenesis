blockSelectFailedCall
	"Precondition: mRef references compiledCall."
	^ [:mRef | (mRef compiledMethod literals first at: 4)
		= -1]