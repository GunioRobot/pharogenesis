xDoubleExtendedDoAnything
	"Replaces the Blue Book double-extended send [132], in which
	the first byte was wasted on 8 bits of argument count.
	Here we use 3 bits for the operation sub-type (opType),
	and the remaining 5 bits for argument count where needed.
	The last byte give access to 256 instVars or literals.
	See also secondExtendedSendBytecode.	"

	"Translator paradise: we've got FIVE extension words to play with!"

	| descriptor index opType nArgs |
	descriptor _ self nextByte.	"was: byte2"
	index _ self nextByte.		"was: byte3"
	opType _ (descriptor >> 5).
	nArgs _ (descriptor bitAnd: 16r1F).

	opType = 0 ifTrue: [ "DoubleExtendedSend numArgs nil nil nil selector"
		 self emitOp: DoubleExtendedSend.
		 self emitInteger: nArgs.
		 self emitSkip: 3.
		^self emitLiteralSelector: index].
	opType = 1 ifTrue: [ "DoubleExtendedSuper numArgs nil nil nil selector"
		 self emitOp: DoubleExtendedSuper.
		 self emitInteger: nArgs.
		 self emitSkip: 3.
		^self emitLiteralSelector: index].

	opType = 2 ifTrue: [ "DoubleExtendedPushReceiverVar index nil nil nil nil"
		 self emitOp: DoubleExtendedPushReceiverVariable.
		 self emitInteger: index.
		^self emitSkip: 4].
	opType = 3 ifTrue: [ "DoubleExtendedPushConst constant nil nil nil nil"
		 self emitOp: DoubleExtendedPushConstant.
		 self emitLiteralConstant: index.
		^self emitSkip: 4].
	opType = 4 ifTrue: [ "DoubleExtendedPushLiteralVar association nil nil nil nil"
		 self emitOp: DoubleExtendedPushLiteralVariable.
		 self emitLiteralVariable: index.
		^self emitSkip: 4].

	opType = 5 ifTrue: [ "DoubleExtendedStoreReceiverVar index nil nil nil nil"
		 self emitOp: DoubleExtendedStoreReceiverVariable.
		 self emitInteger: index.
		^self emitSkip: 4].
	opType = 6 ifTrue: [ "DoubleExtendedStorePopReceiverVar index nil nil nil nil"
		 self emitOp: DoubleExtendedStoreAndPopReceiverVariable.
		 self emitInteger: index.
		^self emitSkip: 4].
	opType = 7 ifTrue: [ "DoubleExtendedStoreLiteralVar association nil nil nil nil"
		 self emitOp: DoubleExtendedStoreLiteralVariable.
		 self emitLiteralVariable: index.
		^self emitSkip: 4].
