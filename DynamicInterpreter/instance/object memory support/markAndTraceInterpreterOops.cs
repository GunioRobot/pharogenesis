markAndTraceInterpreterOops
	"Mark and trace all oops in the interpreter's state."
	"Assume: All traced variables contain valid oops."
	| oop |
	"self verifyImage."

	self markAndTrace: specialObjectsOop.		"also covers nilObj, trueObj, falseObj, and compact classes"

	"Tolerate SmallIntegers as selectors"
	(self isIntegerObject: messageSelector) ifFalse: [self markAndTrace: messageSelector].
	self markAndTrace: newMethod.
	self markAndTrace: newTranslatedMethod.

	(newReceiver = 0 or: [self isIntegerObject: newReceiver]) ifFalse: [self markAndTrace: newReceiver].
	(pseudoReceiver = 0) ifFalse: [self markAndTrace: pseudoReceiver].

	self markAndTraceContextCache.

	1 to: remapBufferCount do: [ :i |
		oop _ remapBuffer at: i.
		(self isIntegerObject: oop) ifFalse: [
			self markAndTrace: oop.
		].
	].

	UseMethodCacheHashBits
		ifTrue: [self markAndTraceMethodCache]
		"If the method cache uses oops as hashes, need to toss the whole thing."
		ifFalse: [self flushMethodCache].