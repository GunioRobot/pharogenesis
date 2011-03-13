initialize
	"Initialize a new socket handle. If socket creation fails, socketHandle will be set to nil."

	| semaIndex |
	semaphore _ Semaphore new.
	semaIndex _ Smalltalk registerExternalObject: semaphore.
	socketHandle _
		self primSocketCreateNetwork: 0
			type: 0
			receiveBufferSize: 8000
			sendBufSize: 8000
			semaIndex: semaIndex.

	socketHandle = nil ifTrue: [  "socket creation failed"
		Smalltalk unregisterExternalObject: semaphore.
		semaphore _ nil].
