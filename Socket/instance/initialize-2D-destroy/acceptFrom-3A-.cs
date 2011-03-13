acceptFrom: aSocket
	"Initialize a new socket handle from an accept call"
	| semaIndex readSemaIndex writeSemaIndex |

	primitiveOnlySupportsOneSemaphore := false.
	semaphore := Semaphore new.
	readSemaphore := Semaphore new.
	writeSemaphore := Semaphore new.
	semaIndex := Smalltalk registerExternalObject: semaphore.
	readSemaIndex := Smalltalk registerExternalObject: readSemaphore.
	writeSemaIndex := Smalltalk registerExternalObject: writeSemaphore.
	socketHandle := self primAcceptFrom: aSocket socketHandle
						receiveBufferSize: 8000
						sendBufSize: 8000
						semaIndex: semaIndex
						readSemaIndex: readSemaIndex
						writeSemaIndex: writeSemaIndex.
	socketHandle = nil ifTrue: [  "socket creation failed"
		Smalltalk unregisterExternalObject: semaphore.
		Smalltalk unregisterExternalObject: readSemaphore.
		Smalltalk unregisterExternalObject: writeSemaphore.
		readSemaphore := writeSemaphore := semaphore := nil
	] ifFalse:[self register].
