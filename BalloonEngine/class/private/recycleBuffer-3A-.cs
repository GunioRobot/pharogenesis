recycleBuffer: balloonBuffer
	"Try to keep the buffer for later drawing operations."
	| buffer |
	CacheProtect critical:[
		buffer := BufferCache at: 1.
		(buffer isNil or:[buffer size < balloonBuffer size] )
			ifTrue:[BufferCache at: 1 put: balloonBuffer].
	].