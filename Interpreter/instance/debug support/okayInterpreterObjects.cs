okayInterpreterObjects

	| oopOrZero oop |
	self okayFields: nilObj.
	self okayFields: falseObj.
	self okayFields: trueObj.
	self okayFields: specialObjectsOop.
	self okayFields: activeContext.
	self okayFields: method.
	self okayFields: receiver.
	self okayFields: theHomeContext.
	self okayFields: messageSelector.
	self okayFields: newMethod.
	1 to: MethodCacheEntries do: [ :i |
		oopOrZero _ methodCache at: i.
		oopOrZero = 0 ifFalse: [
			self okayFields: (methodCache at: i).							"selector"
			self okayFields: (methodCache at: i + MethodCacheEntries).		"class"
			self okayFields: (methodCache at: i + (2 * MethodCacheEntries)).	"method"
		].
	].
	1 to: remapBufferCount do: [ :i |
		oop _ remapBuffer at: i.
		(self isIntegerObject: oop) ifFalse: [
			self okayFields: oop.
		].
	].
	self okayActiveProcessStack.