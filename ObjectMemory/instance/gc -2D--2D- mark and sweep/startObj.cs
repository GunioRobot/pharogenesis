startObj
	"Start tracing the object 'child' and answer the next action. The object may be anywhere in the middle of being swept itself. See comment in markAndTrace for explanation of tracer state variables."

	| oop header lastFieldOffset |
	oop _ child.
	oop < youngStart ifTrue: [
		"old object; skip it"
		 field _ oop.
		^ Upward
	].

	header _ self longAt: oop.
	(header bitAnd: MarkBit) = 0 ifTrue: [
		"unmarked; mark and trace"
		header _ header bitAnd: AllButTypeMask.
		header _ (header bitOr: MarkBit) bitOr: HeaderTypeGC.
		self longAt: oop put: header.
		lastFieldOffset _ self lastPointerOf: oop.
		field _ oop + lastFieldOffset.
		^ StartField	"trace its fields and class"
	] ifFalse: [
		"already marked; skip it"
		field _ oop.
		^ Upward
	].