markAndTraceInterpreterOops
	"Mark and trace all oops in the interpreter's state."
	"Assume: All traced variables contain valid oops."
	| oop |
	self markAndTrace: specialObjectsOop.
		"also covers nilObj, trueObj, falseObj, and compact classes"

	self markAndTrace: activeContext.  "traces entire stack"
		"also covers theHomeContext, receiver, method"

	self markAndTrace: messageSelector.
	self markAndTrace: newMethod.

	1 to: remapBufferCount do: [ :i |
		oop _ remapBuffer at: i.
		(self isIntegerObject: oop) ifFalse: [
			self markAndTrace: oop.
		].
	].