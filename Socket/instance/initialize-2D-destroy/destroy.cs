destroy
	"Destroy this socket. Its connection, if any, is aborted and its resources are freed. Do nothing if the socket has already been destroyed (i.e., if its socketHandle is nil)."

	socketHandle = nil
		ifFalse: [
			self primSocketDestroy: socketHandle.
			Smalltalk unregisterExternalObject: semaphore.
			socketHandle _ nil.
			semaphore _ nil].
