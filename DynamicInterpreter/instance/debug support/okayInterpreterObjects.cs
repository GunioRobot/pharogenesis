okayInterpreterObjects

	| oopOrZero oop |
	self okayFields: nilObj.
	self okayFields: falseObj.
	self okayFields: trueObj.
	self okayFields: specialObjectsOop.
	self okayFields: messageSelector.
	self okayFields: newMethod.

	newReceiver = 0 ifFalse: [self okayFields: newReceiver].
	pseudoReceiver = 0 ifFalse: [self okayFields: pseudoReceiver].

	1 to: MethodCacheEntries do: [ :i |
		oopOrZero _ methodCache at: i + MethodCacheSelectorCol.
		oopOrZero = 0 ifFalse: [
			self okayFields: (methodCache at: i).								"selector"
			self okayFields: (methodCache at: i + MethodCacheClassCol).		"class"
			self okayFields: (methodCache at: i + MethodCacheMethodCol).	"method"
		].
	].
	1 to: remapBufferCount do: [ :i |
		oop _ remapBuffer at: i.
		(self isIntegerObject: oop) ifFalse: [
			self okayFields: oop.
		].
	].
	self okayActiveProcessStack.