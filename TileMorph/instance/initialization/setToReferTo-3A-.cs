setToReferTo: anObject
	"Set the receiver to bear an object reference to the given object."
	self flag: #yo.
	type _ #objRef.
	actualObject _ anObject.
	self line1: anObject nameForViewer.
	self typeColor: (ScriptingSystem colorForType: #Player).
	self enforceTileColorPolicy
