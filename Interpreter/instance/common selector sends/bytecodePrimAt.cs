bytecodePrimAt

	| index rcvr result rcvrClass stringy |
	index _ self internalStackTop.
	rcvr _ self internalStackValue: 1.
	successFlag _ self isIntegerObject: index.
	successFlag ifTrue: [
		rcvrClass _ self fetchClassOf: rcvr.
		stringy _ rcvrClass = (self splObj: ClassString).
		(stringy or: [self okArrayClass: rcvrClass])
			ifFalse: [successFlag _ false]].
	successFlag ifTrue: [
		index _ self integerValueOf: index.
self externalizeIPandSP.
		result _ self stObject: rcvr at: index.
self internalizeIPandSP.
		(stringy and: [successFlag]) ifTrue: [result _ self characterForAscii: result]].
	successFlag ifTrue: [
		self internalPop: 2 thenPush: result.
	] ifFalse: [
		messageSelector _ self specialSelector: 16.
		argumentCount _ 1.
		self normalSend.
	].
