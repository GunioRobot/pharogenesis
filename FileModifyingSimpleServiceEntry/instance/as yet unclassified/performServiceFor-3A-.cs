performServiceFor: anObject
	| retval |
	retval _ super performServiceFor: anObject.
	self changed: #fileListChanged.
	^retval	"is this used anywhere?"