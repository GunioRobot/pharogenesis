initialize
	"Create a new socket handle."

	| semaIndex |
	semaphore _ Semaphore new.
	semaIndex _ Smalltalk registerExternalObject: semaphore.
	socketHandle _
		self primSocketCreateNetwork: 0
			type: 0
			receiveBufferSize: 8000
			sendBufSize: 8000
			semaIndex: semaIndex.
