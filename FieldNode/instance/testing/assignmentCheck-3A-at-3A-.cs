assignmentCheck: encoder at: location
	(encoder cantStoreInto: name) ifTrue: [^location].
	fieldDef toSet ifNil:[
		encoder interactive ifTrue:[^location].
		fieldDef := fieldDef clone assignDefaultSetter.
	].
	^-1