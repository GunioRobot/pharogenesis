opPrimBlockCopy

	| rcvrClass |
	(self initOp: PrimBlockCopy) ifFalse: [
	self beginOp: PrimBlockCopy.

		self skip: 1.
		rcvrClass _ self fetchClassOf: (self internalStackValue: 1).
		successFlag _ true.
		self success:
			((rcvrClass = (self splObj: ClassPseudoContext)) or:
			 [rcvrClass = (self splObj: ClassBlockContext) or:
			 [rcvrClass = (self splObj: ClassMethodContext)]]).
		successFlag ifTrue: [
			self externalizeIPandSP.
			self primitiveBlockCopy.
			self internalizeIPandSP.
		].
		successFlag ifFalse: [
			self sendSpecialSelector: 24 nArgs: 1.
		].

	self endOp: PrimBlockCopy
	]
