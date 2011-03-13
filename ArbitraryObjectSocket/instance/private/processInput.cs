processInput
	"recieve some data"
	| inObjectData |

	"read as much data as possible"
	[ self isConnected and: [ socket dataAvailable ] ] whileTrue: [
		self addToInBuf: socket getData. ].


	"decode as many objects as possible"
	[self nextObjectLength ~~ nil and: [ self nextObjectLength <= (self inBufSize + 4) ]] whileTrue: [
		"a new object has arrived"
		inObjectData _ inBuf copyFrom: (inBufIndex + 4) to: (inBufIndex + 3 + self nextObjectLength).
		inBufIndex := inBufIndex + 4 + self nextObjectLength.

		inObjects addLast: (RWBinaryOrTextStream with: inObjectData) reset fileInObjectAndCode ].

	self shrinkInBuf.