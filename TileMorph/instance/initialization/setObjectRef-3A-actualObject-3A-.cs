setObjectRef: aString actualObject: anObject
	"Set the receiver to bear an object reference to the given object.  aString is historical and no longer used"

	type _ #objRef.
	actualObject _ anObject.
	self line1: anObject nameForViewer
