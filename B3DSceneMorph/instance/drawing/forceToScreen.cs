forceToScreen
	"When using hardware acceleration, this method forces the receiver to swap its buffers."
	myRenderer ifNotNil:[
		myRenderer swapBuffers ifFalse:[
			"Something went wrong"
			myRenderer destroy.
			myRenderer _ nil]].