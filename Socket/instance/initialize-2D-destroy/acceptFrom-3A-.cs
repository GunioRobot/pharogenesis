acceptFrom: aSocket
	"Initialize a new socket handle from an accept call"
	| semaIndex readSemaIndex writeSemaIndex |

	primitiveOnlySupportsOneSemaphore _ false.
	semaphore _ Semaphore new.
	readSemaphore _ Semaphore new.
	writeSemaphore _ Semaphore new.
	semaIndex _ Smalltalk registerExternalObject: semaphore.
	readSemaIndex _ Smalltalk registerExternalObject: readSemaphore.
	writeSemaIndex _ Smalltalk registerExternalObject: writeSemaphore.
	socketHandle _ self primAcceptFrom: aSocket socketHandle
						receiveBufferSize: 8000
						sendBufSize: 8000
						semaIndex: semaIndex
						readSemaIndex: readSemaIndex
						writeSemaIndex: writeSemaIndex.
	socketHandle = nil ifTrue: [  "socket creation failed"
		Smalltalk unregisterExternalObject: semaphore.
		Smalltalk unregisterExternalObject: readSemaphore.
		Smalltalk unregisterExternalObject: writeSemaphore.
		readSemaphore _ writeSemaphore _ semaphore _ nil
	] ifFalse:[self register].
