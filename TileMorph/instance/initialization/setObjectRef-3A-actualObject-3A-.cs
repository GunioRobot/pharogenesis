setObjectRef: aString actualObject: anObject.
	type _ #objRef.
	"aString is historical and no longer used"
	actualObject _ anObject.
	self line1: anObject externalName
