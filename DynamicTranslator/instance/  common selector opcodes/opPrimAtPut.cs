opPrimAtPut

	| value valToStore index rcvr rcvrClass stringy |
	(self initOp: PrimAtPut) ifFalse: [
	self beginOp: PrimAtPut.

		self skip: 1.
		value _ valToStore _ self internalStackTop.
		index _ self internalStackValue: 1.
		rcvr _ self internalStackValue: 2.
		successFlag _ self isIntegerObject: index.
		successFlag ifTrue: [
			rcvrClass _ self fetchClassOf: rcvr.
			stringy _ rcvrClass = (self splObj: ClassString).
			(stringy or: [self okArrayClass: rcvrClass])
				ifFalse: [successFlag _ false]].
		successFlag ifTrue: [
			index _ self integerValueOf: index.
			stringy ifTrue: [valToStore _ self asciiOfCharacter: value].
			self stObject: rcvr at: index put: valToStore.
		].
		successFlag ifTrue: [
			self internalPop: 3 thenPush: value.
		] ifFalse: [
			self sendSpecialSelector: 17 nArgs: 2.
		].

	self endOp: PrimAtPut
	].
