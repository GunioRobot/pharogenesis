mapInterpreterOops
	"Map all oops in the interpreter's state to their new values during garbage collection or a become: operation."
	"Assume: All traced variables contain valid oops."

	| oop |

	nilObj				_ self remap: nilObj.
	falseObj				_ self remap: falseObj.
	trueObj				_ self remap: trueObj.
	specialObjectsOop		_ self remap: specialObjectsOop.

	messageSelector		_ self remap: messageSelector.

	bytePointer	_ bytePointer - newMethod.				"*** rel to newMethod"
	opPointer	_ opPointer - newTranslatedMethod.		"*** rel to newTranslatedMethod"

	newMethod					_ self remap: newMethod.
	newTranslatedMethod		_ self remap: newTranslatedMethod.

	bytePointer	_ bytePointer + newMethod.
	opPointer	_ opPointer + newTranslatedMethod.

	(newReceiver = 0 or: [self isIntegerObject: newReceiver]) ifFalse: [newReceiver _ self remap: newReceiver].
	(pseudoReceiver = 0) ifFalse: [pseudoReceiver _ self remap: pseudoReceiver].

	self mapContextCache.

	1 to: remapBufferCount do: [ :i |
		oop _ remapBuffer at: i.
		(self isIntegerObject: oop) ifFalse: [
			remapBuffer at: i put: (self remap: oop).
		].
	].

	UseMethodCacheHashBits
		"If the method cache uses proper hashes, then remap its contents"
		ifTrue: [self remapMethodCache].

