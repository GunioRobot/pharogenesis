object: anObject 
	"Set anObject to be the object being inspected by the receiver."

	anObject == object
		ifTrue: [self update]
		ifFalse:
			[self inspect: anObject.
			self changed: #inspectObject.
			self changed: #fieldList.
			self changed: #contents]