bytecodeExecuteNewMethod

	primitiveIndex > 0 ifTrue: [
		self primitiveResponse.
		successFlag ifTrue: [^ nil]].

	"if not primitive, or primitive failed, activate the method"
	self bytecodeActivateNewMethod.

	"check for possible interrupts at each real send"
	self quickCheckForInterrupts.
