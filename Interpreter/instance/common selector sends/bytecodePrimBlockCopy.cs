bytecodePrimBlockCopy

	| rcvrClass |
	rcvrClass _ self fetchClassOf: (self internalStackValue: 1).
	successFlag _ true.
	self success:
		((rcvrClass = (self splObj: ClassBlockContext)) or:
		 [rcvrClass = (self splObj: ClassMethodContext)]).
	successFlag ifTrue: [
		self externalizeIPandSP.
		self primitiveBlockCopy.
		self internalizeIPandSP.
	].
	successFlag ifFalse: [
		messageSelector _ self specialSelector: 24.
		argumentCount _ 1.
		^ self normalSend
	].
