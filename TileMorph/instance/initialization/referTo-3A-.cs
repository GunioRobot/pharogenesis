referTo: anObject
	"Make the receiver be an object-reference tile whose referent is anObject"

	type _ #objRef.
	typeColor _ ScriptingSystem colorForType: anObject basicType.
	actualObject _ anObject.
	self line1: anObject uniqueNameForReference