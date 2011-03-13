profile: nBytecodes
	"(InterpreterSimulator new openOn: 'clonex.image') profile: 60000"
	Transcript clear.
	byteCount _ 0.
	MessageTally spyOn: [self runForNBytes: nBytecodes].
	self close