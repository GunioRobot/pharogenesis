xPrimBitShift

	| distance |
	"	-4	PushConstant	_	MacroConstBitShift
		-0	<SmallInteger>"
	(self wasPushInteger: -4) ifTrue:
		[distance _ self integerValueOf: (self longAt: opPointer).
		 ((distance >= 0) and: [distance <= 31]) ifTrue: [self rewrite: -4 to: MacroConstPositiveBitShift].
		 ((distance >= -31) and: [distance < 0]) ifTrue: [self rewrite: -4 to: MacroConstNegativeBitShift]].

	self emitOp: SpecialPrimitive.
	self emitInteger: (PrimitiveBitShift << 16) + (12 << 8) + 1