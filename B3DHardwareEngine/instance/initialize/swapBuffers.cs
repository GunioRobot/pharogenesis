swapBuffers
	"Swap the receiver's buffers. Return true if successful, false otherwise"
	^(self primSwapBuffers: handle) notNil