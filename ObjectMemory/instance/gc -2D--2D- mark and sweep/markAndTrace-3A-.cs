markAndTrace: oop
	"Mark all objects reachable from the given one. Trace from the given object even if it is old or already marked. Mark it only if it is a young object."
	"Tracer state variables:
		child		object being examined
		field		next field of child to examine
		parentField	field where child was stored in its referencing object"

	| header lastFieldOffset action |
	"record tracing status in object's header"
	header _ self longAt: oop.
	header _ (header bitAnd: AllButTypeMask) bitOr: HeaderTypeGC.
	oop >= youngStart ifTrue: [ header _ header bitOr: MarkBit ].  "mark only if young"
	self longAt: oop put: header.

	"initialize the tracer state machine"
	parentField _ GCTopMarker.
	child _ oop.
	lastFieldOffset _ self lastPointerOf: oop.
	field _ oop + lastFieldOffset.
	action _ StartField.

	"run the tracer state machine until all objects reachable from oop are marked"
	[action = Done] whileFalse: [
		action = StartField	ifTrue: [ action _ self startField ].
		action = StartObj		ifTrue: [ action _ self startObj ].
		action = Upward		ifTrue: [ action _ self upward ].
	].